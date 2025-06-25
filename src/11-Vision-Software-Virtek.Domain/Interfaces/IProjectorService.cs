
namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Orchestrates projector lifecycle and projection control at a business-logic level.
    /// </summary>
    public interface IProjectorService
    {
        /// <summary>
        /// Establishes a session with the industrial laser projector.
        /// </summary>
        /// <returns>A task that completes when connected.</returns>
        public Task ConnectAsync();
        
        /// <summary>
        /// Gracefully closes the session with the projector.
        /// </summary>
        /// <returns>A task that completes when disconnected.</returns>
        public Task DisconnectAsync();

        /// <summary>
        /// Pauses the current projection.
        /// </summary>
        /// <returns>A task that completes when projection paused.</returns>
        public Task PauseProjectionAsync();
        
        /// <summary>
        /// Checks if the current projection entity changed.
        /// </summary>
        /// <param name="token">A cancellation token that when activated completes the task.</param>
        /// <returns>A task that completes when Cancellation Token is activated.</returns>
        public Task CheckCurrentProjectionEntityAsync(CancellationToken token);
        
        /// <summary>
        /// Signature of the handler of the NextStep event.
        /// </summary>
        public delegate void NextStepEventHandler(object sender, EventArgs e);
        
        /// <summary>
        /// NextStep event declaration.
        /// </summary>
        event NextStepEventHandler NextStep;
    }
}