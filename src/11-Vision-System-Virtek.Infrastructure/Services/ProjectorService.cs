using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
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
        
        /// <summary>
        /// Connects to a projector using RabbitMQ.
        /// </summary>
        public async Task Connect()
        {
            // Gets projector clientId.
            string clientId = _projector.ClientId; 
            
            // Connects to the RabbitMQ broker.
            await _messageBrokerService.Connect(clientId);
        }

        /// <summary>
        /// Disconnects from projector using RabbitMQ.
        /// </summary>
        public async Task Disconnect()
        {
            await _messageBrokerService.Disconnect();
        }

        public async Task PauseProjection()
        {
            // Gets projector clientId.
            string clientId = _projector.ClientId; 
            
            // Subscribe to projector RabbitMQ channel.
            await _messageBrokerService.Subscribe(clientId, _projector.IsExpectedMessage);
            
            // Pause current projection.
            await _projector.PauseProjection();
        }
    }
}