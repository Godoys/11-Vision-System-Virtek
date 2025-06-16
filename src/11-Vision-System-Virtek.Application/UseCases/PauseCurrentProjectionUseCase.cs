
using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Application.UseCases
{
    public class PauseCurrentProjectionUseCase
    {
        private readonly IProjectorService _projectorService;

        public PauseCurrentProjectionUseCase(IProjectorService projectorService)
        {
            _projectorService = projectorService;
        }

        public async Task Execute()
        {
            await _projectorService.Connect();
            await _projectorService.PauseProjection();
        }
    }
}