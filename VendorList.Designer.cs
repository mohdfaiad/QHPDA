namespace QHMobile
{
    partial class VendorList
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
            this.mnuGRNBack = new System.Windows.Forms.MenuItem();
            this.mnuItemOpt = new System.Windows.Forms.MenuItem();
            this.tbVendorList = new System.Windows.Forms.TabPage();
            this.lblVendorNo = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lstVendorList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.butcancel = new System.Windows.Forms.Button();
            this.tbVendorList.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuGRNBack);
            this.mainMenu1.MenuItems.Add(this.mnuItemOpt);
            // 
            // mnuGRNBack
            // 
            this.mnuGRNBack.Text = "Main";
            // 
            // mnuItemOpt
            // 
            this.mnuItemOpt.Text = "Options";
            // 
            // tbVendorList
            // 
            this.tbVendorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbVendorList.Controls.Add(this.butcancel);
            this.tbVendorList.Controls.Add(this.lblVendorNo);
            this.tbVendorList.Controls.Add(this.btnSubmit);
            this.tbVendorList.Controls.Add(this.lstVendorList);
            this.tbVendorList.Controls.Add(this.label2);
            this.tbVendorList.Location = new System.Drawing.Point(0, 0);
            this.tbVendorList.Name = "tbVendorList";
            this.tbVendorList.Size = new System.Drawing.Size(240, 263);
            this.tbVendorList.Text = "Vendor List";
            // 
            // lblVendorNo
            // 
            this.lblVendorNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblVendorNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblVendorNo.ForeColor = System.Drawing.Color.White;
            this.lblVendorNo.Location = new System.Drawing.Point(96, 0);
            this.lblVendorNo.Name = "lblVendorNo";
            this.lblVendorNo.Size = new System.Drawing.Size(144, 18);
            this.lblVendorNo.Text = "Vendor No:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(83, 236);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 20);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Get";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lstVendorList
            // 
            this.lstVendorList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lstVendorList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lstVendorList.Location = new System.Drawing.Point(0, 18);
            this.lstVendorList.Name = "lstVendorList";
            this.lstVendorList.Size = new System.Drawing.Size(240, 212);
            this.lstVendorList.TabIndex = 0;
            this.lstVendorList.SelectedIndexChanged += new System.EventHandler(this.lstVendorList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 18);
            this.label2.Text = "Vendors";
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbVendorList);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            // 
            // butcancel
            // 
            this.butcancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.butcancel.ForeColor = System.Drawing.Color.White;
            this.butcancel.Location = new System.Drawing.Point(161, 236);
            this.butcancel.Name = "butcancel";
            this.butcancel.Size = new System.Drawing.Size(72, 20);
            this.butcancel.TabIndex = 3;
            this.butcancel.Text = "Cancel";
            this.butcancel.Click += new System.EventHandler(this.butcancel_Click);
            // 
            // VendorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 286);
            this.Controls.Add(this.tbMain);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "VendorList";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbVendorList.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.TabPage tbVendorList;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.ListBox lstVendorList;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblVendorNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butcancel;
    }
}