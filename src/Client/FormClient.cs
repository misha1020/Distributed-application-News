using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Data;
using System.Windows.Forms;
using System.Timers;
using System.Collections.Generic;
using System.Threading;
using MessageSerdServe;

namespace Client
{
    public partial class FormClient : Form
    {
        RabbitMQClient RMQS;
        
        public FormClient()
        {
            InitializeComponent();
            button_refresh_Click(null, null);

            /*System.Timers.Timer pingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            pingTimer.Elapsed += Ping;
            pingTimer.AutoReset = true;
            pingTimer.Start();*/
        }

        private static void Ping(object sender, ElapsedEventArgs e)
        {
            //SocketClient.PingServs();
        }

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

        private string[] GetServersList()
        {
            bt_Reconnect.Visible = false;
            try
            {
                TSMI_Connection.Text = "Connecting...";
                string[] guids = SocketClient.RecieveServersList();
                //tbInfo.Clear();
                for (int i = 0; i < guids.Length; i++)
                    tbInfo.Text += guids[i] + Environment.NewLine;
                TSMI_Connection.Text = "Online";
                return guids;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in " + ex.TargetSite);
                TSMI_Connection.Text = "Offline";
                bt_Reconnect.Visible = true;
                return null;
            }
        }

        private bool TryToConnect()
        {
            bt_Reconnect.Visible = false;
            try
            {
                TSMI_Connection.Text = "Connecting...";
                MessageSendRecieve msg = SocketClient.SocketRecieve();
                RMQS = new RabbitMQClient(msg.hostIP, msg.login, msg.password);
                RMQS.consumer.Received += sender;
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
            TryToConnect();
        }

        private void btGetNews_Click(object sender, EventArgs e)
        {
            tbInfo.Text += Environment.NewLine;
            TryToConnect();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            var guids = GetServersList();
            if (guids == null)
                listView_servs.Enabled = false;
            else
            { 
            listView_servs.Items.Clear();
            foreach (var guid in guids)
                listView_servs.Items.Add(guid);
            }
        }
    }
}
