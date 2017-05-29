namespace QHMobile
{
    partial class POAssignV1
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
            this.MnuRegister = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.MnuPost = new System.Windows.Forms.MenuItem();
            this.Main = new System.Windows.Forms.TabPage();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtScanItemNo = new System.Windows.Forms.ComboBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.txtbin = new System.Windows.Forms.TextBox();
            this.txtlocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTO = new System.Windows.Forms.TextBox();
            this.lblTO = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.GrdTO = new System.Windows.Forms.DataGrid();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.SOLines = new System.Windows.Forms.TabPage();
            this.GrdPoLines = new System.Windows.Forms.DataGrid();
            this.tPEdit = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbAssigned = new System.Windows.Forms.TabPage();
            this.GrdAssign = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.Main.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.SOLines.SuspendLayout();
            this.tPEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbAssigned.SuspendLayout();
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
            this.mnuItemOpt.MenuItems.Add(this.MnuRegister);
            this.mnuItemOpt.MenuItems.Add(this.menuItem2);
            this.mnuItemOpt.MenuItems.Add(this.MnuPost);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "New";
            // 
            // MnuRegister
            // 
            this.MnuRegister.Text = "Transfer to NAV";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Delete";
            // 
            // MnuPost
            // 
            this.MnuPost.Enabled = false;
            this.MnuPost.Text = "Post To NAV";
            // 
            // Main
            // 
            this.Main.Controls.Add(this.lblTotalQty);
            this.Main.Controls.Add(this.txtScanItemNo);
            this.Main.Controls.Add(this.txtqty);
            this.Main.Controls.Add(this.txtbin);
            this.Main.Controls.Add(this.txtlocation);
            this.Main.Controls.Add(this.label6);
            this.Main.Controls.Add(this.txtTO);
            this.Main.Controls.Add(this.lblTO);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.GrdTO);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Assign List";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblTotalQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTotalQty.ForeColor = System.Drawing.Color.White;
            this.lblTotalQty.Location = new System.Drawing.Point(6, 74);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(165, 20);
            // 
            // txtScanItemNo
            // 
            this.txtScanItemNo.Location = new System.Drawing.Point(5, 46);
            this.txtScanItemNo.Name = "txtScanItemNo";
            this.txtScanItemNo.Size = new System.Drawing.Size(73, 22);
            this.txtScanItemNo.TabIndex = 111;
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(173, 46);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(60, 21);
            this.txtqty.TabIndex = 108;
            // 
            // txtbin
            // 
            this.txtbin.Location = new System.Drawing.Point(79, 46);
            this.txtbin.Name = "txtbin";
            this.txtbin.Size = new System.Drawing.Size(92, 21);
            this.txtbin.TabIndex = 107;
            // 
            // txtlocation
            // 
            this.txtlocation.Location = new System.Drawing.Point(174, 2);
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.Size = new System.Drawing.Size(63, 21);
            this.txtlocation.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 17);
            this.label6.Text = "Item.No                      Bin                       Qty.";
            // 
            // txtTO
            // 
            this.txtTO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtTO.Location = new System.Drawing.Point(50, 2);
            this.txtTO.Name = "txtTO";
            this.txtTO.Size = new System.Drawing.Size(121, 20);
            this.txtTO.TabIndex = 46;
            // 
            // lblTO
            // 
            this.lblTO.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblTO.Location = new System.Drawing.Point(6, 5);
            this.lblTO.Name = "lblTO";
            this.lblTO.Size = new System.Drawing.Size(67, 20);
            this.lblTO.Text = "PO No.";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(179, 72);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Put";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // GrdTO
            // 
            this.GrdTO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdTO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdTO.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdTO.Location = new System.Drawing.Point(0, 98);
            this.GrdTO.Name = "GrdTO";
            this.GrdTO.Size = new System.Drawing.Size(240, 165);
            this.GrdTO.TabIndex = 24;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Controls.Add(this.SOLines);
            this.tbMain.Controls.Add(this.tPEdit);
            this.tbMain.Controls.Add(this.tbAssigned);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            // 
            // SOLines
            // 
            this.SOLines.Controls.Add(this.GrdPoLines);
            this.SOLines.Location = new System.Drawing.Point(0, 0);
            this.SOLines.Name = "SOLines";
            this.SOLines.Size = new System.Drawing.Size(232, 260);
            this.SOLines.Text = "PO Lines";
            // 
            // GrdPoLines
            // 
            this.GrdPoLines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdPoLines.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdPoLines.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdPoLines.Location = new System.Drawing.Point(0, -3);
            this.GrdPoLines.Name = "GrdPoLines";
            this.GrdPoLines.Size = new System.Drawing.Size(232, 263);
            this.GrdPoLines.TabIndex = 25;
            // 
            // tPEdit
            // 
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
            this.panel1.Controls.Add(this.txtEditLocation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEditItemNo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtEditBinCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEditQty);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 253);
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
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(30, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.Text = "Quantity";
            // 
            // tbAssigned
            // 
            this.tbAssigned.Controls.Add(this.GrdAssign);
            this.tbAssigned.Controls.Add(this.label3);
            this.tbAssigned.Location = new System.Drawing.Point(0, 0);
            this.tbAssigned.Name = "tbAssigned";
            this.tbAssigned.Size = new System.Drawing.Size(232, 260);
            this.tbAssigned.Text = "Assigend";
            // 
            // GrdAssign
            // 
            this.GrdAssign.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdAssign.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdAssign.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdAssign.Location = new System.Drawing.Point(0, 17);
            this.GrdAssign.Name = "GrdAssign";
            this.GrdAssign.Size = new System.Drawing.Size(232, 243);
            this.GrdAssign.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 21);
            this.label3.Text = "Below Items are already assigned.";
            // 
            // POAssignV1
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
            this.Name = "POAssignV1";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Main.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.SOLines.ResumeLayout(false);
            this.tPEdit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tbAssigned.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem MnuRegister;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGrid GrdTO;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TextBox txtTO;
        private System.Windows.Forms.Label lblTO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage SOLines;
        private System.Windows.Forms.DataGrid GrdPoLines;
        private System.Windows.Forms.TextBox txtlocation;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.TextBox txtbin;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ComboBox txtScanItemNo;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.MenuItem MnuPost;
        private System.Windows.Forms.TabPage tPEdit;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbAssigned;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGrid GrdAssign;
    }
}