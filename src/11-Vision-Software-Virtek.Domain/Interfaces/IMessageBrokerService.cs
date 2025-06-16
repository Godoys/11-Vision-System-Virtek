
namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    public interface IMessageBroker
    {
        string HostName { get; }
        string VirtualHost { get; }
        string Username { get; }
        string Password { get; }
        string ExchangeName { get; }
        string QueueName { get; }

        /// <summary>
        /// Connects to the message broker.
        /// </summary>
        /// <returns>A task representing the asynchronous connection.</returns>
        public Task Connect(string clientId);

        /// <summary>
        /// Disconnects from the message broker.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnection.</returns>
        public Task Disconnect();

        /// <summary>
        /// Subscribes to messages with the given routing key and processes them with the provided handler.
        /// </summary>
        /// <param name="routingKey">The routing key to subscribe with.</param>
        /// <param name="handler">An async delegate that handles received messages as a byte array.</param>
        /// <returns>A task representing the asynchronous subscription.</returns>
        public Task Subscribe(string routingKey, Func<byte[], bool> handler);
    }
}