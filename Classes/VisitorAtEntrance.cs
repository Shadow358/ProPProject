using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class VisitorAtEntrance : Visitor
    {
        //fields
        bool? inside;

        //constructor
        public VisitorAtEntrance(int visitorid, String rfid, String firstname, String lastname, Decimal balance, bool inside)
            : base(visitorid, rfid, firstname, lastname, balance)
        {
            this.inside = inside;
        }

        //properties
        public bool? Inside { get { return this.inside; } }

        //methosds
        public override string ToString()
        {
            return base.ToString();
        }
    }
}