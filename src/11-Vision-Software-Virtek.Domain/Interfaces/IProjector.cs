
namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    public interface IProjector
    {
        string ClientId { get; }
        string ProjectorSerialNumber { get; }

        /// <summary>
        /// Connects to a projector.
        /// </summary>
        public Task Connect();
        
        /// <summary>
        /// Disconnects from a projector.
        /// </summary>
        public Task Disconnect();

        /// <summary>
        /// Pause current projection.
        /// </summary>
        public Task PauseProjection();
    }
}