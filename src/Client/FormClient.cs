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
using Client.Properties;
using System.IO;

namespace Client
{
    public partial class FormClient : Form
    {
        List<RabbitMQClient> RMQS = new List<RabbitMQClient>();
        
        public FormClient()
        {
            InitializeComponent();
            lvServs.CheckBoxes = true;

            ImageList imgs = new ImageList();
            foreach (String path in Directory.GetFiles(@"..\..\images"))
                imgs.Images.Add(Image.FromFile(path));
            imgs.ImageSize = new Size(30, 30);
            
            lvServs.StateImageList = imgs;
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

        public void AppendColorList(string guid, bool ping)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, bool>(AppendColorList), new object[] { guid, ping });
                return;
            }

            int index = -1;
            foreach (ListViewItem lItem in lvServs.Items)
            {
                if (lItem.Tag.ToString() == guid)
                    index = lItem.Index;
            }
            if (index != -1)
                lvServs.Items[index].StateImageIndex = (ping) ? 1 : 0;
        }

        private MessageSendRecieve[] GetServersList()
        {
            try
            {
                MessageSendRecieve[] servers = SocketClient.RecieveServersList();
                Program.msgsWithHosts_Semaphore.WaitOne();
                Program.msgsWithHosts = new List<MessageSendRecieve>(servers);
                Program.msgsWithHosts_Semaphore.Release();
                for (int i = 0; i < servers.Length; i++)
                    tbInfo.Text +=  "[" + servers[i].serverName + "]" + Environment.NewLine;
                return servers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in " + ex.TargetSite);
                return null;
            }
        }

        public void Subscribe(List<MessageSendRecieve> subList)
        {

            if (subList.Count != 0)
                foreach (var serv in subList)
                {
                    RMQS.Add(new RabbitMQClient(serv.mqIP, serv.login, serv.password));
                    RMQS[RMQS.Count-1].consumer.Received += sender;
                }
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var rm in RMQS)
                rm.Dispose();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            tbInfo.Clear();
            var servers = GetServersList();
            if (servers == null)
                lvServs.Enabled = false;
            else
            { 
                lvServs.Items.Clear();
                foreach (var serv in servers)
                {
                    lvServs.Items.Add(serv.serverName).SubItems.AddRange(new string[] { "Nope" });
                    ListViewItem lastItem = lvServs.Items[lvServs.Items.Count - 1];
                    lastItem.Tag = serv.guid;
                    lastItem.SubItems[1].Tag = false;
                    lastItem.StateImageIndex = 0;                    
                }
            }
        }

        private void btSubscribe_Click(object sender, EventArgs e)
        {
            Program.msgsWithHosts_Semaphore.WaitOne();
            var servers = new List<MessageSendRecieve>(Program.msgsWithHosts);
            Program.msgsWithHosts_Semaphore.Release();
            //GetServersList();
            List<MessageSendRecieve> subList = new List<MessageSendRecieve>();
            
            foreach (ListViewItem lvItem in lvServs.SelectedItems)
            {
                for (int i = 0; i < servers.Count; i++)
                {
                    if ((bool) lvItem.SubItems[1].Tag == false && lvItem.Tag.ToString() == servers[i].guid )
                    {
                        lvItem.SubItems[1].Tag = true;
                        lvItem.SubItems[1].Text = "Yes";
                        subList.Add(servers[i]);
                    }
                }
            }

            Subscribe(subList);
        }
    }
}
