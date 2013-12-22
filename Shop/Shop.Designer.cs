namespace Shop
{
    partial class Shop
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
            this.libProducts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.libBasket = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProductSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCurBalance = new System.Windows.Forms.TextBox();
            this.tbCurCost = new System.Windows.Forms.TextBox();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btIncreaseQuantity = new System.Windows.Forms.Button();
            this.btDecreaseQuantity = new System.Windows.Forms.Button();
            this.btDeleteItem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btCancelTransaction = new System.Windows.Forms.Button();
            this.btProductsToBasket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // libProducts
            // 
            this.libProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libProducts.FormattingEnabled = true;
            this.libProducts.ItemHeight = 18;
            this.libProducts.Location = new System.Drawing.Point(12, 37);
            this.libProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.libProducts.Name = "libProducts";
            this.libProducts.Size = new System.Drawing.Size(400, 472);
            this.libProducts.TabIndex = 0;
            this.libProducts.DoubleClick += new System.EventHandler(this.libProducts_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "All products";
            // 
            // libBasket
            // 
            this.libBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libBasket.FormattingEnabled = true;
            this.libBasket.ItemHeight = 18;
            this.libBasket.Location = new System.Drawing.Point(600, 37);
            this.libBasket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.libBasket.Name = "libBasket";
            this.libBasket.Size = new System.Drawing.Size(400, 472);
            this.libBasket.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(595, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Basket";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seach for product";
            // 
            // tbProductSearch
            // 
            this.tbProductSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductSearch.Location = new System.Drawing.Point(12, 558);
            this.tbProductSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbProductSearch.Name = "tbProductSearch";
            this.tbProductSearch.Size = new System.Drawing.Size(151, 24);
            this.tbProductSearch.TabIndex = 5;
            this.tbProductSearch.TextChanged += new System.EventHandler(this.tbProductSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(595, 530);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Balance of user";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(839, 530);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total price to pay";
            // 
            // tbCurBalance
            // 
            this.tbCurBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurBalance.Location = new System.Drawing.Point(600, 558);
            this.tbCurBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCurBalance.Name = "tbCurBalance";
            this.tbCurBalance.ReadOnly = true;
            this.tbCurBalance.Size = new System.Drawing.Size(151, 24);
            this.tbCurBalance.TabIndex = 9;
            // 
            // tbCurCost
            // 
            this.tbCurCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurCost.Location = new System.Drawing.Point(851, 558);
            this.tbCurCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCurCost.Name = "tbCurCost";
            this.tbCurCost.ReadOnly = true;
            this.tbCurCost.Size = new System.Drawing.Size(151, 24);
            this.tbCurCost.TabIndex = 10;
            // 
            // btConfirm
            // 
            this.btConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirm.Location = new System.Drawing.Point(600, 610);
            this.btConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(197, 50);
            this.btConfirm.TabIndex = 11;
            this.btConfirm.Text = "Confirm transaction";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // btIncreaseQuantity
            // 
            this.btIncreaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIncreaseQuantity.Location = new System.Drawing.Point(1005, 37);
            this.btIncreaseQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btIncreaseQuantity.Name = "btIncreaseQuantity";
            this.btIncreaseQuantity.Size = new System.Drawing.Size(100, 50);
            this.btIncreaseQuantity.TabIndex = 12;
            this.btIncreaseQuantity.Text = "+";
            this.btIncreaseQuantity.UseVisualStyleBackColor = true;
            this.btIncreaseQuantity.Click += new System.EventHandler(this.btIncreaseQuantity_Click);
            // 
            // btDecreaseQuantity
            // 
            this.btDecreaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDecreaseQuantity.Location = new System.Drawing.Point(1005, 94);
            this.btDecreaseQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDecreaseQuantity.Name = "btDecreaseQuantity";
            this.btDecreaseQuantity.Size = new System.Drawing.Size(100, 50);
            this.btDecreaseQuantity.TabIndex = 13;
            this.btDecreaseQuantity.Text = "-";
            this.btDecreaseQuantity.UseVisualStyleBackColor = true;
            this.btDecreaseQuantity.Click += new System.EventHandler(this.btDecreaseQuantity_Click);
            // 
            // btDeleteItem
            // 
            this.btDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteItem.Location = new System.Drawing.Point(1005, 149);
            this.btDeleteItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDeleteItem.Name = "btDeleteItem";
            this.btDeleteItem.Size = new System.Drawing.Size(100, 50);
            this.btDeleteItem.TabIndex = 14;
            this.btDeleteItem.Text = "Delete";
            this.btDeleteItem.UseVisualStyleBackColor = true;
            this.btDeleteItem.Click += new System.EventHandler(this.btDeleteItem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 613);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 25);
            this.label10.TabIndex = 64;
            this.label10.Text = "Name of visitor:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 639);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(151, 22);
            this.tbName.TabIndex = 63;
            // 
            // btCancelTransaction
            // 
            this.btCancelTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelTransaction.Location = new System.Drawing.Point(805, 610);
            this.btCancelTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancelTransaction.Name = "btCancelTransaction";
            this.btCancelTransaction.Size = new System.Drawing.Size(197, 50);
            this.btCancelTransaction.TabIndex = 65;
            this.btCancelTransaction.Text = "Cancel";
            this.btCancelTransaction.UseVisualStyleBackColor = true;
            this.btCancelTransaction.Click += new System.EventHandler(this.btCancelTransaction_Click);
            // 
            // btProductsToBasket
            // 
            this.btProductsToBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProductsToBasket.Location = new System.Drawing.Point(455, 206);
            this.btProductsToBasket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btProductsToBasket.Name = "btProductsToBasket";
            this.btProductsToBasket.Size = new System.Drawing.Size(100, 50);
            this.btProductsToBasket.TabIndex = 67;
            this.btProductsToBasket.Text = ">>";
            this.btProductsToBasket.UseVisualStyleBackColor = true;
            this.btProductsToBasket.Click += new System.EventHandler(this.btProductsToBasket_Click);
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 673);
            this.Controls.Add(this.btProductsToBasket);
            this.Controls.Add(this.btCancelTransaction);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btDeleteItem);
            this.Controls.Add(this.btDecreaseQuantity);
            this.Controls.Add(this.btIncreaseQuantity);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.tbCurCost);
            this.Controls.Add(this.tbCurBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbProductSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.libBasket);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.libProducts);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Shop";
            this.Text = "Shop Application";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.shop_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox libProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox libBasket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProductSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCurBalance;
        private System.Windows.Forms.TextBox tbCurCost;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btIncreaseQuantity;
        private System.Windows.Forms.Button btDecreaseQuantity;
        private System.Windows.Forms.Button btDeleteItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btCancelTransaction;
        private System.Windows.Forms.Button btProductsToBasket;
    }
}

