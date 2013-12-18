namespace Entrance
{
    partial class Entrance
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btOn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtOff = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbOnOff = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 63;
            this.label2.Text = "Balance of visitor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 62;
            this.label1.Text = "Name of visitor:";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(316, 203);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(94, 32);
            this.lbInfo.TabIndex = 61;
            this.lbInfo.Text = "<info>";
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(322, 147);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            this.tbBalance.Size = new System.Drawing.Size(176, 24);
            this.tbBalance.TabIndex = 60;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(322, 92);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(300, 24);
            this.tbName.TabIndex = 59;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtOff);
            this.groupBox1.Controls.Add(this.btOn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 159);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "On/Off";
            // 
            // BtOff
            // 
            this.BtOff.Location = new System.Drawing.Point(6, 97);
            this.BtOff.Name = "BtOff";
            this.BtOff.Size = new System.Drawing.Size(150, 56);
            this.BtOff.TabIndex = 67;
            this.BtOff.Text = "Turn Scanner Off";
            this.BtOff.UseVisualStyleBackColor = true;
            this.BtOff.Click += new System.EventHandler(this.BtOff_Click);
            // 
            // timer
            // 
            this.timer.Interval = 2500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbOnOff
            // 
            this.lbOnOff.AutoSize = true;
            this.lbOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnOff.Location = new System.Drawing.Point(7, 174);
            this.lbOnOff.Name = "lbOnOff";
            this.lbOnOff.Size = new System.Drawing.Size(80, 25);
            this.lbOnOff.TabIndex = 68;
            this.lbOnOff.Text = "lbOnOff";
            // 
            // Entrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.lbOnOff);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.tbBalance);
            this.Controls.Add(this.tbName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Entrance";
            this.Text = "Entrance Application";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btOn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtOff;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbOnOff;

    }
}

