namespace RestockShop
{
    partial class Restock
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
            this.lb_items = new System.Windows.Forms.ListBox();
            this.tb_ShopID = new System.Windows.Forms.TextBox();
            this.tb_Quantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_update = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_productID = new System.Windows.Forms.TextBox();
            this.bt_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_items
            // 
            this.lb_items.FormattingEnabled = true;
            this.lb_items.ItemHeight = 16;
            this.lb_items.Location = new System.Drawing.Point(29, 76);
            this.lb_items.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_items.Name = "lb_items";
            this.lb_items.Size = new System.Drawing.Size(311, 308);
            this.lb_items.TabIndex = 0;
            // 
            // tb_ShopID
            // 
            this.tb_ShopID.Location = new System.Drawing.Point(99, 30);
            this.tb_ShopID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_ShopID.Name = "tb_ShopID";
            this.tb_ShopID.Size = new System.Drawing.Size(51, 22);
            this.tb_ShopID.TabIndex = 1;
            // 
            // tb_Quantity
            // 
            this.tb_Quantity.Location = new System.Drawing.Point(423, 251);
            this.tb_Quantity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_Quantity.Name = "tb_Quantity";
            this.tb_Quantity.Size = new System.Drawing.Size(132, 22);
            this.tb_Quantity.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shop ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity:";
            // 
            // bt_update
            // 
            this.bt_update.Location = new System.Drawing.Point(423, 315);
            this.bt_update.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_update.Name = "bt_update";
            this.bt_update.Size = new System.Drawing.Size(101, 70);
            this.bt_update.TabIndex = 5;
            this.bt_update.Text = "UPDATE";
            this.bt_update.UseVisualStyleBackColor = true;
            this.bt_update.Click += new System.EventHandler(this.bt_update_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Product ID:";
            // 
            // tb_productID
            // 
            this.tb_productID.Location = new System.Drawing.Point(439, 209);
            this.tb_productID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_productID.Name = "tb_productID";
            this.tb_productID.Size = new System.Drawing.Size(55, 22);
            this.tb_productID.TabIndex = 7;
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(189, 27);
            this.bt_load.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(100, 28);
            this.bt_load.TabIndex = 8;
            this.bt_load.Text = "Load Shop";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // Restock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 441);
            this.Controls.Add(this.bt_load);
            this.Controls.Add(this.tb_productID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_update);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Quantity);
            this.Controls.Add(this.tb_ShopID);
            this.Controls.Add(this.lb_items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Restock";
            this.Text = "Restock";
            this.Load += new System.EventHandler(this.Restock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.TextBox tb_ShopID;
        private System.Windows.Forms.TextBox tb_Quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_update;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_productID;
        private System.Windows.Forms.Button bt_load;
    }
}

