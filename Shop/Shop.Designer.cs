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
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // libProducts
            // 
            this.libProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libProducts.FormattingEnabled = true;
            this.libProducts.ItemHeight = 15;
            this.libProducts.Location = new System.Drawing.Point(9, 30);
            this.libProducts.Margin = new System.Windows.Forms.Padding(2);
            this.libProducts.Name = "libProducts";
            this.libProducts.Size = new System.Drawing.Size(301, 394);
            this.libProducts.TabIndex = 0;
            this.libProducts.SelectedIndexChanged += new System.EventHandler(this.libProducts_SelectedIndexChanged);
            this.libProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.libProducts_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "All products";
            // 
            // libBasket
            // 
            this.libBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libBasket.FormattingEnabled = true;
            this.libBasket.ItemHeight = 15;
            this.libBasket.Location = new System.Drawing.Point(450, 30);
            this.libBasket.Margin = new System.Windows.Forms.Padding(2);
            this.libBasket.Name = "libBasket";
            this.libBasket.Size = new System.Drawing.Size(301, 394);
            this.libBasket.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Basket";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 431);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seach for product";
            // 
            // tbProductSearch
            // 
            this.tbProductSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductSearch.Location = new System.Drawing.Point(9, 453);
            this.tbProductSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductSearch.Name = "tbProductSearch";
            this.tbProductSearch.Size = new System.Drawing.Size(114, 21);
            this.tbProductSearch.TabIndex = 5;
            this.tbProductSearch.TextChanged += new System.EventHandler(this.tbProductSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 431);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Balance of user";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(629, 431);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total price to pay";
            // 
            // tbCurBalance
            // 
            this.tbCurBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurBalance.Location = new System.Drawing.Point(450, 453);
            this.tbCurBalance.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurBalance.Name = "tbCurBalance";
            this.tbCurBalance.ReadOnly = true;
            this.tbCurBalance.Size = new System.Drawing.Size(114, 21);
            this.tbCurBalance.TabIndex = 9;
            // 
            // tbCurCost
            // 
            this.tbCurCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurCost.Location = new System.Drawing.Point(638, 453);
            this.tbCurCost.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurCost.Name = "tbCurCost";
            this.tbCurCost.ReadOnly = true;
            this.tbCurCost.Size = new System.Drawing.Size(114, 21);
            this.tbCurCost.TabIndex = 10;
            // 
            // btConfirm
            // 
            this.btConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirm.Location = new System.Drawing.Point(450, 496);
            this.btConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(148, 41);
            this.btConfirm.TabIndex = 11;
            this.btConfirm.Text = "Confirm transaction";
            this.btConfirm.UseVisualStyleBackColor = true;
            // 
            // btIncreaseQuantity
            // 
            this.btIncreaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIncreaseQuantity.Location = new System.Drawing.Point(754, 30);
            this.btIncreaseQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.btIncreaseQuantity.Name = "btIncreaseQuantity";
            this.btIncreaseQuantity.Size = new System.Drawing.Size(75, 41);
            this.btIncreaseQuantity.TabIndex = 12;
            this.btIncreaseQuantity.Text = "+";
            this.btIncreaseQuantity.UseVisualStyleBackColor = true;
            // 
            // btDecreaseQuantity
            // 
            this.btDecreaseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDecreaseQuantity.Location = new System.Drawing.Point(754, 76);
            this.btDecreaseQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.btDecreaseQuantity.Name = "btDecreaseQuantity";
            this.btDecreaseQuantity.Size = new System.Drawing.Size(75, 41);
            this.btDecreaseQuantity.TabIndex = 13;
            this.btDecreaseQuantity.Text = "-";
            this.btDecreaseQuantity.UseVisualStyleBackColor = true;
            // 
            // btDeleteItem
            // 
            this.btDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteItem.Location = new System.Drawing.Point(754, 121);
            this.btDeleteItem.Margin = new System.Windows.Forms.Padding(2);
            this.btDeleteItem.Name = "btDeleteItem";
            this.btDeleteItem.Size = new System.Drawing.Size(75, 41);
            this.btDeleteItem.TabIndex = 14;
            this.btDeleteItem.Text = "Delete";
            this.btDeleteItem.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 498);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 64;
            this.label10.Text = "Name of visitor:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(9, 519);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(114, 20);
            this.tbName.TabIndex = 63;
            // 
            // btCancelTransaction
            // 
            this.btCancelTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelTransaction.Location = new System.Drawing.Point(602, 498);
            this.btCancelTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelTransaction.Name = "btCancelTransaction";
            this.btCancelTransaction.Size = new System.Drawing.Size(148, 41);
            this.btCancelTransaction.TabIndex = 65;
            this.btCancelTransaction.Text = "Cancel";
            this.btCancelTransaction.UseVisualStyleBackColor = true;
            this.btCancelTransaction.Click += new System.EventHandler(this.btCancelTransaction_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(341, 167);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 41);
            this.button3.TabIndex = 67;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.button3);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Shop";
            this.Text = "Shop Application";
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
        private System.Windows.Forms.Button button3;
    }
}

