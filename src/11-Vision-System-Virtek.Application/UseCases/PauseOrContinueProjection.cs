using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class PauseOrContinueProjection
    {
        private readonly ISensorService _sensorService;
        private readonly IProjectorService _projectorService;
        private readonly GetImageAnalysisResultUseCase _getImageResult;

        public PauseOrContinueProjection(ISensorService sensorService, IProjectorService projectorService)
        {
            _sensorService = sensorService;
            _projectorService = projectorService;
            _getImageResult = new GetImageAnalysisResultUseCase(_sensorService);
        }

        public async void Subscribe()
        {
            // Subscribe to the event.
            _projectorService.NextStep += Execute;
            
            // Cancellation token for CurrentProjectionEntity checker.
            CancellationTokenSource cts = new();
            
            // Checks if the current projection entity changed.
            await _projectorService.CheckCurrentProjectionEntityAsync(cts.Token);
        }

        private async Task Execute(object sender, EventArgs e)
        {
            // Image analysis result;
            SensorResultStatus sensorResult = await _getImageResult.Execute();
            
            // Decides if projection continues or stops.
            switch (sensorResult)
            {
                case SensorResultStatus.Fail:
                    Console.WriteLine("[!] Failed image analysis with a FAIL.");
                    await _projectorService.PauseProjectionAsync();
                    break;
                case SensorResultStatus.Pass:
                    Console.WriteLine("[!] Passed image analysis with a unconditional PASS.");
                    break;
                case SensorResultStatus.Warn:
                    Console.WriteLine("[!] Passed image analysis with a WARNING,");
                    break;
                case SensorResultStatus.None:
                    break;
            }
        }
    }
}