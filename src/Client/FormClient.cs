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
        ImageList imgsSub = new ImageList();
        ImageList imgsOnOff = new ImageList();

        public FormClient()
        {
            InitializeComponent();


            foreach (String path in Directory.GetFiles(@"..\..\images\Connection"))
                imgsOnOff.Images.Add(Image.FromFile(path));
            imgsOnOff.ImageSize = new Size(30, 30);
            lvServs.StateImageList = imgsOnOff;

            foreach (String path in Directory.GetFiles(@"..\..\images\subscribe"))
                imgsSub.Images.Add(Image.FromFile(path));
            imgsSub.ImageSize = new Size(30, 30);
            lvServs.SmallImageList = imgsSub;
            lvServs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ReadSavedMQs();
            button_refresh_Click(null, null);

            System.Timers.Timer pingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            pingTimer.Elapsed += Ping;
            pingTimer.AutoReset = true;
            pingTimer.Start();
        }

        private void ReadSavedMQs()
        {
            if (System.IO.File.Exists("data.txt"))
            {
                var saveData = SavingXML.ReadFromXmlFile<List<SaveMq>>("data.txt");
                foreach (var data in saveData)
                {
                    Program.msgsWithHosts_Semaphore.WaitOne();
                    Program.msgsWithHosts.Add(data.messageSendRecieve);
                    Program.msgsWithHosts_Semaphore.Release();
                    var lvItem = addServInLvServs(data.messageSendRecieve, true);
                    RMQS.Add(new RabbitMQClient(data.messageSendRecieve, data.mqName));
                    RMQS[RMQS.Count - 1].consumer.Received += sender;
                }
            }
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
                //Program.msgsWithHosts = new List<MessageSendRecieve>(servers);
                foreach(var serv in servers)
                {
                    if(RMQS.Find(mq => mq.serv.mqName == serv.mqName)==null)
                    {
                        Program.msgsWithHosts.Add(serv);
                    }
                }
                return servers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in " + ex.TargetSite);
                return null;
            }
            finally
            {
                Program.msgsWithHosts_Semaphore.Release();
            }
        }

        public void Subscribe(MessageSendRecieve sub)
        {
            try
            {
                var queueName = "";
                RMQS.Add(new RabbitMQClient(sub));
                RMQS[RMQS.Count - 1].consumer.Received += sender;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in " + ex.TargetSite);
            }
        }

        public void Unsubscribe(MessageSendRecieve Unsub)
        {
            try
            {
                for (int i = RMQS.Count - 1; i >= 0; i--)
                {
                    var mq = RMQS[i];
                    if (mq.serv.mqName == Unsub.mqName)
                    {
                        RMQS.Remove(mq);
                        mq.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in " + ex.TargetSite);
            }
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<SaveMq> mqSaveData = new List<SaveMq>();
            foreach (var mq in RMQS)
                mqSaveData.Add(new SaveMq(mq.serv, mq.queueName));
            SavingXML.WriteToXmlFile("data.txt", mqSaveData);
            foreach (var rm in RMQS)
                rm.Dispose();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {

            //tbInfo.Clear();
            var servers = GetServersList();

            if (servers == null)
                lvServs.Enabled = true;
            else
            { 
                lvServs.Items.Clear();
                foreach (var serv in servers)
                {                   
                    if (RMQS.Find(mq => mq.serv.mqName == serv.mqName) == null)
                        addServInLvServs(serv, false);
                    else
                        addServInLvServs(serv, true);
                }
            }
        }

        private ListViewItem addServInLvServs(MessageSendRecieve serv, bool subscribed)
        {
            ListViewItem item = new ListViewItem(new string[] { "     " + serv.serverName });
                    item.Tag = serv.guid;
                    item.SubItems[0].Tag = subscribed;
                    item.StateImageIndex = 0;
                    item.ImageIndex = (subscribed)? 0 : 1;
                    lvServs.Items.Add(item); 
            return item;
        }

        private void btSubscribe_Click(object sender, EventArgs e)
        {
            Program.msgsWithHosts_Semaphore.WaitOne();
            var servers = new List<MessageSendRecieve>(Program.msgsWithHosts);
            Program.msgsWithHosts_Semaphore.Release();
                        
            if(lvServs.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvServs.SelectedItems[0];
                for (int i = 0; i < servers.Count; i++)
                {
                    if (lvItem.Tag.ToString() == servers[i].guid )
                    {
                        if ((bool)lvItem.SubItems[0].Tag == false)
                        {
                            lvItem.SubItems[0].Tag = true;
                            lvItem.ImageIndex = 0; 
                            Subscribe(servers[i]);
                        }
                        else
                        {
                            lvItem.SubItems[0].Tag = false;
                            lvItem.ImageIndex = 1; 
                            Unsubscribe(servers[i]);
                        }
                    }
                }
            }

        }

    }
}
