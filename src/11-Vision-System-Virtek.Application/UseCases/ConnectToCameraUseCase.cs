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

        public void ConnectToCamera(bool forceConnection = false, bool asynchronous = false)
        {
            _cameraService.Connect(forceConnection, asynchronous);
        }
    }
}