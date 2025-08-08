
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
        /// Resumes to previous projection.
        /// </summary>
        /// <returns>A task that completes when projection resumes.</returns>
        public Task ResumeProjectionAsync();

        /// <summary>
        /// Gets the current projection entity.
        /// </summary>
        /// <returns>A task that completed when current projection entity name is returned.</returns>
        public Task<string> GetCurrentProjectionEntityAsync();
        
        /// <summary>
        /// Gets the name of the current open Work Order.
        /// </summary>
        /// <returns>The name of the open Work Order.</returns>
        public Task<string> GetCurrentWorkOrderNameAsync();
        
        /// <summary>
        /// Gets the id of the current connected client.
        /// </summary>
        /// <returns>The id of the connected client</returns>
        public Task<string> GetConnectedClientIdAsync();

        /// <summary>
        /// Adds a .PLY file projection to the current open work order. 
        /// </summary>
        /// <param name="name">Name of the projection to be added to the work order step list.</param>
        /// <param name="id">Unique id manually or automatically added to the new projection.</param>
        /// <param name="unit">Unit of the projection file.</param>
        /// <param name="filepath">Absolute file path to the .PLY file to be used.</param>
        /// <returns></returns>
        public Task AddProjectPolygonAsync(string name, int id, string unit);
        
        /// <summary>
        /// Process an incoming projector message.
        /// </summary>
        /// <param name="msg">The raw bytes received from the projector.</param>
        /// <returns>True, if the received message is equal the expected; False, otherwise.</returns>
        public bool IsExpectedMessage(byte[] msg);
    }
}