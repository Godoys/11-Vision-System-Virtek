using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using Cognex.InSight;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    public class CameraService : ICameraService
    {
        private readonly Camera _camera;

        public CameraService(Camera camera)
        {
            _camera = camera;
            _camera.CameraObj = new CvsInSight();
        }
        
        public void Connect(bool forceConnect = false, bool asynchronous = false)
        {
            string username   = _camera.Username;
            string password   = _camera.Password;
            IPAddress address = _camera.Address;
            CvsInSight camera = _camera.CameraObj;
            
            Console.WriteLine("[*] Connecting to In-Sight sensor " + address + "...");

            try
            {
                // Use camera object Connect method to make a connection to a camera.

                camera.Connect(address, username, password, forceConnect, asynchronous);

                // Set camera state to connected

                _camera.State = CameraState.Connected;
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
    }
}