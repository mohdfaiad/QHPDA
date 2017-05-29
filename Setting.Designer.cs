namespace QHMobile
{
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuMain = new System.Windows.Forms.MenuItem();
            this.mnuSaveSetting = new System.Windows.Forms.MenuItem();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSvcURL = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtsvcPassword = new System.Windows.Forms.TextBox();
            this.txtSvcUser = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.cboCompanyName = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuMain);
            this.mainMenu1.MenuItems.Add(this.mnuSaveSetting);
            // 
            // mnuMain
            // 
            this.mnuMain.Text = "Cancel";
            this.mnuMain.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuSaveSetting
            // 
            this.mnuSaveSetting.Text = "Save";
            this.mnuSaveSetting.Click += new System.EventHandler(this.mnuSaveSetting_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox4.Location = new System.Drawing.Point(0, 90);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(73, 20);
            this.textBox4.TabIndex = 57;
            this.textBox4.Text = "Service URL";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(0, 71);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(73, 20);
            this.textBox3.TabIndex = 56;
            this.textBox3.Text = "Domain";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(0, 52);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(73, 20);
            this.textBox2.TabIndex = 55;
            this.textBox2.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(0, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 54;
            this.textBox1.Text = "User";
            // 
            // txtSvcURL
            // 
            this.txtSvcURL.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtSvcURL.Location = new System.Drawing.Point(73, 90);
            this.txtSvcURL.Multiline = true;
            this.txtSvcURL.Name = "txtSvcURL";
            this.txtSvcURL.Size = new System.Drawing.Size(167, 20);
            this.txtSvcURL.TabIndex = 51;
            // 
            // txtDomain
            // 
            this.txtDomain.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtDomain.Location = new System.Drawing.Point(73, 71);
            this.txtDomain.Multiline = true;
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(167, 20);
            this.txtDomain.TabIndex = 50;
            // 
            // txtsvcPassword
            // 
            this.txtsvcPassword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtsvcPassword.Location = new System.Drawing.Point(73, 52);
            this.txtsvcPassword.Multiline = true;
            this.txtsvcPassword.Name = "txtsvcPassword";
            this.txtsvcPassword.Size = new System.Drawing.Size(167, 20);
            this.txtsvcPassword.TabIndex = 49;
            // 
            // txtSvcUser
            // 
            this.txtSvcUser.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtSvcUser.Location = new System.Drawing.Point(73, 33);
            this.txtSvcUser.Multiline = true;
            this.txtSvcUser.Name = "txtSvcUser";
            this.txtSvcUser.Size = new System.Drawing.Size(167, 20);
            this.txtSvcUser.TabIndex = 48;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox5.Location = new System.Drawing.Point(0, 109);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(73, 22);
            this.textBox5.TabIndex = 59;
            this.textBox5.Text = "Company";
            // 
            // cboCompanyName
            // 
            this.cboCompanyName.Location = new System.Drawing.Point(73, 111);
            this.cboCompanyName.Name = "cboCompanyName";
            this.cboCompanyName.Size = new System.Drawing.Size(167, 22);
            this.cboCompanyName.TabIndex = 60;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox6.Location = new System.Drawing.Point(3, 7);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(88, 20);
            this.textBox6.TabIndex = 61;
            this.textBox6.Text = "APP SETTING";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox7.Location = new System.Drawing.Point(0, 137);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(73, 20);
            this.textBox7.TabIndex = 63;
            this.textBox7.Text = "Bin";
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox8.Location = new System.Drawing.Point(73, 137);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(167, 20);
            this.textBox8.TabIndex = 62;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.cboCompanyName);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtSvcURL);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.txtsvcPassword);
            this.Controls.Add(this.txtSvcUser);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.Text = "frmSetting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtSvcURL;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtsvcPassword;
        private System.Windows.Forms.TextBox txtSvcUser;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox cboCompanyName;
        private System.Windows.Forms.MenuItem mnuMain;
        private System.Windows.Forms.MenuItem mnuSaveSetting;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}