using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form
    {
        RabbitMQClient RMQS;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }

        public void sender(object model, BasicDeliverEventArgs ea)
        {
            string msg;
            var body = ea.Body;
            msg = BinFormatter.FromBytes<string>(body);
            AppendTextBox(msg);
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            tbInfo.Text += value + Environment.NewLine;
        }

        public FormClient()
        {
            InitializeComponent();
            RMQS = new RabbitMQClient("localhost");
            RMQS.consumer.Received += sender;
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            RMQS.Dispose();
        }
    }
}
