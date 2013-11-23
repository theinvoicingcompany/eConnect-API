namespace EConnectDocEx
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabTokens = new System.Windows.Forms.TabPage();
            this.groupBoxAccount = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBoxTokens = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabDocTemps = new System.Windows.Forms.TabPage();
            this.tabFolers = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabControlSettings.SuspendLayout();
            this.tabTokens.SuspendLayout();
            this.groupBoxAccount.SuspendLayout();
            this.groupBoxTokens.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabTokens);
            this.tabControlSettings.Controls.Add(this.tabDocTemps);
            this.tabControlSettings.Controls.Add(this.tabFolers);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(551, 349);
            this.tabControlSettings.TabIndex = 0;
            // 
            // tabTokens
            // 
            this.tabTokens.Controls.Add(this.groupBoxAccount);
            this.tabTokens.Controls.Add(this.groupBoxTokens);
            this.tabTokens.Location = new System.Drawing.Point(4, 25);
            this.tabTokens.Name = "tabTokens";
            this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
            this.tabTokens.Size = new System.Drawing.Size(543, 320);
            this.tabTokens.TabIndex = 0;
            this.tabTokens.Text = "Account";
            this.tabTokens.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccount
            // 
            this.groupBoxAccount.Controls.Add(this.label4);
            this.groupBoxAccount.Controls.Add(this.textBox4);
            this.groupBoxAccount.Controls.Add(this.label1);
            this.groupBoxAccount.Controls.Add(this.textBox3);
            this.groupBoxAccount.Location = new System.Drawing.Point(19, 22);
            this.groupBoxAccount.Name = "groupBoxAccount";
            this.groupBoxAccount.Size = new System.Drawing.Size(500, 154);
            this.groupBoxAccount.TabIndex = 3;
            this.groupBoxAccount.TabStop = false;
            this.groupBoxAccount.Text = "Contact information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Company ID";
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EConnectDocEx.Properties.Settings.Default, "EntityID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox4.Location = new System.Drawing.Point(172, 65);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(309, 22);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = global::EConnectDocEx.Properties.Settings.Default.EntityID;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contact email ID";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EConnectDocEx.Properties.Settings.Default, "AccountContactID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(172, 27);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(309, 22);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = global::EConnectDocEx.Properties.Settings.Default.AccountContactID;
            // 
            // groupBoxTokens
            // 
            this.groupBoxTokens.Controls.Add(this.label3);
            this.groupBoxTokens.Controls.Add(this.label2);
            this.groupBoxTokens.Controls.Add(this.textBox2);
            this.groupBoxTokens.Controls.Add(this.textBox1);
            this.groupBoxTokens.Location = new System.Drawing.Point(19, 195);
            this.groupBoxTokens.Name = "groupBoxTokens";
            this.groupBoxTokens.Size = new System.Drawing.Size(500, 106);
            this.groupBoxTokens.TabIndex = 2;
            this.groupBoxTokens.TabStop = false;
            this.groupBoxTokens.Text = "Security tokens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Secret token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "App key";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EConnectDocEx.Properties.Settings.Default, "OAUThAppKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(172, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(309, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = global::EConnectDocEx.Properties.Settings.Default.OAUThAppKey;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::EConnectDocEx.Properties.Settings.Default, "OAUThSecret", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(172, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = global::EConnectDocEx.Properties.Settings.Default.OAUThSecret;
            // 
            // tabDocTemps
            // 
            this.tabDocTemps.Location = new System.Drawing.Point(4, 25);
            this.tabDocTemps.Name = "tabDocTemps";
            this.tabDocTemps.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocTemps.Size = new System.Drawing.Size(543, 320);
            this.tabDocTemps.TabIndex = 1;
            this.tabDocTemps.Text = "Document templates";
            this.tabDocTemps.UseVisualStyleBackColor = true;
            // 
            // tabFolers
            // 
            this.tabFolers.Location = new System.Drawing.Point(4, 25);
            this.tabFolers.Name = "tabFolers";
            this.tabFolers.Size = new System.Drawing.Size(543, 320);
            this.tabFolers.TabIndex = 2;
            this.tabFolers.Text = "System folders";
            this.tabFolers.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(443, 355);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(96, 33);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.Location = new System.Drawing.Point(349, 355);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 33);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(551, 400);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.tabControlSettings.ResumeLayout(false);
            this.tabTokens.ResumeLayout(false);
            this.groupBoxAccount.ResumeLayout(false);
            this.groupBoxAccount.PerformLayout();
            this.groupBoxTokens.ResumeLayout(false);
            this.groupBoxTokens.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabTokens;
        private System.Windows.Forms.TabPage tabDocTemps;
        private System.Windows.Forms.TabPage tabFolers;
        private System.Windows.Forms.GroupBox groupBoxAccount;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBoxTokens;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}