using System.Text;
using _11_Vision_System_Virtek.Domain.Interfaces;
using VisionAndProjectionService.Swagger.Api;
using ClientInfoDto = VisionAndProjectionService.Swagger.Model.ClientInfoDto;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    /// <summary>
    /// Adapts the Virtek Vision Swagger API and RAbbitMQ messages into IProjector interface.
    /// </summary>
    public class VirtekProjectorAdapter : IProjector
    {
        // Variable used for telling CallApiAndWaitForMessage that message was received.
        private TaskCompletionSource<bool> _tcs = null;
        
        // Variable used for checking RMQ message values.
        private string _currentRequestName = "";
        
        // Vision and Projection service API instances
        private readonly SystemApi _systemApiInstance = new SystemApi();
        private readonly ToolOperationApi _toolOperationApiInstance = new ToolOperationApi();
        private readonly ProjectionApi _projectionApiInstance = new ProjectionApi();
        
        public string ClientId { get; }
        public string ProjectorSerialNumber { get; }

        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------

        public VirtekProjectorAdapter(string clientId, string projectorSerialNumber)
        {
            ClientId = clientId;
            ProjectorSerialNumber = projectorSerialNumber;
        }

        public async Task ConnectAsync()
        {
            var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);
            
            await CallApiWaitForMessage(() => _systemApiInstance.CoreLaserServiceConnectClient(connectClientInfo), "NO USEFUL MESSAGE EXPECTED", "ConnectClient", false);
        }

        public async Task DisconnectAsync()
        {
            var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);
            
            await CallApiWaitForMessage(() => _systemApiInstance.CoreLaserServiceDisconnectClient(connectClientInfo), "NO USEFUL MESSAGE EXPECTED", "DisconnectClient", false);
        }

        public async Task PauseProjectionAsync()
        {
            var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);
            
            await CallApiWaitForMessage(() => _projectionApiInstance.CoreLaserServicePauseAllProjection(connectClientInfo), "NO USEFUL MESSAGE EXPECTED", "PauseProjectionForProjector", false);
        }
        
        public bool IsExpectedMessage(byte[] msg)
        {
            string message = Encoding.UTF8.GetString(msg);
            
            var messageObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(message);

            if (messageObject != null && messageObject.RequestName != null)
            {
                string requestedName = messageObject.RequestName.ToString();

                if (requestedName == _currentRequestName)
                {
                    _tcs.TrySetResult(true);
                    return true;
                }
            }
            
            return false;
        }
        
        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------

        private async Task CallApiWaitForMessage<T>(Func<T> apiCall, string expectedRequest, string apiName,
            bool waitForMessage)
        {
            _tcs = new TaskCompletionSource<bool>();
            
            UpdateExpectedRequest(expectedRequest);
            
            Console.WriteLine($"[{apiName}] Expected RabbitMQ message request: {expectedRequest}");

            // Make the API call.
            var (success, result, errorMessage) = ExecuteApiCall(apiCall);
            
            Console.WriteLine($"[{apiName}] Received RabbitMQ message: {result}");

            if (success)
            {
                if (waitForMessage)
                {
                    // Wait up to 30 seconds for the message
                    await Task.WhenAny(_tcs.Task, Task.Delay(TimeSpan.FromSeconds(30)));

                    if (_tcs.Task.IsCompleted)
                    {
                        Console.WriteLine($"[{apiName}] Completed RabbitMQ message");
                    }
                    else 
                    {
                        Console.WriteLine($"[{apiName}] Timeout waiting for expected message");
                    }
                }
                else
                {
                    Console.WriteLine($"[{apiName}] Skipped waiting for expected message");
                }
            }
            else
            {
                Console.WriteLine($"[{apiName}] Error message: {errorMessage}");
            }
            
            // Stops posting messages received in CMD.
            UpdateExpectedRequest("");
        }

        private (bool success, T result, string errorMessage) ExecuteApiCall<T>(Func<T> apiCall)
        {
            try
            {
                var result = apiCall();
                return (true, result, "");
            }
            catch (Exception ex)
            {
                string errorMessage = "[!] Error while executing API call:" + ex.Message;
                return (false, default(T)!,  errorMessage);
            }
        }

        private void UpdateExpectedRequest(string newRequestName)
        {
            _currentRequestName = newRequestName;
        }
    }
}