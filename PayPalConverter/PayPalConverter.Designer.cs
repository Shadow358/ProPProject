namespace PayPalConverter
{
    partial class PayPalConverter
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
            this.lb_Start = new System.Windows.Forms.ListBox();
            this.bt_Process = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_End = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Start
            // 
            this.lb_Start.FormattingEnabled = true;
            this.lb_Start.Location = new System.Drawing.Point(97, 76);
            this.lb_Start.Name = "lb_Start";
            this.lb_Start.Size = new System.Drawing.Size(248, 290);
            this.lb_Start.TabIndex = 0;
            // 
            // bt_Process
            // 
            this.bt_Process.Location = new System.Drawing.Point(389, 180);
            this.bt_Process.Name = "bt_Process";
            this.bt_Process.Size = new System.Drawing.Size(112, 53);
            this.bt_Process.TabIndex = 2;
            this.bt_Process.Text = "Process >>";
            this.bt_Process.UseVisualStyleBackColor = true;
            this.bt_Process.Click += new System.EventHandler(this.bt_Process_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input:";
            // 
            // lb_End
            // 
            this.lb_End.FormattingEnabled = true;
            this.lb_End.Location = new System.Drawing.Point(558, 76);
            this.lb_End.Name = "lb_End";
            this.lb_End.Size = new System.Drawing.Size(248, 290);
            this.lb_End.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output:";
            // 
            // PayPalConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 436);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_End);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Process);
            this.Controls.Add(this.lb_Start);
            this.Name = "PayPalConverter";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Start;
        private System.Windows.Forms.Button bt_Process;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_End;
        private System.Windows.Forms.Label label2;
    }
}

