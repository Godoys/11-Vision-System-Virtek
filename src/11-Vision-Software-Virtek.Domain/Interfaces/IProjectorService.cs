
namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    public interface IProjectorService
    {
        /// <summary>
        /// Connects to a projector.
        /// </summary>
        public Task Connect();
        
        /// <summary>
        /// Disconnects from projector.
        /// </summary>
        public Task Disconnect();

        /// <summary>
        /// Pauses current projection.
        /// </summary>
        public Task PauseProjection();
    }
}