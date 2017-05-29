namespace QHMobile
{
    partial class CreateTO
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
            this.mnuItmMain = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuNewScan = new System.Windows.Forms.MenuItem();
            this.mnuItmRegtoNav = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnuPost = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuItemOpt = new System.Windows.Forms.MenuItem();
            this.MnuNewGRN = new System.Windows.Forms.MenuItem();
            this.mnuGRNBack = new System.Windows.Forms.MenuItem();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.tapLineToPost = new System.Windows.Forms.TabPage();
            this.lblTOPost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpectDate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboTO = new System.Windows.Forms.ComboBox();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.GrdPost = new System.Windows.Forms.DataGrid();
            this.lblPostStaffRole = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPostStaffName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPostLineCount = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStaffRole = new System.Windows.Forms.TextBox();
            this.lblStaffName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblInfoLocation = new System.Windows.Forms.TextBox();
            this.txtTobin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.txtFromBin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocToCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgTOLine = new System.Windows.Forms.DataGrid();
            this.lblToNo = new System.Windows.Forms.Label();
            this.tapLineToPost.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuItmMain);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // mnuItmMain
            // 
            this.mnuItmMain.Text = "Main";
            this.mnuItmMain.Click += new System.EventHandler(this.mnuItmMain_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuNewScan);
            this.menuItem2.MenuItems.Add(this.mnuItmRegtoNav);
            this.menuItem2.MenuItems.Add(this.menuItem5);
            this.menuItem2.MenuItems.Add(this.mnuPost);
            this.menuItem2.MenuItems.Add(this.menuItem4);
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.Text = "Options";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuNewScan
            // 
            this.menuNewScan.Text = "New Scan";
            this.menuNewScan.Click += new System.EventHandler(this.menuNewScan_Click);
            // 
            // mnuItmRegtoNav
            // 
            this.mnuItmRegtoNav.Enabled = false;
            this.mnuItmRegtoNav.Text = "Register";
            this.mnuItmRegtoNav.Click += new System.EventHandler(this.mnuItmRegtoNav_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Enabled = false;
            this.menuItem5.Text = "Release TO";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // mnuPost
            // 
            this.mnuPost.Enabled = false;
            this.mnuPost.Text = "Create Pick and Post";
            this.mnuPost.Click += new System.EventHandler(this.mnuPost_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Enabled = false;
            this.menuItem4.Text = "Create Put away and Post";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Delete";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Register to NAV";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mnuItemOpt
            // 
            this.mnuItemOpt.MenuItems.Add(this.MnuNewGRN);
            this.mnuItemOpt.MenuItems.Add(this.menuItem1);
            this.mnuItemOpt.Text = "Options";
            this.mnuItemOpt.Click += new System.EventHandler(this.mnuItemOpt_Click);
            // 
            // MnuNewGRN
            // 
            this.MnuNewGRN.Text = "New";
            this.MnuNewGRN.Click += new System.EventHandler(this.MnuNewGRN_Click);
            // 
            // mnuGRNBack
            // 
            this.mnuGRNBack.Text = "Main";
            this.mnuGRNBack.Click += new System.EventHandler(this.mnuGRNBack_Click);
            // 
            // mainMenu2
            // 
            this.mainMenu2.MenuItems.Add(this.mnuGRNBack);
            this.mainMenu2.MenuItems.Add(this.mnuItemOpt);
            // 
            // tapLineToPost
            // 
            this.tapLineToPost.Controls.Add(this.lblTOPost);
            this.tapLineToPost.Controls.Add(this.label5);
            this.tapLineToPost.Controls.Add(this.txtExpectDate);
            this.tapLineToPost.Controls.Add(this.button1);
            this.tapLineToPost.Controls.Add(this.cboTO);
            this.tapLineToPost.Controls.Add(this.cboFrom);
            this.tapLineToPost.Controls.Add(this.label19);
            this.tapLineToPost.Controls.Add(this.label14);
            this.tapLineToPost.Controls.Add(this.label16);
            this.tapLineToPost.Controls.Add(this.GrdPost);
            this.tapLineToPost.Controls.Add(this.lblPostStaffRole);
            this.tapLineToPost.Controls.Add(this.label10);
            this.tapLineToPost.Controls.Add(this.lblPostStaffName);
            this.tapLineToPost.Controls.Add(this.label12);
            this.tapLineToPost.Controls.Add(this.label13);
            this.tapLineToPost.Controls.Add(this.label4);
            this.tapLineToPost.Controls.Add(this.lblPostLineCount);
            this.tapLineToPost.Location = new System.Drawing.Point(0, 0);
            this.tapLineToPost.Name = "tapLineToPost";
            this.tapLineToPost.Size = new System.Drawing.Size(232, 260);
            this.tapLineToPost.Text = "Lines To Post";
            // 
            // lblTOPost
            // 
            this.lblTOPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTOPost.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTOPost.ForeColor = System.Drawing.Color.White;
            this.lblTOPost.Location = new System.Drawing.Point(102, 41);
            this.lblTOPost.Name = "lblTOPost";
            this.lblTOPost.Size = new System.Drawing.Size(75, 20);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(150, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 18);
            this.label5.Text = "Date";
            // 
            // txtExpectDate
            // 
            this.txtExpectDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtExpectDate.Location = new System.Drawing.Point(183, 17);
            this.txtExpectDate.Name = "txtExpectDate";
            this.txtExpectDate.Size = new System.Drawing.Size(54, 19);
            this.txtExpectDate.TabIndex = 57;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(183, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 20);
            this.button1.TabIndex = 56;
            this.button1.Text = "Find TO";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboTO
            // 
            this.cboTO.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboTO.Location = new System.Drawing.Point(102, 17);
            this.cboTO.Name = "cboTO";
            this.cboTO.Size = new System.Drawing.Size(46, 20);
            this.cboTO.TabIndex = 55;
            // 
            // cboFrom
            // 
            this.cboFrom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboFrom.Location = new System.Drawing.Point(33, 17);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(46, 20);
            this.cboFrom.TabIndex = 54;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label19.Location = new System.Drawing.Point(82, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 18);
            this.label19.Text = "TO";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label14.Location = new System.Drawing.Point(5, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 18);
            this.label14.Text = "From";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(2, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(175, 20);
            this.label16.Text = "Transfer Order No.";
            // 
            // GrdPost
            // 
            this.GrdPost.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdPost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdPost.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdPost.Location = new System.Drawing.Point(0, 89);
            this.GrdPost.Name = "GrdPost";
            this.GrdPost.Size = new System.Drawing.Size(232, 171);
            this.GrdPost.TabIndex = 25;
            // 
            // lblPostStaffRole
            // 
            this.lblPostStaffRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblPostStaffRole.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPostStaffRole.ForeColor = System.Drawing.Color.White;
            this.lblPostStaffRole.Location = new System.Drawing.Point(161, 0);
            this.lblPostStaffRole.Name = "lblPostStaffRole";
            this.lblPostStaffRole.Size = new System.Drawing.Size(64, 15);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(132, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 14);
            this.label10.Text = "Role:";
            // 
            // lblPostStaffName
            // 
            this.lblPostStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblPostStaffName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPostStaffName.ForeColor = System.Drawing.Color.White;
            this.lblPostStaffName.Location = new System.Drawing.Point(61, 0);
            this.lblPostStaffName.Name = "lblPostStaffName";
            this.lblPostStaffName.Size = new System.Drawing.Size(66, 15);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.Text = "StaffName:";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, -1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 17);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(157, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 11);
            this.label4.Text = "Line Count : ";
            // 
            // lblPostLineCount
            // 
            this.lblPostLineCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPostLineCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblPostLineCount.Location = new System.Drawing.Point(210, 67);
            this.lblPostLineCount.Name = "lblPostLineCount";
            this.lblPostLineCount.Size = new System.Drawing.Size(26, 10);
            this.lblPostLineCount.Text = "( - )";
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Controls.Add(this.tapLineToPost);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 1;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.chkEmpty);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.label18);
            this.Main.Controls.Add(this.label6);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.label1);
            this.Main.Controls.Add(this.lblStaffRole);
            this.Main.Controls.Add(this.lblStaffName);
            this.Main.Controls.Add(this.label17);
            this.Main.Controls.Add(this.label9);
            this.Main.Controls.Add(this.lblInfoLocation);
            this.Main.Controls.Add(this.txtTobin);
            this.Main.Controls.Add(this.label7);
            this.Main.Controls.Add(this.txtQty);
            this.Main.Controls.Add(this.txtItemNo);
            this.Main.Controls.Add(this.txtFromBin);
            this.Main.Controls.Add(this.label8);
            this.Main.Controls.Add(this.txtLocToCode);
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.dgTOLine);
            this.Main.Controls.Add(this.lblToNo);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "TO";
            this.Main.Click += new System.EventHandler(this.Main_Click);
            // 
            // chkEmpty
            // 
            this.chkEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chkEmpty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkEmpty.ForeColor = System.Drawing.Color.White;
            this.chkEmpty.Location = new System.Drawing.Point(3, 98);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(93, 20);
            this.chkEmpty.TabIndex = 103;
            this.chkEmpty.Text = "Empty Tank";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(175, 100);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 20);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(133, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 14);
            this.label18.Text = "Staff Dimension ";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(2, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 14);
            this.label6.Text = "Item No. and Quantity";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(133, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.Text = "To Bin and Location";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.Text = "From Bin and Location";
            // 
            // lblStaffRole
            // 
            this.lblStaffRole.Enabled = false;
            this.lblStaffRole.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStaffRole.Location = new System.Drawing.Point(180, 65);
            this.lblStaffRole.Name = "lblStaffRole";
            this.lblStaffRole.Size = new System.Drawing.Size(58, 19);
            this.lblStaffRole.TabIndex = 56;
            // 
            // lblStaffName
            // 
            this.lblStaffName.Enabled = false;
            this.lblStaffName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStaffName.Location = new System.Drawing.Point(122, 65);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(57, 19);
            this.lblStaffName.TabIndex = 55;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(0, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(241, 10);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 10);
            // 
            // lblInfoLocation
            // 
            this.lblInfoLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblInfoLocation.Location = new System.Drawing.Point(68, 26);
            this.lblInfoLocation.Name = "lblInfoLocation";
            this.lblInfoLocation.Size = new System.Drawing.Size(54, 19);
            this.lblInfoLocation.TabIndex = 49;
            // 
            // txtTobin
            // 
            this.txtTobin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTobin.Location = new System.Drawing.Point(123, 26);
            this.txtTobin.Name = "txtTobin";
            this.txtTobin.Size = new System.Drawing.Size(58, 19);
            this.txtTobin.TabIndex = 34;
            this.txtTobin.TextChanged += new System.EventHandler(this.txtTobin_TextChanged);
            this.txtTobin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTobin_KeyDown);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 17);
            this.label7.ParentChanged += new System.EventHandler(this.label7_ParentChanged);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(68, 65);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(53, 19);
            this.txtQty.TabIndex = 28;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            // 
            // txtItemNo
            // 
            this.txtItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemNo.Location = new System.Drawing.Point(2, 65);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(65, 19);
            this.txtItemNo.TabIndex = 21;
            this.txtItemNo.TextChanged += new System.EventHandler(this.txtItemNo_TextChanged);
            this.txtItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTOScan_KeyDown);
            // 
            // txtFromBin
            // 
            this.txtFromBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtFromBin.Location = new System.Drawing.Point(2, 26);
            this.txtFromBin.Name = "txtFromBin";
            this.txtFromBin.Size = new System.Drawing.Size(65, 19);
            this.txtFromBin.TabIndex = 31;
            this.txtFromBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFromBin_KeyDown);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 15);
            this.label8.ParentChanged += new System.EventHandler(this.label8_ParentChanged);
            // 
            // txtLocToCode
            // 
            this.txtLocToCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocToCode.Location = new System.Drawing.Point(182, 26);
            this.txtLocToCode.Name = "txtLocToCode";
            this.txtLocToCode.Size = new System.Drawing.Size(56, 19);
            this.txtLocToCode.TabIndex = 45;
            this.txtLocToCode.TextChanged += new System.EventHandler(this.txtLocToCode_TextChanged);
            this.txtLocToCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocToCode_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(102, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            this.label2.ParentChanged += new System.EventHandler(this.label2_ParentChanged);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblCount.Location = new System.Drawing.Point(157, 112);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(22, 10);
            this.lblCount.Text = "( - )";
            this.lblCount.ParentChanged += new System.EventHandler(this.lblCount_ParentChanged);
            // 
            // dgTOLine
            // 
            this.dgTOLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgTOLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgTOLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgTOLine.Location = new System.Drawing.Point(0, 126);
            this.dgTOLine.Name = "dgTOLine";
            this.dgTOLine.Size = new System.Drawing.Size(240, 137);
            this.dgTOLine.TabIndex = 24;
            this.dgTOLine.CurrentCellChanged += new System.EventHandler(this.dgTOLine_CurrentCellChanged);
            // 
            // lblToNo
            // 
            this.lblToNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblToNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblToNo.Location = new System.Drawing.Point(182, 100);
            this.lblToNo.Name = "lblToNo";
            this.lblToNo.Size = new System.Drawing.Size(56, 20);
            this.lblToNo.Text = "Transfer Order No";
            this.lblToNo.Visible = false;
            // 
            // CreateTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tbMain);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "CreateTO";
            this.Text = "frmTR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateTO_KeyDown);
            this.tapLineToPost.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.MenuItem mnuItmMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem MnuNewGRN;
        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuItmRegtoNav;
        private System.Windows.Forms.MenuItem menuNewScan;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuPost;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.TabPage tapLineToPost;
        private System.Windows.Forms.DataGrid GrdPost;
        private System.Windows.Forms.Label lblPostStaffRole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPostStaffName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPostLineCount;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblStaffRole;
        private System.Windows.Forms.TextBox lblStaffName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lblInfoLocation;
        private System.Windows.Forms.TextBox txtTobin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.TextBox txtFromBin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocToCode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblToNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboTO;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtExpectDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTOPost;
        private System.Windows.Forms.CheckBox chkEmpty;
        private System.Windows.Forms.DataGrid dgTOLine;
        private System.Windows.Forms.MenuItem menuItem5;
    }
}