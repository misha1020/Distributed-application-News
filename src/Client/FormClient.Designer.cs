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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSubscribe = new System.Windows.Forms.Button();
            this.lvServs = new System.Windows.Forms.ListView();
            this.chServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btRefresh = new System.Windows.Forms.Button();
            this.btOff = new System.Windows.Forms.Button();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.cNews = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.btSubscribe);
            this.panel1.Controls.Add(this.lvServs);
            this.panel1.Controls.Add(this.btRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 401);
            this.panel1.TabIndex = 6;
            // 
            // btSubscribe
            // 
            this.btSubscribe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btSubscribe.FlatAppearance.BorderSize = 0;
            this.btSubscribe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSubscribe.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSubscribe.ForeColor = System.Drawing.Color.White;
            this.btSubscribe.Location = new System.Drawing.Point(121, 12);
            this.btSubscribe.Name = "btSubscribe";
            this.btSubscribe.Size = new System.Drawing.Size(103, 40);
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
            this.lvServs.Location = new System.Drawing.Point(12, 58);
            this.lvServs.MultiSelect = false;
            this.lvServs.Name = "lvServs";
            this.lvServs.Size = new System.Drawing.Size(213, 331);
            this.lvServs.TabIndex = 0;
            this.lvServs.UseCompatibleStateImageBehavior = false;
            this.lvServs.View = System.Windows.Forms.View.Details;
            // 
            // chServerName
            // 
            this.chServerName.Text = "               Server Name      ";
            this.chServerName.Width = 213;
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btRefresh.FlatAppearance.BorderSize = 0;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRefresh.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRefresh.ForeColor = System.Drawing.Color.White;
            this.btRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btRefresh.Image")));
            this.btRefresh.Location = new System.Drawing.Point(12, 12);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(103, 40);
            this.btRefresh.TabIndex = 7;
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // btOff
            // 
            this.btOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btOff.FlatAppearance.BorderSize = 0;
            this.btOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOff.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOff.ForeColor = System.Drawing.Color.White;
            this.btOff.Image = ((System.Drawing.Image)(resources.GetObject("btOff.Image")));
            this.btOff.Location = new System.Drawing.Point(744, 12);
            this.btOff.Name = "btOff";
            this.btOff.Size = new System.Drawing.Size(40, 40);
            this.btOff.TabIndex = 8;
            this.btOff.UseVisualStyleBackColor = false;
            this.btOff.Click += new System.EventHandler(this.btOff_Click);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNews});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInfo.Location = new System.Drawing.Point(243, 58);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.Size = new System.Drawing.Size(541, 331);
            this.dgvInfo.TabIndex = 11;
            // 
            // cNews
            // 
            this.cNews.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNews.FillWeight = 5000F;
            this.cNews.HeaderText = "News";
            this.cNews.Name = "cNews";
            this.cNews.ReadOnly = true;
            this.cNews.Width = 62;
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.BackColor = System.Drawing.Color.White;
            this.btClear.FlatAppearance.BorderSize = 0;
            this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClear.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btClear.ForeColor = System.Drawing.Color.Black;
            this.btClear.Location = new System.Drawing.Point(684, 60);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(100, 23);
            this.btClear.TabIndex = 12;
            this.btClear.Text = "Clear News";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(796, 401);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.dgvInfo);
            this.Controls.Add(this.btOff);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvServs;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btSubscribe;
        private System.Windows.Forms.ColumnHeader chServerName;
        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNews;
        private System.Windows.Forms.Button btClear;
    }
}

