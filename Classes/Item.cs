using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Item
    {
        //Fields
        private int itemID;
        private decimal itemPrice;
        private string itemName;
        private int stockInShop;

        //Constructor
        public Item(int itemID, decimal itemPrice, string itemName, int stockInShop)
        {
            this.itemID = itemID;
            this.itemPrice = itemPrice;
            this.itemName = itemName;
            this.stockInShop = stockInShop;
        }

        //Properties
        public int ItemID { get { return this.itemID;}}
        public decimal ItemPrice { get { return this.itemPrice; } }
        public string ItemName { get { return this.itemName; } }
        public int StockInShop { get { return this.stockInShop; }
            set{ this.stockInShop = value; }
        }

        //Methods
        public override string ToString()
        {
            string info = (itemID.ToString() + ", " + itemPrice.ToString() + ", " + itemName + ", stock:" + StockInShop.ToString());
            return info;
        }
    }
}
