using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Data;
using System.Windows.Forms;
using System.Timers;
using System.Collections.Generic;
using System.Threading;
using MessageSendServe;
using System.Drawing;

namespace Client
{
    public partial class FormClient : Form
    {
        RabbitMQClient RMQS;
        
        public FormClient()
        {
            InitializeComponent();
            button_refresh_Click(null, null);

            System.Timers.Timer pingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            pingTimer.Elapsed += Ping;
            pingTimer.AutoReset = true;
            pingTimer.Start();
        }

        private void Ping(object sender, ElapsedEventArgs e)
        {
            SocketClient.PingServs(this);
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

        public void AppendColorList(int id, bool ping)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int, bool>(AppendColorList), new object[] { id, ping });
                return;
            }
            lvServs.Items[id].BackColor = (ping) ? Color.Green: Color.Red;
        }

        private MessageSendRecieve[] GetServersList()
        {
            bt_Reconnect.Visible = false;
            try
            {
                TSMI_Connection.Text = "Connecting...";
                MessageSendRecieve[] servers = SocketClient.RecieveServersList();
                Program.msgsWithHosts_Semaphore.WaitOne();
                Program.msgsWithHosts = new List<MessageSendRecieve>(servers);
                Program.msgsWithHosts_Semaphore.Release();
                //tbInfo.Clear();
                for (int i = 0; i < servers.Length; i++)
                    tbInfo.Text += servers[i] + Environment.NewLine;
                TSMI_Connection.Text = "Online";
                return servers;
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
            var servers = GetServersList();
            if (servers == null)
                lvServs.Enabled = false;
            else
            { 
                lvServs.Items.Clear();
                foreach (var serv in servers)
                    lvServs.Items.Add(serv.IP);
            }
        }
    }
}
