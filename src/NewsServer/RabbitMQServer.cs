using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace NewsServer
{
    class RabbitMQServer : IDisposable
    {
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        public delegate void MessageSendHandler(string message);
        public event MessageSendHandler MessageSend;

        public RabbitMQServer(string hostName)
        {
            factory = new ConnectionFactory()
            {
                UserName = "username",
                Password = "password",
                VirtualHost = "/",
                HostName = hostName,
                Port = 5672
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "news", type: "fanout");
        }

        public void Send(string message)
        {
            var body = BinFormatter.ToBytes<string>(message);
            channel.BasicPublish(exchange: "news",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
            MessageSend(message);
        }
        
        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
    
}

