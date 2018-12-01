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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSubscribe = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.lvServs = new System.Windows.Forms.ListView();
            this.chServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubscribed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbInfo.Location = new System.Drawing.Point(225, 24);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfo.Size = new System.Drawing.Size(379, 303);
            this.tbInfo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSubscribe);
            this.panel1.Controls.Add(this.button_refresh);
            this.panel1.Controls.Add(this.lvServs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 372);
            this.panel1.TabIndex = 6;
            // 
            // btSubscribe
            // 
            this.btSubscribe.Location = new System.Drawing.Point(117, 333);
            this.btSubscribe.Name = "btSubscribe";
            this.btSubscribe.Size = new System.Drawing.Size(99, 36);
            this.btSubscribe.TabIndex = 7;
            this.btSubscribe.Text = "Subscribe";
            this.btSubscribe.UseVisualStyleBackColor = true;
            this.btSubscribe.Click += new System.EventHandler(this.btSubscribe_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(3, 333);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(108, 36);
            this.button_refresh.TabIndex = 7;
            this.button_refresh.Text = "refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // lvServs
            // 
            this.lvServs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chServerName,
            this.chSubscribed});
            this.lvServs.FullRowSelect = true;
            this.lvServs.Location = new System.Drawing.Point(3, 24);
            this.lvServs.MultiSelect = false;
            this.lvServs.Name = "lvServs";
            this.lvServs.Size = new System.Drawing.Size(213, 303);
            this.lvServs.TabIndex = 0;
            this.lvServs.UseCompatibleStateImageBehavior = false;
            this.lvServs.View = System.Windows.Forms.View.Details;
            // 
            // chServerName
            // 
            this.chServerName.Text = "Server name";
            this.chServerName.Width = 81;
            // 
            // chSubscribed
            // 
            this.chSubscribed.Text = "Subscribed";
            this.chSubscribed.Width = 89;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 372);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbInfo);
            this.Name = "FormClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvServs;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button btSubscribe;
        private System.Windows.Forms.ColumnHeader chServerName;
        private System.Windows.Forms.ColumnHeader chSubscribed;
    }
}

