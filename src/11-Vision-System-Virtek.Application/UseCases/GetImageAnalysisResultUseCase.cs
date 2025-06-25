using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class GetImageAnalysisResultUseCase
    {
        private readonly ICameraService _cameraService;

        public GetImageAnalysisResultUseCase(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public async Task<ResultStatus> Execute()
        {
            return await _cameraService.GetLastAnalysisResultAsync();
        }
    }
}