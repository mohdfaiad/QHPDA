namespace QHMobile
{
    partial class MainScreen
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
            this.btnStockTake = new System.Windows.Forms.Button();
            this.btnPOAssignBin = new System.Windows.Forms.Button();
            this.btnLedgerTransfer = new System.Windows.Forms.Button();
            this.btnTransferOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUL = new System.Windows.Forms.Label();
            this.lblUserLevel = new System.Windows.Forms.Label();
            this.lblUserDimension = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDailyLoss = new System.Windows.Forms.Button();
            this.btnDailyLossTS = new System.Windows.Forms.Button();
            this.btnPKQH = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStockTake
            // 
            this.btnStockTake.Location = new System.Drawing.Point(3, 11);
            this.btnStockTake.Name = "btnStockTake";
            this.btnStockTake.Size = new System.Drawing.Size(151, 20);
            this.btnStockTake.TabIndex = 0;
            this.btnStockTake.Text = "Stock Take";
            this.btnStockTake.Click += new System.EventHandler(this.btnStockTake_Click);
            // 
            // btnPOAssignBin
            // 
            this.btnPOAssignBin.Location = new System.Drawing.Point(3, 37);
            this.btnPOAssignBin.Name = "btnPOAssignBin";
            this.btnPOAssignBin.Size = new System.Drawing.Size(151, 20);
            this.btnPOAssignBin.TabIndex = 1;
            this.btnPOAssignBin.Text = "PO Assign";
            this.btnPOAssignBin.Click += new System.EventHandler(this.btnPOAssignBin_Click);
            // 
            // btnLedgerTransfer
            // 
            this.btnLedgerTransfer.Location = new System.Drawing.Point(2, 63);
            this.btnLedgerTransfer.Name = "btnLedgerTransfer";
            this.btnLedgerTransfer.Size = new System.Drawing.Size(152, 20);
            this.btnLedgerTransfer.TabIndex = 2;
            this.btnLedgerTransfer.Text = "Transfer Order";
            this.btnLedgerTransfer.Click += new System.EventHandler(this.btnLedgerTransfer_Click);
            // 
            // btnTransferOrder
            // 
            this.btnTransferOrder.Location = new System.Drawing.Point(3, 90);
            this.btnTransferOrder.Name = "btnTransferOrder";
            this.btnTransferOrder.Size = new System.Drawing.Size(151, 20);
            this.btnTransferOrder.TabIndex = 3;
            this.btnTransferOrder.Text = "Create Transfer Order";
            this.btnTransferOrder.Click += new System.EventHandler(this.btnTransferOrder_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.Text = "User Name:";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(117, 199);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(64, 20);
            // 
            // lblUL
            // 
            this.lblUL.Location = new System.Drawing.Point(117, 219);
            this.lblUL.Name = "lblUL";
            this.lblUL.Size = new System.Drawing.Size(64, 20);
            // 
            // lblUserLevel
            // 
            this.lblUserLevel.Location = new System.Drawing.Point(15, 219);
            this.lblUserLevel.Name = "lblUserLevel";
            this.lblUserLevel.Size = new System.Drawing.Size(64, 20);
            this.lblUserLevel.Text = "User Level";
            // 
            // lblUserDimension
            // 
            this.lblUserDimension.Location = new System.Drawing.Point(117, 239);
            this.lblUserDimension.Name = "lblUserDimension";
            this.lblUserDimension.Size = new System.Drawing.Size(64, 20);
            this.lblUserDimension.ParentChanged += new System.EventHandler(this.label5_ParentChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.Text = "User Dimension";
            this.label6.ParentChanged += new System.EventHandler(this.label6_ParentChanged);
            // 
            // btnDailyLoss
            // 
            this.btnDailyLoss.Location = new System.Drawing.Point(2, 117);
            this.btnDailyLoss.Name = "btnDailyLoss";
            this.btnDailyLoss.Size = new System.Drawing.Size(152, 20);
            this.btnDailyLoss.TabIndex = 6;
            this.btnDailyLoss.Text = "Daily Loss Form";
            this.btnDailyLoss.Click += new System.EventHandler(this.btnDailyLoss_Click);
            // 
            // btnDailyLossTS
            // 
            this.btnDailyLossTS.Location = new System.Drawing.Point(2, 144);
            this.btnDailyLossTS.Name = "btnDailyLossTS";
            this.btnDailyLossTS.Size = new System.Drawing.Size(152, 20);
            this.btnDailyLossTS.TabIndex = 13;
            this.btnDailyLossTS.Text = "Daily Loss TS";
            this.btnDailyLossTS.Click += new System.EventHandler(this.btnDailyLossTS_Click);
            // 
            // btnPKQH
            // 
            this.btnPKQH.Location = new System.Drawing.Point(2, 171);
            this.btnPKQH.Name = "btnPKQH";
            this.btnPKQH.Size = new System.Drawing.Size(152, 20);
            this.btnPKQH.TabIndex = 20;
            this.btnPKQH.Text = "Picking List QH";
            this.btnPKQH.Click += new System.EventHandler(this.btnPKQH_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnPKQH);
            this.Controls.Add(this.btnDailyLossTS);
            this.Controls.Add(this.btnDailyLoss);
            this.Controls.Add(this.lblUserDimension);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblUL);
            this.Controls.Add(this.lblUserLevel);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTransferOrder);
            this.Controls.Add(this.btnLedgerTransfer);
            this.Controls.Add(this.btnPOAssignBin);
            this.Controls.Add(this.btnStockTake);
            this.Menu = this.mainMenu1;
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStockTake;
        private System.Windows.Forms.Button btnPOAssignBin;
        private System.Windows.Forms.Button btnLedgerTransfer;
        private System.Windows.Forms.Button btnTransferOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUL;
        private System.Windows.Forms.Label lblUserLevel;
        private System.Windows.Forms.Label lblUserDimension;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDailyLoss;
        private System.Windows.Forms.Button btnDailyLossTS;
        private System.Windows.Forms.Button btnPKQH;
    }
}