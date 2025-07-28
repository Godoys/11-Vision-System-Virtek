using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;
using Keyence.IV2.Sdk;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    public class KeyenceCameraAdapter : ISensor
    {
        // Keyence camera object.
        private IVisionSensor _sensor;
        
        public SensorConfig Config { get; }
        
        // -------------------------------
        //  Public Methods Implementation
        // -------------------------------

        public KeyenceCameraAdapter(string username, string password, IPAddress address, ushort portNumber)
        {
            Config = new SensorConfig(username, password, address, portNumber);
        }

        public async Task ConnectAsync()
        {
            try
            {
                if (Config.State == SensorState.Connected)
                {
                    Console.WriteLine($"[!] Sensor {Config.Address} is already connected");
                }
                else
                {
                    Console.WriteLine($"[*] Connecting to Cognex In-Sight sensor {Config.Address}.");
                    
                    // Object used to create a connection to a Keyence sensor.
                    VisionSensorStore sensorStore = new VisionSensorStore();
                
                    // Connects to a Keyence sensor using the Keyence SDK Connect method.
                    await Task.Run(() => _sensor = sensorStore.Create(Config.Address, Config.PortNumber));
                    
                    // Starts the function that syncs data between the software and the real camera.
                    SyncData();
                
                    // Updates the CameraState in configuration object.
                    Config.UpdateState(SensorState.Connected);   
                    
                    Console.WriteLine($"[*] Connected to sensor {Config.Address}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DisconnectAsync()
        {
            try
            {
                if (Config.State == SensorState.Disconnected || Config.State == SensorState.Offline)
                {
                    Console.WriteLine($"[!] Sensor {Config.Address} is already disconnected");
                }
                else
                {
                    Console.WriteLine($"[*] Disconnecting from sensor {Config.Address}.");
                    
                    // Disconnects to a Keyence sensor using the Keyence SDK Dispose method.
                    await Task.Run(() => _sensor.Dispose());
                
                    // Updates the CameraState in configuration object.
                    Config.UpdateState(SensorState.Disconnected);   
                    
                    Console.WriteLine($"[*] Disconnected to sensor {Config.Address}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task TriggerImageCaptureAsync()
        {
            try
            {
                if (Config.State == SensorState.Connected)
                {
                    Console.WriteLine($"[*] Triggering image capture in sensor {Config.Address}.");

                    // Triggers image capture to a Keyence sensor using the Keyence SDK Trigger method.
                    await Task.Run(() => _sensor.Trigger());
                    
                    Console.WriteLine($"[*] Image captured by sensor {Config.Address}.");
                }
                else
                {
                    Console.WriteLine($"[*] Sensor {Config.Address} is either disconnected or offline. Trying to estabilish a connection with sensor {Config.Address}.");

                    // Trying to reconnect with sensor.
                    await ConnectAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task GetAnalysisResultAsync()
        {
            try
            {
                if (Config.State == SensorState.Connected)
                {
                    Console.WriteLine($"[*] Retrieving image analysis result in sensor {Config.Address}.");
                    
                    await Task.Run(() =>
                    {
                        _sensor.ResultUpdated += (sender, args) =>
                        {
                            if (args.TotalStatusResult)
                            {
                                Config.UpdateResult(ResultStatus.Pass);
                            }
                            else
                            {
                                Config.UpdateResult(ResultStatus.Fail);
                            }
                        };
                    });
                    
                    Console.WriteLine($"[*] Result status updated in sensor {Config.Address}.");
                }
                else
                {
                    Console.WriteLine($"[*] Sensor {Config.Address} is either disconnected or offline. Trying to estabilish a connection with sensor {Config.Address}.");

                    // Trying to reconnect with sensor.
                    await ConnectAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        // --------------------------------
        //  Private Methods Implementation
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