using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class TriggerImageCaptureUseCase
    {
        private readonly ICameraService _cameraService;

        TriggerImageCaptureUseCase(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void TriggerImageCapture()
        {
            _cameraService.TriggerImageCapture();
        }
    }
}