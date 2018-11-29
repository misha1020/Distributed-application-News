namespace Client
{
    partial class FormClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMI_Connection = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_Reconnect = new System.Windows.Forms.Button();
            this.btGetNews = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView_servs = new System.Windows.Forms.ListView();
            this.button_refresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(201, 112);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfo.Size = new System.Drawing.Size(398, 214);
            this.tbInfo.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Connection});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMI_Connection
            // 
            this.TSMI_Connection.Enabled = false;
            this.TSMI_Connection.Name = "TSMI_Connection";
            this.TSMI_Connection.Size = new System.Drawing.Size(55, 20);
            this.TSMI_Connection.Text = "Offline";
            // 
            // bt_Reconnect
            // 
            this.bt_Reconnect.Location = new System.Drawing.Point(524, 0);
            this.bt_Reconnect.Name = "bt_Reconnect";
            this.bt_Reconnect.Size = new System.Drawing.Size(75, 23);
            this.bt_Reconnect.TabIndex = 4;
            this.bt_Reconnect.Text = "Reconnect";
            this.bt_Reconnect.UseVisualStyleBackColor = true;
            this.bt_Reconnect.Click += new System.EventHandler(this.bt_Reconnect_Click);
            // 
            // btGetNews
            // 
            this.btGetNews.Location = new System.Drawing.Point(524, 29);
            this.btGetNews.Name = "btGetNews";
            this.btGetNews.Size = new System.Drawing.Size(75, 23);
            this.btGetNews.TabIndex = 5;
            this.btGetNews.Text = "GetNews";
            this.btGetNews.UseVisualStyleBackColor = true;
            this.btGetNews.Click += new System.EventHandler(this.btGetNews_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_refresh);
            this.panel1.Controls.Add(this.listView_servs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 301);
            this.panel1.TabIndex = 6;
            // 
            // listView_servs
            // 
            this.listView_servs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_servs.Location = new System.Drawing.Point(0, 0);
            this.listView_servs.Name = "listView_servs";
            this.listView_servs.Size = new System.Drawing.Size(200, 301);
            this.listView_servs.TabIndex = 0;
            this.listView_servs.UseCompatibleStateImageBehavior = false;
            this.listView_servs.View = System.Windows.Forms.View.List;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(122, 3);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 7;
            this.button_refresh.Text = "refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btGetNews);
            this.Controls.Add(this.bt_Reconnect);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Connection;
        private System.Windows.Forms.Button bt_Reconnect;
        private System.Windows.Forms.Button btGetNews;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView_servs;
        private System.Windows.Forms.Button button_refresh;
    }
}

