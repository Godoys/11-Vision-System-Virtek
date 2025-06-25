
namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Publishes and subscribes to messages via a message broker.
    /// </summary>
    public interface IMessageBrokerService
    {
        /// <summary>
        /// Hostname or IP of the message broker.
        /// </summary>
        string HostName { get; }
        
        /// <summary>
        /// Virtual host on the broker. 
        /// </summary>
        string VirtualHost { get; }
        
        /// <summary>
        /// Login username for broker authentication.
        /// </summary>
        string Username { get; }
        
        /// <summary>
        /// Login password for broker authentication.
        /// </summary>
        string Password { get; }
        
        /// <summary>
        /// Name of the exchange to publish/subscribe.
        /// </summary>
        string ExchangeName { get; }
        
        /// <summary>
        /// Name of the queue bound to the exchange.
        /// </summary>
        string QueueName { get; }

        /// <summary>
        /// Connects to the message broker.
        /// </summary>
        /// <param name="clientId">Unique client identifier.</param>
        /// <returns>A task representing the asynchronous connection.</returns>
        public Task ConnectAsync(string clientId);

        /// <summary>
        /// Disconnects and releases broker resources.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnection.</returns>
        public Task DisconnectAsync();

        /// <summary>
        /// Subscribes to messages matching the routing key.
        /// </summary>
        /// <param name="routingKey">Routing key to subscribe with.</param>
        /// <param name="handler">Async delegate invoked for each message. Return true to ack, false to nack.</param>
        /// <returns>A task representing the asynchronous subscription.</returns>
        public Task SubscribeAsync(string routingKey, Func<byte[], bool> handler);
    }
}