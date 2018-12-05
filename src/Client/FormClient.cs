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
using Client.ServiceReference1;
using System.Threading.Tasks;

namespace Client
{
    public partial class FormClient : Form
    {
        static string wcfServerIp = ConfigManager.Get("wcfServerIp");
        List<RabbitMQClient> RMQS = new List<RabbitMQClient>();
        RabbitMQClient ourMQ;
        ImageList imgsSub = new ImageList();
        ImageList imgsOnOff = new ImageList();

        public FormClient()
        {
            InitializeComponent();
            InitializeOurMQ();
            dgvInfo.Columns[0].Width = 50;
            dgvRestNews.Columns[0].Width = 50;
            lvServs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LoadImages();
            ReadSavedMQs();
            button_refresh_Click(null, null);
            Ping();
        }

        private void InitializeOurMQ()
        {
            string mqIp = ConfigManager.Get("rabbitMqIp");
            string mqName = ConfigManager.Get("rabbitMqName");
            string mqLog = ConfigManager.Get("rabbitMqNLogin");
            string mqPass = ConfigManager.Get("rabbitMqPassword");
            try
            {
                MessageSendRecieve ourMqMessage = new MessageSendRecieve(null, mqIp, mqName, mqLog, mqPass);
                ourMQ = new RabbitMQClient(ourMqMessage);
                ourMQ.consumer.Received += sender;
            }
            catch (Exception ex)
            {
                MessageBox.Show("rabbitMq doesn't answer");
            }
        }

        private void Ping()
        {
            System.Timers.Timer pingTimer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            pingTimer.Elapsed += Ping;
            pingTimer.AutoReset = true;
            pingTimer.Start();
        }

        private void LoadImages()
        {
            foreach (String path in Directory.GetFiles(@"..\..\images\Connection"))
                imgsOnOff.Images.Add(Image.FromFile(path));
            imgsOnOff.ImageSize = new Size(30, 30);
            lvServs.StateImageList = imgsOnOff;

            foreach (String path in Directory.GetFiles(@"..\..\images\subscribe"))
                imgsSub.Images.Add(Image.FromFile(path));
            imgsSub.ImageSize = new Size(30, 30);
            lvServs.SmallImageList = imgsSub;
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
                    try
                    {
                        RMQS.Add(new RabbitMQClient(data.messageSendRecieve, data.mqName));
                        RMQS[RMQS.Count - 1].consumer.Received += sender;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"RabbitMq at {data.messageSendRecieve.mqIP} doesn't answer");
                    }
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
            Article msg=null;
            var body = ea.Body;
            msg = BinFormatter.FromBytes<Article>(body);
            AppendDataGridView(msg);
        }

