using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Client
{
    class RabbitMQClient : IDisposable
    {
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        public EventingBasicConsumer consumer { get; }

        public RabbitMQClient(string host)
        {
            factory = new ConnectionFactory()
            {
                UserName = "username",
                Password = "password",
                VirtualHost = "/",
                HostName = host,
                Port = 5672
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "news", type: "fanout");
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName, exchange: "news", routingKey: "");
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}
