using System.Text;
using _11_Vision_System_Virtek.Domain.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Publishes and subscribes to RabbitMQ messages.
    /// </summary>
    public class MessageBrokerService : IMessageBrokerService
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

        public MessageBrokerService(string exchangeName, string queueName)
        {
            HostName     = "127.0.0.1";
            VirtualHost  = "virtek";
            Username     = "virtek";
            Password     = "lQc40E76";
            ExchangeName = exchangeName;
            QueueName    = queueName;
        }
        
        public async Task ConnectAsync(string clientId)
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
        
        public async Task DisconnectAsync()
        {
            await _connection.DisposeAsync();
            await _channel.DisposeAsync();
        }
        
        public async Task SubscribeAsync(string routingKey, Func<byte[], bool> handler)
        {
            // Declaring consumer.
            
            _consumer = new AsyncEventingBasicConsumer(_channel);
            
            // Pass message to handler.
            
            _consumer.ReceivedAsync += async (model, ea) =>
            {
                try
                {
                    byte[] body = ea.Body.ToArray();
                    string message = Encoding.UTF8.GetString(body);

                    if (handler(body))
                    {
                        Console.WriteLine("[*] Received expected message: " + message);
                        await _channel.BasicAckAsync(ea.DeliveryTag, false);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[!] Error processing message: " + ex.Message);
                    await _channel.BasicNackAsync(ea.DeliveryTag, false, true);
                }
            };

            await _channel.BasicConsumeAsync(QueueName, false, _consumer);
        }
    }
}