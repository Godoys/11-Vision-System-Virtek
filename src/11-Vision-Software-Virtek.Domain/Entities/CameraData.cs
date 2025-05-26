using System.Net;
using _11_Vision_Software_Virtek.Domain.Enums;

namespace _11_Vision_Software_Virtek.Domain.Entities
{
    /// <summary>
    /// Information of the camera being utilized.
    /// </summary>
    /// <param name="Camera">Gets a Camera object to deal with specific camera function</param>
    /// <param name="Username">Gets the username to log on the sensor</param>
    /// <param name="Password">Gets the password to log on the sensor</param>
    /// <param name="Address">Gets the IP address of the sensor</param>
    /// <param name="State">Gets the state of the sensor</param>
    public class CameraData
    {
        public dynamic Camera;
        public string Username { get; set; }
        public string Password { get; set; }
        public IPAddress Address { get; set; }
        public CameraState State { get; set; }

        public CameraData(string username, string password, IPAddress address, CameraState state)
        {
            this.Username = username;
            this.Password = password;
            this.Address = address;
            this.State = state;
        }
    }
}

