using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class PauseOrContinueProjection
    {
        private readonly ICameraService _cameraService;
        private readonly IProjectorService _projectorService;
        private readonly GetImageAnalysisResultUseCase _getImageResult;

        public PauseOrContinueProjection(ICameraService cameraService, IProjectorService projectorService)
        {
            _cameraService = cameraService;
            _projectorService = projectorService;
            _getImageResult = new GetImageAnalysisResultUseCase(_cameraService);
        }

        public void Subscribe()
        {
            // Subscribe to the event.
            _projectorService.NextStep += Execute;
            
            // Cancellation token for CurrentProjectionEntity checker.
            CancellationTokenSource cts = new();
            
            // Checks if the current projection entity changed.
            _projectorService.CheckCurrentProjectionEntityAsync(cts.Token);
        }

        private async Task Execute(object sender, EventArgs e)
        {
            Console.WriteLine("[!] Next Step event raised!");
            
            // Image analysis result;
            ResultStatus result = await _getImageResult.Execute();
            
            // Decides if projection continues or stops.
            switch (result)
            {
                case ResultStatus.Fail:
                    await _projectorService.PauseProjectionAsync();
                    break;
                case ResultStatus.Pass:
                    Console.WriteLine("[!] Passed image analysis with a unconditional pass.");
                    break;
                case ResultStatus.Warn:
                    Console.WriteLine("[!] Passed image analysis with a WARNING,");
                    break;
                case ResultStatus.None:
                    break;
            }
        }
    }
}