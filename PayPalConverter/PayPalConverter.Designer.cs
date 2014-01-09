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
            this.lb_Start.ItemHeight = 16;
            this.lb_Start.Location = new System.Drawing.Point(129, 94);
            this.lb_Start.Margin = new System.Windows.Forms.Padding(4);
            this.lb_Start.Name = "lb_Start";
            this.lb_Start.Size = new System.Drawing.Size(329, 356);
            this.lb_Start.TabIndex = 0;
            // 
            // bt_Process
            // 
            this.bt_Process.Location = new System.Drawing.Point(558, 224);
            this.bt_Process.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Process.Name = "bt_Process";
            this.bt_Process.Size = new System.Drawing.Size(149, 65);
            this.bt_Process.TabIndex = 2;
            this.bt_Process.Text = "Process >>";
            this.bt_Process.UseVisualStyleBackColor = true;
            this.bt_Process.Click += new System.EventHandler(this.bt_Process_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input:";
            // 
            // lb_End
            // 
            this.lb_End.FormattingEnabled = true;
            this.lb_End.ItemHeight = 16;
            this.lb_End.Location = new System.Drawing.Point(805, 94);
            this.lb_End.Margin = new System.Windows.Forms.Padding(4);
            this.lb_End.Name = "lb_End";
            this.lb_End.Size = new System.Drawing.Size(329, 356);
            this.lb_End.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(801, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output:";
            // 
            // PayPalConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_End);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Process);
            this.Controls.Add(this.lb_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PayPalConverter";
            this.Text = "PayPal Converter";
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

