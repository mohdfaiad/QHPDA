namespace QHMobile
{
    partial class PurChaseOrder
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
            this.mnuRegisterToNav = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tbPOLines = new System.Windows.Forms.TabPage();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendorNo = new System.Windows.Forms.TextBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.btnVendor = new System.Windows.Forms.Button();
            this.GrdPO = new System.Windows.Forms.DataGrid();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblPO = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tPEdit = new System.Windows.Forms.TabPage();
            this.txtLineno = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.tetEditDescription = new System.Windows.Forms.TextBox();
            this.txtEditItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEditDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfirmUpdate = new System.Windows.Forms.Button();
            this.txtEditLocation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEditQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPOLines.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tPEdit.SuspendLayout();
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
            this.mnuItemOpt.MenuItems.Add(this.mnuRegisterToNav);
            this.mnuItemOpt.MenuItems.Add(this.menuItem2);
            this.mnuItemOpt.Text = "Options";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "New";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mnuRegisterToNav
            // 
            this.mnuRegisterToNav.Text = "Create PO";
            this.mnuRegisterToNav.Click += new System.EventHandler(this.mnuRegisterToNav_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Delete";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // tbPOLines
            // 
            this.tbPOLines.Controls.Add(this.txtSearch);
            this.tbPOLines.Controls.Add(this.txtLocation);
            this.tbPOLines.Controls.Add(this.label7);
            this.tbPOLines.Controls.Add(this.txtRegDate);
            this.tbPOLines.Controls.Add(this.label5);
            this.tbPOLines.Controls.Add(this.txtQty);
            this.tbPOLines.Controls.Add(this.label3);
            this.tbPOLines.Controls.Add(this.txtItemNo);
            this.tbPOLines.Controls.Add(this.label1);
            this.tbPOLines.Controls.Add(this.label6);
            this.tbPOLines.Controls.Add(this.txtVendorNo);
            this.tbPOLines.Controls.Add(this.txtVendorName);
            this.tbPOLines.Controls.Add(this.btnVendor);
            this.tbPOLines.Controls.Add(this.GrdPO);
            this.tbPOLines.Controls.Add(this.btnAdd);
            this.tbPOLines.Controls.Add(this.lblPO);
            this.tbPOLines.Location = new System.Drawing.Point(0, 0);
            this.tbPOLines.Name = "tbPOLines";
            this.tbPOLines.Size = new System.Drawing.Size(240, 263);
            this.tbPOLines.Text = "Purchase Lines";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSearch.Location = new System.Drawing.Point(121, 1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(52, 19);
            this.txtSearch.TabIndex = 120;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocation.Location = new System.Drawing.Point(158, 56);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(79, 19);
            this.txtLocation.TabIndex = 108;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(112, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.Text = "Location";
            // 
            // txtRegDate
            // 
            this.txtRegDate.Enabled = false;
            this.txtRegDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtRegDate.Location = new System.Drawing.Point(33, 77);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(77, 19);
            this.txtRegDate.TabIndex = 107;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(3, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 18);
            this.label5.Text = "Date";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(158, 77);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(79, 19);
            this.txtQty.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(133, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.Text = "Qty";
            // 
            // txtItemNo
            // 
            this.txtItemNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemNo.Location = new System.Drawing.Point(33, 56);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(77, 19);
            this.txtItemNo.TabIndex = 103;
            this.txtItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNo_KeyDown_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(4, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.Text = "Item";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 10);
            // 
            // txtVendorNo
            // 
            this.txtVendorNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtVendorNo.Location = new System.Drawing.Point(3, 24);
            this.txtVendorNo.Name = "txtVendorNo";
            this.txtVendorNo.Size = new System.Drawing.Size(51, 19);
            this.txtVendorNo.TabIndex = 118;
            // 
            // txtVendorName
            // 
            this.txtVendorName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtVendorName.Location = new System.Drawing.Point(56, 24);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(181, 19);
            this.txtVendorName.TabIndex = 116;
            // 
            // btnVendor
            // 
            this.btnVendor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnVendor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnVendor.ForeColor = System.Drawing.Color.White;
            this.btnVendor.Location = new System.Drawing.Point(174, 0);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(66, 20);
            this.btnVendor.TabIndex = 115;
            this.btnVendor.Text = "Find Vendor";
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // GrdPO
            // 
            this.GrdPO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GrdPO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrdPO.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.GrdPO.Location = new System.Drawing.Point(0, 122);
            this.GrdPO.Name = "GrdPO";
            this.GrdPO.Size = new System.Drawing.Size(240, 141);
            this.GrdPO.TabIndex = 114;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(182, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 21);
            this.btnAdd.TabIndex = 105;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // lblPO
            // 
            this.lblPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblPO.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblPO.Location = new System.Drawing.Point(0, 0);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(240, 21);
            this.lblPO.Text = "PO:";
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbPOLines);
            this.tbMain.Controls.Add(this.tPEdit);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(240, 286);
            this.tbMain.TabIndex = 0;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // tPEdit
            // 
            this.tPEdit.Controls.Add(this.txtLineno);
            this.tPEdit.Controls.Add(this.lblDesc);
            this.tPEdit.Controls.Add(this.tetEditDescription);
            this.tPEdit.Controls.Add(this.txtEditItem);
            this.tPEdit.Controls.Add(this.label2);
            this.tPEdit.Controls.Add(this.txtEditDate);
            this.tPEdit.Controls.Add(this.label8);
            this.tPEdit.Controls.Add(this.btnConfirmUpdate);
            this.tPEdit.Controls.Add(this.txtEditLocation);
            this.tPEdit.Controls.Add(this.label11);
            this.tPEdit.Controls.Add(this.txtEditQuantity);
            this.tPEdit.Controls.Add(this.label4);
            this.tPEdit.Location = new System.Drawing.Point(0, 0);
            this.tPEdit.Name = "tPEdit";
            this.tPEdit.Size = new System.Drawing.Size(232, 260);
            this.tPEdit.Text = "Edit";
            // 
            // txtLineno
            // 
            this.txtLineno.Location = new System.Drawing.Point(94, 180);
            this.txtLineno.Name = "txtLineno";
            this.txtLineno.Size = new System.Drawing.Size(100, 21);
            this.txtLineno.TabIndex = 142;
            this.txtLineno.Visible = false;
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(7, 105);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(72, 20);
            this.lblDesc.Text = "Description";
            // 
            // tetEditDescription
            // 
            this.tetEditDescription.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tetEditDescription.Location = new System.Drawing.Point(84, 105);
            this.tetEditDescription.Name = "tetEditDescription";
            this.tetEditDescription.Size = new System.Drawing.Size(118, 19);
            this.tetEditDescription.TabIndex = 137;
            // 
            // txtEditItem
            // 
            this.txtEditItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditItem.Location = new System.Drawing.Point(85, 10);
            this.txtEditItem.Name = "txtEditItem";
            this.txtEditItem.Size = new System.Drawing.Size(118, 19);
            this.txtEditItem.TabIndex = 132;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.Text = "Item No";
            // 
            // txtEditDate
            // 
            this.txtEditDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditDate.Location = new System.Drawing.Point(85, 34);
            this.txtEditDate.Name = "txtEditDate";
            this.txtEditDate.Size = new System.Drawing.Size(118, 19);
            this.txtEditDate.TabIndex = 131;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(7, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.Text = "Date";
            // 
            // btnConfirmUpdate
            // 
            this.btnConfirmUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnConfirmUpdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnConfirmUpdate.ForeColor = System.Drawing.Color.White;
            this.btnConfirmUpdate.Location = new System.Drawing.Point(94, 140);
            this.btnConfirmUpdate.Name = "btnConfirmUpdate";
            this.btnConfirmUpdate.Size = new System.Drawing.Size(109, 20);
            this.btnConfirmUpdate.TabIndex = 126;
            this.btnConfirmUpdate.Text = "Confirm Update";
            this.btnConfirmUpdate.Click += new System.EventHandler(this.btnConfirmUpdate_Click);
            // 
            // txtEditLocation
            // 
            this.txtEditLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditLocation.Location = new System.Drawing.Point(84, 56);
            this.txtEditLocation.Name = "txtEditLocation";
            this.txtEditLocation.Size = new System.Drawing.Size(118, 19);
            this.txtEditLocation.TabIndex = 125;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(7, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.Text = "Location";
            // 
            // txtEditQuantity
            // 
            this.txtEditQuantity.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEditQuantity.Location = new System.Drawing.Point(84, 80);
            this.txtEditQuantity.Name = "txtEditQuantity";
            this.txtEditQuantity.Size = new System.Drawing.Size(118, 19);
            this.txtEditQuantity.TabIndex = 121;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(7, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.Text = "Quantity";
            // 
            // PurChaseOrder
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
            this.Name = "PurChaseOrder";
            this.Text = "frmGRN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbPOLines.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tPEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuGRNBack;
        private System.Windows.Forms.MenuItem mnuItemOpt;
        private System.Windows.Forms.TabPage tbPOLines;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuRegisterToNav;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRegDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid GrdPO;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.TextBox txtVendorNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabPage tPEdit;
        private System.Windows.Forms.Button btnConfirmUpdate;
        private System.Windows.Forms.TextBox txtEditLocation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEditQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEditDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox tetEditDescription;
        private System.Windows.Forms.TextBox txtLineno;
    }
}