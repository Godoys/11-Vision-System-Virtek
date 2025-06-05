
using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class LoadJobUseCase
    {
        private readonly ICameraService _cameraService;

        public LoadJobUseCase(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void LoadJob(string filePath, string fileName)
        {
            _cameraService.UploadJob(filePath, fileName);
            _cameraService.LoadJob(fileName);
        }
    }
}