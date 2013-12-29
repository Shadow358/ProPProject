namespace RentalShop
{
    partial class ReturnRentals
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
            this.btCancelReturnal = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNameReturn = new System.Windows.Forms.TextBox();
            this.btDeleteReturningItem = new System.Windows.Forms.Button();
            this.btConfirmReturnal = new System.Windows.Forms.Button();
            this.tbMoneyToRestore = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.libProductsRented = new System.Windows.Forms.ListBox();
            this.btProductsToBasket = new System.Windows.Forms.Button();
            this.libItemsRetuning = new System.Windows.Forms.ListBox();
            this.btAddComment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btCancelReturnal
            // 
            this.btCancelReturnal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelReturnal.Location = new System.Drawing.Point(857, 613);
            this.btCancelReturnal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancelReturnal.Name = "btCancelReturnal";
            this.btCancelReturnal.Size = new System.Drawing.Size(154, 50);
            this.btCancelReturnal.TabIndex = 81;
            this.btCancelReturnal.Text = "Cancel";
            this.btCancelReturnal.UseVisualStyleBackColor = true;
            this.btCancelReturnal.Click += new System.EventHandler(this.btCancelReturnal_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 613);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 25);
            this.label10.TabIndex = 79;
            this.label10.Text = "Name of visitor:";
            // 
            // tbNameReturn
            // 
            this.tbNameReturn.Location = new System.Drawing.Point(14, 638);
            this.tbNameReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNameReturn.Name = "tbNameReturn";
            this.tbNameReturn.ReadOnly = true;
            this.tbNameReturn.Size = new System.Drawing.Size(151, 22);
            this.tbNameReturn.TabIndex = 78;
            // 
            // btDeleteReturningItem
            // 
            this.btDeleteReturningItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteReturningItem.Location = new System.Drawing.Point(1016, 37);
            this.btDeleteReturningItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDeleteReturningItem.Name = "btDeleteReturningItem";
            this.btDeleteReturningItem.Size = new System.Drawing.Size(100, 50);
            this.btDeleteReturningItem.TabIndex = 77;
            this.btDeleteReturningItem.Text = "Delete";
            this.btDeleteReturningItem.UseVisualStyleBackColor = true;
            this.btDeleteReturningItem.Click += new System.EventHandler(this.btDeleteReturningItem_Click);
            // 
            // btConfirmReturnal
            // 
            this.btConfirmReturnal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmReturnal.Location = new System.Drawing.Point(609, 613);
            this.btConfirmReturnal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btConfirmReturnal.Name = "btConfirmReturnal";
            this.btConfirmReturnal.Size = new System.Drawing.Size(242, 50);
            this.btConfirmReturnal.TabIndex = 76;
            this.btConfirmReturnal.Text = "Confirm returnal of items";
            this.btConfirmReturnal.UseVisualStyleBackColor = true;
            this.btConfirmReturnal.Click += new System.EventHandler(this.btConfirmReturnal_Click);
            // 
            // tbMoneyToRestore
            // 
            this.tbMoneyToRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMoneyToRestore.Location = new System.Drawing.Point(861, 557);
            this.tbMoneyToRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMoneyToRestore.Name = "tbMoneyToRestore";
            this.tbMoneyToRestore.ReadOnly = true;
            this.tbMoneyToRestore.Size = new System.Drawing.Size(151, 24);
            this.tbMoneyToRestore.TabIndex = 75;
            this.tbMoneyToRestore.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(805, 529);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 25);
            this.label7.TabIndex = 74;
            this.label7.Text = "Total money to restore";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(604, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 25);
            this.label9.TabIndex = 73;
            this.label9.Text = "Items to return";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 25);
            this.label6.TabIndex = 72;
            this.label6.Text = "All items rented";
            // 
            // libProductsRented
            // 
            this.libProductsRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libProductsRented.FormattingEnabled = true;
            this.libProductsRented.ItemHeight = 18;
            this.libProductsRented.Location = new System.Drawing.Point(16, 37);
            this.libProductsRented.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.libProductsRented.Name = "libProductsRented";
            this.libProductsRented.Size = new System.Drawing.Size(400, 472);
            this.libProductsRented.TabIndex = 71;
            this.libProductsRented.DoubleClick += new System.EventHandler(this.libProductsRented_DoubleClick);
            // 
            // btProductsToBasket
            // 
            this.btProductsToBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProductsToBasket.Location = new System.Drawing.Point(461, 240);
            this.btProductsToBasket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btProductsToBasket.Name = "btProductsToBasket";
            this.btProductsToBasket.Size = new System.Drawing.Size(100, 50);
            this.btProductsToBasket.TabIndex = 86;
            this.btProductsToBasket.Text = ">>";
            this.btProductsToBasket.UseVisualStyleBackColor = true;
            this.btProductsToBasket.Click += new System.EventHandler(this.btProductsToBasket_Click);
            // 
            // libItemsRetuning
            // 
            this.libItemsRetuning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libItemsRetuning.FormattingEnabled = true;
            this.libItemsRetuning.ItemHeight = 18;
            this.libItemsRetuning.Location = new System.Drawing.Point(609, 37);
            this.libItemsRetuning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.libItemsRetuning.Name = "libItemsRetuning";
            this.libItemsRetuning.Size = new System.Drawing.Size(400, 472);
            this.libItemsRetuning.TabIndex = 87;
            // 
            // btAddComment
            // 
            this.btAddComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddComment.Location = new System.Drawing.Point(1016, 91);
            this.btAddComment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddComment.Name = "btAddComment";
            this.btAddComment.Size = new System.Drawing.Size(234, 50);
            this.btAddComment.TabIndex = 88;
            this.btAddComment.Text = "Add comment to item";
            this.btAddComment.UseVisualStyleBackColor = true;
            this.btAddComment.Click += new System.EventHandler(this.btAddComment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1015, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 89;
            this.label1.Text = "Comment:";
            // 
            // tbComment
            // 
            this.tbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComment.Location = new System.Drawing.Point(1020, 172);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(230, 24);
            this.tbComment.TabIndex = 90;
            // 
            // ReturnRentals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddComment);
            this.Controls.Add(this.libItemsRetuning);
            this.Controls.Add(this.btProductsToBasket);
            this.Controls.Add(this.btCancelReturnal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbNameReturn);
            this.Controls.Add(this.btDeleteReturningItem);
            this.Controls.Add(this.btConfirmReturnal);
            this.Controls.Add(this.tbMoneyToRestore);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.libProductsRented);
            this.Name = "ReturnRentals";
            this.Text = "ReturnRentals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancelReturnal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNameReturn;
        private System.Windows.Forms.Button btDeleteReturningItem;
        private System.Windows.Forms.Button btConfirmReturnal;
        private System.Windows.Forms.TextBox tbMoneyToRestore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox libProductsRented;
        private System.Windows.Forms.Button btProductsToBasket;
        private System.Windows.Forms.ListBox libItemsRetuning;
        private System.Windows.Forms.Button btAddComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComment;
    }
}