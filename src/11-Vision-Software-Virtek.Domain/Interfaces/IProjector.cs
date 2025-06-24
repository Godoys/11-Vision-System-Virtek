
namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Controls a industrial laser projector: connects/disconnects, pause/resume projection, open/closes projection file.
    /// </summary>
    public interface IProjector
    {
        /// <summary>
        /// Unique client identifier used when connecting.
        /// </summary>
        string ClientId { get; }
        
        /// <summary>
        /// Serial number of the projector device.
        /// </summary>
        string ProjectorSerialNumber { get; }

        /// <summary>
        /// Establishes a session with the projector.
        /// </summary>
        /// <returns>A task that completes when connected.</returns>
        public Task ConnectAsync();
        
        /// <summary>
        /// Gracefully closes the session with the projector.
        /// </summary>
        /// <returns>A task that completes when disconnected.</returns>
        public Task DisconnectAsync();

        /// <summary>
        /// Pause current projection.
        /// </summary>
        /// <returns>A task that completes when projection pauses.</returns>
        public Task PauseProjectionAsync();

        /// <summary>
        /// Gets the current projection entity.
        /// </summary>
        /// <returns>A task that completed when current projection entity name is returned.</returns>
        public Task<string> GetCurrentProjectionEntityAsync();
        
        /// <summary>
        /// Process an incoming projector message.
        /// </summary>
        /// <param name="msg">The raw bytes received from the projector.</param>
        /// <returns>True, if the received message is equal the expected; False, otherwise.</returns>
        public bool IsExpectedMessage(byte[] msg);
    }
}