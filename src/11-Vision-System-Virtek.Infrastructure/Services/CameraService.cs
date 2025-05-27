using System.Net;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;
using Cognex.InSight;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Implementaion of ICameraService interface.
    /// </summary>
    public class CameraService : ICameraService
    {
        public CameraData Camera { get; set; }
        private CvsResultSet SensorResult { get; set; }

        public CameraService(CameraData camera)
        {
            this.Camera = camera;
            this.Camera.Camera = new CvsInSight();
        }

        public CameraState Connect(bool forceConnect, bool asynchronous)
        {
            string username = Camera.Username;
            string password = Camera.Password;
            IPAddress address = Camera.Address;
            CameraState state = Camera.State;
            CvsInSight sensor = Camera.Camera;
            
            Console.WriteLine("[*] Connecting to In-Sight sensor " + address + "...");

            try
            {
                sensor.Connect(address, username, password, forceConnect, asynchronous);

                // Determine the state of the sensor

                switch (state)
                {
                    case CameraState.Offline:
                        Console.WriteLine("[!] In-Sight sensor offline.");
                        break;
                    case CameraState.Online:
                        Console.WriteLine("[!] In-Sight sensor online.");
                        break;
                    case CameraState.Disconnected:
                        Console.WriteLine("[!] In-Sight sensor disconnected.");
                        break;
                }

                return CameraState.Connected;
            }
            catch (CvsInSightLockedException)
            {
                // The sensor has been software-locked, preventing connection.
                Console.WriteLine("[!] In-Sight locked.");
                return CameraState.Disconnected;
            }
            catch (CvsSensorAlreadyConnectedException)
            {
                // The sensor is already connected to a computer.
                Console.WriteLine("[!] Sensor already connected.");
                return CameraState.Disconnected;
            }
            catch (CvsInvalidLogonException ex)
            {
                // Invalid username or password.

                if (ex.IsInvalidUsername)
                {
                    Console.WriteLine("[!] Invalid username.");
                }
                else
                {
                    Console.WriteLine("[!] Invalid password.");
                }
                
                return CameraState.Disconnected;
            }
            catch (CvsNetworkException ex)
            {
                // Unable to successfully connect to a sensor.
                Console.WriteLine("[!] A network error occurred while trying to establish a connection: " + ex.Message);
                return CameraState.Disconnected;
            }
            catch (Exception ex)
            {
                // Consume any other exception that occur.
                Console.WriteLine("[!] An Error occured: " + ex.Message);
                return CameraState.Disconnected;
            }
        }

        public void CaptureImage()
        {
            CvsInSight sensor = Camera.Camera;
            
            Console.WriteLine("[!] Captureing image...");
            
            sensor.ManualAcquire();
        }

        public CvsStatusLevel GetStatus()
        {
            return SensorResult.StatusLevel;
        }
    }
}

