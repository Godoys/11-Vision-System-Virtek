using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Interface of a Camera and the Vision System.
    /// </summary>
    /// <param name="Camera">Gets the camera object of an SDK</param>
    
    public interface ICameraService
    {
        public CameraData Camera { get; set; }

        /// <summary>
        /// Connects to a Camera using its IP address
        /// </summary>
        /// <param name="forceConnect">True, will break an existing connection and connect; False, will prohibit a connection if one already exists</param>
        /// <param name="asynchronous">True, will return without waiting for the connection to be complete; False, will wait for connection to complete</param>
        
        public void Connect(bool forceConnect, bool asynchronous);
    }
}


