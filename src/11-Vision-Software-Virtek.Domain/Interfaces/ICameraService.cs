using System.Net;
using _11_Vision_Software_Virtek.Domain.Entities;

namespace _11_Vision_Software_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Interface of a Camera and the Vision System.
    /// </summary>
    /// <param name="Image">Captured image data</param>
    /// <param name="Camera">Camera configuration and address</param>
    public interface ICameraService
    {
        public ImageData Image { get; set; }
        public CameraData Camera { get; set; }

        /// <summary>
        /// Connects to a Camera using its IP address
        /// </summary>
        /// <param name="address">Camera's IP address</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="forceConnect">True, will break an existing connection and connect; False, will prohibit a connection if one already exists</param>
        /// <param name="asynchronous">True, will return without waiting for the connection to be complete; False, will wait for connection to complete</param>
        public void Connect(bool forceConnect, bool asynchronous);
    }
}


