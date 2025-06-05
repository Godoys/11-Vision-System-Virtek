using System.Net;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Entities
{
    
    /// <summary>
    /// Represents a Camera with CameraObj (object of a camera SDK) , Username, Password, IP Address, and State.
    /// </summary>
    
    public class Camera
    {
        public string Username { get; }
        public string Password { get; }
        public IPAddress Address { get; }
        public CameraState State { get; set; }
        
        public Camera(string username, string password, IPAddress address)
        {
            this.Username = username;
            this.Password = password;
            this.Address = address;
            this.State = CameraState.Offline;
        }
    }
}