        public void AppendDataGridView(Article value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Article>(AppendDataGridView), new object[] { value });
                return;
            }
            dgvInfo.Rows.Add();
            dgvInfo.Rows[dgvInfo.Rows.Count - 1].Cells[0].Value = value.Title;
            dgvInfo.Rows[dgvInfo.Rows.Count - 1].Cells[1].Value = value.Content;
            dgvInfo.Rows[dgvInfo.Rows.Count - 1].Cells[2].Value = value.PublishedAt;
        }

        public void AppendOnOffImg(string mqName, bool ping)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, bool>(AppendOnOffImg), new object[] { mqName, ping });
                return;
            }

            int index = -1;
            foreach (ListViewItem lItem in lvServs.Items)
            {
                if (lItem.Tag.ToString() == mqName)
                    index = lItem.Index;
            }
            if (index != -1)
                lvServs.Items[index].StateImageIndex = (ping) ? 1 : 0;
        }

        private MessageSendRecieve[] GetServersList()
        {
            try
            {
                Program.msgsWithHosts_Semaphore.WaitOne();
                MessageSendRecieve[] servers = SocketClient.RecieveServersList();
                foreach (var serv in servers)
                {
                    if (RMQS.Find(mq => mq.serv.mqName == serv.mqName) == null)
                    {
                        Program.msgsWithHosts.Add(serv);
                    }
                }
                return servers;
            }
            catch (Exception)
            {
                MessageBox.Show("Dispacher connection error");
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
            if (ourMQ != null) ourMQ.Dispose();

        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            var servers = GetServersList();

            if (servers == null)
                lvServs.Enabled = true;
            else
            {
                for (int i = lvServs.Items.Count - 1; i >= 0; i--)
                    if (!(bool)lvServs.Items[i].SubItems[0].Tag)
                        lvServs.Items[i].Remove();

                foreach (var serv in servers)
                {
                    if (RMQS.Find(mq => mq.serv.mqName == serv.mqName) == null)
                        addServInLvServs(serv, false);
                }
            }
        }

        private ListViewItem addServInLvServs(MessageSendRecieve serv, bool subscribed)
        {
            ListViewItem item = new ListViewItem(new string[] { "     " + serv.mqName });
            item.Tag = serv.mqName;
            item.SubItems[0].Tag = subscribed;
            item.StateImageIndex = 0;
            item.ImageIndex = (subscribed) ? 0 : 1;
            lvServs.Items.Add(item);
            return item;
        }

        private void btSubscribe_Click(object sender, EventArgs e)
        {
            Program.msgsWithHosts_Semaphore.WaitOne();
            var servers = new List<MessageSendRecieve>(Program.msgsWithHosts);
            Program.msgsWithHosts_Semaphore.Release();

            if (lvServs.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvServs.SelectedItems[0];
                for (int i = 0; i < servers.Count; i++)
                {
                    if (lvItem.Tag.ToString() == servers[i].mqName)
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

        private static long Benchmark(string endpointConfigurationName)
        {
            INewsService serviceClient = new NewsServiceClient(endpointConfigurationName);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < 2000; i++)
            {
                serviceClient.Test();
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        private void btOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btHideShow_Click(object sender, EventArgs e)
        {
            if (btHideShow.Text == "Create news")
            {
                lbConnecting.Visible = true;
                try
                {
                    var NSC = new NewsServiceClient("BasicHttpBinding_INewsService",
                        $"http://{wcfServerIp}/INewService");
                    NSC.Test();

                    panelNews.Visible = !panelNews.Visible;
                    panelNewNews.Visible = !panelNewNews.Visible;
                    btHideShow.Text = "Watch news";
                }
                catch (Exception)
                {
                    MessageBox.Show("News server is not connected");
                }
                finally
                {
                    lbConnecting.Visible = false;
                }
            }
            else
            {
                btHideShow.Text = "Create news";
                panelNews.Visible = !panelNews.Visible;
                panelNewNews.Visible = !panelNewNews.Visible;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            lbConnecting.Visible = true;
            try
            {
                LibNews addingNews = new LibNews();
                addingNews.Title = tbTitle.Text;
                addingNews.ReleaseDate = DateTime.Now;
                addingNews.TextContent = tbTextContent.Text;
                string restaurantName = cbRestaurantAdd.Text;

                var NSC = new NewsServiceClient("BasicHttpBinding_INewsService",
                    $"http://{wcfServerIp}/INewService");
                NSC.CreateNewWithCatAndRest(addingNews, new string[] { cbCategory.Text }, restaurantName, null);
                cbCategory.Text = "";
                tbTitle.Text = "";
                tbTextContent.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("News server is not connected right now");
            }
            finally
            {
                lbConnecting.Visible = false;
            }
        }

        private void cbCategory_TextChanged(object sender, EventArgs e)
        {
            if (cbCategory.Text != "" && tbTitle.Text != "" && tbTextContent.Text != "")
                btAdd.Enabled = true;
            else
                btAdd.Enabled = false;
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (cbCategory.Text != "" && tbTitle.Text != "" && tbTextContent.Text != "")
                btAdd.Enabled = true;
            else
                btAdd.Enabled = false;
        }

        private void tbTextContent_TextChanged(object sender, EventArgs e)
        {
            if (cbCategory.Text != "" && tbTitle.Text != "" && tbTextContent.Text != "")
                btAdd.Enabled = true;
            else
                btAdd.Enabled = false;
        }

        private void cbCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                var NSC = new NewsServiceClient("BasicHttpBinding_INewsService",
                    $"http://{wcfServerIp}/INewService");
                LibCategory[] allCategories = NSC.SelectAllCategory();
                cbCategory.Items.Clear();
                foreach (var category in allCategories)
                    cbCategory.Items.Add(category.NameCat);
            }
            catch (Exception)
            {
                MessageBox.Show("Server with categories is not connected right now");
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            dgvInfo.Rows.Clear();
        }

        private void btClearRestNews_Click(object sender, EventArgs e)
        {
            dgvRestNews.Rows.Clear();
        }

        private void btOff2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLoadNews_Click(object sender, EventArgs e)
        {
            try
            {
                LibNews[] restaurantNews;
                string restaurantName = cbRestaurants.Text;
                var NSC = new NewsServiceClient("BasicHttpBinding_INewsService",
                    $"http://{wcfServerIp}/INewService");
                
                restaurantNews = NSC.SelectNewsFromRestoran(restaurantName);
                dgvRestNews.Rows.Clear();
                foreach (var news in restaurantNews)
                {
                    dgvRestNews.Rows.Add();
                    dgvRestNews.Rows[dgvRestNews.Rows.Count - 1].Cells[0].Value = news.Title;
                    dgvRestNews.Rows[dgvRestNews.Rows.Count - 1].Cells[1].Value = news.TextContent;
                    dgvRestNews.Rows[dgvRestNews.Rows.Count - 1].Cells[2].Value = news.ReleaseDate;
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server with restaurants is not connected right now");
            }   
        }
        private void cbRestaurantAdd_DropDown(object sender, EventArgs e)
        {
            try
            {
                var NSC = new NewsServiceClient("BasicHttpBinding_INewsService",
                    $"http://{wcfServerIp}/INewService");
                string[] restaurants = NSC.SelectRestorans();
                cbRestaurantAdd.Items.Clear();
                foreach (var restaurant in restaurants)
                    cbRestaurantAdd.Items.Add(restaurant);
            }
            catch (Exception)
            {
                MessageBox.Show("Server with restaurants is not connected right now");
            }
        }

        private void cbRestaurants_DropDown(object sender, EventArgs e)
        {
            try
            {
                var NSC = new NewsServiceClient("BasicHttpBinding_INewsService",
                    $"http://{wcfServerIp}/INewService");
                int sitsCount = Convert.ToInt32(nudSitsCount.Value);
                string[] restaurantsWithSitsCount = NSC.SelectRestWithCount(sitsCount);
                cbRestaurants.Items.Clear();
                foreach (var restaurant in restaurantsWithSitsCount)
                    cbRestaurants.Items.Add(restaurant);
            }
            catch (Exception)
            {
                MessageBox.Show("Server with restaurants is not connected right now");
            }
        }
        
        private void cbRestaurants_TextChanged(object sender, EventArgs e)
        {
            if (cbRestaurants.Text != "")
                btLoadNews.Enabled = true;
            else
                btLoadNews.Enabled = false;
        }
    }
}
