using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using _11_Vision_System_Virtek.Domain.Interfaces;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Model;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Model;
using ClientIdDto = WorkorderService.Swagger.Model.ClientIdDto;
using ClientInfoDto = VisionAndProjectionService.Swagger.Model.ClientInfoDto;
using LoadWorkOrderDto = WorkorderService.Swagger.Model.LoadWorkOrderDto;
using NormalPoint3DDto = VisionAndProjectionService.Swagger.Model.NormalPoint3DDto;
using PolygonDto = VisionAndProjectionService.Swagger.Model.PolygonDto;
using ProjectionEntityDataDto = VisionAndProjectionService.Swagger.Model.ProjectionEntityDataDto;
using ResultDtoListString = WorkorderService.Swagger.Model.ResultDtoListString;
using VertexDto = VisionAndProjectionService.Swagger.Model.VertexDto;

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
        
        public string ClientId { get; private set; }

        // -------------------------------
        //  Public Methods Implementation
        // -------------------------------

        public async Task ConnectAsync()
        {
            try
            {
                // Gets the id of the client available.
                ClientId = GetConnectedClientIdAsync().Result;
                
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
                    
                    // Gets the id of the client available.
                    ClientId = GetConnectedClientIdAsync().Result;
                    
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

        public async Task ResumeProjectionAsync()
        {
            try
            {
                // Creates DTO with values for connection to the client.
                var connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);

                // Attempts to resume to previous projection in given client.
                await CallApiWaitForMessage(
                    () => _projectionApiInstance.CoreLaserServiceResumeAllProjection(clientInfo: connectClientInfo),
                    "NO USEFUL MESSAGE EXPECTED", "ResumeProjection", false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to resume projection failed due to ${e.Message}.");
            }
        }

        public async Task RemoveProjectionAsync(int id)
        {
            try
            {
                // Creates DTO with values for connection to the client.
                ClientInfoDto connectClientInfo =
                    new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);

                // List to hold the id value.
                List<int?> idList = new List<int?>();
                
                idList.Add(id);
                
                // Creates a DTO to hold the id of the entity to be removed.
                RemoveEntitiesWithIdDto removeEntity = new(
                    clientInfo: connectClientInfo,
                    entityUniqueIds:  idList
                    );

                // Removes projection entity by its id.
                await CallApiWaitForMessage(
                    () => _projectionApiInstance.CoreLaserServiceRemoveEntitiesWithId(removeEntity),
                    "NO USEFUL MESSAGE EXPECTED",
                    "RemoveEntitiesWithId",
                    false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!] An error occured while adding a project polygon: {ex.Message}");
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
                ResultDtoListClientDataDto connectedClientDataDto = new();

                // Calls the API command that collects the DTO that holds the list of available clients in the network.
                await CallApiWaitForMessage(
                    () => connectedClientDataDto = _systemApiInstance.CoreLaserServiceGetCurrentClients(),
                    "NO USEFUL MESSAGE EXPECTED", "GetCurrentClients", false);
                
                // Loops through all activated client ids and gets the one who has an open work order.
                for (int i = 0; i < connectedClientDataDto.Payload.Count; i++)
                {
                    // Variable to store the client ids available in the list.
                    string clientId = connectedClientDataDto.Payload[i].ClientInfo.ClientId;
                    
                    // Variable to store the client id open work order name.
                    string workOrderName = connectedClientDataDto.Payload[i].CurrentWorkOrder;

                    // Checks if the workOrderName variable is an empty string or not. If yes, then not correct client id;
                    // if false, then it is the correct client id.
                    if (!string.IsNullOrEmpty(workOrderName))
                    {
                        // Returns the client id with an open work order.
                        return clientId;
                    }
                }

                // Returns an empty string since not client id with an open work order was found.
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Attempt to get connected client id due to ${e.Message}.");
                
                // Returns empty string since method failed.
                return "";
            }
        }
        
        public async Task AddProjectPolygonAsync(string name, int id, string filePath)
        {
            try
            {
                // Creates DTO with values for connection to the client.
                ClientInfoDto connectClientInfo = new ClientInfoDto(clientId: ClientId, type: ClientInfoDto.TypeEnum.Passive);
            
                // List of the steps inside the .PLY file.
                List<string> stepList = GenerateStepList(filePath);

                // List of the points inside each step.
                List<List<NormalPoint3DDto>> pointList = GeneratePointsList(stepList);

                // List of PolygonDto that holds the Normal Point values.
                List<PolygonDto> polygonList = new List<PolygonDto>();
            
                // Loop to add all Normal Points to the polygon list.
                for (int i = 0; i < pointList.Count; i++)
                {
                    // Polygon DTO with point list values to be added to polygon list.
                    PolygonDto polygonDto = new PolygonDto(false,  pointList[i]);
                
                    // Adds polygon to polygon list.
                    polygonList.Add(polygonDto);
                }
            
                // Projection entity DTO.
                List<ProjectionEntityDataDto> projectionEntity = new List<ProjectionEntityDataDto>
                {
                    new (id, name, polygonList, isLayer: false, plyUnit: ProjectionEntityDataDto.PlyUnitEnum.Millimetres)
                };
            
                // Projection text entity.
                ProjectEntitiesDto projectionText = new(
                    clientInfo: connectClientInfo,
                    entities: projectionEntity,
                    operation: ProjectEntitiesDto.OperationEnum.ProjectSkipInspectingCurrent,
                    appendProjection: false
                );
                
                await CallApiWaitForMessage(() => _projectionApiInstance.CoreLaserServiceProjectEntities(projectionText),
                    "NO USEFUL MESSAGE EXPECTED",
                    "AddProjectPolygonAsync",
                    false
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!] An error occured while adding a project polygon: {ex.Message}");
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
        //  Private Methods Implementation
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

        /// <summary>
        /// Generates a list of the steps containing in the .PLY file
        /// </summary>
        /// <param name="filePath">The absolute path to a file.</param>
        /// <returns>A string list of all the content of the steps inside a .PLY file</returns>
        private List<string> GenerateStepList(string filePath)
        {
            // List of the steps contained in the .PLY file.
            List<string> stepList = new();
            
            // Buffer to store the content of each step.
            string buffer = "";
            
            // Number of lines in the file.
            int nOfLines = CountFileLines(filePath);
            
            // StreamReader to parse through the .PLY file.
            using StreamReader reader = new(filePath);

            for (int i = 0; i < nOfLines; i++)
            {
                // Variable to store the content of a line.
                string line = reader.ReadLine();

                if (line != null)
                {
                    if (line.StartsWith("START"))
                    {
                        // Add all the content between the START and END to the buffer.
                        while (!line.Contains("END"))
                        {
                            line = reader.ReadLine();
                            
                            // Adds line to the buffer only if the line do not contain END.
                            if (!line.Contains("END"))
                            {
                                buffer += line;
                            }
                        }
                        
                        // Adds the buffer to stepList.
                        stepList.Add(buffer);
                        
                        // Resets the buffer.
                        buffer = "";
                    }
                }
            }
            
            return stepList;
        }

        /// <summary>
        /// Counts the number of lines in a given file.
        /// </summary>
        /// <param name="filePath">The absolute path to a file.</param>
        /// <returns>An integer that represents the number of lines in a file</returns>
        private int CountFileLines(string filePath)
        {
            // Variable to store the number of lines in the given file.
            int nOfLines = 0;
            
            // StreamReader to parse through the file.
            using (StreamReader reader = new(filePath))
            {
                // Variable to store the content of a line.
                string line;
                
                // Loop that counts the number of lines in the file
                while ((line = reader.ReadLine()) != null)
                {
                    nOfLines++;
                }
            }
            
            return nOfLines;
        }

        private List<List<NormalPoint3DDto>> GeneratePointsList(List<string> stepList)
        {
            // List to store the Normal Points contained in the step list.
            List<List<NormalPoint3DDto>> pointsList = new();
            
            // Buffer to store the content of the points of a polygon.
            List<NormalPoint3DDto> buffer = new();

            for (int i = 0; i < stepList.Count; i++)
            {
                // Splits a step into polygons.
                string[] polygonsList = stepList[i].Split('P').Skip(1).ToArray();

                for (int j = 0; j < polygonsList.Length; j++)
                {
                    // Regex pattern to be used in split to separate based on any number of whitespaces.
                    string pattern = "[\\s*]+";
                    
                    // Splits a polygons list into coordinates.
                    string[] coordinatesList = Regex.Split(polygonsList[j], pattern);
                    
                    // Variable to store the coordinates of a point.
                    string[] coordinatesBuffer = new string[3];
                    
                    // Variable to count the number of found coordinates that form a point, which is 3.
                    int counter = 0;

                    for (int k = 0; k < coordinatesList.Length + 1; k++)
                    {
                        if (counter == 3)
                        {
                            // Creates new Normal Point.
                            NormalPoint3DDto np = new(
                                new VertexDto(
                                    double.Parse(coordinatesBuffer[0], CultureInfo.InvariantCulture),
                                    double.Parse(coordinatesBuffer[1], CultureInfo.InvariantCulture),
                                    double.Parse(coordinatesBuffer[2], CultureInfo.InvariantCulture), true),
                                new VertexDto(0, 0, 1, true)
                            );
                            
                            // Adds Normal Point to buffer.
                            buffer.Add(np);
                            
                            // Resets counter.
                            counter = 0;
                            
                            // Resets coordinates buffer.
                            coordinatesBuffer = new string[3];
                        } 
                        
                        if (k < coordinatesList.Length && coordinatesList[k].Contains('.'))
                        {
                            // Adds coordinates to buffer.
                            coordinatesBuffer[counter] = coordinatesList[k];
                            
                            // Adds one to the counter.
                            counter++;
                        }
                    }
                    
                    // Adds points buffer to points list.
                    pointsList.Add(buffer);
                    
                    // Resets points buffer.
                    buffer = new();
                }
            }
            
            return pointsList;
        }
    }
}