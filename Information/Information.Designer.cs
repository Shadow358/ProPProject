namespace Information
{
    partial class Information
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
            this.tcTabs = new System.Windows.Forms.TabControl();
            this.tabGeneralInfo = new System.Windows.Forms.TabPage();
            this.btRefreshGeneralInfo = new System.Windows.Forms.Button();
            this.libGeneralInfo = new System.Windows.Forms.ListBox();
            this.tabVisitorInfo = new System.Windows.Forms.TabPage();
            this.btRefreshVisitor = new System.Windows.Forms.Button();
            this.libVisitorInfo = new System.Windows.Forms.ListBox();
            this.tbVisitorID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabShopInfo = new System.Windows.Forms.TabPage();
            this.btRefreshShop = new System.Windows.Forms.Button();
            this.libShopInfo = new System.Windows.Forms.ListBox();
            this.tbShopID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCamping = new System.Windows.Forms.TabPage();
            this.libCampingInfo = new System.Windows.Forms.ListBox();
            this.btRefreshCamping = new System.Windows.Forms.Button();
            this.tbCampingSpotID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tcTabs.SuspendLayout();
            this.tabGeneralInfo.SuspendLayout();
            this.tabVisitorInfo.SuspendLayout();
            this.tabShopInfo.SuspendLayout();
            this.tabCamping.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTabs
            // 
            this.tcTabs.Controls.Add(this.tabGeneralInfo);
            this.tcTabs.Controls.Add(this.tabVisitorInfo);
            this.tcTabs.Controls.Add(this.tabShopInfo);
            this.tcTabs.Controls.Add(this.tabCamping);
            this.tcTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcTabs.Location = new System.Drawing.Point(13, 13);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(1237, 648);
            this.tcTabs.TabIndex = 0;
            // 
            // tabGeneralInfo
            // 
            this.tabGeneralInfo.Controls.Add(this.btRefreshGeneralInfo);
            this.tabGeneralInfo.Controls.Add(this.libGeneralInfo);
            this.tabGeneralInfo.Location = new System.Drawing.Point(4, 27);
            this.tabGeneralInfo.Name = "tabGeneralInfo";
            this.tabGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralInfo.Size = new System.Drawing.Size(1229, 617);
            this.tabGeneralInfo.TabIndex = 0;
            this.tabGeneralInfo.Text = "General event information";
            this.tabGeneralInfo.UseVisualStyleBackColor = true;
            // 
            // btRefreshGeneralInfo
            // 
            this.btRefreshGeneralInfo.Location = new System.Drawing.Point(7, 5);
            this.btRefreshGeneralInfo.Name = "btRefreshGeneralInfo";
            this.btRefreshGeneralInfo.Size = new System.Drawing.Size(100, 23);
            this.btRefreshGeneralInfo.TabIndex = 7;
            this.btRefreshGeneralInfo.Text = "Refresh";
            this.btRefreshGeneralInfo.UseVisualStyleBackColor = true;
            // 
            // libGeneralInfo
            // 
            this.libGeneralInfo.FormattingEnabled = true;
            this.libGeneralInfo.ItemHeight = 18;
            this.libGeneralInfo.Location = new System.Drawing.Point(7, 35);
            this.libGeneralInfo.Name = "libGeneralInfo";
            this.libGeneralInfo.Size = new System.Drawing.Size(1216, 580);
            this.libGeneralInfo.TabIndex = 0;
            // 
            // tabVisitorInfo
            // 
            this.tabVisitorInfo.Controls.Add(this.btRefreshVisitor);
            this.tabVisitorInfo.Controls.Add(this.libVisitorInfo);
            this.tabVisitorInfo.Controls.Add(this.tbVisitorID);
            this.tabVisitorInfo.Controls.Add(this.label1);
            this.tabVisitorInfo.Location = new System.Drawing.Point(4, 27);
            this.tabVisitorInfo.Name = "tabVisitorInfo";
            this.tabVisitorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisitorInfo.Size = new System.Drawing.Size(1229, 617);
            this.tabVisitorInfo.TabIndex = 1;
            this.tabVisitorInfo.Text = "Visitor Information";
            this.tabVisitorInfo.UseVisualStyleBackColor = true;
            // 
            // btRefreshVisitor
            // 
            this.btRefreshVisitor.Location = new System.Drawing.Point(7, 5);
            this.btRefreshVisitor.Name = "btRefreshVisitor";
            this.btRefreshVisitor.Size = new System.Drawing.Size(100, 23);
            this.btRefreshVisitor.TabIndex = 6;
            this.btRefreshVisitor.Text = "Refresh";
            this.btRefreshVisitor.UseVisualStyleBackColor = true;
            // 
            // libVisitorInfo
            // 
            this.libVisitorInfo.FormattingEnabled = true;
            this.libVisitorInfo.ItemHeight = 18;
            this.libVisitorInfo.Location = new System.Drawing.Point(7, 35);
            this.libVisitorInfo.Name = "libVisitorInfo";
            this.libVisitorInfo.Size = new System.Drawing.Size(1216, 580);
            this.libVisitorInfo.TabIndex = 2;
            // 
            // tbVisitorID
            // 
            this.tbVisitorID.Location = new System.Drawing.Point(228, 4);
            this.tbVisitorID.Name = "tbVisitorID";
            this.tbVisitorID.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert visitor ID:";
            // 
            // tabShopInfo
            // 
            this.tabShopInfo.Controls.Add(this.btRefreshShop);
            this.tabShopInfo.Controls.Add(this.libShopInfo);
            this.tabShopInfo.Controls.Add(this.tbShopID);
            this.tabShopInfo.Controls.Add(this.label2);
            this.tabShopInfo.Location = new System.Drawing.Point(4, 27);
            this.tabShopInfo.Name = "tabShopInfo";
            this.tabShopInfo.Size = new System.Drawing.Size(1229, 617);
            this.tabShopInfo.TabIndex = 2;
            this.tabShopInfo.Text = "Shop Information";
            this.tabShopInfo.UseVisualStyleBackColor = true;
            // 
            // btRefreshShop
            // 
            this.btRefreshShop.Location = new System.Drawing.Point(7, 5);
            this.btRefreshShop.Name = "btRefreshShop";
            this.btRefreshShop.Size = new System.Drawing.Size(100, 23);
            this.btRefreshShop.TabIndex = 5;
            this.btRefreshShop.Text = "Refresh";
            this.btRefreshShop.UseVisualStyleBackColor = true;
            // 
            // libShopInfo
            // 
            this.libShopInfo.FormattingEnabled = true;
            this.libShopInfo.ItemHeight = 18;
            this.libShopInfo.Location = new System.Drawing.Point(7, 35);
            this.libShopInfo.Name = "libShopInfo";
            this.libShopInfo.Size = new System.Drawing.Size(1213, 580);
            this.libShopInfo.TabIndex = 4;
            // 
            // tbShopID
            // 
            this.tbShopID.Location = new System.Drawing.Point(225, 4);
            this.tbShopID.Name = "tbShopID";
            this.tbShopID.Size = new System.Drawing.Size(150, 24);
            this.tbShopID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Insert shop ID:";
            // 
            // tabCamping
            // 
            this.tabCamping.Controls.Add(this.libCampingInfo);
            this.tabCamping.Controls.Add(this.btRefreshCamping);
            this.tabCamping.Controls.Add(this.tbCampingSpotID);
            this.tabCamping.Controls.Add(this.label3);
            this.tabCamping.Location = new System.Drawing.Point(4, 27);
            this.tabCamping.Name = "tabCamping";
            this.tabCamping.Size = new System.Drawing.Size(1229, 617);
            this.tabCamping.TabIndex = 3;
            this.tabCamping.Text = "Camping information";
            this.tabCamping.UseVisualStyleBackColor = true;
            // 
            // libCampingInfo
            // 
            this.libCampingInfo.FormattingEnabled = true;
            this.libCampingInfo.ItemHeight = 18;
            this.libCampingInfo.Location = new System.Drawing.Point(7, 35);
            this.libCampingInfo.Name = "libCampingInfo";
            this.libCampingInfo.Size = new System.Drawing.Size(1213, 580);
            this.libCampingInfo.TabIndex = 9;
            // 
            // btRefreshCamping
            // 
            this.btRefreshCamping.Location = new System.Drawing.Point(7, 5);
            this.btRefreshCamping.Name = "btRefreshCamping";
            this.btRefreshCamping.Size = new System.Drawing.Size(100, 23);
            this.btRefreshCamping.TabIndex = 8;
            this.btRefreshCamping.Text = "Refresh";
            this.btRefreshCamping.UseVisualStyleBackColor = true;
            // 
            // tbCampingSpotID
            // 
            this.tbCampingSpotID.Location = new System.Drawing.Point(272, 4);
            this.tbCampingSpotID.Name = "tbCampingSpotID";
            this.tbCampingSpotID.Size = new System.Drawing.Size(150, 24);
            this.tbCampingSpotID.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Insert camping spot ID:";
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.tcTabs);
            this.Name = "Information";
            this.Text = "Information Application";
            this.tcTabs.ResumeLayout(false);
            this.tabGeneralInfo.ResumeLayout(false);
            this.tabVisitorInfo.ResumeLayout(false);
            this.tabVisitorInfo.PerformLayout();
            this.tabShopInfo.ResumeLayout(false);
            this.tabShopInfo.PerformLayout();
            this.tabCamping.ResumeLayout(false);
            this.tabCamping.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tabGeneralInfo;
        private System.Windows.Forms.TabPage tabVisitorInfo;
        private System.Windows.Forms.TabPage tabShopInfo;
        private System.Windows.Forms.TabPage tabCamping;
        private System.Windows.Forms.ListBox libGeneralInfo;
        private System.Windows.Forms.TextBox tbVisitorID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox libVisitorInfo;
        private System.Windows.Forms.TextBox tbShopID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRefreshGeneralInfo;
        private System.Windows.Forms.Button btRefreshVisitor;
        private System.Windows.Forms.Button btRefreshShop;
        private System.Windows.Forms.ListBox libShopInfo;
        private System.Windows.Forms.Button btRefreshCamping;
        private System.Windows.Forms.TextBox tbCampingSpotID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox libCampingInfo;
    }
}

