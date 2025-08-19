using System.Net;
using System.Timers;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;
using Keyence.IV2.Sdk;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    public class KeyenceCameraAdapter(string username, string password, IPAddress address, ushort portNumber) : ISensor
    {
        // Keyence camera object.
        private IVisionSensor? _sensor; 
        
        public SensorConfig Config { get; } = new SensorConfig(username, password, address, portNumber);
        
        // -------------------------------
        //  Public Methods Implementation
        // -------------------------------

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
                    
                    // Object used to create a connection to a Keyence sensor.
                    VisionSensorStore sensorStore = new VisionSensorStore();
                
                    // Connects to a Keyence sensor using the Keyence SDK Connect method.
                    await Task.Run(() => _sensor = sensorStore.Create(Config.Address, Config.PortNumber));
                    
                    // Starts the timer that raises the event that calls teh SyncData method.
                    SetTimer();
                    
                    // Subscribe ResultUpdate event handler to event.
                    if (_sensor != null) _sensor.ResultUpdated += ResultUpdatedEventHandler;

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
                    
                    // Disconnects to a Keyence sensor using the Keyence SDK Dispose method.
                    await Task.Run(() => _sensor?.Dispose());
                
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

                    // Triggers image capture to a Keyence sensor using the Keyence SDK Trigger method.
                    await Task.Run(() => _sensor.Trigger());
                    
                    Console.WriteLine($"[*] Image captured by sensor {Config.Address}.");
                }
                else
                {
                    Console.WriteLine($"[*] Sensor {Config.Address} is either disconnected or offline. Trying to establish a connection with sensor {Config.Address}.");

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
        private void SyncData()
        {
            // Runs method that syncs the data with the camera.
            _sensor.TickTack();
        }

        /// <summary>
        /// Sets a timer to run continuously throughout the program.
        /// </summary>
        private void SetTimer()
        {
            // Creates a timer with 500 milliseconds delay.
            System.Timers.Timer timer = new (500);
            
            // Hook up the Elapsed event for the timer.
            timer.Elapsed += OnTimedEvent;
            
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            SyncData();
        }
        
        /// <summary>
        /// Handles the ResultUpdate event, updating the result status of the image analysis. 
        /// </summary>
        /// <param name="sender">Object raising the event</param>
        /// <param name="args">Arguments sent with the event</param>
        private void ResultUpdatedEventHandler(object sender, ToolResultUpdatedEventArgs  args)
        {
            Config.UpdateResult(args.TotalStatusResult ? SensorResultStatus.Pass : SensorResultStatus.Fail);
        }
        
    }
}