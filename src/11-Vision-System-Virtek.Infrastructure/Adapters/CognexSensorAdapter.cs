using System.Net;
using System.Text.RegularExpressions;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using Cognex.InSight;
using Cognex.InSight.Ftp;
using Cognex.InSight.NativeMode;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    /// <summary>
    /// Adapts Cognex InSight SDK to the ICamera interface.
    /// </summary>
    public class CognexSensorAdapter : ISensor
    {
        // Cognex SDK sensor object that is used for interaction with real sensor.
        private readonly CvsInSight _sensor;
        
        public SensorConfig Config { get; }
        
        // -------------------------------
        //  Public Methods Implementation
        // -------------------------------

        public CognexSensorAdapter(string username, string password, IPAddress address)
        {
            Config = new SensorConfig(username,  password,  address);
            _sensor = new CvsInSight();
        }
        
        
        public async Task ConnectAsync()
        {
            try
            {
                if (Config.ConnectionState == SensorConnectionState.Connected)
                {
                    Console.WriteLine($"[!] Sensor {Config.Address} is already connected");
                }
                else
                {
                    Console.WriteLine($"[*] Connecting to Cognex In-Sight sensor {Config.Address}.");
                
                    // Connects to a Cognex sensor using the Cognex SDK Connect method.
                    await Task.Run(() => _sensor.Connect(Config.Address, Config.Username, Config.Password, false, true));
                
                    // Updates the CameraState in configuration object.
                    Config.UpdateState(SensorConnectionState.Connected);   
                    
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
                if (Config.ConnectionState == SensorConnectionState.Disconnected || Config.ConnectionState == SensorConnectionState.Offline)
                {
                    Console.WriteLine($"[!] Sensor {Config.Address} is already disconnected");
                }
                else
                {
                    Console.WriteLine($"[*] Disconnecting from sensor {Config.Address}.");
                    
                    // Disconnects to a Cognex sensor using the Cognex SDK Disconnect method.
                    await Task.Run(() => _sensor.Disconnect());
                
                    // Updates the CameraState in configuration object.
                    Config.UpdateState(SensorConnectionState.Disconnected);   
                    
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
                if (Config.ConnectionState == SensorConnectionState.Connected)
                {
                    Console.WriteLine($"[*] Triggering image capture in sensor {Config.Address}.");

                    // Triggers image capture to a Cognex sensor using the Cognex SDK ManualAcquire method.
                    await Task.Run(() => _sensor.ManualAcquire());
                    
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
                if (Config.ConnectionState == SensorConnectionState.Connected)
                {
                    Console.WriteLine($"[*] Retrieving image analysis result in sensor {Config.Address}.");
                    
                    // Enum of Cognex SDK result status.
                    CvsStatusLevel resultStatus = _sensor.Results.StatusLevel;
                    
                    // Checks the sensor results and updates the result variable on the sensor configuration object.
                    switch (resultStatus)
                    {
                        case CvsStatusLevel.Pass:
                            Config.UpdateResult(ResultStatus.Pass);
                            break;
                        case CvsStatusLevel.Warn:
                            Config.UpdateResult(ResultStatus.Warn);
                            break;
                        case CvsStatusLevel.Fail:
                            Config.UpdateResult(ResultStatus.Fail);
                            break;
                    }
                    
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
    }
}