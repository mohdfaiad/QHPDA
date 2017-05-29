namespace QHMobile
{
    partial class EmptyBin
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
            this.mnuMainBack = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuBinContent = new System.Windows.Forms.MenuItem();
            this.mnuEmptyBin1 = new System.Windows.Forms.MenuItem();
            this.mnuBinItem = new System.Windows.Forms.MenuItem();
            this.mnudailyloss = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.Main = new System.Windows.Forms.TabPage();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.lblTodate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.butFind = new System.Windows.Forms.Button();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.txtBinNo = new System.Windows.Forms.TextBox();
            this.gdBins = new System.Windows.Forms.DataGrid();
            this.lblStaffInfo = new System.Windows.Forms.Label();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Main.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuMainBack);
            this.mainMenu1.MenuItems.Add(this.mnuOptions);
            // 
            // mnuMainBack
            // 
            this.mnuMainBack.Text = "Main";
            this.mnuMainBack.Click += new System.EventHandler(this.mnuMainBack_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.MenuItems.Add(this.mnuBinContent);
            this.mnuOptions.MenuItems.Add(this.mnuEmptyBin1);
            this.mnuOptions.MenuItems.Add(this.mnuBinItem);
            this.mnuOptions.MenuItems.Add(this.mnudailyloss);
            this.mnuOptions.MenuItems.Add(this.menuItem1);
            this.mnuOptions.Text = "Options";
            // 
            // mnuBinContent
            // 
            this.mnuBinContent.Checked = true;
            this.mnuBinContent.Text = "Find Bin Content";
            this.mnuBinContent.Click += new System.EventHandler(this.mnuBinContent_Click);
            // 
            // mnuEmptyBin1
            // 
            this.mnuEmptyBin1.Text = "Find Empty Bin";
            this.mnuEmptyBin1.Click += new System.EventHandler(this.mnuEmptyBin1_Click);
            // 
            // mnuBinItem
            // 
            this.mnuBinItem.Text = "Bin Content by Item";
            this.mnuBinItem.Click += new System.EventHandler(this.mnuBinItem_Click);
            // 
            // mnudailyloss
            // 
            this.mnudailyloss.Text = "Find Daily Loss";
            this.mnudailyloss.Click += new System.EventHandler(this.mnudailyloss_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Find WH Entry";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.txtToDate);
            this.Main.Controls.Add(this.lblTodate);
            this.Main.Controls.Add(this.lblFromDate);
            this.Main.Controls.Add(this.txtFromDate);
            this.Main.Controls.Add(this.butFind);
            this.Main.Controls.Add(this.lblStaffName);
            this.Main.Controls.Add(this.txtBinNo);
            this.Main.Controls.Add(this.gdBins);
            this.Main.Controls.Add(this.lblStaffInfo);
            this.Main.Controls.Add(this.lblItemNo);
            this.Main.Controls.Add(this.label2);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Bin Info";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblCount.Location = new System.Drawing.Point(183, 66);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(30, 10);
            this.lblCount.Text = "( - )";
            // 
            // txtToDate
            // 
            this.txtToDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtToDate.Location = new System.Drawing.Point(147, 45);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(86, 19);
            this.txtToDate.TabIndex = 59;
            // 
            // lblTodate
            // 
            this.lblTodate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblTodate.Location = new System.Drawing.Point(129, 47);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.Size = new System.Drawing.Size(25, 20);
            this.lblTodate.Text = "To";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFromDate.Location = new System.Drawing.Point(4, 47);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 20);
            this.lblFromDate.Text = "From";
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtFromDate.Location = new System.Drawing.Point(50, 46);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(76, 19);
            this.txtFromDate.TabIndex = 57;
            // 
            // butFind
            // 
            this.butFind.Location = new System.Drawing.Point(147, 23);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(86, 20);
            this.butFind.TabIndex = 51;
            this.butFind.Text = "Find";
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
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
            // txtBinNo
            // 
            this.txtBinNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBinNo.Location = new System.Drawing.Point(50, 24);
            this.txtBinNo.Name = "txtBinNo";
            this.txtBinNo.Size = new System.Drawing.Size(76, 19);
            this.txtBinNo.TabIndex = 46;
            this.txtBinNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNo_KeyDown);
            // 
            // gdBins
            // 
            this.gdBins.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gdBins.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gdBins.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.gdBins.Location = new System.Drawing.Point(0, 81);
            this.gdBins.Name = "gdBins";
            this.gdBins.Size = new System.Drawing.Size(240, 182);
            this.gdBins.TabIndex = 24;
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
            // lblItemNo
            // 
            this.lblItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblItemNo.Location = new System.Drawing.Point(4, 27);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.Size = new System.Drawing.Size(56, 20);
            this.lblItemNo.Text = "Bin No.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(130, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 11);
            this.label2.Text = "No. of Bins";
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
            // EmptyBin
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
            this.Name = "EmptyBin";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Main.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuMainBack;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.TextBox txtBinNo;
        private System.Windows.Forms.DataGrid gdBins;
        private System.Windows.Forms.Label lblStaffInfo;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuBinContent;
        private System.Windows.Forms.Button butFind;
        private System.Windows.Forms.MenuItem mnuEmptyBin1;
        private System.Windows.Forms.MenuItem mnuBinItem;
        private System.Windows.Forms.MenuItem mnudailyloss;
        private System.Windows.Forms.Label lblTodate;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}