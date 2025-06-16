
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
        
        /// <summary>
        /// Work as the handler of a subscribe function.
        /// </summary>
        /// <param name="msg">Received message.</param>
        /// <returns>True, if the received message is equal the expected; False, otherwise.</returns>
        public bool IsExpectedMessage(byte[] msg);
    }
}