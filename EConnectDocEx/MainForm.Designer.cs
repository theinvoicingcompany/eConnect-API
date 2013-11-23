namespace EConnectDocEx
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StripStatusLabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectAndRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.tabFilterInvoice = new System.Windows.Forms.TabPage();
            this.tabManualSend = new System.Windows.Forms.TabPage();
            this.comboTemplate = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.tabControlDocuments = new System.Windows.Forms.TabControl();
            this.tabInbox = new System.Windows.Forms.TabPage();
            this.tabOutbox = new System.Windows.Forms.TabPage();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabLogFeed = new System.Windows.Forms.TabPage();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tabPagePayload = new System.Windows.Forms.TabPage();
            this.textBoxPayload = new System.Windows.Forms.TextBox();
            this.tabPageRequest = new System.Windows.Forms.TabPage();
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.tabPageResponse = new System.Windows.Forms.TabPage();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabManualSend.SuspendLayout();
            this.tabControlDocuments.SuspendLayout();
            this.tabInbox.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabLogFeed.SuspendLayout();
            this.tabPagePayload.SuspendLayout();
            this.tabPageRequest.SuspendLayout();
            this.tabPageResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusLabelConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(628, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StripStatusLabelConnection
            // 
            this.StripStatusLabelConnection.Name = "StripStatusLabelConnection";
            this.StripStatusLabelConnection.Size = new System.Drawing.Size(86, 17);
            this.StripStatusLabelConnection.Text = "Not connected";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectAndRefreshToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectAndRefreshToolStripMenuItem
            // 
            this.connectAndRefreshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.connectAndRefreshToolStripMenuItem.Name = "connectAndRefreshToolStripMenuItem";
            this.connectAndRefreshToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.connectAndRefreshToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAll);
            this.tabControl1.Controls.Add(this.tabFilterInvoice);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(616, 333);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAll
            // 
            this.tabAll.Location = new System.Drawing.Point(4, 22);
            this.tabAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabAll.Size = new System.Drawing.Size(608, 307);
            this.tabAll.TabIndex = 1;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // tabFilterInvoice
            // 
            this.tabFilterInvoice.Location = new System.Drawing.Point(4, 22);
            this.tabFilterInvoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabFilterInvoice.Name = "tabFilterInvoice";
            this.tabFilterInvoice.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabFilterInvoice.Size = new System.Drawing.Size(609, 309);
            this.tabFilterInvoice.TabIndex = 0;
            this.tabFilterInvoice.Text = "Invoices";
            this.tabFilterInvoice.UseVisualStyleBackColor = true;
            // 
            // tabManualSend
            // 
            this.tabManualSend.Controls.Add(this.dataGridView1);
            this.tabManualSend.Controls.Add(this.comboTemplate);
            this.tabManualSend.Controls.Add(this.buttonConnect);
            this.tabManualSend.Location = new System.Drawing.Point(4, 22);
            this.tabManualSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabManualSend.Name = "tabManualSend";
            this.tabManualSend.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabManualSend.Size = new System.Drawing.Size(620, 337);
            this.tabManualSend.TabIndex = 3;
            this.tabManualSend.Text = "Manual send";
            this.tabManualSend.UseVisualStyleBackColor = true;
            // 
            // comboTemplate
            // 
            this.comboTemplate.FormattingEnabled = true;
            this.comboTemplate.Items.AddRange(new object[] {
            "Invoice",
            "Order",
            "Booking"});
            this.comboTemplate.Location = new System.Drawing.Point(20, 67);
            this.comboTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboTemplate.Name = "comboTemplate";
            this.comboTemplate.Size = new System.Drawing.Size(156, 21);
            this.comboTemplate.TabIndex = 4;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(14, 24);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(94, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabControlDocuments
            // 
            this.tabControlDocuments.Controls.Add(this.tabManualSend);
            this.tabControlDocuments.Controls.Add(this.tabInbox);
            this.tabControlDocuments.Controls.Add(this.tabOutbox);
            this.tabControlDocuments.Controls.Add(this.tabResults);
            this.tabControlDocuments.Location = new System.Drawing.Point(0, 25);
            this.tabControlDocuments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlDocuments.Name = "tabControlDocuments";
            this.tabControlDocuments.SelectedIndex = 0;
            this.tabControlDocuments.Size = new System.Drawing.Size(628, 363);
            this.tabControlDocuments.TabIndex = 5;
            // 
            // tabInbox
            // 
            this.tabInbox.Controls.Add(this.tabControl1);
            this.tabInbox.Location = new System.Drawing.Point(4, 22);
            this.tabInbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabInbox.Name = "tabInbox";
            this.tabInbox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabInbox.Size = new System.Drawing.Size(620, 337);
            this.tabInbox.TabIndex = 0;
            this.tabInbox.Text = "Inbox";
            this.tabInbox.UseVisualStyleBackColor = true;
            // 
            // tabOutbox
            // 
            this.tabOutbox.Location = new System.Drawing.Point(4, 22);
            this.tabOutbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabOutbox.Name = "tabOutbox";
            this.tabOutbox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabOutbox.Size = new System.Drawing.Size(620, 337);
            this.tabOutbox.TabIndex = 1;
            this.tabOutbox.Text = "Outbox";
            this.tabOutbox.UseVisualStyleBackColor = true;
            // 
            // tabResults
            // 
            this.tabResults.BackColor = System.Drawing.Color.Transparent;
            this.tabResults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabResults.Controls.Add(this.tabControl2);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabResults.Size = new System.Drawing.Size(620, 337);
            this.tabResults.TabIndex = 2;
            this.tabResults.Text = "Debug and logs";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabLogFeed);
            this.tabControl2.Controls.Add(this.tabPagePayload);
            this.tabControl2.Controls.Add(this.tabPageRequest);
            this.tabControl2.Controls.Add(this.tabPageResponse);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(2, 2);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(616, 333);
            this.tabControl2.TabIndex = 2;
            // 
            // tabLogFeed
            // 
            this.tabLogFeed.Controls.Add(this.textBoxLog);
            this.tabLogFeed.Location = new System.Drawing.Point(4, 22);
            this.tabLogFeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabLogFeed.Name = "tabLogFeed";
            this.tabLogFeed.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabLogFeed.Size = new System.Drawing.Size(608, 307);
            this.tabLogFeed.TabIndex = 1;
            this.tabLogFeed.Text = "Log";
            this.tabLogFeed.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(2, 2);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(604, 303);
            this.textBoxLog.TabIndex = 1;
            // 
            // tabPagePayload
            // 
            this.tabPagePayload.Controls.Add(this.textBoxPayload);
            this.tabPagePayload.Location = new System.Drawing.Point(4, 22);
            this.tabPagePayload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPagePayload.Name = "tabPagePayload";
            this.tabPagePayload.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPagePayload.Size = new System.Drawing.Size(609, 309);
            this.tabPagePayload.TabIndex = 0;
            this.tabPagePayload.Text = "Last Payload";
            this.tabPagePayload.UseVisualStyleBackColor = true;
            // 
            // textBoxPayload
            // 
            this.textBoxPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPayload.Location = new System.Drawing.Point(2, 2);
            this.textBoxPayload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPayload.Multiline = true;
            this.textBoxPayload.Name = "textBoxPayload";
            this.textBoxPayload.Size = new System.Drawing.Size(605, 305);
            this.textBoxPayload.TabIndex = 0;
            // 
            // tabPageRequest
            // 
            this.tabPageRequest.Controls.Add(this.textBoxRequest);
            this.tabPageRequest.Location = new System.Drawing.Point(4, 22);
            this.tabPageRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageRequest.Name = "tabPageRequest";
            this.tabPageRequest.Size = new System.Drawing.Size(609, 309);
            this.tabPageRequest.TabIndex = 2;
            this.tabPageRequest.Text = "Last request";
            this.tabPageRequest.UseVisualStyleBackColor = true;
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRequest.Location = new System.Drawing.Point(0, 0);
            this.textBoxRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.Size = new System.Drawing.Size(609, 309);
            this.textBoxRequest.TabIndex = 2;
            // 
            // tabPageResponse
            // 
            this.tabPageResponse.Controls.Add(this.textBoxResponse);
            this.tabPageResponse.Location = new System.Drawing.Point(4, 22);
            this.tabPageResponse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageResponse.Name = "tabPageResponse";
            this.tabPageResponse.Size = new System.Drawing.Size(609, 309);
            this.tabPageResponse.TabIndex = 3;
            this.tabPageResponse.Text = "Last response";
            this.tabPageResponse.UseVisualStyleBackColor = true;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResponse.Location = new System.Drawing.Point(0, 0);
            this.textBoxResponse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.Size = new System.Drawing.Size(609, 309);
            this.textBoxResponse.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 411);
            this.Controls.Add(this.tabControlDocuments);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "eVerbinding document exchange";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabManualSend.ResumeLayout(false);
            this.tabControlDocuments.ResumeLayout(false);
            this.tabInbox.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabLogFeed.ResumeLayout(false);
            this.tabLogFeed.PerformLayout();
            this.tabPagePayload.ResumeLayout(false);
            this.tabPagePayload.PerformLayout();
            this.tabPageRequest.ResumeLayout(false);
            this.tabPageRequest.PerformLayout();
            this.tabPageResponse.ResumeLayout(false);
            this.tabPageResponse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.ToolStripStatusLabel StripStatusLabelConnection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectAndRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.TabPage tabFilterInvoice;
        private System.Windows.Forms.TabPage tabManualSend;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TabControl tabControlDocuments;
        private System.Windows.Forms.TabPage tabInbox;
        private System.Windows.Forms.TabPage tabOutbox;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.ComboBox comboTemplate;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabLogFeed;
        public System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TabPage tabPagePayload;
        public System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.TabPage tabPageRequest;
        public System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.TabPage tabPageResponse;
        public System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

