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
        public VisitorAtExit(int visitorid, String rfid, String firstname, String lastname, Decimal balance, bool inside)
            : base(visitorid, rfid, firstname, lastname, balance, inside)
        {
            this.countnotreturnedArticles = dbhelper.CountArticlesNotReturned(this);
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