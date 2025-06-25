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

        public async Task Execute(string filePath, string fileName)
        {
            await _cameraService.UploadAndLoadJobAsync(filePath, fileName);
        }
    }
}