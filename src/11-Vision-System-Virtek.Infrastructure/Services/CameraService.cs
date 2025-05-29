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

        public CameraService(string username, string password, IPAddress address)
        {
            this.Camera = new CameraData(username, password, address);
            try
            {
                this.Camera.Camera = new CvsInSight();
            }
            catch (Exception e)
            {
                Console.WriteLine("[!] Camera service error: " + e.Message);
            }
            
        }

        public void Connect(bool forceConnect, bool asynchronous)
        {
            string username = Camera.Username;
            string password = Camera.Password;
            IPAddress address = Camera.Address;
            CameraState state = Camera.State;
            CvsInSight camera = Camera.Camera;
            
            Console.WriteLine("[*] Connecting to In-Sight sensor " + address + "...");

            try
            {
                camera.Connect(address, username, password, forceConnect, asynchronous);

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
                
                // Setting camera state to online.
                
                Camera.State = CameraState.Online;
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
            CvsInSight sensor = Camera.Camera;
            
            Console.WriteLine("[!] Capturing image...");
            
            sensor.ManualAcquire();
        }
    }
}

