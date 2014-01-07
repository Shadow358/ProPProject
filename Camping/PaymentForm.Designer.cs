namespace Camping
{
    partial class PaymentForm
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
            this.btConfirmPayment = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tbAmountToPay = new System.Windows.Forms.TextBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVbalance = new System.Windows.Forms.TextBox();
            this.tbVname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btConfirmPayment
            // 
            this.btConfirmPayment.Location = new System.Drawing.Point(248, 365);
            this.btConfirmPayment.Name = "btConfirmPayment";
            this.btConfirmPayment.Size = new System.Drawing.Size(147, 37);
            this.btConfirmPayment.TabIndex = 1;
            this.btConfirmPayment.Text = "Confirm Payment";
            this.btConfirmPayment.UseVisualStyleBackColor = true;
            this.btConfirmPayment.Click += new System.EventHandler(this.btConfirmPayment_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(401, 365);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(113, 37);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // tbAmountToPay
            // 
            this.tbAmountToPay.Location = new System.Drawing.Point(12, 122);
            this.tbAmountToPay.Name = "tbAmountToPay";
            this.tbAmountToPay.ReadOnly = true;
            this.tbAmountToPay.Size = new System.Drawing.Size(113, 22);
            this.tbAmountToPay.TabIndex = 74;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.ForeColor = System.Drawing.Color.Green;
            this.lbInfo.Location = new System.Drawing.Point(7, 162);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(67, 25);
            this.lbInfo.TabIndex = 75;
            this.lbInfo.Text = "<info>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 76;
            this.label1.Text = "Amount to pay:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 78;
            this.label2.Text = "Visitor scanned:";
            // 
            // tbVbalance
            // 
            this.tbVbalance.Location = new System.Drawing.Point(12, 334);
            this.tbVbalance.Name = "tbVbalance";
            this.tbVbalance.ReadOnly = true;
            this.tbVbalance.Size = new System.Drawing.Size(113, 22);
            this.tbVbalance.TabIndex = 77;
            // 
            // tbVname
            // 
            this.tbVname.Location = new System.Drawing.Point(12, 306);
            this.tbVname.Name = "tbVname";
            this.tbVname.ReadOnly = true;
            this.tbVname.Size = new System.Drawing.Size(209, 22);
            this.tbVname.TabIndex = 79;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 414);
            this.Controls.Add(this.tbVname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVbalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.tbAmountToPay);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btConfirmPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaymentForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConfirmPayment;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox tbAmountToPay;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVbalance;
        private System.Windows.Forms.TextBox tbVname;
    }
}