using _11_Vision_Software_Virtek.Domain.Entities;

namespace _11_Vision_Software_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Interface of the Cognex Camera and the Vision System.
    /// </summary>
    /// <param name="Image">Captured image data</param>
    /// <param name="Camera">Camera configuration and address</param>
    interface ICameraService
    {
        ImageData Image { get; set; }
        CameraData Camera { get; set; }
    }
}


