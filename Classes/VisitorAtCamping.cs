using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class VisitorAtCamping : Visitor
    {
        //Field
        String spotid;

        //Constructor
        public VisitorAtCamping(int visitorid, String rfid, String firstname, String lastname, Decimal balance, String spotid)
            : base(visitorid, rfid, firstname, lastname, balance)
        {
            this.spotid = spotid;
        }

        //Properties
        public String SpotID { get { return this.spotid; } }

        //Methods
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
