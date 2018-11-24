using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        public static void QueueRecieve(string host)
        {
            RabbitMQServer RMQS = new RabbitMQServer(host);
            String message;
            RMQS.consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                message = BinFormatter.FromBytes<string>(body);
                MessageBox.Show(message);
            };

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            QueueRecieve("localhost");
        }
    }
}
