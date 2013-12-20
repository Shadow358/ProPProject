using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Product
    {
        //Fields
        private int productID;
        private decimal productPrice;
        private string productName;
        private int stockInShop;

        //Constructor
        public Product(int productID, decimal productPrice, string productName, int stockInShop)
        {
            this.productID = productID;
            this.productPrice = productPrice;
            this.productName = productName;
            this.stockInShop = stockInShop;
        }

        //Properties
        public int ProductID { get { return this.productID; } }
        public decimal ProductPrice { get { return this.productPrice; } }
        public string ProductName { get { return this.productName; } }
        public int StockInShop
        {
            get { return this.stockInShop; }
            set { this.stockInShop = value; }
        }

        //Methods
        public override string ToString()
        {
            string info = ("productID: " + productID.ToString() + ", " + productName + ", " + productPrice.ToString() + ", quantity: " + StockInShop.ToString());
            return info;
        }
    }
}
