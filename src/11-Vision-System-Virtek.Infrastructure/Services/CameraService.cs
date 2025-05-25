using _11_Vision_Software_Virtek.Domain.Interfaces;
using _11_Vision_Software_Virtek.Domain.Entities;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Implementaion of ICameraService interface.
    /// </summary>
    public class CameraService
    {
        private ImageData Image { get; set; }
        private CameraData Camera { get; set; }

        public CameraService(ImageData image, CameraData camera)
        {
            this.Image = image;
            this.Camera = camera;
        }
    }
}

