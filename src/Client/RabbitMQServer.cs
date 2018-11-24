using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class RabbitMQServer : IDisposable
    {
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        public EventingBasicConsumer consumer { get; }

        public RabbitMQServer(string host)
        {
            factory = new ConnectionFactory() { HostName = host };
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
