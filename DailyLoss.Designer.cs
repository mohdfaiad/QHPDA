namespace QHMobile
{
    partial class DailyLoss
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
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.Main = new System.Windows.Forms.TabPage();
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.txtPostingDate = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtBinCode = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.GrdDailyLoss = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStaffInfo = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblBinCode = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLineNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStaffCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.txtEditLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEditItemNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEditBinCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEditQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Main.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.mnuItemOpt.MenuItems.Add(this.menuItem3);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem1
            // 
            this.menuItem1.Checked = true;
            this.menuItem1.Text = "Register to Nav";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Delete";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click_1);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.chkEmpty);
            this.Main.Controls.Add(this.lblStaffName);
            this.Main.Controls.Add(this.txtPostingDate);
            this.Main.Controls.Add(this.txtQuantity);
            this.Main.Controls.Add(this.txtBinCode);
            this.Main.Controls.Add(this.txtLocation);
            this.Main.Controls.Add(this.txtItemNo);
            this.Main.Controls.Add(this.GrdDailyLoss);
            this.Main.Controls.Add(this.label5);
            this.Main.Controls.Add(this.lblStaffInfo);
            this.Main.Controls.Add(this.lblLocation);
            this.Main.Controls.Add(this.lblItemNo);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.lblQty);
            this.Main.Controls.Add(this.lblBinCode);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Daily Loss";
            // 
            // chkEmpty
            // 
            this.chkEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chkEmpty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkEmpty.ForeColor = System.Drawing.Color.White;
            this.chkEmpty.Location = new System.Drawing.Point(7, 69);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(95, 20);
            this.chkEmpty.TabIndex = 71;
            this.chkEmpty.Text = "Empty Tank";
            // 
            // lblStaffName
            // 
            this.lblStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblStaffName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStaffName.ForeColor = System.Drawing.Color.White;
            this.lblStaffName.Location = new System.Drawing.Point(64, 1);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(94, 14);
            // 
            // txtPostingDate
            // 
            this.txtPostingDate.Enabled = false;
            this.txtPostingDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPostingDate.Location = new System.Drawing.Point(175, 67);
            this.txtPostingDate.Name = "txtPostingDate";
            this.txtPostingDate.Size = new System.Drawing.Size(62, 19);
            this.txtPostingDate.TabIndex = 62;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQuantity.Location = new System.Drawing.Point(174, 44);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(63, 19);
            this.txtQuantity.TabIndex = 36;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            // 
            // txtBinCode
            // 
            this.txtBinCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBinCode.Location = new System.Drawing.Point(58, 21);
            this.txtBinCode.Name = "txtBinCode";
            this.txtBinCode.Size = new System.Drawing.Size(69, 19);
            this.txtBinCode.TabIndex = 53;
            this.txtBinCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBinCode_KeyDown);
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocation.Location = new System.Drawing.Point(174, 21);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(63, 19);
            this.txtLocation.TabIndex = 49;
            // 
            // txtItemNo
            // 
            this.txtItemNo.Enabled = false;
            this.txtItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemNo.Location = new System.Drawing.Point(58, 44);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(69, 19);
            this.txtItemNo.TabIndex = 46;
            this.txtItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNo_KeyDown);
            // 
            // GrdDailyLoss
            // 
            this.GrdDailyLoss.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdDailyLoss.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdDailyLoss.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdDailyLoss.Location = new System.Drawing.Point(0, 116);
            this.GrdDailyLoss.Name = "GrdDailyLoss";
            this.GrdDailyLoss.Size = new System.Drawing.Size(240, 147);
            this.GrdDailyLoss.TabIndex = 24;
            this.GrdDailyLoss.CurrentCellChanged += new System.EventHandler(this.GrdDailyLoss_CurrentCellChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(108, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.Text = "Posting Date";
            // 
            // lblStaffInfo
            // 
            this.lblStaffInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblStaffInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStaffInfo.ForeColor = System.Drawing.Color.White;
            this.lblStaffInfo.Location = new System.Drawing.Point(0, 0);
            this.lblStaffInfo.Name = "lblStaffInfo";
            this.lblStaffInfo.Size = new System.Drawing.Size(240, 18);
            this.lblStaffInfo.Text = "Staff Name:";
            // 
            // lblLocation
            // 
            this.lblLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblLocation.Location = new System.Drawing.Point(129, 24);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(56, 20);
            this.lblLocation.Text = "Location";
            // 
            // lblItemNo
            // 
            this.lblItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblItemNo.Location = new System.Drawing.Point(6, 44);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.Size = new System.Drawing.Size(56, 20);
            this.lblItemNo.Text = "Item No.";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(195, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblCount.Location = new System.Drawing.Point(60, 101);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(30, 10);
            this.lblCount.Text = "( - )";
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblQty.Location = new System.Drawing.Point(130, 44);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(32, 20);
            this.lblQty.Text = "Qty";
            // 
            // lblBinCode
            // 
            this.lblBinCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblBinCode.Location = new System.Drawing.Point(6, 24);
            this.lblBinCode.Name = "lblBinCode";
            this.lblBinCode.Size = new System.Drawing.Size(67, 20);
            this.lblBinCode.Text = "Bin Code";
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 260);
            this.tabPage1.Text = "Edit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLineNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblStaffCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSaveUpdate);
            this.panel1.Controls.Add(this.txtEditLocation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEditItemNo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtEditBinCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEditQty);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 253);
            // 
            // txtLineNo
            // 
            this.txtLineNo.Location = new System.Drawing.Point(89, 176);
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Size = new System.Drawing.Size(118, 21);
            this.txtLineNo.TabIndex = 169;
            this.txtLineNo.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.Text = "Line";
            this.label3.Visible = false;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblRole.Location = new System.Drawing.Point(162, 18);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(58, 20);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(129, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.Text = "Role:";
            // 
            // lblStaffCode
            // 
            this.lblStaffCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStaffCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblStaffCode.Location = new System.Drawing.Point(73, 18);
            this.lblStaffCode.Name = "lblStaffCode";
            this.lblStaffCode.Size = new System.Drawing.Size(47, 20);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(9, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.Text = "Staff Code:";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnSaveUpdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSaveUpdate.ForeColor = System.Drawing.Color.White;
            this.btnSaveUpdate.Location = new System.Drawing.Point(135, 150);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(72, 20);
            this.btnSaveUpdate.TabIndex = 163;
            this.btnSaveUpdate.Text = "Save";
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // txtEditLocation
            // 
            this.txtEditLocation.Enabled = false;
            this.txtEditLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditLocation.Location = new System.Drawing.Point(89, 70);
            this.txtEditLocation.Name = "txtEditLocation";
            this.txtEditLocation.Size = new System.Drawing.Size(118, 19);
            this.txtEditLocation.TabIndex = 162;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(31, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.Text = "Location";
            // 
            // txtEditItemNo
            // 
            this.txtEditItemNo.Enabled = false;
            this.txtEditItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditItemNo.Location = new System.Drawing.Point(89, 47);
            this.txtEditItemNo.Name = "txtEditItemNo";
            this.txtEditItemNo.Size = new System.Drawing.Size(118, 19);
            this.txtEditItemNo.TabIndex = 160;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(31, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 18);
            this.label10.Text = "Item No";
            // 
            // txtEditBinCode
            // 
            this.txtEditBinCode.Enabled = false;
            this.txtEditBinCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditBinCode.Location = new System.Drawing.Point(89, 117);
            this.txtEditBinCode.Name = "txtEditBinCode";
            this.txtEditBinCode.Size = new System.Drawing.Size(118, 19);
            this.txtEditBinCode.TabIndex = 158;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(31, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.Text = "Bin Code";
            // 
            // txtEditQty
            // 
            this.txtEditQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditQty.Location = new System.Drawing.Point(89, 93);
            this.txtEditQty.Name = "txtEditQty";
            this.txtEditQty.Size = new System.Drawing.Size(118, 19);
            this.txtEditQty.TabIndex = 157;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(30, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.Text = "Quantity";
            // 
            // DailyLoss
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
            this.Name = "DailyLoss";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGRN_Load);
            this.Main.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.TextBox txtPostingDate;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtBinCode;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.DataGrid GrdDailyLoss;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStaffInfo;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblBinCode;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStaffCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.TextBox txtEditLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEditItemNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEditBinCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLineNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEmpty;
    }
}