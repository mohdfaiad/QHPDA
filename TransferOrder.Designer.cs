namespace QHMobile
{
    partial class TransferOrder
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuPostToNav = new System.Windows.Forms.MenuItem();
            this.tbScanLine = new System.Windows.Forms.TabPage();
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.lblStaffDimension = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFishDescription = new System.Windows.Forms.TextBox();
            this.lblInfoLocation = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToBin = new System.Windows.Forms.TextBox();
            this.txtFromBin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.GrdTO = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbLinePost = new System.Windows.Forms.TabPage();
            this.grdLineToPost = new System.Windows.Forms.DataGrid();
            this.tbScanLine.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tbLinePost.SuspendLayout();
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
            this.mnuGRNBack.Click += new System.EventHandler(this.mnuGRNBack_Click);
            // 
            // mnuItemOpt
            // 
            this.mnuItemOpt.MenuItems.Add(this.menuItem1);
            this.mnuItemOpt.MenuItems.Add(this.menuItem2);
            this.mnuItemOpt.MenuItems.Add(this.menuItem3);
            this.mnuItemOpt.MenuItems.Add(this.mnuPostToNav);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "New";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Register To Nav";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Delete";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // mnuPostToNav
            // 
            this.mnuPostToNav.Text = "Post To Nav";
            this.mnuPostToNav.Click += new System.EventHandler(this.mnuPostToNav_Click);
            // 
            // tbScanLine
            // 
            this.tbScanLine.Controls.Add(this.chkEmpty);
            this.tbScanLine.Controls.Add(this.lblStaffDimension);
            this.tbScanLine.Controls.Add(this.label5);
            this.tbScanLine.Controls.Add(this.label4);
            this.tbScanLine.Controls.Add(this.txtFishDescription);
            this.tbScanLine.Controls.Add(this.lblInfoLocation);
            this.tbScanLine.Controls.Add(this.textBox1);
            this.tbScanLine.Controls.Add(this.label3);
            this.tbScanLine.Controls.Add(this.txtToBin);
            this.tbScanLine.Controls.Add(this.txtFromBin);
            this.tbScanLine.Controls.Add(this.label2);
            this.tbScanLine.Controls.Add(this.label7);
            this.tbScanLine.Controls.Add(this.label8);
            this.tbScanLine.Controls.Add(this.txtItemNo);
            this.tbScanLine.Controls.Add(this.btnAdd);
            this.tbScanLine.Controls.Add(this.GrdTO);
            this.tbScanLine.Controls.Add(this.label1);
            this.tbScanLine.Location = new System.Drawing.Point(0, 0);
            this.tbScanLine.Name = "tbScanLine";
            this.tbScanLine.Size = new System.Drawing.Size(240, 263);
            this.tbScanLine.Text = "Scan Lines";
            // 
            // chkEmpty
            // 
            this.chkEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chkEmpty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkEmpty.ForeColor = System.Drawing.Color.White;
            this.chkEmpty.Location = new System.Drawing.Point(3, 106);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(93, 20);
            this.chkEmpty.TabIndex = 104;
            this.chkEmpty.Text = "Empty Tank";
            // 
            // lblStaffDimension
            // 
            this.lblStaffDimension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblStaffDimension.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStaffDimension.ForeColor = System.Drawing.Color.White;
            this.lblStaffDimension.Location = new System.Drawing.Point(182, 64);
            this.lblStaffDimension.Name = "lblStaffDimension";
            this.lblStaffDimension.Size = new System.Drawing.Size(51, 17);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(114, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.Text = "Staff Dimen:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 17);
            this.label4.Text = "Fish Description";
            // 
            // txtFishDescription
            // 
            this.txtFishDescription.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtFishDescription.Location = new System.Drawing.Point(3, 84);
            this.txtFishDescription.Name = "txtFishDescription";
            this.txtFishDescription.Size = new System.Drawing.Size(234, 20);
            this.txtFishDescription.TabIndex = 92;
            // 
            // lblInfoLocation
            // 
            this.lblInfoLocation.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblInfoLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblInfoLocation.ForeColor = System.Drawing.Color.Black;
            this.lblInfoLocation.Location = new System.Drawing.Point(179, 0);
            this.lblInfoLocation.Name = "lblInfoLocation";
            this.lblInfoLocation.Size = new System.Drawing.Size(61, 17);
            this.lblInfoLocation.Text = "Location";
            this.lblInfoLocation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(41, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 19);
            this.textBox1.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.Text = "Qty";
            // 
            // txtToBin
            // 
            this.txtToBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtToBin.Location = new System.Drawing.Point(166, 42);
            this.txtToBin.Name = "txtToBin";
            this.txtToBin.Size = new System.Drawing.Size(71, 19);
            this.txtToBin.TabIndex = 74;
            this.txtToBin.TextChanged += new System.EventHandler(this.txtToBin_TextChanged);
            // 
            // txtFromBin
            // 
            this.txtFromBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtFromBin.Location = new System.Drawing.Point(41, 20);
            this.txtFromBin.Name = "txtFromBin";
            this.txtFromBin.Size = new System.Drawing.Size(73, 19);
            this.txtFromBin.TabIndex = 53;
            this.txtFromBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFromBin_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(114, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.Text = "To Bin";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(5, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 20);
            this.label7.Text = "Bin";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 17);
            this.label8.Text = "Scan the Bin";
            // 
            // txtItemNo
            // 
            this.txtItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemNo.ForeColor = System.Drawing.Color.Black;
            this.txtItemNo.Location = new System.Drawing.Point(166, 20);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(71, 19);
            this.txtItemNo.TabIndex = 70;
            this.txtItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNo_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(177, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // GrdTO
            // 
            this.GrdTO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdTO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdTO.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdTO.Location = new System.Drawing.Point(0, 128);
            this.GrdTO.Name = "GrdTO";
            this.GrdTO.Size = new System.Drawing.Size(240, 135);
            this.GrdTO.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(112, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.Text = "Item No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbScanLine);
            this.tbMain.Controls.Add(this.tbLinePost);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            // 
            // tbLinePost
            // 
            this.tbLinePost.Controls.Add(this.grdLineToPost);
            this.tbLinePost.Location = new System.Drawing.Point(0, 0);
            this.tbLinePost.Name = "tbLinePost";
            this.tbLinePost.Size = new System.Drawing.Size(232, 260);
            this.tbLinePost.Text = "Lines To Post";
            // 
            // grdLineToPost
            // 
            this.grdLineToPost.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdLineToPost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdLineToPost.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.grdLineToPost.Location = new System.Drawing.Point(0, -3);
            this.grdLineToPost.Name = "grdLineToPost";
            this.grdLineToPost.Size = new System.Drawing.Size(232, 263);
            this.grdLineToPost.TabIndex = 25;
            // 
            // TransferOrder
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
            this.Name = "TransferOrder";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbScanLine.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tbLinePost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.TabPage tbScanLine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGrid GrdTO;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TextBox txtFromBin;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.TextBox txtToBin;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfoLocation;
        private System.Windows.Forms.MenuItem mnuPostToNav;
        private System.Windows.Forms.TabPage tbLinePost;
        private System.Windows.Forms.DataGrid grdLineToPost;
        private System.Windows.Forms.TextBox txtFishDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStaffDimension;
        private System.Windows.Forms.CheckBox chkEmpty;
    }
}