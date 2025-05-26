using System.Net;
using _11_Vision_Software_Virtek.Domain.Interfaces;
using _11_Vision_Software_Virtek.Domain.Entities;
using _11_Vision_Software_Virtek.Domain.Enums;
using Cognex.InSight;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Implementaion of ICameraService interface.
    /// </summary>
    public class CameraService : ICameraService
    {
        public CameraData Camera { get; set; }
        private CvsInSight Sensor { get; set; }
        private CvsResultSet SensorResult { get; set; }

        public CameraService(CameraData camera)
        {
            this.Camera = camera;
            this.Sensor = new CvsInSight();
        }

        public void Connect(bool forceConnect, bool asynchronous)
        {
            string username = Camera.Username;
            string password = Camera.Password;
            IPAddress address = Camera.Address;
            
            Console.WriteLine("[*] Connecting to In-Sight sensor " + address + "...");

            try
            {
                Sensor.Connect(address, username, password, forceConnect, asynchronous);

                // Determine the state of the sensor

                switch (Camera.State)
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
            }
            catch (CvsInSightLockedException)
            {
                // The sensor has been software-locked, preventing connection.
                Console.WriteLine("[!] In-Sight locked.");
            }
            catch (CvsSensorAlreadyConnectedException)
            {
                // The sensor is already connected to a computer.
                Console.WriteLine("[!] Sensor already connected.");
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
            }
            catch (CvsNetworkException ex)
            {
                // Unable to successfully connect to a sensor.
                Console.WriteLine("[!] A network error occurred while trying to establish a connection: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Consume any other exception that occur.
                Console.WriteLine("[!] An Error occured: " + ex.Message);
            }
        }

        public void CaptureImage()
        {
            Console.WriteLine("[!] Captureing image...");
            
            Sensor.ManualAcquire();
        }

        public CvsStatusLevel GetStatus()
        {
            return SensorResult.StatusLevel;
        }
    }
}

