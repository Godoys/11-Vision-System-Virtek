using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Entities;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class ConnectToCameraUseCase
    {
        private readonly ICameraService _cameraService;

        public ConnectToCameraUseCase(ICameraService cameraService)
        {
            _cameraService = cameraService ?? throw new ArgumentNullException(nameof(cameraService));
        }

        public async Task<CameraState> ConnectToCamera(CameraData camera)
        {
            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }

            return _cameraService.Connect(false, true);
        }
    }
}