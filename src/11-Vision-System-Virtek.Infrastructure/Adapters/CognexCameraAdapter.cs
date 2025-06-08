using System.Net;
using System.Text.RegularExpressions;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using Cognex.InSight;
using Cognex.InSight.Ftp;
using Cognex.InSight.NativeMode;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    public class CognexCameraAdapter : ICamera
    {
        // Cognex sensor objects for different type of connections.
        
        private readonly CvsInSight sensor;
        private readonly CvsFtpClient sensorFTP;
        private readonly CvsNativeModeClient sensorNativeMode;
        
        // Sensor logging, state, and result information.
        public string Username { get; private set; }
        public string Password { get; private set; }
        public IPAddress Address { get; private set; }
        public CameraState State { get; private set; }
        public ResultState Result { get; private set; }
        
        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------

        CognexCameraAdapter(string username, string password, IPAddress address)
        {
            Username = username;
            Password = password;
            Address = address;
            State = CameraState.Offline;
            Result = ResultState.None;
            sensor = new CvsInSight();
            sensorFTP = new CvsFtpClient();
            sensorNativeMode = new CvsNativeModeClient();
        }

        /// <summary>
        /// Updates Username with newUsername value.
        /// </summary>
        /// <param name="newUsername">Holds the value of the new username to be set.</param>
        
        public void UpdateUsername(string newUsername)
        {
            Username = newUsername;
        }

        /// <summary>
        /// Updates the Password with newPassword value.
        /// </summary>
        /// <param name="newPassword">Holds the value of the new password to be set.</param>
        
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        /// <summary>
        /// Updates the Address with newAddress value.
        /// </summary>
        /// <param name="newAddress">Holds the value of the new password to be set.</param>
        
        public void UpdateAddress(IPAddress newAddress)
        {
            Address = newAddress;
        }

        /// <summary>
        /// Updates the State with newState value.
        /// </summary>
        /// <param name="newState">Holds the value of the new state to be set.</param>

        public void UpdateState(CameraState newState)
        {
            State = newState;
        }

        /// <summary>
        /// Updates the Result with newResult value.
        /// </summary>
        /// <param name="newResult">Holds the value of the new state to be set.</param>

        public void UpdateResult(ResultState newResult)
        {
            Result = newResult;
        }

        /// <summary>
        /// Connects to a camera through ConnectionType.
        /// </summary>
        /// <param name="connectionType">Type of connection that will be used.</param>
        /// <exception cref="NotSupportedException">Connection type is not support.</exception>
        
        public async Task Connect(CameraConnectionType connectionType)
        {
            switch (connectionType)
            {
                case CameraConnectionType.CM:
                    await ConnectCm();
                    break;
                case CameraConnectionType.FTP:
                    await ConnectFtp();
                    break;
                case CameraConnectionType.NM:
                    await ConnectNm();
                    break;
                default:
                    throw new NotSupportedException("[!] Unsupported connection type: " + connectionType);
            }
            
            // Set state to connected.
            State = CameraState.Connected;
        }

        /// <summary>
        /// Disconnects from a camera.
        /// </summary>
        /// <param name="connectionType">Type of connection used.</param>
        
        public async Task Disconnect(CameraConnectionType connectionType)
        {
            Console.WriteLine("[*] Disconnecting from sensor " + Address + "...");
            
            switch (connectionType)
            {
                case CameraConnectionType.CM:
                    await Task.Run(() => sensor.Disconnect());
                    break;
                case CameraConnectionType.FTP:
                    await Task.Run(() => sensorFTP.Disconnect());
                    break;
                case CameraConnectionType.NM:
                    await Task.Run(() => sensorNativeMode.Disconnect());
                    break;
            }
            
            // Set state to disconnected.
            State = CameraState.Disconnected;
            
            Console.WriteLine("[*] Disconnected from sensor " + Address + "...");
        }

        public async Task UploadJob(string jobPath, string jobName)
        {
            Console.WriteLine("[*] Uploading job " + jobName + "to sensor " + Address + "...");

            try
            {
                await Connect(CameraConnectionType.FTP);
                
                // Set state to connected.
                State = CameraState.Connected;

                // Checks if the JobName is accepted by the sensor system.

                if (sensorFTP.IsValidFilename(jobName))
                {
                    await Task.Run(() =>
                    {
                        using (FileStream stream = new FileStream(jobPath, FileMode.Open))
                        {
                            sensorFTP.SendFileToInSight(stream, jobName);
                        }
                    });
                }

                await Disconnect(CameraConnectionType.FTP);
                
                // Set state to disconnected.
                State = CameraState.Disconnected;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            
            Console.WriteLine("[*] " + jobName + " uploaded to sensor " + Address);
        }

        public async Task LoadJob(string jobName)
        {
            Console.WriteLine("[*] Setting " + jobName + " as default job in sensor " + Address + "...");

            try
            {
                await Connect(CameraConnectionType.NM);
                
                // Set state to connected.
                State = CameraState.Connected;

                // Gets the jobId.
                string jobId = GetJobId(jobName);

                // Set JobFile as the active job being used by the camera.
                sensorNativeMode.SendCommand("SJ" + jobId);
                
                await Disconnect(CameraConnectionType.NM);
                
                // Set state to disconnected.
                State = CameraState.Disconnected;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            
            Console.WriteLine("[*] Job successfully loaded to sensor " + Address);
        }

        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------

        /// <summary>
        /// Connects to InSight sensor using the high-level CvsInSight class.
        /// </summary>
        private async Task ConnectCm()
        {
            Console.WriteLine("[*] Connecting to InSight sensor " + Address + "...");

            try
            {
                await Task.Run(() => { sensor.Connect(Address, Username, Password, false, true); });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
        }

        /// <summary>
        /// Connects to InSight sensor using the File Transfer Protocol.
        /// </summary>
        private async Task ConnectFtp()
        {
            Console.WriteLine("[*] Connecting to InSight sensor " + Address + "through FTP...");

            try
            {
                await Task.Run(() => { sensorFTP.Connect(Address, Username, Password); });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
        }

        /// <summary>
        /// Connects to InSight sensor using the Native Mode.
        /// </summary>
        private async Task ConnectNm()
        {
            Console.WriteLine("[*] Connecting to InSight sensor " + Address + "through Native Mode...");

            try
            {
                await Task.Run(() => { sensorNativeMode.Connect(Address, Username, Password); });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
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