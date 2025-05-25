using System.Net;
using _11_Vision_Software_Virtek.Domain.Enums;

namespace _11_Vision_Software_Virtek.Domain.Entities
{
    public class CameraData
    {
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

