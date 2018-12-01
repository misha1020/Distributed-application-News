using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Client
{
    [Serializable]
    public class RabbitMQClient : IDisposable
    {
        public ConnectionFactory factory;
        public IConnection connection;
        public IModel channel;
        public EventingBasicConsumer consumer { get; }
        public string queueName;

        public RabbitMQClient()
        {

        }

        public RabbitMQClient(string hostName, string login, string password, string queueName = "")
        {
            factory = new ConnectionFactory()
            {
                UserName = login,
                Password = password,
                VirtualHost = "/",
                HostName = hostName,
                Port = 5672
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "news", type: "fanout");
            this.queueName = (queueName=="")?channel.QueueDeclare(durable: true,exclusive: false, autoDelete: false).QueueName:queueName;
            channel.QueueBind(queue: this.queueName, exchange: "news", routingKey: "");
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
