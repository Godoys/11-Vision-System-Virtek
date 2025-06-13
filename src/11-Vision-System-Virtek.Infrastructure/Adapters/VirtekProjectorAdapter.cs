using System.Text;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Infrastructure.Services;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    public class VirtekProjectorAdapter : IProjector
    {
        // Variable used for telling CallApiAndWaitForMessage that message was received.
        private static TaskCompletionSource<bool> _tcs = null;
        
        // Variable used for checking RMQ message values.
        private string _currentRequestName = "";
        public string ClientId { get; }
        public string ProjectorSerialNumber { get; }
        
        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------

        VirtekProjectorAdapter(string clientId, string projectorSerialNumber)
        {
            ClientId = clientId;
            ProjectorSerialNumber = projectorSerialNumber;
        }

        public async Task Connect()
        {
            throw new NotImplementedException();
        }

        public async Task Disconnect()
        {
            throw new NotImplementedException();
        }

        public async Task PauseProjection()
        {
            throw new NotImplementedException();
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
        
        private bool IsExpectedMessage(byte[] msg)
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

        private void UpdateExpectedRequest(string newRequestName)
        {
            _currentRequestName = newRequestName;
        }
    }
}