
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
        /// Publishes a message to the broker using the specified routing key.
        /// </summary>
        /// <typeparam name="T">The type of the message (will be serialized).</typeparam>
        /// <param name="routingKey">The routing key for message routing.</param>
        /// <param name="message">The message to publish.</param>
        /// <returns>A task representing the asynchronous publish operation.</returns>
        public Task Publish<T>(string routingKey, T message);

        /// <summary>
        /// Subscribes to messages with the given routing key and processes them with the provided handler.
        /// </summary>
        /// <param name="routingKey">The routing key to subscribe with.</param>
        /// <param name="handler">An async delegate that handles received messages as a byte array.</param>
        /// <returns>A task representing the asynchronous subscription.</returns>
        public Task Subscribe(string routingKey, Func<byte[], Task> handler);
    }
}