﻿namespace RentalShop
{
    partial class RentalShop
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
            this.tabRenting = new System.Windows.Forms.TabPage();
            this.libRentals = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btDeleteItem = new System.Windows.Forms.Button();
            this.btConfirmTransaction = new System.Windows.Forms.Button();
            this.tbCurDeposit = new System.Windows.Forms.TextBox();
            this.tbCurBalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProductSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.libProducts = new System.Windows.Forms.ListBox();
            this.tabReturning = new System.Windows.Forms.TabPage();
            this.clibItemsRetuning = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNameReturn = new System.Windows.Forms.TextBox();
            this.btDeleteReturningItem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.libProductsRented = new System.Windows.Forms.ListBox();
            this.tcTabs.SuspendLayout();
            this.tabRenting.SuspendLayout();
            this.tabReturning.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTabs
            // 
            this.tcTabs.Controls.Add(this.tabRenting);
            this.tcTabs.Controls.Add(this.tabReturning);
            this.tcTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcTabs.Location = new System.Drawing.Point(10, 11);
            this.tcTabs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(928, 526);
            this.tcTabs.TabIndex = 0;
            // 
            // tabRenting
            // 
            this.tabRenting.Controls.Add(this.libRentals);
            this.tabRenting.Controls.Add(this.label8);
            this.tabRenting.Controls.Add(this.tbName);
            this.tabRenting.Controls.Add(this.btDeleteItem);
            this.tabRenting.Controls.Add(this.btConfirmTransaction);
            this.tabRenting.Controls.Add(this.tbCurDeposit);
            this.tabRenting.Controls.Add(this.tbCurBalance);
            this.tabRenting.Controls.Add(this.label5);
            this.tabRenting.Controls.Add(this.label4);
            this.tabRenting.Controls.Add(this.label2);
            this.tabRenting.Controls.Add(this.tbProductSearch);
            this.tabRenting.Controls.Add(this.label3);
            this.tabRenting.Controls.Add(this.label1);
            this.tabRenting.Controls.Add(this.libProducts);
            this.tabRenting.Location = new System.Drawing.Point(4, 24);
            this.tabRenting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRenting.Name = "tabRenting";
            this.tabRenting.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRenting.Size = new System.Drawing.Size(920, 498);
            this.tabRenting.TabIndex = 0;
            this.tabRenting.Text = "Renting items";
            this.tabRenting.UseVisualStyleBackColor = true;
            // 
            // libRentals
            // 
            this.libRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libRentals.FormattingEnabled = true;
            this.libRentals.ItemHeight = 15;
            this.libRentals.Location = new System.Drawing.Point(450, 28);
            this.libRentals.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.libRentals.Name = "libRentals";
            this.libRentals.Size = new System.Drawing.Size(301, 319);
            this.libRentals.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 427);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 56;
            this.label8.Text = "Name of visitor:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(4, 448);
            this.tbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(114, 21);
            this.tbName.TabIndex = 55;
            // 
            // btDeleteItem
            // 
            this.btDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteItem.Location = new System.Drawing.Point(754, 28);
            this.btDeleteItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteItem.Name = "btDeleteItem";
            this.btDeleteItem.Size = new System.Drawing.Size(75, 41);
            this.btDeleteItem.TabIndex = 52;
            this.btDeleteItem.Text = "Delete";
            this.btDeleteItem.UseVisualStyleBackColor = true;
            // 
            // btConfirmTransaction
            // 
            this.btConfirmTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmTransaction.Location = new System.Drawing.Point(450, 448);
            this.btConfirmTransaction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btConfirmTransaction.Name = "btConfirmTransaction";
            this.btConfirmTransaction.Size = new System.Drawing.Size(300, 41);
            this.btConfirmTransaction.TabIndex = 49;
            this.btConfirmTransaction.Text = "Confirm transaction";
            this.btConfirmTransaction.UseVisualStyleBackColor = true;
            // 
            // tbCurDeposit
            // 
            this.tbCurDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurDeposit.Location = new System.Drawing.Point(638, 378);
            this.tbCurDeposit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCurDeposit.Name = "tbCurDeposit";
            this.tbCurDeposit.ReadOnly = true;
            this.tbCurDeposit.Size = new System.Drawing.Size(114, 21);
            this.tbCurDeposit.TabIndex = 48;
            // 
            // tbCurBalance
            // 
            this.tbCurBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurBalance.Location = new System.Drawing.Point(450, 378);
            this.tbCurBalance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbCurBalance.Name = "tbCurBalance";
            this.tbCurBalance.ReadOnly = true;
            this.tbCurBalance.Size = new System.Drawing.Size(114, 21);
            this.tbCurBalance.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(614, 355);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "Total deposit to pay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 355);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Balance of visitor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Basket";
            // 
            // tbProductSearch
            // 
            this.tbProductSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductSearch.Location = new System.Drawing.Point(4, 378);
            this.tbProductSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbProductSearch.Name = "tbProductSearch";
            this.tbProductSearch.Size = new System.Drawing.Size(114, 21);
            this.tbProductSearch.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 355);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Seach for product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "All rental products";
            // 
            // libProducts
            // 
            this.libProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libProducts.FormattingEnabled = true;
            this.libProducts.ItemHeight = 15;
            this.libProducts.Location = new System.Drawing.Point(4, 28);
            this.libProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.libProducts.Name = "libProducts";
            this.libProducts.Size = new System.Drawing.Size(301, 319);
            this.libProducts.TabIndex = 39;
            this.libProducts.SelectedIndexChanged += new System.EventHandler(this.libProducts_SelectedIndexChanged);
            // 
            // tabReturning
            // 
            this.tabReturning.Controls.Add(this.clibItemsRetuning);
            this.tabReturning.Controls.Add(this.label10);
            this.tabReturning.Controls.Add(this.tbNameReturn);
            this.tabReturning.Controls.Add(this.btDeleteReturningItem);
            this.tabReturning.Controls.Add(this.button2);
            this.tabReturning.Controls.Add(this.textBox1);
            this.tabReturning.Controls.Add(this.label7);
            this.tabReturning.Controls.Add(this.label9);
            this.tabReturning.Controls.Add(this.label6);
            this.tabReturning.Controls.Add(this.libProductsRented);
            this.tabReturning.Location = new System.Drawing.Point(4, 24);
            this.tabReturning.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabReturning.Name = "tabReturning";
            this.tabReturning.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabReturning.Size = new System.Drawing.Size(920, 498);
            this.tabReturning.TabIndex = 1;
            this.tabReturning.Text = "Return items";
            this.tabReturning.UseVisualStyleBackColor = true;
            // 
            // clibItemsRetuning
            // 
            this.clibItemsRetuning.FormattingEnabled = true;
            this.clibItemsRetuning.Location = new System.Drawing.Point(450, 28);
            this.clibItemsRetuning.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clibItemsRetuning.Name = "clibItemsRetuning";
            this.clibItemsRetuning.Size = new System.Drawing.Size(301, 324);
            this.clibItemsRetuning.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 427);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 62;
            this.label10.Text = "Name of visitor:";
            // 
            // tbNameReturn
            // 
            this.tbNameReturn.Location = new System.Drawing.Point(4, 448);
            this.tbNameReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNameReturn.Name = "tbNameReturn";
            this.tbNameReturn.ReadOnly = true;
            this.tbNameReturn.Size = new System.Drawing.Size(114, 21);
            this.tbNameReturn.TabIndex = 61;
            // 
            // btDeleteReturningItem
            // 
            this.btDeleteReturningItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteReturningItem.Location = new System.Drawing.Point(754, 28);
            this.btDeleteReturningItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteReturningItem.Name = "btDeleteReturningItem";
            this.btDeleteReturningItem.Size = new System.Drawing.Size(75, 41);
            this.btDeleteReturningItem.TabIndex = 60;
            this.btDeleteReturningItem.Text = "Delete";
            this.btDeleteReturningItem.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(450, 428);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 41);
            this.button2.TabIndex = 59;
            this.button2.Text = "Confirm retunal of items";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(638, 378);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(114, 21);
            this.textBox1.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(596, 355);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "Total money to restore";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(446, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 20);
            this.label9.TabIndex = 54;
            this.label9.Text = "Items to return";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "All items rented";
            // 
            // libProductsRented
            // 
            this.libProductsRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libProductsRented.FormattingEnabled = true;
            this.libProductsRented.ItemHeight = 15;
            this.libProductsRented.Location = new System.Drawing.Point(4, 28);
            this.libProductsRented.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.libProductsRented.Name = "libProductsRented";
            this.libProductsRented.Size = new System.Drawing.Size(301, 319);
            this.libProductsRented.TabIndex = 41;
            // 
            // RentalShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.tcTabs);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RentalShop";
            this.Text = "Rental Shop Application";
            this.tcTabs.ResumeLayout(false);
            this.tabRenting.ResumeLayout(false);
            this.tabRenting.PerformLayout();
            this.tabReturning.ResumeLayout(false);
            this.tabReturning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tabRenting;
        private System.Windows.Forms.Button btDeleteItem;
        private System.Windows.Forms.Button btConfirmTransaction;
        private System.Windows.Forms.TextBox tbCurDeposit;
        private System.Windows.Forms.TextBox tbCurBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProductSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox libProducts;
        private System.Windows.Forms.TabPage tabReturning;
        private System.Windows.Forms.Button btDeleteReturningItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox libProductsRented;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNameReturn;
        private System.Windows.Forms.ListBox libRentals;
        private System.Windows.Forms.CheckedListBox clibItemsRetuning;


    }
}

