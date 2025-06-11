using _11_Vision_System_Virtek.Domain.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    public class MessageBroker : IMessageBroker
    {
        private IConnection _connection;
        private IChannel _channel;
        private AsyncEventingBasicConsumer _consumer;
        
        public string HostName { get; }
        public string VirtualHost { get; }
        public string Username { get; }
        public string Password { get; }
        public string ExchangeName { get; }
        public string QueueName { get; }

        public MessageBroker(string exchangeName, string queueName)
        {
            HostName     = "127.0.0.1";
            VirtualHost  = "virtek";
            Username     = "virtek";
            Password     = "lQc40E76";
            ExchangeName = exchangeName;
            QueueName    = queueName;
        }

        /// <summary>
        /// Connects to the message broker.
        /// </summary>
        /// <returns>A task representing the asynchronous connection.</returns>
        public async Task Connect(string clientId)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = HostName,
                VirtualHost  = VirtualHost,
                UserName = Username,
                Password = Password,
            };
            
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
            
            // Declaring Direct Exchange

            await _channel.ExchangeDeclareAsync(ExchangeName, "direct", true);
            
            // Declaring Queue
            
            await _channel.QueueDeclareAsync(QueueName, true, false, false);
            
            // Binding Queue to Direct Exchange

            string routingKey = clientId;
            await _channel.QueueBindAsync(QueueName, ExchangeName, routingKey);
        }

        /// <summary>
        /// Disconnects from the message broker.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnection.</returns>
        public async Task Disconnect()
        {
            await _connection.DisposeAsync();
        }

        /// <summary>
        /// Subscribes to messages with the given routing key and processes them with the provided handler.
        /// </summary>
        /// <param name="routingKey">The routing key to subscribe with.</param>
        /// <param name="handler">An async delegate that handles received messages as a byte array.</param>
        /// <returns>A task representing the asynchronous subscription.</returns>
        public async Task Subscribe(string routingKey, Func<byte[], Task> handler)
        {
            throw new NotImplementedException();
        }
    }
}