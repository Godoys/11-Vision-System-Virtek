using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Entities;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    /// <summary>
    /// Connects to a camera / vision system using ICameraService defined connect method.
    /// </summary>
    
    public class ConnectToCameraUseCase
    {
        private readonly ICameraService _cameraService;

        public ConnectToCameraUseCase(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Connect(bool forceConnect = false, bool asynchronous = false)
        {
            _cameraService.Connect(forceConnect, asynchronous);
        }
    }
}