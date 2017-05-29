namespace QHMobile
{
    partial class DailyLPost
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
            this.MnuNewGRN = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabpost = new System.Windows.Forms.TabPage();
            this.btnFind = new System.Windows.Forms.Button();
            this.cboDailyLPost = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblcountforpost = new System.Windows.Forms.Label();
            this.lblSuperRole = new System.Windows.Forms.Label();
            this.GrdPost = new System.Windows.Forms.DataGrid();
            this.tPEdit = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStaffCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStaffCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMain.SuspendLayout();
            this.tabpost.SuspendLayout();
            this.tPEdit.SuspendLayout();
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
            this.mnuItemOpt.MenuItems.Add(this.MnuNewGRN);
            this.mnuItemOpt.MenuItems.Add(this.menuItem1);
            this.mnuItemOpt.MenuItems.Add(this.menuItem2);
            this.mnuItemOpt.Text = "Options";
            // 
            // MnuNewGRN
            // 
            this.MnuNewGRN.Enabled = false;
            this.MnuNewGRN.Text = "Post To NAV";
            this.MnuNewGRN.Click += new System.EventHandler(this.MnuNewGRN_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Daily Loss";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Change Size";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tabpost);
            this.tbMain.Controls.Add(this.tPEdit);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // tabpost
            // 
            this.tabpost.Controls.Add(this.btnFind);
            this.tabpost.Controls.Add(this.cboDailyLPost);
            this.tabpost.Controls.Add(this.label1);
            this.tabpost.Controls.Add(this.label3);
            this.tabpost.Controls.Add(this.lblcountforpost);
            this.tabpost.Controls.Add(this.lblSuperRole);
            this.tabpost.Controls.Add(this.GrdPost);
            this.tabpost.Location = new System.Drawing.Point(0, 0);
            this.tabpost.Name = "tabpost";
            this.tabpost.Size = new System.Drawing.Size(240, 263);
            this.tabpost.Text = "Post";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(183, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(52, 20);
            this.btnFind.TabIndex = 28;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cboDailyLPost
            // 
            this.cboDailyLPost.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboDailyLPost.Location = new System.Drawing.Point(85, 23);
            this.cboDailyLPost.Name = "cboDailyLPost";
            this.cboDailyLPost.Size = new System.Drawing.Size(96, 20);
            this.cboDailyLPost.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(2, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.Text = "Staff Dimension";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(147, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 11);
            this.label3.Text = "Line Count : ";
            // 
            // lblcountforpost
            // 
            this.lblcountforpost.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblcountforpost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblcountforpost.Location = new System.Drawing.Point(204, 47);
            this.lblcountforpost.Name = "lblcountforpost";
            this.lblcountforpost.Size = new System.Drawing.Size(30, 10);
            this.lblcountforpost.Text = "( - )";
            // 
            // lblSuperRole
            // 
            this.lblSuperRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblSuperRole.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSuperRole.ForeColor = System.Drawing.Color.White;
            this.lblSuperRole.Location = new System.Drawing.Point(0, 0);
            this.lblSuperRole.Name = "lblSuperRole";
            this.lblSuperRole.Size = new System.Drawing.Size(240, 18);
            this.lblSuperRole.Text = "Choose the Staff Dimension Code Below.";
            // 
            // GrdPost
            // 
            this.GrdPost.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdPost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdPost.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdPost.Location = new System.Drawing.Point(0, 61);
            this.GrdPost.Name = "GrdPost";
            this.GrdPost.Size = new System.Drawing.Size(240, 202);
            this.GrdPost.TabIndex = 25;
            // 
            // tPEdit
            // 
            this.tPEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.tPEdit.Controls.Add(this.panel1);
            this.tPEdit.Location = new System.Drawing.Point(0, 0);
            this.tPEdit.Name = "tPEdit";
            this.tPEdit.Size = new System.Drawing.Size(232, 260);
            this.tPEdit.Text = "Edit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblStaffCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSaveUpdate);
            this.panel1.Controls.Add(this.txtLocation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLine);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtItemNo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtStaffCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtBin);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 247);
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblRole.Location = new System.Drawing.Point(157, 4);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(58, 20);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(124, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.Text = "Role:";
            // 
            // lblStaffCode
            // 
            this.lblStaffCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStaffCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblStaffCode.Location = new System.Drawing.Point(68, 4);
            this.lblStaffCode.Name = "lblStaffCode";
            this.lblStaffCode.Size = new System.Drawing.Size(47, 20);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.Text = "Staff Code:";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnSaveUpdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSaveUpdate.ForeColor = System.Drawing.Color.White;
            this.btnSaveUpdate.Location = new System.Drawing.Point(130, 184);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(72, 20);
            this.btnSaveUpdate.TabIndex = 146;
            this.btnSaveUpdate.Text = "Save";
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocation.Location = new System.Drawing.Point(84, 87);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(118, 19);
            this.txtLocation.TabIndex = 145;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(26, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.Text = "Location";
            // 
            // txtLine
            // 
            this.txtLine.Enabled = false;
            this.txtLine.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLine.Location = new System.Drawing.Point(84, 40);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(118, 19);
            this.txtLine.TabIndex = 144;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label11.Location = new System.Drawing.Point(26, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 18);
            this.label11.Text = "Line No";
            // 
            // txtItemNo
            // 
            this.txtItemNo.Enabled = false;
            this.txtItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemNo.Location = new System.Drawing.Point(84, 64);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(118, 19);
            this.txtItemNo.TabIndex = 143;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(26, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 18);
            this.label10.Text = "Item No";
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtStaffCode.Location = new System.Drawing.Point(84, 159);
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.Size = new System.Drawing.Size(118, 19);
            this.txtStaffCode.TabIndex = 142;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label9.Location = new System.Drawing.Point(26, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.Text = "Staff Code";
            // 
            // txtBin
            // 
            this.txtBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBin.Location = new System.Drawing.Point(84, 134);
            this.txtBin.Name = "txtBin";
            this.txtBin.Size = new System.Drawing.Size(118, 19);
            this.txtBin.TabIndex = 141;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(26, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.Text = "Bin Code";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(84, 110);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(118, 19);
            this.txtQty.TabIndex = 140;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(25, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.Text = "Quantity";
            // 
            // DailyLPost
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
            this.Name = "DailyLPost";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbMain.ResumeLayout(false);
            this.tabpost.ResumeLayout(false);
            this.tPEdit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem MnuNewGRN;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabpost;
        private System.Windows.Forms.DataGrid GrdPost;
        private System.Windows.Forms.Label lblSuperRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcountforpost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDailyLPost;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TabPage tPEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStaffCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStaffCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
    }
}