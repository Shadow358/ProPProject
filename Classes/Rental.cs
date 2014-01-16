using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Rental : Product
    {
        //Fields
        private string comment;

        //Constructor
        public Rental(int productID, decimal productPrice, string productName, int availability, string comment)
            : base(productID, productPrice, productName, availability)
        {
            this.comment = comment;
        }
        
        //Properties
        public string Comment {
            get { return this.comment; }
            set { this.comment = value; }
        }

        //Methods
        public override string ToString()
        {
            string info = ("productID: " + base.ProductID.ToString() + ", " + base.ProductName + ", " + base.ProductPrice.ToString() + ", " + this.comment);
            return info;
        }
    }
}
