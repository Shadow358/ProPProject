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
            this.components = new System.ComponentModel.Container();
            this.tbVisitor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpotid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSpotPaidBy = new System.Windows.Forms.TextBox();
            this.lbOnOff = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOff = new System.Windows.Forms.Button();
            this.btOn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.btCreateNewReservation = new System.Windows.Forms.Button();
            this.btUpdateExistingReservation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVisitor
            // 
            this.tbVisitor.Location = new System.Drawing.Point(12, 281);
            this.tbVisitor.Name = "tbVisitor";
            this.tbVisitor.ReadOnly = true;
            this.tbVisitor.Size = new System.Drawing.Size(209, 24);
            this.tbVisitor.TabIndex = 72;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 25);
            this.label12.TabIndex = 71;
            this.label12.Text = "Visitor:";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(7, 514);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(80, 29);
            this.lbInfo.TabIndex = 73;
            this.lbInfo.Text = "<info>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 74;
            this.label1.Text = "Spot ID:";
            // 
            // tbSpotid
            // 
            this.tbSpotid.Location = new System.Drawing.Point(12, 383);
            this.tbSpotid.Name = "tbSpotid";
            this.tbSpotid.ReadOnly = true;
            this.tbSpotid.Size = new System.Drawing.Size(120, 24);
            this.tbSpotid.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 25);
            this.label2.TabIndex = 76;
            this.label2.Text = "Spot reserved by:";
            // 
            // tbSpotPaidBy
            // 
            this.tbSpotPaidBy.Location = new System.Drawing.Point(12, 451);
            this.tbSpotPaidBy.Name = "tbSpotPaidBy";
            this.tbSpotPaidBy.ReadOnly = true;
            this.tbSpotPaidBy.Size = new System.Drawing.Size(209, 24);
            this.tbSpotPaidBy.TabIndex = 77;
            // 
            // lbOnOff
            // 
            this.lbOnOff.AutoSize = true;
            this.lbOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnOff.Location = new System.Drawing.Point(7, 174);
            this.lbOnOff.Name = "lbOnOff";
            this.lbOnOff.Size = new System.Drawing.Size(80, 25);
            this.lbOnOff.TabIndex = 79;
            this.lbOnOff.Text = "lbOnOff";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btOff);
            this.groupBox1.Controls.Add(this.btOn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 159);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "On/Off";
            // 
            // btOff
            // 
            this.btOff.Location = new System.Drawing.Point(6, 97);
            this.btOff.Name = "btOff";
            this.btOff.Size = new System.Drawing.Size(150, 56);
            this.btOff.TabIndex = 67;
            this.btOff.Text = "Turn Scanner Off";
            this.btOff.UseVisualStyleBackColor = true;
            this.btOff.Click += new System.EventHandler(this.btOff_Click);
            // 
            // btOn
            // 
            this.btOn.Location = new System.Drawing.Point(6, 35);
            this.btOn.Name = "btOn";
            this.btOn.Size = new System.Drawing.Size(150, 56);
            this.btOn.TabIndex = 65;
            this.btOn.Text = "Turn Scanner On";
            this.btOn.UseVisualStyleBackColor = true;
            this.btOn.Click += new System.EventHandler(this.btOn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 2500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(12, 311);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            this.tbBalance.Size = new System.Drawing.Size(120, 24);
            this.tbBalance.TabIndex = 81;
            // 
            // btCreateNewReservation
            // 
            this.btCreateNewReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreateNewReservation.Location = new System.Drawing.Point(1039, 12);
            this.btCreateNewReservation.Name = "btCreateNewReservation";
            this.btCreateNewReservation.Size = new System.Drawing.Size(211, 153);
            this.btCreateNewReservation.TabIndex = 82;
            this.btCreateNewReservation.Text = "Create New Reservation";
            this.btCreateNewReservation.UseVisualStyleBackColor = true;
            this.btCreateNewReservation.Click += new System.EventHandler(this.btCreateNewReservation_Click);
            // 
            // btUpdateExistingReservation
            // 
            this.btUpdateExistingReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdateExistingReservation.Location = new System.Drawing.Point(1039, 171);
            this.btUpdateExistingReservation.Name = "btUpdateExistingReservation";
            this.btUpdateExistingReservation.Size = new System.Drawing.Size(211, 153);
            this.btUpdateExistingReservation.TabIndex = 83;
            this.btUpdateExistingReservation.Text = "Update Existing Reservation";
            this.btUpdateExistingReservation.UseVisualStyleBackColor = true;
            this.btUpdateExistingReservation.Click += new System.EventHandler(this.btUpdateExistingReservation_Click);
            // 
            // Camping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btUpdateExistingReservation);
            this.Controls.Add(this.btCreateNewReservation);
            this.Controls.Add(this.tbBalance);
            this.Controls.Add(this.lbOnOff);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpotPaidBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSpotid);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbVisitor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Camping";
            this.Text = "Camping Application";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVisitor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSpotid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSpotPaidBy;
        private System.Windows.Forms.Label lbOnOff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.Button btOn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.Button btCreateNewReservation;
        private System.Windows.Forms.Button btUpdateExistingReservation;
    }
}

