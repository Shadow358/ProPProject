using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class VisitorAtEntrance : Visitor
    {
        //database connection & all queries to database
        DBHelper dbhelper = new DBHelper();

        //fields
        bool? inside;

        //constructor
        public VisitorAtEntrance(int visitor_id, String rfid, String first_name, String last_name, Decimal balance, bool inside)
            : base(visitor_id, rfid, first_name, last_name, balance)
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

        public bool enterEvent()
        {
            if (dbhelper.enterEvent(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
