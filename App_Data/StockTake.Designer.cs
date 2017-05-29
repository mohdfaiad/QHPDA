namespace QHMobile
{
    partial class StockTake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnuItemOpt = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.MnuNewGRN = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.txtDescription2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBin = new System.Windows.Forms.TextBox();
            this.lblStaffInfo = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgGRNLine = new System.Windows.Forms.DataGrid();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMain.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuGRNBack);
            this.mainMenu1.MenuItems.Add(this.mnuItemOpt);
            // 
            // mnuGRNBack
            // 
            this.mnuGRNBack.MenuItems.Add(this.menuItem3);
            this.mnuGRNBack.MenuItems.Add(this.menuItem4);
            this.mnuGRNBack.MenuItems.Add(this.menuItem5);
            this.mnuGRNBack.Text = "View";
            this.mnuGRNBack.Click += new System.EventHandler(this.mnuGRNBack_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Opening Balance";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Stock Take";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Main Menu";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // mnuItemOpt
            // 
            this.mnuItemOpt.MenuItems.Add(this.menuItem1);
            this.mnuItemOpt.MenuItems.Add(this.MnuNewGRN);
            this.mnuItemOpt.MenuItems.Add(this.menuItem2);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "New";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // MnuNewGRN
            // 
            this.MnuNewGRN.Text = "Transfer to NAV";
            this.MnuNewGRN.Click += new System.EventHandler(this.MnuNewGRN_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Delete";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
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
            // Main
            // 
            this.Main.Controls.Add(this.txtDescription2);
            this.Main.Controls.Add(this.label8);
            this.Main.Controls.Add(this.txtDescription);
            this.Main.Controls.Add(this.label7);
            this.Main.Controls.Add(this.txtCategory);
            this.Main.Controls.Add(this.txtLocation);
            this.Main.Controls.Add(this.btnAdd);
            this.Main.Controls.Add(this.label6);
            this.Main.Controls.Add(this.textBox1);
            this.Main.Controls.Add(this.label5);
            this.Main.Controls.Add(this.txtBin);
            this.Main.Controls.Add(this.lblStaffInfo);
            this.Main.Controls.Add(this.txtQty);
            this.Main.Controls.Add(this.label4);
            this.Main.Controls.Add(this.label2);
            this.Main.Controls.Add(this.lblCount);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.dgGRNLine);
            this.Main.Controls.Add(this.txtItemNo);
            this.Main.Controls.Add(this.label1);
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(240, 263);
            this.Main.Text = "Stock Take";
            // 
            // txtDescription2
            // 
            this.txtDescription2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDescription2.Location = new System.Drawing.Point(65, 84);
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.Size = new System.Drawing.Size(172, 19);
            this.txtDescription2.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(2, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.Text = "Description2";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDescription.Location = new System.Drawing.Point(65, 63);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(172, 19);
            this.txtDescription.TabIndex = 84;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(2, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.Text = "Description";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(68, 106);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(77, 21);
            this.txtCategory.TabIndex = 72;
            this.txtCategory.Visible = false;
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.txtLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocation.ForeColor = System.Drawing.Color.White;
            this.txtLocation.Location = new System.Drawing.Point(171, 1);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(53, 17);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(7, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 21);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAdd_KeyDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(118, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.Text = "Location:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(160, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 19);
            this.textBox1.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(129, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.Text = "Date";
            // 
            // txtBin
            // 
            this.txtBin.Enabled = false;
            this.txtBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBin.Location = new System.Drawing.Point(65, 21);
            this.txtBin.Name = "txtBin";
            this.txtBin.Size = new System.Drawing.Size(58, 19);
            this.txtBin.TabIndex = 36;
            this.txtBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBin_KeyDown);
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
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(65, 42);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(58, 19);
            this.txtQty.TabIndex = 45;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(2, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.Text = "Bin Code";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(150, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 11);
            this.label2.Text = "Line Count : ";
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(207, 120);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(28, 11);
            this.lblCount.Text = "( - )";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(2, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.Text = "Quantity";
            // 
            // dgGRNLine
            // 
            this.dgGRNLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgGRNLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgGRNLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.dgGRNLine.Location = new System.Drawing.Point(0, 133);
            this.dgGRNLine.Name = "dgGRNLine";
            this.dgGRNLine.Size = new System.Drawing.Size(240, 130);
            this.dgGRNLine.TabIndex = 24;
            // 
            // txtItemNo
            // 
            this.txtItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemNo.Location = new System.Drawing.Point(160, 21);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(77, 19);
            this.txtItemNo.TabIndex = 21;
            this.txtItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNo_KeyDown);
            this.txtItemNo.LostFocus += new System.EventHandler(this.txtItemNo_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(129, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.Text = "Item";
            // 
            // StockTake
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
            this.Name = "StockTake";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbMain.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem MnuNewGRN;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Label txtLocation;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBin;
        private System.Windows.Forms.Label lblStaffInfo;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGrid dgGRNLine;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDescription2;
        private System.Windows.Forms.Label label8;

    }
}