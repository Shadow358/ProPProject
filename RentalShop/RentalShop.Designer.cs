namespace RentalShop
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
            this.btReturnItems = new System.Windows.Forms.Button();
            this.btCancelTransaction = new System.Windows.Forms.Button();
            this.btProductsToBasket = new System.Windows.Forms.Button();
            this.libBasket = new System.Windows.Forms.ListBox();
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
            this.SuspendLayout();
            // 
            // btReturnItems
            // 
            this.btReturnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReturnItems.Location = new System.Drawing.Point(1017, 612);
            this.btReturnItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btReturnItems.Name = "btReturnItems";
            this.btReturnItems.Size = new System.Drawing.Size(217, 50);
            this.btReturnItems.TabIndex = 87;
            this.btReturnItems.Text = "Return items";
            this.btReturnItems.UseVisualStyleBackColor = true;
            this.btReturnItems.Click += new System.EventHandler(this.btReturnItems_Click);
            // 
            // btCancelTransaction
            // 
            this.btCancelTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelTransaction.Location = new System.Drawing.Point(814, 612);
            this.btCancelTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancelTransaction.Name = "btCancelTransaction";
            this.btCancelTransaction.Size = new System.Drawing.Size(197, 50);
            this.btCancelTransaction.TabIndex = 86;
            this.btCancelTransaction.Text = "Cancel";
            this.btCancelTransaction.UseVisualStyleBackColor = true;
            this.btCancelTransaction.Click += new System.EventHandler(this.btCancelTransaction_Click);
            // 
            // btProductsToBasket
            // 
            this.btProductsToBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProductsToBasket.Location = new System.Drawing.Point(461, 240);
            this.btProductsToBasket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btProductsToBasket.Name = "btProductsToBasket";
            this.btProductsToBasket.Size = new System.Drawing.Size(100, 50);
            this.btProductsToBasket.TabIndex = 85;
            this.btProductsToBasket.Text = ">>";
            this.btProductsToBasket.UseVisualStyleBackColor = true;
            this.btProductsToBasket.Click += new System.EventHandler(this.btProductsToBasket_Click);
            // 
            // libBasket
            // 
            this.libBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libBasket.FormattingEnabled = true;
            this.libBasket.ItemHeight = 18;
            this.libBasket.Location = new System.Drawing.Point(610, 37);
            this.libBasket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.libBasket.Name = "libBasket";
            this.libBasket.Size = new System.Drawing.Size(400, 472);
            this.libBasket.TabIndex = 84;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 604);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 25);
            this.label8.TabIndex = 83;
            this.label8.Text = "Name of visitor:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(17, 629);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(151, 22);
            this.tbName.TabIndex = 82;
            // 
            // btDeleteItem
            // 
            this.btDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteItem.Location = new System.Drawing.Point(1016, 37);
            this.btDeleteItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDeleteItem.Name = "btDeleteItem";
            this.btDeleteItem.Size = new System.Drawing.Size(100, 50);
            this.btDeleteItem.TabIndex = 81;
            this.btDeleteItem.Text = "Delete";
            this.btDeleteItem.UseVisualStyleBackColor = true;
            this.btDeleteItem.Click += new System.EventHandler(this.btDeleteItem_Click);
            // 
            // btConfirmTransaction
            // 
            this.btConfirmTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmTransaction.Location = new System.Drawing.Point(611, 612);
            this.btConfirmTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btConfirmTransaction.Name = "btConfirmTransaction";
            this.btConfirmTransaction.Size = new System.Drawing.Size(197, 50);
            this.btConfirmTransaction.TabIndex = 80;
            this.btConfirmTransaction.Text = "Confirm transaction";
            this.btConfirmTransaction.UseVisualStyleBackColor = true;
            this.btConfirmTransaction.Click += new System.EventHandler(this.btConfirmTransaction_Click);
            // 
            // tbCurDeposit
            // 
            this.tbCurDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurDeposit.Location = new System.Drawing.Point(863, 543);
            this.tbCurDeposit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCurDeposit.Name = "tbCurDeposit";
            this.tbCurDeposit.ReadOnly = true;
            this.tbCurDeposit.Size = new System.Drawing.Size(151, 24);
            this.tbCurDeposit.TabIndex = 79;
            this.tbCurDeposit.Text = "0.00";
            // 
            // tbCurBalance
            // 
            this.tbCurBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurBalance.Location = new System.Drawing.Point(612, 543);
            this.tbCurBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCurBalance.Name = "tbCurBalance";
            this.tbCurBalance.ReadOnly = true;
            this.tbCurBalance.Size = new System.Drawing.Size(151, 24);
            this.tbCurBalance.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(831, 515);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 25);
            this.label5.TabIndex = 77;
            this.label5.Text = "Total deposit to pay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 76;
            this.label4.Text = "Balance of visitor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(606, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 75;
            this.label2.Text = "Basket";
            // 
            // tbProductSearch
            // 
            this.tbProductSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductSearch.Location = new System.Drawing.Point(17, 543);
            this.tbProductSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbProductSearch.Name = "tbProductSearch";
            this.tbProductSearch.Size = new System.Drawing.Size(151, 24);
            this.tbProductSearch.TabIndex = 74;
            this.tbProductSearch.TextChanged += new System.EventHandler(this.tbProductSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 73;
            this.label3.Text = "Seach for product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 72;
            this.label1.Text = "All rental products";
            // 
            // libProducts
            // 
            this.libProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libProducts.FormattingEnabled = true;
            this.libProducts.ItemHeight = 18;
            this.libProducts.Location = new System.Drawing.Point(16, 37);
            this.libProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.libProducts.Name = "libProducts";
            this.libProducts.Size = new System.Drawing.Size(400, 472);
            this.libProducts.TabIndex = 71;
            this.libProducts.DoubleClick += new System.EventHandler(this.libProducts_DoubleClick);
            // 
            // RentalShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btReturnItems);
            this.Controls.Add(this.btCancelTransaction);
            this.Controls.Add(this.btProductsToBasket);
            this.Controls.Add(this.libBasket);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btDeleteItem);
            this.Controls.Add(this.btConfirmTransaction);
            this.Controls.Add(this.tbCurDeposit);
            this.Controls.Add(this.tbCurBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbProductSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.libProducts);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RentalShop";
            this.Text = "Rental Shop Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btReturnItems;
        private System.Windows.Forms.Button btCancelTransaction;
        private System.Windows.Forms.Button btProductsToBasket;
        private System.Windows.Forms.ListBox libBasket;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName;
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



    }
}

