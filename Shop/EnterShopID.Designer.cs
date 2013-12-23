namespace Shop
{
    partial class EnterShopID
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
            this.tbShopID = new System.Windows.Forms.TextBox();
            this.btConfirmShopID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbShopID
            // 
            this.tbShopID.Location = new System.Drawing.Point(13, 29);
            this.tbShopID.Name = "tbShopID";
            this.tbShopID.Size = new System.Drawing.Size(257, 22);
            this.tbShopID.TabIndex = 0;
            // 
            // btConfirmShopID
            // 
            this.btConfirmShopID.Location = new System.Drawing.Point(13, 57);
            this.btConfirmShopID.Name = "btConfirmShopID";
            this.btConfirmShopID.Size = new System.Drawing.Size(257, 58);
            this.btConfirmShopID.TabIndex = 1;
            this.btConfirmShopID.Text = "Confirm";
            this.btConfirmShopID.UseVisualStyleBackColor = true;
            this.btConfirmShopID.Click += new System.EventHandler(this.btConfirmShopID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Insert shop ID here:";
            // 
            // EnterShopID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btConfirmShopID);
            this.Controls.Add(this.tbShopID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EnterShopID";
            this.Text = "EnterShopID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbShopID;
        private System.Windows.Forms.Button btConfirmShopID;
        private System.Windows.Forms.Label label1;
    }
}