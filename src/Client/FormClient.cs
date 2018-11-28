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
        static string dispatcherIp = ConfigManager.Get("dispatcherIp");

        public FormClient()
        {
            InitializeComponent();
            TryConnect();
        }

        private bool TryConnect()
        {
            bt_Reconnect.Visible = false;
            try
            {
                TSMI_Connection.Text = "Connecting...";
                MessageToRecieve msg = SocketClient.SocketRecieve(dispatcherIp);
                RMQS = new RabbitMQClient(msg.hostIP, msg.login, msg.password);
                RMQS.consumer.Received += Sender;
                TSMI_Connection.Text = "Online";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in " + ex.TargetSite);
                TSMI_Connection.Text = "Offline";
                bt_Reconnect.Visible = true;
                return false;
            }
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(RMQS!=null) RMQS.Dispose();
        }

        private void bt_Reconnect_Click(object sender, EventArgs e)
        {
            TryConnect();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ActiveControl = null;
        }

        public void Sender(object model, BasicDeliverEventArgs ea)
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
    }
}
