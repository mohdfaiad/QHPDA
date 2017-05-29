namespace RGSMobile
{
    partial class PickSlip
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
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cboBin = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblToLoc = new System.Windows.Forms.Label();
            this.lblSaleMan = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblaccount = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.txtTO = new System.Windows.Forms.TextBox();
            this.lblTO = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgGRNLine = new System.Windows.Forms.DataGrid();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.SOLines = new System.Windows.Forms.TabPage();
            this.dgSOLines = new System.Windows.Forms.DataGrid();
            this.Main.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.SOLines.SuspendLayout();
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
            this.MnuNewGRN.Text = "Register to NAV";
            this.MnuNewGRN.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.txtQty);
            this.Main.Controls.Add(this.cboBin);
            this.Main.Controls.Add(this.label6);
            this.Main.Controls.Add(this.label5);
            this.Main.Controls.Add(this.lblDate);
            this.Main.Controls.Add(this.lblToLoc);
            this.Main.Controls.Add(this.lblSaleMan);
            this.Main.Controls.Add(this.lblAccountNo);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.label1);
            this.Main.Controls.Add(this.lblaccount);
            this.Main.Controls.Add(this.cboLine);
            this.Main.Controls.Add(this.txtTO);
            this.Main.Controls.Add(this.lblTO);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.dgGRNLine);
            this.Main.Controls.Add(this.pictureBox1);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Pick List";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(120, 100);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(56, 20);
            this.txtQty.TabIndex = 100;
            // 
            // cboBin
            // 
            this.cboBin.Enabled = false;
            this.cboBin.Location = new System.Drawing.Point(5, 99);
            this.cboBin.Name = "cboBin";
            this.cboBin.Size = new System.Drawing.Size(109, 22);
            this.cboBin.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(3, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 12);
            this.label6.Text = "Select Item No. to pick";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(108, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.Text = "Date";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(140, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(95, 13);
            // 
            // lblToLoc
            // 
            this.lblToLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblToLoc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblToLoc.Location = new System.Drawing.Point(23, 42);
            this.lblToLoc.Name = "lblToLoc";
            this.lblToLoc.Size = new System.Drawing.Size(82, 14);
            // 
            // lblSaleMan
            // 
            this.lblSaleMan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSaleMan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblSaleMan.Location = new System.Drawing.Point(164, 26);
            this.lblSaleMan.Name = "lblSaleMan";
            this.lblSaleMan.Size = new System.Drawing.Size(73, 14);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAccountNo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblAccountNo.Location = new System.Drawing.Point(50, 26);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(50, 13);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.Text = "To";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(107, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.Text = "Sales Man";
            // 
            // lblaccount
            // 
            this.lblaccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblaccount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblaccount.Location = new System.Drawing.Point(4, 26);
            this.lblaccount.Name = "lblaccount";
            this.lblaccount.Size = new System.Drawing.Size(44, 12);
            this.lblaccount.Text = "Acct No";
            // 
            // cboLine
            // 
            this.cboLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.cboLine.Location = new System.Drawing.Point(5, 76);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(228, 20);
            this.cboLine.TabIndex = 59;
            // 
            // txtTO
            // 
            this.txtTO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtTO.Location = new System.Drawing.Point(70, 2);
            this.txtTO.Name = "txtTO";
            this.txtTO.Size = new System.Drawing.Size(163, 20);
            this.txtTO.TabIndex = 46;
            this.txtTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTO_KeyDown);
            // 
            // lblTO
            // 
            this.lblTO.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblTO.Location = new System.Drawing.Point(6, 5);
            this.lblTO.Name = "lblTO";
            this.lblTO.Size = new System.Drawing.Size(67, 20);
            this.lblTO.Text = "DO Ref No.";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(182, 100);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Pick";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgGRNLine
            // 
            this.dgGRNLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgGRNLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgGRNLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgGRNLine.Location = new System.Drawing.Point(0, 124);
            this.dgGRNLine.Name = "dgGRNLine";
            this.dgGRNLine.Size = new System.Drawing.Size(240, 139);
            this.dgGRNLine.TabIndex = 24;
            this.dgGRNLine.CurrentCellChanged += new System.EventHandler(this.dgGRNLine_CurrentCellChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 35);
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Controls.Add(this.SOLines);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            // 
            // SOLines
            // 
            this.SOLines.Controls.Add(this.dgSOLines);
            this.SOLines.Location = new System.Drawing.Point(0, 0);
            this.SOLines.Name = "SOLines";
            this.SOLines.Size = new System.Drawing.Size(240, 263);
            this.SOLines.Text = "SO Lines";
            // 
            // dgSOLines
            // 
            this.dgSOLines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgSOLines.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgSOLines.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgSOLines.Location = new System.Drawing.Point(0, 0);
            this.dgSOLines.Name = "dgSOLines";
            this.dgSOLines.Size = new System.Drawing.Size(240, 263);
            this.dgSOLines.TabIndex = 25;
            // 
            // PickSlip
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
            this.Name = "PickSlip";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGRN_Load);
            this.Main.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.SOLines.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTO;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblToLoc;
        private System.Windows.Forms.Label lblSaleMan;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblaccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage SOLines;
        private System.Windows.Forms.DataGrid dgSOLines;
        private System.Windows.Forms.TextBox txtQty;
    }
}