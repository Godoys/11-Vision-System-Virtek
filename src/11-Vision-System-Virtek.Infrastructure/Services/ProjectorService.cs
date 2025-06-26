using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Orchestrates projection connectivity, functioning, and message handling via RabbitMQ
    /// </summary>
    public class ProjectorService : IProjectorService
    {
        // RabbitMQ broker interface.
        private readonly IMessageBrokerService _messageBrokerService;
        
        // Virtek Vision projector interface,
        private readonly IProjector _projector;
        
        // Current and previous active projection entities in Work Order.
        private string _currentProjectionEntity = "";
        private string _previousProjectionEntity = "";

        public ProjectorService(IMessageBrokerService brokerService, IProjector projector)
        {
            _messageBrokerService = brokerService;
            _projector = projector;
        }
        
        public async Task ConnectAsync()
        {
            // Gets projector clientId.
            string clientId = _projector.ClientId; 
            
            // Connects to the RabbitMQ broker.
            await _messageBrokerService.ConnectAsync(clientId);
            
            // Subscribe to projector RabbitMQ channel.
            await _messageBrokerService.SubscribeAsync(clientId, _projector.IsExpectedMessage);
            
            // Connects to the Projector Client.
            await _projector.ConnectAsync();
        }
        
        public async Task DisconnectAsync()
        {
            await _messageBrokerService.DisconnectAsync();
        }

        public async Task PauseProjectionAsync()
        {
            // Gets projector clientId.
            string clientId = _projector.ClientId; 
            
            // Pause current projection.
            await _projector.PauseProjectionAsync();
        }

        public async Task CheckCurrentProjectionEntityAsync(CancellationToken token)
        {
            // Gets the current name of the active projection entity
            _currentProjectionEntity = await _projector.GetCurrentProjectionEntityAsync();
            
            // Loops while the cancellation token is not activated
            while (!token.IsCancellationRequested)
            {
                // Compares the current and previous projection entity name.
                if (_currentProjectionEntity != _previousProjectionEntity)
                {
                    await OnNextStepEvent(this, EventArgs.Empty);
                    
                    // Sets the _previousProjectionEntity to be equal to _currentProjectionEntity
                    _previousProjectionEntity = _currentProjectionEntity;
                }
            }
            

        }
        
        public event IProjectorService.NextStepEventHandler NextStep;

        /// <summary>
        /// Method to invoke event.
        /// </summary>
        /// <param name="sender">Object passed to event handler.</param>
        /// <param name="e">Event arguments passed to delegate.</param>
        protected virtual async Task OnNextStepEvent(object sender, EventArgs e)
        {
            NextStep?.Invoke(sender, e);
        }
    }
}