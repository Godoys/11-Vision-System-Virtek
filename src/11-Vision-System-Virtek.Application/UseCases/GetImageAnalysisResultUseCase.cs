using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class GetImageAnalysisResultUseCase
    {
        private readonly ISensorService _cameraService;

        public GetImageAnalysisResultUseCase(ISensorService cameraService)
        {
            _cameraService = cameraService;
        }

        public async Task<SensorResultStatus> Execute()
        {
            return await _cameraService.GetLastAnalysisResultAsync();
        }
    }
}