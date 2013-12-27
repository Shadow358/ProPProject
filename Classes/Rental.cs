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
        private int productID;
        private decimal productPrice;
        private string productName;
        private int availability;
        private string comment;

        //Constructor
        public Rental(int productID, decimal productPrice, string productName, int availability, string comment)
            : base(productID, productPrice, productName, availability)
        {
            this.comment = comment;
        }
        
        //Properties
        public string Comment { get { return this.comment; } }

        //Methods
        public override string ToString()
        {
            return base.ToString() + " " + this.comment;
        }
    }
}
