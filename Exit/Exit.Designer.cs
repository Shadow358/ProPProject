namespace Entrance
{
    partial class Exit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOff = new System.Windows.Forms.Button();
            this.btOn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbOnOff = new System.Windows.Forms.Label();
            this.btCash = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btOff);
            this.groupBox1.Controls.Add(this.btOn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 159);
            this.groupBox1.TabIndex = 73;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 72;
            this.label2.Text = "Balance of visitor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(317, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 25);
            this.label6.TabIndex = 71;
            this.label6.Text = "Name of visitor:";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(316, 203);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(94, 32);
            this.lbInfo.TabIndex = 70;
            this.lbInfo.Text = "<info>";
            // 
            // tbBalance
            // 
            this.tbBalance.Location = new System.Drawing.Point(322, 147);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            this.tbBalance.Size = new System.Drawing.Size(176, 24);
            this.tbBalance.TabIndex = 69;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(322, 92);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(300, 24);
            this.tbName.TabIndex = 68;
            // 
            // lbOnOff
            // 
            this.lbOnOff.AutoSize = true;
            this.lbOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnOff.Location = new System.Drawing.Point(7, 174);
            this.lbOnOff.Name = "lbOnOff";
            this.lbOnOff.Size = new System.Drawing.Size(80, 25);
            this.lbOnOff.TabIndex = 75;
            this.lbOnOff.Text = "lbOnOff";
            // 
            // btCash
            // 
            this.btCash.Location = new System.Drawing.Point(322, 276);
            this.btCash.Name = "btCash";
            this.btCash.Size = new System.Drawing.Size(150, 56);
            this.btCash.TabIndex = 76;
            this.btCash.Text = "Cash out?";
            this.btCash.UseVisualStyleBackColor = true;
            this.btCash.Visible = false;
            this.btCash.Click += new System.EventHandler(this.btCash_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btCash);
            this.Controls.Add(this.lbOnOff);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.tbBalance);
            this.Controls.Add(this.tbName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Exit";
            this.Text = "Exit Application";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.Button btOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbOnOff;
        private System.Windows.Forms.Button btCash;
        private System.Windows.Forms.Timer timer;

    }
}

