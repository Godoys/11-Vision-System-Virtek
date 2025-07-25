using System.Text;
using _11_Vision_System_Virtek.Domain.Interfaces;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Model;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Model;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Model;
using ClientIdDto = WorkorderService.Swagger.Model.ClientIdDto;
using ClientInfoDto = VisionAndProjectionService.Swagger.Model.ClientInfoDto;
using LoadWorkOrderDto = WorkorderService.Swagger.Model.LoadWorkOrderDto;
using ResultDtoListString = WorkorderService.Swagger.Model.ResultDtoListString;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    /// <summary>
    /// Adapts the Virtek Vision Swagger API and RabbitMQ messages into IProjector interface.
    /// </summary>
    public class VirtekProjectorAdapter : IProjector
    {
        // Variable used for telling CallApiAndWaitForMessage that message was received.
        private TaskCompletionSource<bool> _tcs = null;
        
        // Variable used for checking RMQ message values.
        private string _currentRequestName = "";
        
        // Vision and Projection service API instances
        private readonly SystemApi _systemApiInstance = new SystemApi();
        private readonly ProjectionApi _projectionApiInstance = new ProjectionApi();
        private readonly WorkOrderOperationsApi _workOrderOperationsApiInstance = new WorkOrderOperationsApi();
        private readonly ProjectionOperationsApi _projectionOperationsApiInstance = new ProjectionOperationsApi();
        
        public string ClientId { get; }
        public string ProjectorSerialNumber { get; }

        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------

        public VirtekProjectorAdapter(string projectorSerialNumber)
        {
            ClientId =  GetConnectedClientIdAsync().Result;
            ProjectorSerialNumber = projectorSerialNumber;
        }

        public async Task ConnectAsync()
        {
            try
            {
                // Creates DTO with values for connection to the client.
                var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);

                // First attempt to connect to projector through API.
                await CallApiWaitForMessage(() => _systemApiInstance.CoreLaserServiceConnectClient(connectClientInfo),
                    "NO USEFUL MESSAGE EXPECTED", "ConnectClient", false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Connection to the projector failed due to ${e.Message}.");
                Console.WriteLine("[!] Attempting connection in 30s.");

                try
                {
                    // Waits 30s after first connection attempt.
                    await Task.Delay(TimeSpan.FromSeconds(30));
                    
                    // Creates DTO with values for connection to the client.
                    var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);
                    
                    // Second attempt to connect to projector.
                    await CallApiWaitForMessage(() => _systemApiInstance.CoreLaserServiceConnectClient(connectClientInfo),
                        "NO USEFUL MESSAGE EXPECTED", "ConnectClient", false);
                }
                catch (Exception e2)
                {
                    Console.WriteLine($"[!] Second attempt to establish a connection failed due to ${e2.Message}.");
                }
            }
        }

        public async Task DisconnectAsync()
        {
            try
            {
                // Creates DTO with values for connection to the client.
                var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);

                // Attempts to disconnect from the projector.
                await CallApiWaitForMessage(
                    () => _systemApiInstance.CoreLaserServiceDisconnectClient(connectClientInfo),
                    "NO USEFUL MESSAGE EXPECTED", "DisconnectClient", false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to disconnect from projector failed due to ${e.Message}.");
            }
            
            
            
        }

        public async Task PauseProjectionAsync()
        {
            try
            {
                // Creates DTO with values for connection to the client.
                var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);

                // Attempts to pause current projection.
                await CallApiWaitForMessage(
                    () => _projectionApiInstance.CoreLaserServicePauseAllProjection(connectClientInfo),
                    "NO USEFUL MESSAGE EXPECTED", "PauseProjectionForProjector", false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to pause current projection failed due to ${e.Message}.");
            }
        }
        
        public async Task<string> GetCurrentProjectionEntityAsync()
        {
            try
            {
                // Gets the name of the current open Work Order and stores it.
                string workorderName = await GetCurrentWorkOrderNameAsync();

                // DTO for storing data for Work Order access.
                LoadWorkOrderDto loadWorkOrderDto =
                    new LoadWorkOrderDto(clientId: ClientId, workOrderName: workorderName);

                // DTO for storing the result of the API call.
                ResultDtoListString projectionEntityCollectionJson = new ResultDtoListString();

                // Calls the API command that collects the DTO that holds list of projection entities.
                await CallApiWaitForMessage(
                    () => projectionEntityCollectionJson =
                        _projectionOperationsApiInstance.WorkOrderServiceGetLastAccessedProjectionEntities(
                            loadWorkOrderDto), "NO USEFUL MESSAGE EXPECTED", "GetCurrentProjectionEntity", false);

                string currentProjectionEntity = "";

                try
                {
                    // Gets the name of the current projection entity.
                    currentProjectionEntity = projectionEntityCollectionJson.Payload.First();
                }
                catch (Exception e)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                    currentProjectionEntity = projectionEntityCollectionJson.Payload.First();
                }

                return currentProjectionEntity;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to get current projection name failed due to ${e.Message}.");

                // Returns an empty string since the method failed to get the current projection name.
                return "";
            }
        }
        
        public async Task<string> GetCurrentWorkOrderNameAsync()
        {
            try
            {
                // DTO that stores the value of the client ID.
                ClientIdDto clientIdDto = new ClientIdDto(clientId: ClientId);

                // DTO that holds the result of the API call.
                ResultDtoWorkOrderNameDto workOrderNameDto = new ResultDtoWorkOrderNameDto();

                // Calls the API command that collects the DTO that holds the Work Order name.
                await CallApiWaitForMessage(
                    () => workOrderNameDto =
                        _workOrderOperationsApiInstance.WorkOrderServiceGetCurrentWorkOrderName(clientIdDto),
                    "NO  USEFUL MESSAGE EXPECTED", "GetCurrentWorkOrderName", false);

                // Current open Work Order name.
                string workOrderName = workOrderNameDto.Payload.WorkOrderName;

                return workOrderName;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to get current work order name failed due to ${e.Message}.");
                
                // Returns an empty string since the method failed to get the current work order name.
                return "";
            }
        }

        public async Task<string> GetConnectedClientIdAsync()
        {
            try
            {
                // DTO that holds the client ids available in the network.
                VisionAndProjectionService.Swagger.Model.ResultDtoListString connectedClientDataDto = new();

                // Calls the API command that collects the DTO that holds the list of available clients in the network.
                await CallApiWaitForMessage(
                    () => connectedClientDataDto = _systemApiInstance.CoreLaserServiceGetConnectedClientIDs(),
                    "NO USEFUL MESSAGE EXPECTED", "GetCurrentClients", false);

                // Variable to store client id.
                string clientId = connectedClientDataDto.Payload.First();

                return clientId;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to get connected client id due to ${e.Message}.");
                
                // Returns empty string since method failed.
                return "";
            }
        }
        
        public bool IsExpectedMessage(byte[] msg)
        {
            try
            {
                // Gets binary message and converts to UTF8.
                string message = Encoding.UTF8.GetString(msg);

                // Deserialize a JSON object and gets the message received from RMQ.
                var messageObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(message);

                // Comparares if received message is the same as current request message.
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
            catch (Exception e)
            {
                Console.WriteLine($"[!] Message verification failed due to ${e.Message}.");
                
                // Returns false since the operations failed.
                return false;
            }
        }
        
        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------

        /// <summary>
        /// Executes the API call and waits for a response from the projector.
        /// </summary>
        /// <param name="apiCall">The function that represents the API call.</param>
        /// <param name="expectedRequest">The expected message to be received after the API call.</param>
        /// <param name="apiName">The name of the API being used.</param>
        /// <param name="waitForMessage">If true, waits 30 seconds for response; False, do not wait for response.</param>
        private async Task CallApiWaitForMessage<T>(Func<T> apiCall, string expectedRequest, string apiName,
            bool waitForMessage)
        {
            _tcs = new TaskCompletionSource<bool>();
            
            UpdateExpectedRequest(expectedRequest);

            // Make the API call and gets the success boolean value, result, and error message.
            var (success, result, errorMessage) = ExecuteApiCall(apiCall);

            if (success)
            {
                if (waitForMessage)
                {
                    // Wait up to 30 seconds for the message
                    await Task.WhenAny(_tcs.Task, Task.Delay(TimeSpan.FromSeconds(30)));

                    if (_tcs.Task.IsCompleted)
                    {
                        Console.WriteLine($"[{apiName}] Completed task RabbitMQ message");
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

        /// <summary>
        /// Executes the API call.
        /// </summary>
        /// <param name="apiCall">The function that represents the API call.</param>
        /// <returns>A tuple that holds three values about the execution of the API call.</returns>
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

        /// <summary>
        /// Changes the current request name. 
        /// </summary>
        /// <param name="newRequestName">The new request name.</param>
        private void UpdateExpectedRequest(string newRequestName)
        {
            _currentRequestName = newRequestName;
        }
    }
}