namespace RGSMobile
{
    partial class frmSO
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
            this.mnuMain = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.MnuItmNew = new System.Windows.Forms.MenuItem();
            this.mnuItemNAV = new System.Windows.Forms.MenuItem();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScanNo = new System.Windows.Forms.TextBox();
            this.dgSoLine = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSOScan = new System.Windows.Forms.TextBox();
            this.Scan = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tbMain.SuspendLayout();
            this.Main.SuspendLayout();
            this.Scan.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuMain);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // mnuMain
            // 
            this.mnuMain.Text = "Main";
            this.mnuMain.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.MnuItmNew);
            this.menuItem2.MenuItems.Add(this.mnuItemNAV);
            this.menuItem2.Text = "Options";
            // 
            // MnuItmNew
            // 
            this.MnuItmNew.Text = "New";
            // 
            // mnuItemNAV
            // 
            this.mnuItemNAV.Text = "Register to NAV";
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.Main);
            this.tbMain.Controls.Add(this.Scan);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 294);
            this.tbMain.TabIndex = 1;
            // 
            // Main
            // 
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.txtScanNo);
            this.Main.Controls.Add(this.dgSoLine);
            this.Main.Controls.Add(this.label1);
            this.Main.Controls.Add(this.txtSOScan);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 271);
            this.Main.Text = "Main";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(130, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(187, 48);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(48, 10);
            this.lblCount.Text = "( - )";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.Text = "Scan No. :";
            // 
            // txtScanNo
            // 
            this.txtScanNo.Location = new System.Drawing.Point(77, 25);
            this.txtScanNo.Name = "txtScanNo";
            this.txtScanNo.Size = new System.Drawing.Size(160, 21);
            this.txtScanNo.TabIndex = 36;
            this.txtScanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScanNo_KeyDown);
            // 
            // dgSoLine
            // 
            this.dgSoLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgSoLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgSoLine.Location = new System.Drawing.Point(0, 62);
            this.dgSoLine.Name = "dgSoLine";
            this.dgSoLine.Size = new System.Drawing.Size(240, 209);
            this.dgSoLine.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.Text = "SO No. :";
            // 
            // txtSOScan
            // 
            this.txtSOScan.Location = new System.Drawing.Point(77, 2);
            this.txtSOScan.Name = "txtSOScan";
            this.txtSOScan.Size = new System.Drawing.Size(160, 21);
            this.txtSOScan.TabIndex = 21;
            this.txtSOScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSOScan_KeyDown);
            // 
            // Scan
            // 
            this.Scan.Controls.Add(this.dataGrid1);
            this.Scan.Location = new System.Drawing.Point(0, 0);
            this.Scan.Name = "Scan";
            this.Scan.Size = new System.Drawing.Size(232, 268);
            this.Scan.Text = "Scaned";
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 271);
            this.dataGrid1.TabIndex = 0;
            // 
            // frmSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tbMain);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmSO";
            this.Text = "frmSO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSO_Load);
            this.tbMain.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Scan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage Scan;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.MenuItem mnuMain;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem MnuItmNew;
        private System.Windows.Forms.MenuItem mnuItemNAV;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScanNo;
        private System.Windows.Forms.DataGrid dgSoLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSOScan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
    }
}