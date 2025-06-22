using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Orchestrates projection connectitvity, functioning, and message handling via RabbitMQ
    /// </summary>
    public class ProjectorService : IProjectorService
    {
        // RabbitMQ broker interface.
        private readonly IMessageBrokerService _messageBrokerService;
        
        // Virtek Vision projector interface,
        private readonly IProjector _projector;

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
    }
}