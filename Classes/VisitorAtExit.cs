using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class VisitorAtExit : VisitorAtEntrance
    {
        //database connection & all queries to database
        DBHelper dbhelper = new DBHelper();

        //fields
        int countnotreturnedArticles;

        //constructor
        public VisitorAtExit(int visitor_id, String rfid, String first_name, String last_name, Decimal balance, bool inside)
            : base(visitor_id, rfid, first_name, last_name, balance, inside)
        {
            this.countnotreturnedArticles = dbhelper.countArticlesNotReturned(this);
        }

        //properties
        public int CountNotReturnedArticles { get { return this.countnotreturnedArticles; } }

        //methosds
        public override string ToString()
        {
            return base.ToString();
        }
    }
}