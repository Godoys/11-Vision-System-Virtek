using System.Net;
using System.Text.RegularExpressions;
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
    public class CognexCameraAdapter : ICamera
    {
        // Cognex sensor objects for different type of connections.
        
        private readonly CvsInSight _sensor;
        private readonly CvsFtpClient _sensorFTP;
        private readonly CvsNativeModeClient _sensorNativeMode;
        
        public string Username { get; private set; }
        public string Password { get; private set; }
        public IPAddress Address { get; private set; }
        public CameraState State { get; private set; }
        public ResultStatus LastAnalysisResult { get; private set; }
        
        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------

        public CognexCameraAdapter(string username, string password, IPAddress address)
        {
            Username = username;
            Password = password;
            Address = address;
            State = CameraState.Offline;
            LastAnalysisResult = ResultStatus.None;
            _sensor = new CvsInSight();
            _sensorFTP = new CvsFtpClient();
            _sensorNativeMode = new CvsNativeModeClient();
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
        
        public async Task ConnectAsync(CameraConnectionType connectionType)
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
        
        public async Task DisconnectAsync(CameraConnectionType connectionType)
        {
            Console.WriteLine("[*] Disconnecting from sensor " + Address + "...");
            
            switch (connectionType)
            {
                case CameraConnectionType.CM:
                    await Task.Run(() => _sensor.Disconnect());
                    break;
                case CameraConnectionType.FTP:
                    await Task.Run(() => _sensorFTP.Disconnect());
                    break;
                case CameraConnectionType.NM:
                    await Task.Run(() => _sensorNativeMode.Disconnect());
                    break;
            }
            
            // Set state to disconnected.
            State = CameraState.Disconnected;
            
            Console.WriteLine("[*] Disconnected from sensor " + Address + "...");
        }
        
        public async Task UploadJobAsync(string jobPath, string jobName)
        {
            Console.WriteLine("[*] Uploading job " + jobName + "to sensor " + Address + "...");

            try
            {
                await ConnectAsync(CameraConnectionType.FTP);
                
                // Set state to connected.
                State = CameraState.Connected;

                // Checks if the JobName is accepted by the sensor system.

                if (_sensorFTP.IsValidFilename(jobName))
                {
                    await Task.Run(() =>
                    {
                        using (FileStream stream = new FileStream(jobPath, FileMode.Open))
                        {
                            _sensorFTP.SendFileToInSight(stream, jobName);
                        }
                    });
                }

                await DisconnectAsync(CameraConnectionType.FTP);
                
                // Set state to disconnected.
                State = CameraState.Disconnected;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            
            Console.WriteLine("[*] " + jobName + " uploaded to sensor " + Address);
        }
        
        public async Task LoadJobAsync(string jobName)
        {
            Console.WriteLine("[*] Setting " + jobName + " as default job in sensor " + Address + "...");

            try
            {
                await ConnectAsync(CameraConnectionType.NM);
                
                // Set state to connected.
                State = CameraState.Connected;

                // Gets the jobId.
                string jobId = ParseJobId(jobName);

                // Set JobFile as the active job being used by the camera.
                _sensorNativeMode.SendCommand("SJ" + jobId);
                
                await DisconnectAsync(CameraConnectionType.NM);
                
                // Set state to disconnected.
                State = CameraState.Disconnected;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            
            Console.WriteLine("[*] Job successfully loaded to sensor " + Address);
        }
        
        public async Task TriggerImageCaptureAsync()
        {
            Console.WriteLine("[*] Triggering image capture");

            try
            {
                await ConnectAsync(CameraConnectionType.CM);
                await Task.Run(() => { _sensor.ManualAcquire(); });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
            
            await DisconnectAsync(CameraConnectionType.CM);
        }
        
        public async Task GetAnalysisResultAsync()
        {
            // Enum of Cognex SDK result status.
            CvsStatusLevel resultStatus;
            
            // Connects to sensor.
            await ConnectAsync(CameraConnectionType.CM);
            
            // Gets result status from camera.
            resultStatus = _sensor.Results.StatusLevel;

            switch (resultStatus)
            {
                case CvsStatusLevel.Pass:
                    UpdateResult(ResultStatus.Pass);
                    break;
                case CvsStatusLevel.Warn:
                    UpdateResult(ResultStatus.Warn);
                    break;
                case CvsStatusLevel.Fail:
                    UpdateResult(ResultStatus.Fail);
                    break;
            }
            
            // Disconnects from camera.
            await DisconnectAsync(CameraConnectionType.CM);
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
                await Task.Run(() => { _sensor.Connect(Address, Username, Password, false, true); });
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
                await Task.Run(() => { _sensorFTP.Connect(Address, Username, Password); });
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
                await Task.Run(() => { _sensorNativeMode.Connect(Address, Username, Password); });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[!] " + ex.Message);
            }
        }
        
        /// <summary>
        /// Gets the job identifier based on the job file name.
        /// </summary>
        /// <param name="jobName">Job file name.</param>
        /// <returns>Returns the identifier of the given job file.</returns>
        private string ParseJobId(string jobName)
        {
            // Extract numeric prefix (e.g. "123ABC" -> "123")
            var m = Regex.Match(jobName, @"^\d+");
            return m.Success ? m.Value : throw new FormatException($"[!] Invalid job name: {jobName}");
        }
    }
}