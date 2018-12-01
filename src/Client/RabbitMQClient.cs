using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using MessageSendServe;

namespace Client
{
    public class RabbitMQClient : IDisposable
    {
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        public EventingBasicConsumer consumer { get; }
        public MessageSendRecieve serv;
        public string queueName;


        public RabbitMQClient(MessageSendRecieve serv, string queueName = "")
        {
            this.serv = serv;
            factory = new ConnectionFactory()
            {
                UserName = serv.login,
                Password = serv.password,
                VirtualHost = "/",
                HostName = serv.mqIP,
                Port = 5672
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: serv.mqName, type: "fanout");
            this.queueName = (queueName=="")?channel.QueueDeclare(durable: true,exclusive: false, autoDelete: false).QueueName:queueName;
            channel.QueueBind(queue: this.queueName, exchange: serv.mqName, routingKey: "");
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
