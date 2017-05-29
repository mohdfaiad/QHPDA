namespace RGSMobile
{
    partial class frmToReceive
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
            this.mnuItmRegtoTO = new System.Windows.Forms.MenuItem();
            this.Main = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgTOLine = new System.Windows.Forms.DataGrid();
            this.txtTOScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gdScanned = new System.Windows.Forms.DataGrid();
            this.Scan = new System.Windows.Forms.TabPage();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuItemOpt = new System.Windows.Forms.MenuItem();
            this.MnuNewGRN = new System.Windows.Forms.MenuItem();
            this.mnuGRNBack = new System.Windows.Forms.MenuItem();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReqLineCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtScanNo = new System.Windows.Forms.TextBox();
            this.dgTrReqLines = new System.Windows.Forms.DataGrid();
            this.Main.SuspendLayout();
            this.Scan.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.menuItem2.MenuItems.Add(this.mnuItmRegtoTO);
            this.menuItem2.Text = "Options";
            // 
            // menuNewScan
            // 
            this.menuNewScan.Text = "New Scan";
            this.menuNewScan.Click += new System.EventHandler(this.menuNewScan_Click);
            // 
            // mnuItmRegtoTO
            // 
            this.mnuItmRegtoTO.Text = "Register to Nav";
            this.mnuItmRegtoTO.Click += new System.EventHandler(this.mnuItmRegtoTO_Click);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.dgTOLine);
            this.Main.Controls.Add(this.txtTOScan);
            this.Main.Controls.Add(this.label1);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Main";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(128, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(185, 27);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(48, 10);
            this.lblCount.Text = "( - )";
            // 
            // dgTOLine
            // 
            this.dgTOLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgTOLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgTOLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgTOLine.Location = new System.Drawing.Point(0, 38);
            this.dgTOLine.Name = "dgTOLine";
            this.dgTOLine.Size = new System.Drawing.Size(240, 225);
            this.dgTOLine.TabIndex = 24;
            // 
            // txtTOScan
            // 
            this.txtTOScan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtTOScan.Location = new System.Drawing.Point(64, 4);
            this.txtTOScan.Name = "txtTOScan";
            this.txtTOScan.Size = new System.Drawing.Size(170, 20);
            this.txtTOScan.TabIndex = 21;
            this.txtTOScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTOScan_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.Text = "TO No.";
            // 
            // gdScanned
            // 
            this.gdScanned.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gdScanned.Location = new System.Drawing.Point(0, 0);
            this.gdScanned.Name = "gdScanned";
            this.gdScanned.Size = new System.Drawing.Size(240, 271);
            this.gdScanned.TabIndex = 0;
            // 
            // Scan
            // 
            this.Scan.Controls.Add(this.gdScanned);
            this.Scan.Location = new System.Drawing.Point(0, 0);
            this.Scan.Name = "Scan";
            this.Scan.Size = new System.Drawing.Size(232, 268);
            this.Scan.Text = "Scanned";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Register to NAV";
            // 
            // mnuItemOpt
            // 
            this.mnuItemOpt.MenuItems.Add(this.MnuNewGRN);
            this.mnuItemOpt.MenuItems.Add(this.menuItem1);
            this.mnuItemOpt.Text = "Options";
            // 
            // MnuNewGRN
            // 
            this.MnuNewGRN.Text = "New";
            // 
            // mnuGRNBack
            // 
            this.mnuGRNBack.Text = "Main";
            // 
            // mainMenu2
            // 
            this.mainMenu2.MenuItems.Add(this.mnuGRNBack);
            this.mainMenu2.MenuItems.Add(this.mnuItemOpt);
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.Scan);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 1;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblReqLineCount);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtScanNo);
            this.tabPage1.Controls.Add(this.dgTrReqLines);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 268);
            this.tabPage1.Text = "Trans Recv. Line";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(128, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 11);
            this.label3.Text = "Line Count : ";
            // 
            // lblReqLineCount
            // 
            this.lblReqLineCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblReqLineCount.Location = new System.Drawing.Point(185, 24);
            this.lblReqLineCount.Name = "lblReqLineCount";
            this.lblReqLineCount.Size = new System.Drawing.Size(48, 10);
            this.lblReqLineCount.Text = "( - )";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.Text = "Scan No.";
            // 
            // txtScanNo
            // 
            this.txtScanNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtScanNo.Location = new System.Drawing.Point(71, 2);
            this.txtScanNo.Name = "txtScanNo";
            this.txtScanNo.Size = new System.Drawing.Size(165, 20);
            this.txtScanNo.TabIndex = 38;
            this.txtScanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScanNo_KeyDown);
            // 
            // dgTrReqLines
            // 
            this.dgTrReqLines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgTrReqLines.Location = new System.Drawing.Point(0, 37);
            this.dgTrReqLines.Name = "dgTrReqLines";
            this.dgTrReqLines.Size = new System.Drawing.Size(240, 234);
            this.dgTrReqLines.TabIndex = 1;
            // 
            // frmToReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tbMain);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmToReceive";
            this.Text = "frmTR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTR_Load);
            this.Main.ResumeLayout(false);
            this.Scan.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.MenuItem mnuItmMain;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.DataGrid dgTOLine;
        private System.Windows.Forms.TextBox txtTOScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid gdScanned;
        private System.Windows.Forms.TabPage Scan;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem MnuNewGRN;
        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGrid dgTrReqLines;
        private System.Windows.Forms.MenuItem mnuItmRegtoTO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtScanNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblReqLineCount;
        private System.Windows.Forms.MenuItem menuNewScan;
    }
}