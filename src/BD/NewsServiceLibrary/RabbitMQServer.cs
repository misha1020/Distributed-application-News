using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace NewsServiceLibrary
{
    class RabbitMQServer : IDisposable
    {
        private string mqName;
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        public delegate void MessageSendHandler(string message);
        public event MessageSendHandler MessageSend;

        public RabbitMQServer(string hostName, string mqName, string login, string password)
        {
            this.mqName = mqName;
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
            channel.ExchangeDeclare(exchange: this.mqName, type: "fanout");
        }

        public void Send(string message)
        {
            var body = BinFormatter.ToBytes<string>(message);
            channel.BasicPublish(exchange: mqName,
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }

}

