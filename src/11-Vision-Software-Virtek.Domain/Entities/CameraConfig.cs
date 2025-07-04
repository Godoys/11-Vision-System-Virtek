using System.Net;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Entities
{
    /// <summary>
    /// Holds the configuration details used to connect to a camera.
    /// </summary>
    public class CameraConfig
    {
        public string Username { get; }
        public string Password { get; }
        public IPAddress Address { get; }
        public CameraState State { get; set; }
        
        // Holds the most current result of a image analysis.
        public ResultStatus Result { get; set; }
        
        public Camera(string username, string password, IPAddress address)
        {
            this.Username = username;
            this.Password = password;
            this.Address = address;
            this.State = CameraState.Offline;
        }
    }
}