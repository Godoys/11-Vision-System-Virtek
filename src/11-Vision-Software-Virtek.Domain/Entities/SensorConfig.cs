using System.Net;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Entities
{
    /// <summary>
    /// Holds connection and image analysis information about the sensor.
    /// </summary>
    public class SensorConfig(string username, string password, IPAddress ipAddress, ushort portNumber = 0)
    {
        public string Username { get; private set; } = username;
        public string Password { get; private set; } =  password;
        public ushort PortNumber { get; private set; } = portNumber;
        public IPAddress Address { get; private set; } = ipAddress;
        public SensorConnectionState ConnectionState { get; private set; } = SensorConnectionState.Offline;
        public SensorResultStatus LastSensorResult { get; private set; } = SensorResultStatus.None;


        /// <summary>
        /// Changes the sensor's username.
        /// </summary>
        /// <param name="newUsername">The new login username.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateUsername(string newUsername)
        {
            Username = newUsername;
        }

        /// <summary>
        /// Changes the camera's password.
        /// </summary>
        /// <param name="newPassword">The new login password.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        /// <summary>
        /// Changes the sensor's address.
        /// </summary>
        /// <param name="newAddress">The new IP address.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateAddress(IPAddress newAddress)
        {
            Address = newAddress;
        }

        /// <summary>
        /// Changes the sensor's state.
        /// </summary>
        /// <param name="newConnectionState">The new sensor state.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateState(SensorConnectionState newConnectionState)
        {
            ConnectionState = newConnectionState;
        }

        /// <summary>
        /// Changes the sensor's last image analysis result.
        /// </summary>
        /// <param name="newSensorResult">The new image analysis result.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateResult(SensorResultStatus newSensorResult)
        {
            LastSensorResult = newSensorResult;
        }
    }
}