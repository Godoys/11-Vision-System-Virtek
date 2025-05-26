using System.Net;
using _11_Vision_Software_Virtek.Domain.Entities;

namespace _11_Vision_Software_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Interface of a Camera and the Vision System.
    /// </summary>
    /// <param name="Camera">Gets the object that holds the data of the camera for connection</param>
    public interface ICameraService
    {
        public CameraData Camera { get; set; }

        /// <summary>
        /// Connects to a Camera using its IP address
        /// </summary>
        /// <param name="forceConnect">True, will break an existing connection and connect; False, will prohibit a connection if one already exists</param>
        /// <param name="asynchronous">True, will return without waiting for the connection to be complete; False, will wait for connection to complete</param>
        public void Connect(bool forceConnect, bool asynchronous);

        /// <summary>
        /// Triggers the Camera to capture an image.
        /// </summary>
        public void CaptureImage();
    }
}


