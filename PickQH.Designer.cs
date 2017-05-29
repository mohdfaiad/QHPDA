namespace QHMobile
{
    partial class PickQH
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
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.tPEdit = new System.Windows.Forms.TabPage();
            this.GrdEditPick = new System.Windows.Forms.DataGrid();
            this.btnEditAdd = new System.Windows.Forms.Button();
            this.btnConfirmUpdate = new System.Windows.Forms.Button();
            this.chkEditEmptyTank = new System.Windows.Forms.CheckBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtEditLine = new System.Windows.Forms.TextBox();
            this.txtEditQty = new System.Windows.Forms.TextBox();
            this.txtEditBin = new System.Windows.Forms.TextBox();
            this.txtEditItem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLinePost = new System.Windows.Forms.TabPage();
            this.lblBagCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblpicklinecount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grdLineToPost = new System.Windows.Forms.DataGrid();
            this.tbScanLine = new System.Windows.Forms.TabPage();
            this.lblStaffDimension = new System.Windows.Forms.Label();
            this.txtSubsItem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblBagC = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblLC = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkAutoScan = new System.Windows.Forms.CheckBox();
            this.chkEmptyTank = new System.Windows.Forms.CheckBox();
            this.txtPickedQty = new System.Windows.Forms.TextBox();
            this.txtBin = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.GrdPick = new System.Windows.Forms.DataGrid();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLineInfo = new System.Windows.Forms.Label();
            this.GrdPickedAredy = new System.Windows.Forms.TabControl();
            this.tPEdit.SuspendLayout();
            this.tbLinePost.SuspendLayout();
            this.tbScanLine.SuspendLayout();
            this.GrdPickedAredy.SuspendLayout();
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
            this.mnuItemOpt.MenuItems.Add(this.menuItem2);
            this.mnuItemOpt.MenuItems.Add(this.menuItem3);
            this.mnuItemOpt.MenuItems.Add(this.menuItem4);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "New";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Enabled = false;
            this.menuItem3.Text = "Confirm to Register";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "-";
            // 
            // tPEdit
            // 
            this.tPEdit.Controls.Add(this.GrdEditPick);
            this.tPEdit.Controls.Add(this.btnEditAdd);
            this.tPEdit.Controls.Add(this.btnConfirmUpdate);
            this.tPEdit.Controls.Add(this.chkEditEmptyTank);
            this.tPEdit.Controls.Add(this.lblTotalQty);
            this.tPEdit.Controls.Add(this.txtEditLine);
            this.tPEdit.Controls.Add(this.txtEditQty);
            this.tPEdit.Controls.Add(this.txtEditBin);
            this.tPEdit.Controls.Add(this.txtEditItem);
            this.tPEdit.Controls.Add(this.label10);
            this.tPEdit.Controls.Add(this.label9);
            this.tPEdit.Controls.Add(this.label7);
            this.tPEdit.Controls.Add(this.label6);
            this.tPEdit.Location = new System.Drawing.Point(0, 0);
            this.tPEdit.Name = "tPEdit";
            this.tPEdit.Size = new System.Drawing.Size(232, 260);
            this.tPEdit.Text = "Edit";
            // 
            // GrdEditPick
            // 
            this.GrdEditPick.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdEditPick.Location = new System.Drawing.Point(0, 81);
            this.GrdEditPick.Name = "GrdEditPick";
            this.GrdEditPick.Size = new System.Drawing.Size(240, 182);
            this.GrdEditPick.TabIndex = 135;
            // 
            // btnEditAdd
            // 
            this.btnEditAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnEditAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnEditAdd.ForeColor = System.Drawing.Color.White;
            this.btnEditAdd.Location = new System.Drawing.Point(89, 61);
            this.btnEditAdd.Name = "btnEditAdd";
            this.btnEditAdd.Size = new System.Drawing.Size(92, 20);
            this.btnEditAdd.TabIndex = 129;
            this.btnEditAdd.Text = "Confirm Update";
            this.btnEditAdd.Click += new System.EventHandler(this.btnEditAdd_Click);
            // 
            // btnConfirmUpdate
            // 
            this.btnConfirmUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnConfirmUpdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnConfirmUpdate.ForeColor = System.Drawing.Color.White;
            this.btnConfirmUpdate.Location = new System.Drawing.Point(183, 61);
            this.btnConfirmUpdate.Name = "btnConfirmUpdate";
            this.btnConfirmUpdate.Size = new System.Drawing.Size(57, 20);
            this.btnConfirmUpdate.TabIndex = 115;
            this.btnConfirmUpdate.Text = "Confirm";
            this.btnConfirmUpdate.Click += new System.EventHandler(this.btnConfirmUpdate_Click);
            // 
            // chkEditEmptyTank
            // 
            this.chkEditEmptyTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chkEditEmptyTank.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkEditEmptyTank.ForeColor = System.Drawing.Color.White;
            this.chkEditEmptyTank.Location = new System.Drawing.Point(0, 61);
            this.chkEditEmptyTank.Name = "chkEditEmptyTank";
            this.chkEditEmptyTank.Size = new System.Drawing.Size(240, 20);
            this.chkEditEmptyTank.TabIndex = 123;
            this.chkEditEmptyTank.Text = "Empty Tank";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTotalQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTotalQty.ForeColor = System.Drawing.Color.White;
            this.lblTotalQty.Location = new System.Drawing.Point(204, 26);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(27, 20);
            // 
            // txtEditLine
            // 
            this.txtEditLine.Enabled = false;
            this.txtEditLine.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditLine.Location = new System.Drawing.Point(48, 3);
            this.txtEditLine.Name = "txtEditLine";
            this.txtEditLine.Size = new System.Drawing.Size(56, 19);
            this.txtEditLine.TabIndex = 106;
            // 
            // txtEditQty
            // 
            this.txtEditQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditQty.Location = new System.Drawing.Point(153, 27);
            this.txtEditQty.Name = "txtEditQty";
            this.txtEditQty.Size = new System.Drawing.Size(47, 19);
            this.txtEditQty.TabIndex = 103;
            // 
            // txtEditBin
            // 
            this.txtEditBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditBin.Location = new System.Drawing.Point(48, 26);
            this.txtEditBin.Name = "txtEditBin";
            this.txtEditBin.Size = new System.Drawing.Size(56, 19);
            this.txtEditBin.TabIndex = 100;
            // 
            // txtEditItem
            // 
            this.txtEditItem.Enabled = false;
            this.txtEditItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditItem.Location = new System.Drawing.Point(153, 4);
            this.txtEditItem.Name = "txtEditItem";
            this.txtEditItem.Size = new System.Drawing.Size(79, 19);
            this.txtEditItem.TabIndex = 97;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 18);
            this.label10.Text = "Line No";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(108, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.Text = "Qty";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(4, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.Text = "Bin";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(108, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.Text = "Item";
            // 
            // tbLinePost
            // 
            this.tbLinePost.Controls.Add(this.lblBagCount);
            this.tbLinePost.Controls.Add(this.label11);
            this.tbLinePost.Controls.Add(this.lblpicklinecount);
            this.tbLinePost.Controls.Add(this.label13);
            this.tbLinePost.Controls.Add(this.grdLineToPost);
            this.tbLinePost.Location = new System.Drawing.Point(0, 0);
            this.tbLinePost.Name = "tbLinePost";
            this.tbLinePost.Size = new System.Drawing.Size(240, 263);
            this.tbLinePost.Text = "Picked";
            // 
            // lblBagCount
            // 
            this.lblBagCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblBagCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblBagCount.ForeColor = System.Drawing.Color.White;
            this.lblBagCount.Location = new System.Drawing.Point(94, 0);
            this.lblBagCount.Name = "lblBagCount";
            this.lblBagCount.Size = new System.Drawing.Size(47, 20);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.Text = "No of Bags picked:";
            // 
            // lblpicklinecount
            // 
            this.lblpicklinecount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblpicklinecount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblpicklinecount.ForeColor = System.Drawing.Color.White;
            this.lblpicklinecount.Location = new System.Drawing.Point(196, 0);
            this.lblpicklinecount.Name = "lblpicklinecount";
            this.lblpicklinecount.Size = new System.Drawing.Size(43, 20);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(141, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.Text = "Line Count:";
            // 
            // grdLineToPost
            // 
            this.grdLineToPost.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdLineToPost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdLineToPost.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.grdLineToPost.Location = new System.Drawing.Point(0, 19);
            this.grdLineToPost.Name = "grdLineToPost";
            this.grdLineToPost.Size = new System.Drawing.Size(240, 244);
            this.grdLineToPost.TabIndex = 25;
            // 
            // tbScanLine
            // 
            this.tbScanLine.Controls.Add(this.lblStaffDimension);
            this.tbScanLine.Controls.Add(this.txtSubsItem);
            this.tbScanLine.Controls.Add(this.label12);
            this.tbScanLine.Controls.Add(this.lblBagC);
            this.tbScanLine.Controls.Add(this.label15);
            this.tbScanLine.Controls.Add(this.lblLC);
            this.tbScanLine.Controls.Add(this.label17);
            this.tbScanLine.Controls.Add(this.btnAdd);
            this.tbScanLine.Controls.Add(this.chkAutoScan);
            this.tbScanLine.Controls.Add(this.chkEmptyTank);
            this.tbScanLine.Controls.Add(this.txtPickedQty);
            this.tbScanLine.Controls.Add(this.txtBin);
            this.tbScanLine.Controls.Add(this.txtQty);
            this.tbScanLine.Controls.Add(this.txtItem);
            this.tbScanLine.Controls.Add(this.txtScan);
            this.tbScanLine.Controls.Add(this.GrdPick);
            this.tbScanLine.Controls.Add(this.label14);
            this.tbScanLine.Controls.Add(this.label5);
            this.tbScanLine.Controls.Add(this.label4);
            this.tbScanLine.Controls.Add(this.label2);
            this.tbScanLine.Controls.Add(this.label1);
            this.tbScanLine.Controls.Add(this.label8);
            this.tbScanLine.Controls.Add(this.label3);
            this.tbScanLine.Controls.Add(this.lblLineInfo);
            this.tbScanLine.Location = new System.Drawing.Point(0, 0);
            this.tbScanLine.Name = "tbScanLine";
            this.tbScanLine.Size = new System.Drawing.Size(240, 263);
            this.tbScanLine.Text = "Pick";
            // 
            // lblStaffDimension
            // 
            this.lblStaffDimension.BackColor = System.Drawing.Color.White;
            this.lblStaffDimension.Enabled = false;
            this.lblStaffDimension.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStaffDimension.ForeColor = System.Drawing.Color.Black;
            this.lblStaffDimension.Location = new System.Drawing.Point(178, 3);
            this.lblStaffDimension.Name = "lblStaffDimension";
            this.lblStaffDimension.Size = new System.Drawing.Size(58, 20);
            this.lblStaffDimension.Text = "Staff";
            // 
            // txtSubsItem
            // 
            this.txtSubsItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSubsItem.Location = new System.Drawing.Point(46, 73);
            this.txtSubsItem.Name = "txtSubsItem";
            this.txtSubsItem.Size = new System.Drawing.Size(64, 19);
            this.txtSubsItem.TabIndex = 138;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(2, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 19);
            this.label12.Text = "Sbt Item";
            // 
            // lblBagC
            // 
            this.lblBagC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblBagC.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblBagC.ForeColor = System.Drawing.Color.White;
            this.lblBagC.Location = new System.Drawing.Point(94, 94);
            this.lblBagC.Name = "lblBagC";
            this.lblBagC.Size = new System.Drawing.Size(47, 20);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(1, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 20);
            this.label15.Text = "No of Bags picked:";
            // 
            // lblLC
            // 
            this.lblLC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblLC.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblLC.ForeColor = System.Drawing.Color.White;
            this.lblLC.Location = new System.Drawing.Point(196, 94);
            this.lblLC.Name = "lblLC";
            this.lblLC.Size = new System.Drawing.Size(43, 20);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(141, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 20);
            this.label17.Text = "Line Count:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(179, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 20);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkAutoScan
            // 
            this.chkAutoScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chkAutoScan.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkAutoScan.ForeColor = System.Drawing.Color.White;
            this.chkAutoScan.Location = new System.Drawing.Point(112, 3);
            this.chkAutoScan.Name = "chkAutoScan";
            this.chkAutoScan.Size = new System.Drawing.Size(56, 19);
            this.chkAutoScan.TabIndex = 127;
            this.chkAutoScan.Text = "Auto";
            this.chkAutoScan.CheckStateChanged += new System.EventHandler(this.chkAutoScan_CheckStateChanged);
            // 
            // chkEmptyTank
            // 
            this.chkEmptyTank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chkEmptyTank.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkEmptyTank.ForeColor = System.Drawing.Color.White;
            this.chkEmptyTank.Location = new System.Drawing.Point(112, 73);
            this.chkEmptyTank.Name = "chkEmptyTank";
            this.chkEmptyTank.Size = new System.Drawing.Size(65, 20);
            this.chkEmptyTank.TabIndex = 119;
            this.chkEmptyTank.Text = "Empty";
            // 
            // txtPickedQty
            // 
            this.txtPickedQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPickedQty.Location = new System.Drawing.Point(177, 53);
            this.txtPickedQty.Name = "txtPickedQty";
            this.txtPickedQty.Size = new System.Drawing.Size(60, 19);
            this.txtPickedQty.TabIndex = 117;
            // 
            // txtBin
            // 
            this.txtBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBin.Location = new System.Drawing.Point(177, 32);
            this.txtBin.Name = "txtBin";
            this.txtBin.Size = new System.Drawing.Size(60, 19);
            this.txtBin.TabIndex = 100;
            this.txtBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBin_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(46, 53);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(64, 19);
            this.txtQty.TabIndex = 97;
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItem.Location = new System.Drawing.Point(46, 32);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(64, 19);
            this.txtItem.TabIndex = 95;
            // 
            // txtScan
            // 
            this.txtScan.BackColor = System.Drawing.Color.White;
            this.txtScan.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtScan.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtScan.Location = new System.Drawing.Point(43, 4);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(67, 19);
            this.txtScan.TabIndex = 91;
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // GrdPick
            // 
            this.GrdPick.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdPick.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdPick.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdPick.Location = new System.Drawing.Point(0, 114);
            this.GrdPick.Name = "GrdPick";
            this.GrdPick.Size = new System.Drawing.Size(240, 149);
            this.GrdPick.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label14.Location = new System.Drawing.Point(116, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 18);
            this.label14.Text = "Picked Qty";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(119, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.Text = "Bin Code";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(17, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.Text = "Qty";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.Text = "Item No";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.Text = "Entry";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 28);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(0, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 10);
            // 
            // lblLineInfo
            // 
            this.lblLineInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblLineInfo.Location = new System.Drawing.Point(4, 3);
            this.lblLineInfo.Name = "lblLineInfo";
            this.lblLineInfo.Size = new System.Drawing.Size(27, 19);
            this.lblLineInfo.Visible = false;
            // 
            // GrdPickedAredy
            // 
            this.GrdPickedAredy.Controls.Add(this.tbScanLine);
            this.GrdPickedAredy.Controls.Add(this.tbLinePost);
            this.GrdPickedAredy.Controls.Add(this.tPEdit);
            this.GrdPickedAredy.Location = new System.Drawing.Point(0, 0);
            this.GrdPickedAredy.Name = "GrdPickedAredy";
            this.GrdPickedAredy.SelectedIndex = 0;
            this.GrdPickedAredy.Size = new System.Drawing.Size(240, 286);
            this.GrdPickedAredy.TabIndex = 0;
            this.GrdPickedAredy.SelectedIndexChanged += new System.EventHandler(this.GrdPickedAredy_SelectedIndexChanged);
            // 
            // PickQH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 286);
            this.Controls.Add(this.GrdPickedAredy);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PickQH";
            this.Text = "g";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tPEdit.ResumeLayout(false);
            this.tbLinePost.ResumeLayout(false);
            this.tbScanLine.ResumeLayout(false);
            this.GrdPickedAredy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.TabPage tPEdit;
        private System.Windows.Forms.Button btnConfirmUpdate;
        private System.Windows.Forms.TextBox txtEditLine;
        private System.Windows.Forms.TextBox txtEditQty;
        private System.Windows.Forms.TextBox txtEditBin;
        private System.Windows.Forms.TextBox txtEditItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tbLinePost;
        private System.Windows.Forms.DataGrid grdLineToPost;
        private System.Windows.Forms.TabPage tbScanLine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkAutoScan;
        private System.Windows.Forms.CheckBox chkEmptyTank;
        private System.Windows.Forms.TextBox txtPickedQty;
        private System.Windows.Forms.TextBox txtBin;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.DataGrid GrdPick;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl GrdPickedAredy;
        private System.Windows.Forms.Label lblLineInfo;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.CheckBox chkEditEmptyTank;
        private System.Windows.Forms.Button btnEditAdd;
        private System.Windows.Forms.DataGrid GrdEditPick;
        private System.Windows.Forms.Label lblpicklinecount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblBagCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBagC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblLC;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSubsItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStaffDimension;
    }
}