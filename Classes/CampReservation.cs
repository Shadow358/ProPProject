using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class CampReservation
    {
        //Field
        int bookingid;
        VisitorAtCamping visitor;
        DateTime bookingdate;
        String spotid;
        Decimal shouldbepaid;
        Decimal amountpaid;

        //Constructor
        public CampReservation(int bookingid, VisitorAtCamping visitor, DateTime bookingdate, String spotid, Decimal shouldbepaid, Decimal amountpaid)
        {
            this.bookingid = bookingid;
            this.visitor = visitor;
            this.bookingdate = bookingdate;
            this.spotid = spotid;
            this.shouldbepaid = shouldbepaid;
            this.amountpaid = amountpaid;
        }

        //Properties
        public int BookingID { get { return this.bookingid; } }
        public Visitor Visitor { get { return this.visitor; } }
        public DateTime BookingDate { get { return this.bookingdate; } }
        public String SpotID { get { return this.spotid; } }
        public Decimal ShouldBePaid { get { return this.shouldbepaid; } }
        public Decimal AmountPaid { get { return this.amountpaid; } }

        //Methods
        public override String ToString()
        {
            return "Date booked: " + BookingDate.Date.ToString("dd-M-yyyy") + " - reserved by: " + visitor.ToString() + " - spotID : " + SpotID;
        }
    }
}
