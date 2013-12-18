namespace Camping
{
    partial class Camping
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
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.libSpots = new System.Windows.Forms.ListBox();
            this.gbEnterCamping = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbCanEnter = new System.Windows.Forms.Label();
            this.tbVisitorName = new System.Windows.Forms.TextBox();
            this.btEnterState = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbVisitorBalance = new System.Windows.Forms.TextBox();
            this.btConfirmTransaction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPayerAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPayerBalance = new System.Windows.Forms.TextBox();
            this.tbVisitorID6 = new System.Windows.Forms.TextBox();
            this.tbVisitorID5 = new System.Windows.Forms.TextBox();
            this.tbVisitorID4 = new System.Windows.Forms.TextBox();
            this.tbVisitorID3 = new System.Windows.Forms.TextBox();
            this.tbVisitorID2 = new System.Windows.Forms.TextBox();
            this.tbVisitorID1 = new System.Windows.Forms.TextBox();
            this.tbPayerID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.gbEnterCamping.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(12, 37);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(442, 335);
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 41;
            this.label1.Text = "Map of the camping";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(493, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "List of all spots";
            // 
            // libSpots
            // 
            this.libSpots.FormattingEnabled = true;
            this.libSpots.ItemHeight = 18;
            this.libSpots.Location = new System.Drawing.Point(498, 37);
            this.libSpots.Name = "libSpots";
            this.libSpots.Size = new System.Drawing.Size(380, 328);
            this.libSpots.TabIndex = 43;
            // 
            // gbEnterCamping
            // 
            this.gbEnterCamping.Controls.Add(this.label14);
            this.gbEnterCamping.Controls.Add(this.textBox1);
            this.gbEnterCamping.Controls.Add(this.lbCanEnter);
            this.gbEnterCamping.Controls.Add(this.tbVisitorName);
            this.gbEnterCamping.Controls.Add(this.label12);
            this.gbEnterCamping.Controls.Add(this.label13);
            this.gbEnterCamping.Controls.Add(this.tbVisitorBalance);
            this.gbEnterCamping.Location = new System.Drawing.Point(884, 68);
            this.gbEnterCamping.Name = "gbEnterCamping";
            this.gbEnterCamping.Size = new System.Drawing.Size(366, 304);
            this.gbEnterCamping.TabIndex = 44;
            this.gbEnterCamping.TabStop = false;
            this.gbEnterCamping.Text = "Enter camping";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 25);
            this.label14.TabIndex = 74;
            this.label14.Text = "Amount to pay";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(150, 24);
            this.textBox1.TabIndex = 75;
            // 
            // lbCanEnter
            // 
            this.lbCanEnter.AutoSize = true;
            this.lbCanEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCanEnter.Location = new System.Drawing.Point(21, 268);
            this.lbCanEnter.Name = "lbCanEnter";
            this.lbCanEnter.Size = new System.Drawing.Size(316, 29);
            this.lbCanEnter.TabIndex = 73;
            this.lbCanEnter.Text = "The current visitor can enter!";
            this.lbCanEnter.Click += new System.EventHandler(this.lbCanEnter_Click);
            // 
            // tbVisitorName
            // 
            this.tbVisitorName.Location = new System.Drawing.Point(5, 64);
            this.tbVisitorName.Name = "tbVisitorName";
            this.tbVisitorName.ReadOnly = true;
            this.tbVisitorName.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorName.TabIndex = 72;
            // 
            // btEnterState
            // 
            this.btEnterState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEnterState.Location = new System.Drawing.Point(896, 12);
            this.btEnterState.Name = "btEnterState";
            this.btEnterState.Size = new System.Drawing.Size(354, 50);
            this.btEnterState.TabIndex = 69;
            this.btEnterState.Text = "Change to check enter state";
            this.btEnterState.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 25);
            this.label12.TabIndex = 71;
            this.label12.Text = "Name of visitor:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 25);
            this.label13.TabIndex = 69;
            this.label13.Text = "Balance of visitor:";
            // 
            // tbVisitorBalance
            // 
            this.tbVisitorBalance.Location = new System.Drawing.Point(5, 118);
            this.tbVisitorBalance.Name = "tbVisitorBalance";
            this.tbVisitorBalance.ReadOnly = true;
            this.tbVisitorBalance.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorBalance.TabIndex = 70;
            // 
            // btConfirmTransaction
            // 
            this.btConfirmTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmTransaction.Location = new System.Drawing.Point(498, 611);
            this.btConfirmTransaction.Name = "btConfirmTransaction";
            this.btConfirmTransaction.Size = new System.Drawing.Size(380, 50);
            this.btConfirmTransaction.TabIndex = 50;
            this.btConfirmTransaction.Text = "Confirm transaction";
            this.btConfirmTransaction.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(493, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "Amount to pay:";
            // 
            // tbPayerAmount
            // 
            this.tbPayerAmount.Location = new System.Drawing.Point(498, 535);
            this.tbPayerAmount.Name = "tbPayerAmount";
            this.tbPayerAmount.ReadOnly = true;
            this.tbPayerAmount.Size = new System.Drawing.Size(150, 24);
            this.tbPayerAmount.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(493, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 25);
            this.label4.TabIndex = 53;
            this.label4.Text = "Balance of payer:";
            // 
            // tbPayerBalance
            // 
            this.tbPayerBalance.Location = new System.Drawing.Point(498, 428);
            this.tbPayerBalance.Name = "tbPayerBalance";
            this.tbPayerBalance.ReadOnly = true;
            this.tbPayerBalance.Size = new System.Drawing.Size(150, 24);
            this.tbPayerBalance.TabIndex = 54;
            // 
            // tbVisitorID6
            // 
            this.tbVisitorID6.Location = new System.Drawing.Point(12, 637);
            this.tbVisitorID6.Name = "tbVisitorID6";
            this.tbVisitorID6.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID6.TabIndex = 55;
            // 
            // tbVisitorID5
            // 
            this.tbVisitorID5.Location = new System.Drawing.Point(12, 607);
            this.tbVisitorID5.Name = "tbVisitorID5";
            this.tbVisitorID5.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID5.TabIndex = 56;
            // 
            // tbVisitorID4
            // 
            this.tbVisitorID4.Location = new System.Drawing.Point(12, 577);
            this.tbVisitorID4.Name = "tbVisitorID4";
            this.tbVisitorID4.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID4.TabIndex = 57;
            // 
            // tbVisitorID3
            // 
            this.tbVisitorID3.Location = new System.Drawing.Point(12, 547);
            this.tbVisitorID3.Name = "tbVisitorID3";
            this.tbVisitorID3.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID3.TabIndex = 58;
            // 
            // tbVisitorID2
            // 
            this.tbVisitorID2.Location = new System.Drawing.Point(12, 517);
            this.tbVisitorID2.Name = "tbVisitorID2";
            this.tbVisitorID2.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID2.TabIndex = 59;
            // 
            // tbVisitorID1
            // 
            this.tbVisitorID1.Location = new System.Drawing.Point(12, 487);
            this.tbVisitorID1.Name = "tbVisitorID1";
            this.tbVisitorID1.Size = new System.Drawing.Size(150, 24);
            this.tbVisitorID1.TabIndex = 60;
            // 
            // tbPayerID
            // 
            this.tbPayerID.Location = new System.Drawing.Point(12, 428);
            this.tbPayerID.Name = "tbPayerID";
            this.tbPayerID.Size = new System.Drawing.Size(150, 24);
            this.tbPayerID.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 25);
            this.label5.TabIndex = 62;
            this.label5.Text = "Payer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 18);
            this.label6.TabIndex = 63;
            this.label6.Text = "Visitor 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 18);
            this.label7.TabIndex = 64;
            this.label7.Text = "Visitor 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 550);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 18);
            this.label8.TabIndex = 65;
            this.label8.Text = "Visitor 3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 580);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 18);
            this.label9.TabIndex = 66;
            this.label9.Text = "Visitor 4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 610);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 18);
            this.label10.TabIndex = 67;
            this.label10.Text = "Visitor 5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 640);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 18);
            this.label11.TabIndex = 68;
            this.label11.Text = "Visitor 6";
            // 
            // Camping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btEnterState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPayerID);
            this.Controls.Add(this.tbVisitorID1);
            this.Controls.Add(this.tbVisitorID2);
            this.Controls.Add(this.tbVisitorID3);
            this.Controls.Add(this.tbVisitorID4);
            this.Controls.Add(this.tbVisitorID5);
            this.Controls.Add(this.tbVisitorID6);
            this.Controls.Add(this.tbPayerBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPayerAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btConfirmTransaction);
            this.Controls.Add(this.gbEnterCamping);
            this.Controls.Add(this.libSpots);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Camping";
            this.Text = "Camping Application";
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.gbEnterCamping.ResumeLayout(false);
            this.gbEnterCamping.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox libSpots;
        private System.Windows.Forms.GroupBox gbEnterCamping;
        private System.Windows.Forms.Button btConfirmTransaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPayerAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPayerBalance;
        private System.Windows.Forms.TextBox tbVisitorID6;
        private System.Windows.Forms.TextBox tbVisitorID5;
        private System.Windows.Forms.TextBox tbVisitorID4;
        private System.Windows.Forms.TextBox tbVisitorID3;
        private System.Windows.Forms.TextBox tbVisitorID2;
        private System.Windows.Forms.TextBox tbVisitorID1;
        private System.Windows.Forms.TextBox tbPayerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btEnterState;
        private System.Windows.Forms.TextBox tbVisitorName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbVisitorBalance;
        private System.Windows.Forms.Label lbCanEnter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
    }
}

