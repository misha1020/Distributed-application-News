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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelServers = new System.Windows.Forms.Panel();
            this.btSubscribe = new System.Windows.Forms.Button();
            this.lvServs = new System.Windows.Forms.ListView();
            this.chServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btRefresh = new System.Windows.Forms.Button();
            this.panelNews = new System.Windows.Forms.Panel();
            this.btClear = new System.Windows.Forms.Button();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.cTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNews = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btOff = new System.Windows.Forms.Button();
            this.btHideShow = new System.Windows.Forms.Button();
            this.lbConnecting = new System.Windows.Forms.Label();
            this.panelNewNews = new System.Windows.Forms.Panel();
            this.btAdd = new System.Windows.Forms.Button();
            this.gbTextContent = new System.Windows.Forms.GroupBox();
            this.tbTextContent = new System.Windows.Forms.TextBox();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tcClient = new System.Windows.Forms.TabControl();
            this.tpNews = new System.Windows.Forms.TabPage();
            this.tbRestaurants = new System.Windows.Forms.TabPage();
            this.btOff2 = new System.Windows.Forms.Button();
            this.btLoadNews = new System.Windows.Forms.Button();
            this.btClearRestNews = new System.Windows.Forms.Button();
            this.dgvRestNews = new System.Windows.Forms.DataGridView();
            this.gbRestaurants = new System.Windows.Forms.GroupBox();
            this.cbRestaurants = new System.Windows.Forms.ComboBox();
            this.gbSitsCount = new System.Windows.Forms.GroupBox();
            this.nudSitsCount = new System.Windows.Forms.NumericUpDown();
            this.gbRestaurantAdd = new System.Windows.Forms.GroupBox();
            this.cbRestaurantAdd = new System.Windows.Forms.ComboBox();
            this.cRestaurantTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRestaurantDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelServers.SuspendLayout();
            this.panelNews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panelNewNews.SuspendLayout();
            this.gbTextContent.SuspendLayout();
            this.gbTitle.SuspendLayout();
            this.gbCategory.SuspendLayout();
            this.tcClient.SuspendLayout();
            this.tpNews.SuspendLayout();
            this.tbRestaurants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestNews)).BeginInit();
            this.gbRestaurants.SuspendLayout();
            this.gbSitsCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSitsCount)).BeginInit();
            this.gbRestaurantAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelServers
            // 
            this.panelServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelServers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelServers.Controls.Add(this.btSubscribe);
            this.panelServers.Controls.Add(this.lvServs);
            this.panelServers.Controls.Add(this.btRefresh);
            this.panelServers.Location = new System.Drawing.Point(2, 2);
            this.panelServers.Name = "panelServers";
            this.panelServers.Size = new System.Drawing.Size(235, 386);
            this.panelServers.TabIndex = 6;
            // 
            // btSubscribe
            // 
            this.btSubscribe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btSubscribe.FlatAppearance.BorderSize = 0;
            this.btSubscribe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSubscribe.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSubscribe.ForeColor = System.Drawing.Color.White;
            this.btSubscribe.Location = new System.Drawing.Point(120, 8);
            this.btSubscribe.Name = "btSubscribe";
            this.btSubscribe.Size = new System.Drawing.Size(110, 40);
            this.btSubscribe.TabIndex = 7;
            this.btSubscribe.Text = "Subscribe";
            this.btSubscribe.UseVisualStyleBackColor = false;
            this.btSubscribe.Click += new System.EventHandler(this.btSubscribe_Click);
            // 
            // lvServs
            // 
            this.lvServs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvServs.BackColor = System.Drawing.Color.White;
            this.lvServs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chServerName});
            this.lvServs.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvServs.ForeColor = System.Drawing.Color.Black;
            this.lvServs.FullRowSelect = true;
            this.lvServs.Location = new System.Drawing.Point(3, 54);
            this.lvServs.MultiSelect = false;
            this.lvServs.Name = "lvServs";
            this.lvServs.Size = new System.Drawing.Size(227, 327);
            this.lvServs.TabIndex = 0;
            this.lvServs.UseCompatibleStateImageBehavior = false;
            this.lvServs.View = System.Windows.Forms.View.Details;
            // 
            // chServerName
            // 
            this.chServerName.Text = "               Server Name      ";
            this.chServerName.Width = 211;
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btRefresh.FlatAppearance.BorderSize = 0;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRefresh.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRefresh.ForeColor = System.Drawing.Color.White;
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.Location = new System.Drawing.Point(3, 8);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(110, 40);
            this.btRefresh.TabIndex = 7;
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // panelNews
            // 
            this.panelNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNews.Controls.Add(this.btClear);
            this.panelNews.Controls.Add(this.dgvInfo);
            this.panelNews.Location = new System.Drawing.Point(243, 57);
            this.panelNews.Name = "panelNews";
            this.panelNews.Size = new System.Drawing.Size(541, 331);
            this.panelNews.TabIndex = 16;
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.BackColor = System.Drawing.Color.White;
            this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClear.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.btClear.ForeColor = System.Drawing.Color.Black;
            this.btClear.Location = new System.Drawing.Point(454, 5);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(80, 20);
            this.btClear.TabIndex = 20;
            this.btClear.Text = "Clear News";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTitle,
            this.cNews,
            this.cDate});
            this.dgvInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.Size = new System.Drawing.Size(533, 323);
            this.dgvInfo.TabIndex = 19;
            // 
            // cTitle
            // 
            this.cTitle.HeaderText = "Title";
            this.cTitle.Name = "cTitle";
            this.cTitle.ReadOnly = true;
            // 
            // cNews
            // 
            this.cNews.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cNews.DefaultCellStyle = dataGridViewCellStyle5;
            this.cNews.FillWeight = 5000F;
            this.cNews.HeaderText = "News";
            this.cNews.Name = "cNews";
            this.cNews.ReadOnly = true;
            this.cNews.Width = 59;
            // 
            // cDate
            // 
            this.cDate.HeaderText = "Date";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            // 
            // btOff
            // 
            this.btOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btOff.FlatAppearance.BorderSize = 0;
            this.btOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOff.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOff.ForeColor = System.Drawing.Color.White;
            this.btOff.Image = ((System.Drawing.Image)(resources.GetObject("btOff.Image")));
            this.btOff.Location = new System.Drawing.Point(744, 11);
            this.btOff.Name = "btOff";
            this.btOff.Size = new System.Drawing.Size(40, 40);
            this.btOff.TabIndex = 8;
            this.btOff.UseVisualStyleBackColor = false;
            this.btOff.Click += new System.EventHandler(this.btOff_Click);
            // 
            // btHideShow
            // 
            this.btHideShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btHideShow.FlatAppearance.BorderSize = 0;
            this.btHideShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btHideShow.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btHideShow.ForeColor = System.Drawing.Color.White;
            this.btHideShow.Location = new System.Drawing.Point(243, 11);
            this.btHideShow.Name = "btHideShow";
            this.btHideShow.Size = new System.Drawing.Size(146, 40);
            this.btHideShow.TabIndex = 13;
            this.btHideShow.Text = "Create news";
            this.btHideShow.UseVisualStyleBackColor = false;
            this.btHideShow.Click += new System.EventHandler(this.btHideShow_Click);
            // 
            // lbConnecting
            // 
            this.lbConnecting.AutoSize = true;
            this.lbConnecting.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbConnecting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbConnecting.Location = new System.Drawing.Point(395, 21);
            this.lbConnecting.Name = "lbConnecting";
            this.lbConnecting.Size = new System.Drawing.Size(114, 21);
            this.lbConnecting.TabIndex = 15;
            this.lbConnecting.Text = "Connecting...";
            this.lbConnecting.Visible = false;
            // 
            // panelNewNews
            // 
            this.panelNewNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNewNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewNews.Controls.Add(this.gbRestaurantAdd);
            this.panelNewNews.Controls.Add(this.btAdd);
            this.panelNewNews.Controls.Add(this.gbTextContent);
            this.panelNewNews.Controls.Add(this.gbTitle);
            this.panelNewNews.Controls.Add(this.gbCategory);
            this.panelNewNews.Location = new System.Drawing.Point(242, 57);
            this.panelNewNews.Name = "panelNewNews";
            this.panelNewNews.Size = new System.Drawing.Size(541, 331);
            this.panelNewNews.TabIndex = 19;
            this.panelNewNews.Visible = false;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btAdd.Enabled = false;
            this.btAdd.FlatAppearance.BorderSize = 0;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAdd.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdd.ForeColor = System.Drawing.Color.White;
            this.btAdd.Location = new System.Drawing.Point(394, 16);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(140, 40);
            this.btAdd.TabIndex = 18;
            this.btAdd.Text = "Add news";
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // gbTextContent
            // 
            this.gbTextContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTextContent.Controls.Add(this.tbTextContent);
            this.gbTextContent.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.gbTextContent.ForeColor = System.Drawing.Color.White;
            this.gbTextContent.Location = new System.Drawing.Point(5, 121);
            this.gbTextContent.Name = "gbTextContent";
            this.gbTextContent.Size = new System.Drawing.Size(529, 205);
            this.gbTextContent.TabIndex = 17;
            this.gbTextContent.TabStop = false;
            this.gbTextContent.Text = "Text Content";
            // 
            // tbTextContent
            // 
            this.tbTextContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTextContent.BackColor = System.Drawing.Color.White;
            this.tbTextContent.Location = new System.Drawing.Point(6, 22);
            this.tbTextContent.Multiline = true;
            this.tbTextContent.Name = "tbTextContent";
            this.tbTextContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTextContent.Size = new System.Drawing.Size(517, 177);
            this.tbTextContent.TabIndex = 0;
            this.tbTextContent.TextChanged += new System.EventHandler(this.tbTextContent_TextChanged);
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.tbTitle);
            this.gbTitle.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.gbTitle.ForeColor = System.Drawing.Color.White;
            this.gbTitle.Location = new System.Drawing.Point(5, 62);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(261, 53);
            this.gbTitle.TabIndex = 16;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.White;
            this.tbTitle.Location = new System.Drawing.Point(6, 19);
            this.tbTitle.Multiline = true;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbTitle.Size = new System.Drawing.Size(249, 23);
            this.tbTitle.TabIndex = 0;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.cbCategory);
            this.gbCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.gbCategory.ForeColor = System.Drawing.Color.White;
            this.gbCategory.Location = new System.Drawing.Point(5, 3);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(261, 53);
            this.gbCategory.TabIndex = 15;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.Color.White;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(6, 22);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(249, 25);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.DropDown += new System.EventHandler(this.cbCategory_DropDown);
            this.cbCategory.TextChanged += new System.EventHandler(this.cbCategory_TextChanged);
            // 
            // tcClient
            // 
            this.tcClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcClient.Controls.Add(this.tpNews);
            this.tcClient.Controls.Add(this.tbRestaurants);
            this.tcClient.Location = new System.Drawing.Point(0, 0);
            this.tcClient.Name = "tcClient";
            this.tcClient.SelectedIndex = 0;
            this.tcClient.Size = new System.Drawing.Size(800, 420);
            this.tcClient.TabIndex = 20;
            // 
            // tpNews
            // 
            this.tpNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tpNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpNews.Controls.Add(this.panelServers);
            this.tpNews.Controls.Add(this.panelNewNews);
            this.tpNews.Controls.Add(this.btHideShow);
            this.tpNews.Controls.Add(this.btOff);
            this.tpNews.Controls.Add(this.panelNews);
            this.tpNews.Controls.Add(this.lbConnecting);
            this.tpNews.Location = new System.Drawing.Point(4, 22);
            this.tpNews.Name = "tpNews";
            this.tpNews.Padding = new System.Windows.Forms.Padding(3);
            this.tpNews.Size = new System.Drawing.Size(792, 394);
            this.tpNews.TabIndex = 0;
            this.tpNews.Text = "News";
            // 
            // tbRestaurants
            // 
            this.tbRestaurants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tbRestaurants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRestaurants.Controls.Add(this.btOff2);
            this.tbRestaurants.Controls.Add(this.btLoadNews);
            this.tbRestaurants.Controls.Add(this.btClearRestNews);
            this.tbRestaurants.Controls.Add(this.dgvRestNews);
            this.tbRestaurants.Controls.Add(this.gbRestaurants);
            this.tbRestaurants.Controls.Add(this.gbSitsCount);
            this.tbRestaurants.Location = new System.Drawing.Point(4, 22);
            this.tbRestaurants.Name = "tbRestaurants";
            this.tbRestaurants.Padding = new System.Windows.Forms.Padding(3);
            this.tbRestaurants.Size = new System.Drawing.Size(792, 394);
            this.tbRestaurants.TabIndex = 1;
            this.tbRestaurants.Text = "Restaurants";
            // 
            // btOff2
            // 
            this.btOff2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOff2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btOff2.FlatAppearance.BorderSize = 0;
            this.btOff2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOff2.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOff2.ForeColor = System.Drawing.Color.White;
            this.btOff2.Image = ((System.Drawing.Image)(resources.GetObject("btOff2.Image")));
            this.btOff2.Location = new System.Drawing.Point(744, 11);
            this.btOff2.Name = "btOff2";
            this.btOff2.Size = new System.Drawing.Size(40, 40);
            this.btOff2.TabIndex = 24;
            this.btOff2.UseVisualStyleBackColor = false;
            this.btOff2.Click += new System.EventHandler(this.btOff2_Click);
            // 
            // btLoadNews
            // 
            this.btLoadNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btLoadNews.Enabled = false;
            this.btLoadNews.FlatAppearance.BorderSize = 0;
            this.btLoadNews.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLoadNews.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btLoadNews.ForeColor = System.Drawing.Color.White;
            this.btLoadNews.Location = new System.Drawing.Point(419, 16);
            this.btLoadNews.Name = "btLoadNews";
            this.btLoadNews.Size = new System.Drawing.Size(146, 40);
            this.btLoadNews.TabIndex = 23;
            this.btLoadNews.Text = "Load news";
            this.btLoadNews.UseVisualStyleBackColor = false;
            this.btLoadNews.Click += new System.EventHandler(this.btLoadNews_Click);
            // 
            // btClearRestNews
            // 
            this.btClearRestNews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearRestNews.BackColor = System.Drawing.Color.White;
            this.btClearRestNews.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClearRestNews.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.btClearRestNews.ForeColor = System.Drawing.Color.Black;
            this.btClearRestNews.Location = new System.Drawing.Point(702, 65);
            this.btClearRestNews.Name = "btClearRestNews";
            this.btClearRestNews.Size = new System.Drawing.Size(80, 32);
            this.btClearRestNews.TabIndex = 22;
            this.btClearRestNews.Text = "Clear News";
            this.btClearRestNews.UseVisualStyleBackColor = false;
            this.btClearRestNews.Click += new System.EventHandler(this.btClearRestNews_Click);
            // 
            // dgvRestNews
            // 
            this.dgvRestNews.AllowUserToAddRows = false;
            this.dgvRestNews.AllowUserToDeleteRows = false;
            this.dgvRestNews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRestNews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRestNews.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvRestNews.BackgroundColor = System.Drawing.Color.White;
            this.dgvRestNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRestaurantTitle,
            this.dataGridViewTextBoxColumn1,
            this.cRestaurantDate});
            this.dgvRestNews.Location = new System.Drawing.Point(7, 63);
            this.dgvRestNews.Name = "dgvRestNews";
            this.dgvRestNews.ReadOnly = true;
            this.dgvRestNews.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRestNews.RowHeadersVisible = false;
            this.dgvRestNews.Size = new System.Drawing.Size(777, 323);
            this.dgvRestNews.TabIndex = 21;
            // 
            // gbRestaurants
            // 
            this.gbRestaurants.Controls.Add(this.cbRestaurants);
            this.gbRestaurants.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.gbRestaurants.ForeColor = System.Drawing.Color.White;
            this.gbRestaurants.Location = new System.Drawing.Point(213, 6);
            this.gbRestaurants.Name = "gbRestaurants";
            this.gbRestaurants.Size = new System.Drawing.Size(200, 53);
            this.gbRestaurants.TabIndex = 2;
            this.gbRestaurants.TabStop = false;
            this.gbRestaurants.Text = "Restaurants";
            // 
            // cbRestaurants
            // 
            this.cbRestaurants.BackColor = System.Drawing.Color.White;
            this.cbRestaurants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRestaurants.FormattingEnabled = true;
            this.cbRestaurants.Location = new System.Drawing.Point(6, 22);
            this.cbRestaurants.Name = "cbRestaurants";
            this.cbRestaurants.Size = new System.Drawing.Size(188, 25);
            this.cbRestaurants.TabIndex = 3;
            this.cbRestaurants.DropDown += new System.EventHandler(this.cbRestaurants_DropDown);
            this.cbRestaurants.TextChanged += new System.EventHandler(this.cbRestaurants_TextChanged);
            // 
            // gbSitsCount
            // 
            this.gbSitsCount.Controls.Add(this.nudSitsCount);
            this.gbSitsCount.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.gbSitsCount.ForeColor = System.Drawing.Color.White;
            this.gbSitsCount.Location = new System.Drawing.Point(7, 6);
            this.gbSitsCount.Name = "gbSitsCount";
            this.gbSitsCount.Size = new System.Drawing.Size(200, 53);
            this.gbSitsCount.TabIndex = 1;
            this.gbSitsCount.TabStop = false;
            this.gbSitsCount.Text = "Sits count";
            // 
            // nudSitsCount
            // 
            this.nudSitsCount.BackColor = System.Drawing.Color.White;
            this.nudSitsCount.Location = new System.Drawing.Point(6, 22);
            this.nudSitsCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSitsCount.Name = "nudSitsCount";
            this.nudSitsCount.Size = new System.Drawing.Size(188, 23);
            this.nudSitsCount.TabIndex = 0;
            // 
            // gbRestaurantAdd
            // 
            this.gbRestaurantAdd.Controls.Add(this.cbRestaurantAdd);
            this.gbRestaurantAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.gbRestaurantAdd.ForeColor = System.Drawing.Color.White;
            this.gbRestaurantAdd.Location = new System.Drawing.Point(272, 62);
            this.gbRestaurantAdd.Name = "gbRestaurantAdd";
            this.gbRestaurantAdd.Size = new System.Drawing.Size(262, 53);
            this.gbRestaurantAdd.TabIndex = 19;
            this.gbRestaurantAdd.TabStop = false;
            this.gbRestaurantAdd.Text = "Restaurants";
            // 
            // cbRestaurantAdd
            // 
            this.cbRestaurantAdd.BackColor = System.Drawing.Color.White;
            this.cbRestaurantAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRestaurantAdd.FormattingEnabled = true;
            this.cbRestaurantAdd.Location = new System.Drawing.Point(6, 22);
            this.cbRestaurantAdd.Name = "cbRestaurantAdd";
            this.cbRestaurantAdd.Size = new System.Drawing.Size(250, 25);
            this.cbRestaurantAdd.TabIndex = 3;
            this.cbRestaurantAdd.DropDown += new System.EventHandler(this.cbRestaurantAdd_DropDown);
            // 
            // cRestaurantTitle
            // 
            this.cRestaurantTitle.HeaderText = "Title";
            this.cRestaurantTitle.Name = "cRestaurantTitle";
            this.cRestaurantTitle.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.FillWeight = 5000F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Restaurant news";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 103;
            // 
            // cRestaurantDate
            // 
            this.cRestaurantDate.HeaderText = "Date";
            this.cRestaurantDate.Name = "cRestaurantDate";
            this.cRestaurantDate.ReadOnly = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.tcClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.panelServers.ResumeLayout(false);
            this.panelNews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panelNewNews.ResumeLayout(false);
            this.gbTextContent.ResumeLayout(false);
            this.gbTextContent.PerformLayout();
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.gbCategory.ResumeLayout(false);
            this.tcClient.ResumeLayout(false);
            this.tpNews.ResumeLayout(false);
            this.tpNews.PerformLayout();
            this.tbRestaurants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestNews)).EndInit();
            this.gbRestaurants.ResumeLayout(false);
            this.gbSitsCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSitsCount)).EndInit();
            this.gbRestaurantAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelServers;
        private System.Windows.Forms.ListView lvServs;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btSubscribe;
        private System.Windows.Forms.ColumnHeader chServerName;
        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.Button btHideShow;
        private System.Windows.Forms.Label lbConnecting;
        private System.Windows.Forms.Panel panelNews;
        private System.Windows.Forms.Panel panelNewNews;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.GroupBox gbTextContent;
        private System.Windows.Forms.TextBox tbTextContent;
        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.TabControl tcClient;
        private System.Windows.Forms.TabPage tpNews;
        private System.Windows.Forms.TabPage tbRestaurants;
        private System.Windows.Forms.Button btClearRestNews;
        private System.Windows.Forms.DataGridView dgvRestNews;
        private System.Windows.Forms.GroupBox gbRestaurants;
        private System.Windows.Forms.ComboBox cbRestaurants;
        private System.Windows.Forms.GroupBox gbSitsCount;
        private System.Windows.Forms.NumericUpDown nudSitsCount;
        private System.Windows.Forms.Button btOff2;
        private System.Windows.Forms.Button btLoadNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.GroupBox gbRestaurantAdd;
        private System.Windows.Forms.ComboBox cbRestaurantAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRestaurantTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRestaurantDate;
    }
}

