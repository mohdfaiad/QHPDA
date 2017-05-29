namespace RGSMobile
{
    partial class TO
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
            this.txtqty = new System.Windows.Forms.TextBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.txtTOWhere = new System.Windows.Forms.TextBox();
            this.lblTowhere = new System.Windows.Forms.Label();
            this.txtfrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtTO = new System.Windows.Forms.TextBox();
            this.lblTO = new System.Windows.Forms.Label();
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
            this.Main.Controls.Add(this.txtqty);
            this.Main.Controls.Add(this.cboLine);
            this.Main.Controls.Add(this.txtTOWhere);
            this.Main.Controls.Add(this.lblTowhere);
            this.Main.Controls.Add(this.txtfrom);
            this.Main.Controls.Add(this.lblFrom);
            this.Main.Controls.Add(this.txtTO);
            this.Main.Controls.Add(this.lblTO);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.dgGRNLine);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Receive List";
            // 
            // txtqty
            // 
            this.txtqty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtqty.Location = new System.Drawing.Point(134, 57);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(47, 20);
            this.txtqty.TabIndex = 62;
            // 
            // cboLine
            // 
            this.cboLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.cboLine.Location = new System.Drawing.Point(5, 58);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(125, 20);
            this.cboLine.TabIndex = 59;
            // 
            // txtTOWhere
            // 
            this.txtTOWhere.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtTOWhere.Location = new System.Drawing.Point(147, 24);
            this.txtTOWhere.Name = "txtTOWhere";
            this.txtTOWhere.Size = new System.Drawing.Size(86, 20);
            this.txtTOWhere.TabIndex = 53;
            // 
            // lblTowhere
            // 
            this.lblTowhere.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblTowhere.Location = new System.Drawing.Point(130, 25);
            this.lblTowhere.Name = "lblTowhere";
            this.lblTowhere.Size = new System.Drawing.Size(22, 20);
            this.lblTowhere.Text = "To";
            // 
            // txtfrom
            // 
            this.txtfrom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtfrom.Location = new System.Drawing.Point(42, 24);
            this.txtfrom.Name = "txtfrom";
            this.txtfrom.Size = new System.Drawing.Size(85, 20);
            this.txtfrom.TabIndex = 49;
            // 
            // lblFrom
            // 
            this.lblFrom.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblFrom.Location = new System.Drawing.Point(6, 27);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(67, 20);
            this.lblFrom.Text = "From";
            // 
            // txtTO
            // 
            this.txtTO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.txtTO.Location = new System.Drawing.Point(42, 2);
            this.txtTO.Name = "txtTO";
            this.txtTO.Size = new System.Drawing.Size(191, 20);
            this.txtTO.TabIndex = 46;
            this.txtTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTO_KeyDown);
            // 
            // lblTO
            // 
            this.lblTO.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lblTO.Location = new System.Drawing.Point(6, 5);
            this.lblTO.Name = "lblTO";
            this.lblTO.Size = new System.Drawing.Size(67, 20);
            this.lblTO.Text = "TO No";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(183, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Update";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(150, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(207, 82);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(30, 10);
            this.lblCount.Text = "( - )";
            // 
            // dgGRNLine
            // 
            this.dgGRNLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgGRNLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgGRNLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgGRNLine.Location = new System.Drawing.Point(0, 95);
            this.dgGRNLine.Name = "dgGRNLine";
            this.dgGRNLine.Size = new System.Drawing.Size(240, 168);
            this.dgGRNLine.TabIndex = 24;
            this.dgGRNLine.CurrentCellChanged += new System.EventHandler(this.dgGRNLine_CurrentCellChanged);
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
            // TO
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
            this.Name = "TO";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGrid dgGRNLine;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TextBox txtTO;
        private System.Windows.Forms.Label lblTO;
        private System.Windows.Forms.TextBox txtTOWhere;
        private System.Windows.Forms.Label lblTowhere;
        private System.Windows.Forms.TextBox txtfrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.TextBox txtqty;
    }
}