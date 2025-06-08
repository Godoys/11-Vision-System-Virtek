using System.Net;
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
            
            Console.WriteLine("[*] Disconnected from sensor " + Address + "...");
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
    }
}