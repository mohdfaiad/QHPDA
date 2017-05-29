namespace RGSMobile
{
    partial class PickingSlip
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
            this.MnuNewGRN = new System.Windows.Forms.MenuItem();
            this.Main = new System.Windows.Forms.TabPage();
            this.cboItemList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBin = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblToAdd = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblaccount = new System.Windows.Forms.Label();
            this.txtTO = new System.Windows.Forms.TextBox();
            this.lbldoref = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgGRNLine = new System.Windows.Forms.DataGrid();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Main.SuspendLayout();
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
            this.mnuGRNBack.Click += new System.EventHandler(this.mnuGRNBack_Click);
            // 
            // mnuItemOpt
            // 
            this.mnuItemOpt.MenuItems.Add(this.menuItem1);
            this.mnuItemOpt.MenuItems.Add(this.MnuNewGRN);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "New";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // MnuNewGRN
            // 
            this.MnuNewGRN.Text = "Received Post";
            this.MnuNewGRN.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.cboItemList);
            this.Main.Controls.Add(this.label6);
            this.Main.Controls.Add(this.label5);
            this.Main.Controls.Add(this.label4);
            this.Main.Controls.Add(this.cboBin);
            this.Main.Controls.Add(this.lblDate);
            this.Main.Controls.Add(this.lblToAdd);
            this.Main.Controls.Add(this.lblAccountNo);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.label1);
            this.Main.Controls.Add(this.lblaccount);
            this.Main.Controls.Add(this.txtTO);
            this.Main.Controls.Add(this.lbldoref);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.dgGRNLine);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Daily Loss";
            // 
            // cboItemList
            // 
            this.cboItemList.Enabled = false;
            this.cboItemList.Location = new System.Drawing.Point(6, 76);
            this.cboItemList.Name = "cboItemList";
            this.cboItemList.Size = new System.Drawing.Size(227, 22);
            this.cboItemList.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.Text = "Item No";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(108, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(140, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            // 
            // cboBin
            // 
            this.cboBin.Enabled = false;
            this.cboBin.Location = new System.Drawing.Point(6, 102);
            this.cboBin.Name = "cboBin";
            this.cboBin.Size = new System.Drawing.Size(78, 22);
            this.cboBin.TabIndex = 79;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblDate.Location = new System.Drawing.Point(23, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(90, 20);
            // 
            // lblToAdd
            // 
            this.lblToAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblToAdd.Location = new System.Drawing.Point(164, 25);
            this.lblToAdd.Name = "lblToAdd";
            this.lblToAdd.Size = new System.Drawing.Size(73, 20);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblAccountNo.Location = new System.Drawing.Point(51, 25);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(50, 20);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.Text = "To";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(107, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.Text = "Sales Man";
            // 
            // lblaccount
            // 
            this.lblaccount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblaccount.Location = new System.Drawing.Point(4, 27);
            this.lblaccount.Name = "lblaccount";
            this.lblaccount.Size = new System.Drawing.Size(50, 19);
            this.lblaccount.Text = "Acct No";
            // 
            // txtTO
            // 
            this.txtTO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtTO.Location = new System.Drawing.Point(63, 2);
            this.txtTO.Name = "txtTO";
            this.txtTO.Size = new System.Drawing.Size(174, 20);
            this.txtTO.TabIndex = 46;
            // 
            // lbldoref
            // 
            this.lbldoref.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lbldoref.Location = new System.Drawing.Point(2, 5);
            this.lbldoref.Name = "lbldoref";
            this.lbldoref.Size = new System.Drawing.Size(67, 20);
            this.lbldoref.Text = "DO Ref No.";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(90, 103);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Pick";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(148, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(205, 108);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(30, 10);
            this.lblCount.Text = "( - )";
            // 
            // dgGRNLine
            // 
            this.dgGRNLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgGRNLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgGRNLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgGRNLine.Location = new System.Drawing.Point(0, 130);
            this.dgGRNLine.Name = "dgGRNLine";
            this.dgGRNLine.Size = new System.Drawing.Size(240, 133);
            this.dgGRNLine.TabIndex = 24;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            // 
            // PickingSlip
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
            this.Name = "PickingSlip";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGRN_Load);
            this.Main.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem MnuNewGRN;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGrid dgGRNLine;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TextBox txtTO;
        private System.Windows.Forms.Label lbldoref;
        private System.Windows.Forms.Label lblaccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblToAdd;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cboBin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboItemList;
    }
}