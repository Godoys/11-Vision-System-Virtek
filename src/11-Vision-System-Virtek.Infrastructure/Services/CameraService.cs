using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using Cognex.InSight;
using Cognex.InSight.Ftp;
using Cognex.InSight.NativeMode;
using System.Text.RegularExpressions;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    public class CameraService : ICameraService
    {
        private readonly Camera Camera;

        public CameraService(Camera camera)
        {
            Camera = camera;
        }
        
        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------
        
        /// <summary>
        /// Uploads a job file to a camera.
        /// </summary>
        /// <param name="filePath">Contains the path to the job file in the computer.</param>
        /// <param name="fileName">Contains the name of the file.</param>
        public void UploadJob(string filePath, string fileName)
        {
            // Creates a FtpClient object.
            CvsFtpClient camera = new CvsFtpClient();
            
            // Connects to the camera.
            Connect(camera, false, false);

            try
            {
                // Checks if the fileName is accepted by the camera system.
                if (camera.IsValidFilename(fileName))
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Open))
                    {
                        camera.SendFileToInSight(stream, fileName);
                    }
                }
                else
                {
                    Console.WriteLine("[!] Invalid file name.");
                }
                
                Disconnect(camera);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("[!] File not found when trying to upload file.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("[!] Directory not found when trying to upload file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("[!] Unauthorized access when trying to upload file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("[!] I/O Error: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("[!] Invalid path format: " + ex.Message);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("[!] Data is null.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("[!] fileName is not valid.");
            }
            catch (CvsNotConnectedException)
            {
                Console.WriteLine("[!] Not connected to a camera.");
            }
            catch (CvsFileOperationFailedException ex)
            {
                Console.WriteLine("[!] File could not be uploaded: " + ex.Message);
            }
            catch (CvsNetworkException)
            {
                Console.WriteLine("[!] Could not find an acceptable IP address to perform the file transfer or some other network error occured.");
            }
        }

        /// <summary>
        /// Loads the uploaded job file in the camera, and set it as the using job file.
        /// </summary>
        /// <param name="fileName">Constains the name of the uploaded job file.</param>
        public void LoadJob(string fileName)
        {
            // Creates a NativeMode client.
            CvsNativeModeClient camera = new CvsNativeModeClient();
            
            // Connects to the camera.
            Connect(camera, false, false);
            
            // Variable that holds the JobId
            string jobID = GetJobId(fileName);

            try
            {
                // Set JobFile as the active job being used by the camera.
                camera.SendCommand("SJ" + jobID);

                Console.WriteLine("[!] Job sucessfully loaded.");
            }
            catch (CvsNotConnectedException ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            catch (CvsNativeModeResponseException ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            catch (CvsNativeModeTimeoutException ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            catch (CvsNetworkException ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
        }

        /// <summary>
        /// Triggers the manual capturing of an image.
        /// </summary>
        public void TriggerImageCapture()
        {
            // Connects to the camesa using In-Sight.
            CvsInSight camera = new CvsInSight();

            try
            {
                // Triggers a manual acquisition of an image.
                camera.ManualAcquire();

                Console.WriteLine("[!] Image acquired manually.");
            }
            catch (CvsNotConnectedException ex)
            {
                Console.WriteLine("[!]" + ex.Message);
            }
            catch (CvsLiveAcquisitionException ex)
            {
                Console.WriteLine("[!]" + ex.Message);
            }
            catch (CvsNetworkException ex)
            {
                Console.WriteLine("[!]" + ex.Message);
            }
            catch (CvsInSightLockedException ex)
            {
                Console.WriteLine("[!]" + ex.Message);
            }
        }
        
        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------

        /// <summary>
        /// Connects to the In-Sight sensor at the specified IP address.
        /// </summary>
        /// <param name="camera">Contains an object of type CvsInSight, CvsFtpClient, or CvsNativeModeClient.</param>
        /// <param name="forceConnect">When true, will break an existing connection; False, will prohibit a connection if one already exists.</param>
        /// <param name="asynchronous">When true, will return without waiting for the connection to be complete; False, will wait for the connection to complete.</param>
        /// <returns></returns>
        private dynamic Connect(dynamic camera, bool forceConnect = false, bool asynchronous = false)
        {
            string username   = Camera.Username;
            string password   = Camera.Password;
            IPAddress address = Camera.Address;
            
            Console.WriteLine("[*] Connecting to In-Sight sensor " + address + "...");

            try
            {

                if (forceConnect == true || asynchronous == true)
                {
                    // Use camera object Connect method to make a connection to a camera.
                    camera.Connect(address, username, password, forceConnect, asynchronous);
                }
                else
                {
                    // Use camera object Connect method to make a connection to a camera.
                    camera.Connect(address, username, password);
                }
                
                // Set camera state to connected
                Camera.State = CameraState.Connected;
                
                // Returns CvsInSight object for use.
                return camera;
            }
            catch (CvsInSightLockedException ex)
            {
                // The sensor has been software-locked, preventing connection.
                Console.WriteLine("[!] " + ex.Message);
                
                // Returns CvsInSight object for connection retry.
                return camera;
            }
            catch (CvsSensorAlreadyConnectedException ex)
            {
                // The sensor is already connected to a computer.
                Console.WriteLine("[!] " + ex.Message);
                
                // Returns CvsInSight object for connection retry.
                return camera;
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
                
                // Returns CvsInSight object for connection retry.
                return camera;
            }
            catch (CvsNetworkException ex)
            {
                // Unable to successfully connect to a sensor.
                Console.WriteLine("[!] " + ex.Message);
                
                // Returns CvsInSight object for connection retry.
                return camera;
            }
            catch (Exception ex)
            {
                // Consume any other exception that occur.
                Console.WriteLine("[!] " + ex.Message);
                
                // Returns CvsInSight object for connection retry.
                return camera;
            }
        }

        /// <summary>
        /// Disconnects from a camera.
        /// </summary>
        /// <param name="camera">Contains an object of type CvsInSight, CvsFtpClient, or CvsNativeModeClient.</param>
        private void Disconnect(dynamic camera)
        {
            camera.Disconnect();
            
            // Sets the state of the camera to disconnected.
            Camera.State = CameraState.Disconnected;
        }

        /// <summary>
        /// Gets the job ID based on the job file name.
        /// </summary>
        /// <param name="jobName">Job file name.</param>
        /// <returns></returns>
        private string GetJobId(string jobName)
        {
            // Variable to hold the id value for return.
            string result = string.Empty;
            
            // Regex to get the first alphabetic character on the JobName.
            Regex rx = new Regex(@"a-zA-Z");
            
            // Collection of matches that hold the first alphabethic character.
            MatchCollection matches = rx.Matches(jobName);
            
            // First alphabetic character found in JobName.
            string firstAlphaCharacter = matches[0].Value;
            
            // Location of the first alphabetic character.
            int charLocation = jobName.IndexOf(firstAlphaCharacter, StringComparison.Ordinal);
            
            // Gets the substring that represents the job ID.
            if (charLocation > 0)
            {
                result = jobName.Substring(0, charLocation);
            }
            
            return result;
        }
    }
}