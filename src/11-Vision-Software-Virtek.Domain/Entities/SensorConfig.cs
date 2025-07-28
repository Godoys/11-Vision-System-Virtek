using System.Net;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Entities
{
    /// <summary>
    /// Holds connection and image analysis information about the sensor.
    /// </summary>
    public class SensorConfig
    {
        public string         Username { get; private set; }
        public string         Password { get; private set; }
        public ushort       PortNumber { get; private set; }
        public IPAddress       Address { get; private set; }
        public SensorConnectionState       ConnectionState { get; private set; }
        public SensorResultStatus LastSensorResult { get; private set; }

        public SensorConfig(string username, string password, IPAddress address, ushort portNumber = 0)
        {
            Username = username;
            Password = password;
            PortNumber = portNumber;
            Address = address;
            ConnectionState = SensorConnectionState.Offline;
            LastSensorResult = SensorResultStatus.None;
        }

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