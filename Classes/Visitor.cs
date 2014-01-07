using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Visitor
    {
        //fields
        int visitorid;
        String rfid;
        String firstname;
        String lastname;
        Decimal balance;

        //constructor
        public Visitor(int visitorid, String rfid, String firstname, String lastname, Decimal balance)
        {
            this.visitorid = visitorid;
            this.rfid = rfid;
            this.firstname = firstname;
            this.lastname = lastname;
            this.balance = balance;
        }

        //properties
        public int VisitorID { get { return this.visitorid; } }
        public String Rfid { get { return this.rfid; } }
        public String FirstName { get { return this.firstname; } }
        public String LastName { get { return this.lastname; } }
        public Decimal Balance { get { return this.balance; } }

        //methods
        public override string ToString()
        {
            return firstname + " " + lastname;
        }
    }
}
