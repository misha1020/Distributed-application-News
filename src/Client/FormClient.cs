using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form
    {
        public static void QueueRecieve()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "news", type: "fanout");
                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                                      exchange: "news",
                                      routingKey: "");
                    var consumer = new EventingBasicConsumer(channel);

                    String message;
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        message = BinFormatter.FromBytes<string>(body);
                        MessageBox.Show("Ожидание...");
                    };
                    channel.BasicConsume(queue: queueName,
                                    autoAck: true,
                                    consumer: consumer);
                }
            }
        }

        public FormClient()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            QueueRecieve();            
        }
    }
}
