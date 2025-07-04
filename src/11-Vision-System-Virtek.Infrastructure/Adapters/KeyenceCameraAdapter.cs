using System.Net;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;
using Keyence.IV2.Sdk;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    public class KeyenceCameraAdapter : ICamera
    {
        // Keyence camera object.
        private IVisionSensor _sensor;
        
        public string Username { get; private set;  }
        
        public string Password { get; private set; }
        
        public IPAddress Address { get; private set; }

        public CameraState State { get;  private set; }
        
        public ResultStatus LastAnalysisResult { get; private set; }
        
        public ushort PortNumber { get; private set; }
        
        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------

        public KeyenceCameraAdapter(string username, string password, IPAddress address, ushort portNumber)
        {
            Username = username;
            Password = password;
            Address = address;
            PortNumber = portNumber;
            State = CameraState.Offline;
            LastAnalysisResult = ResultStatus.None;
        }

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void UpdateAddress(IPAddress newAddress)
        {
            Address = newAddress;
        }

        public void UpdateState(CameraState newState)
        {
            State = newState;
        }

        public void UpdateResult(ResultStatus newResult)
        {
            LastAnalysisResult = newResult;
        }

        public void UpdatePortnumber(ushort newPortNumber)
        {
            PortNumber = newPortNumber;
        }

        public async Task ConnectAsync(CameraConnectionType connectionType)
        {
            // Object used to create a connection to a Keyence sensor.
            VisionSensorStore sensorStore = new VisionSensorStore();

            try
            {
                await Task.Run(() => _sensor = sensorStore.Create(Address, PortNumber));
                SyncData();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Error trying to establish connection: {e.Message}");
            }
        }
        
        public async Task DisconnectAsync(CameraConnectionType connectionType)
        {
            await Task.Run(() => _sensor.Dispose());
        }

        public Task UploadJobAsync(string jobPath, string jobName)
        {
            throw new NotImplementedException();
        }

        public Task LoadJobAsync(string jobName)
        {
            throw new NotImplementedException();
        }

        public async Task TriggerImageCaptureAsync()
        {
            await Task.Run(() => _sensor.Trigger());
        }

        public async Task GetAnalysisResultAsync()
        {
            await Task.Run(() =>
            {
                _sensor.ResultUpdated += (sender, args) =>
                {
                    if (args.TotalStatusResult)
                    {
                        UpdateResult(ResultStatus.Pass);
                    }
                    else
                    {
                        UpdateResult(ResultStatus.Fail);
                    }
                };
            });
        }
        
        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------

        /// <summary>
        /// Syncs the data collected by the camera with the data in the class.
        /// </summary>
        private async void SyncData()
        {
            while (true)
            {
                await Task.Delay(500);
                
                // Runs method that syncs the data with the camera.
                _sensor.TickTack();
            }
        }
        
    }
}