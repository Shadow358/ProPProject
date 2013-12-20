using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BasketItem
    {
        //Fields
        private Product product;
        private int quantity;
        private decimal totalPrice;

        //Constructor
        public BasketItem(Product product, int quantity, decimal totalPrice)
        {
            this.product = product;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
        }

        //Properties
        public Product Product { get { return this.product; } }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public decimal TotalPrice
        {
            get { return this.totalPrice; }
            set { this.totalPrice = value; }
        }

        //Methods
        public override string ToString()
        {
            return this.product.ProductName + " --- price: " + this.product.ProductPrice.ToString() + " --- quantity: " + this.quantity.ToString();
        }
    }
}
