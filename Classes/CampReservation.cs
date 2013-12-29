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
        int bookingID;
        VisitorAtCamping visitor;
        DateTime bookingDate;
        String spotID;
        Decimal shouldbePaid;
        Decimal amountPaid;

        //Constructor
        public CampReservation(int bookingID, VisitorAtCamping visitor, DateTime bookingDate, String spotID, Decimal shouldbePaid, Decimal amountPaid)
        {
            this.bookingID = bookingID;
            this.visitor = visitor;
            this.bookingDate = bookingDate;
            this.spotID = spotID;
            this.shouldbePaid = shouldbePaid;
            this.amountPaid = amountPaid;
        }

        //Properties
        public int BookingID { get { return this.bookingID; } }
        public Visitor Visitor { get { return this.visitor; } }
        public DateTime BookingDate { get { return this.bookingDate; } }
        public String SpotID { get { return this.spotID; } }
        public Decimal ShouldBePaid { get { return this.shouldbePaid; } }
        public Decimal AmountPaid { get { return this.amountPaid; } }

        //Methods
        public override String ToString()
        {
            return "Date booked: " + BookingDate.Date.ToString("dd-M-yyyy") + " - reserved by: " + visitor.ToString() + " - spotID : " + SpotID;
        }
    }
}
