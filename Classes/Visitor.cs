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
        int visitor_id;
        String rfid;
        String first_name;
        String last_name;
        Decimal balance;

        //constructor
        public Visitor(int visitor_id, String rfid, String first_name, String last_name, Decimal balance)
        {
            this.visitor_id = visitor_id;
            this.rfid = rfid;
            this.first_name = first_name;
            this.last_name = last_name;
            this.balance = balance;
        }

        //properties
        public int Visitor_id { get { return this.visitor_id; } }
        public String Rfid { get { return this.rfid; } }
        public String First_name { get { return this.first_name; } }
        public String Last_name { get { return this.last_name; } }
        public Decimal Balance { get { return this.balance; } }

        //methods
        public override string ToString()
        {
            return first_name + " " + last_name;
        }
    }
}
