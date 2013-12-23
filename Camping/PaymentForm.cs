using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using Classes;

namespace Camping
{
    public partial class PaymentForm : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        CampReservation reservation;
        Visitor myvisitor;
        bool ScannerOn;

        //Default constructor...
        public PaymentForm()
        {
            InitializeComponent();
        }

        //Constructor passing the reservation information...
        public PaymentForm(CampReservation reservation, VisitorAtCamping myvisitor)
        {
            this.dbhelper = new DBHelper();
            this.reservation = reservation;
            this.myvisitor = myvisitor;

            InitializeComponent();
            ScannerOn = false;
            tbAmountToPay.Text = (reservation.ShouldBePaid - reservation.AmountPaid).ToString();

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
                lbInfo.Text = "";

                if (myvisitor.Visitor_id == reservation.Visitor.Visitor_id)
                {
                    tbVname.Text = myvisitor.ToString();
                    tbVbalance.Text = myvisitor.Balance.ToString();
                    lbInfo.ForeColor = Color.Green;
                    lbInfo.Text = "Click 'Pay'";
                }
                else
                {
                    btPay.Visible = false;
                    btScan.Visible = true;
                    lbInfo.ForeColor = Color.Red;
                    lbInfo.Text = "Camping reservation not booked by this visitor\nPlease click 'Start Scanner' to scan reservation visitor\n(" + reservation.Visitor.ToString() + ")";
                }
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error, could not start");
            }
        }

        private void ReadTag(object sender, TagEventArgs e)
        {
            this.BackColor = DefaultBackColor;
            Console.Beep(2500, 200);
            try
            {
                myvisitor = dbhelper.getVisitorCamping(e.Tag);
                tbVname.Text = myvisitor.ToString();
                tbVbalance.Text = myvisitor.Balance.ToString();

                if (myvisitor.Visitor_id == reservation.Visitor.Visitor_id)
                {
                    btPay.Visible = true;
                    lbInfo.ForeColor = Color.Green;
                    lbInfo.Text = "Click 'Pay'";
                }
                else
                {
                    btPay.Visible = false;
                    lbInfo.ForeColor = Color.Red;
                    lbInfo.Text = "Camping reservation not booked by this visitor\nPlease scan reservation visitor\n(" + reservation.Visitor.ToString() + ")";
                }
            }
            catch (NullReferenceException x)
            {
                MessageBox.Show(x.Message);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btScan_Click(object sender, EventArgs e)
        {
            if (ScannerOn == false)
            {
                btScan.Text = "Stop Scanner";
                ScanOn();
            }
            else
            {
                btScan.Text = "Start Scanner";
                ScanOff();
            }
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }
            if (reservation.ShouldBePaid - reservation.AmountPaid > myvisitor.Balance)
            {
                lbInfo.Text = "";
                this.BackColor = Color.Red;
                MessageBox.Show("Visitor does not have enough money on his/her account.");
                this.Dispose();
            }
            else
            {
                lbInfo.Text = "";
                this.BackColor = Color.Green;
                DialogResult confirm = MessageBox.Show("Click OK to confirm payment or Cancel to cancel this transaction.", "Confirm", MessageBoxButtons.OKCancel);
                if (confirm == DialogResult.OK)
                {
                    if (dbhelper.PayCampingSpot(reservation.ShouldBePaid - reservation.AmountPaid) && dbhelper.RemoveMoneyFromBalance(myvisitor, (reservation.ShouldBePaid - reservation.AmountPaid)))
                    {
                        MessageBox.Show("Transaction successfully");
                        this.Dispose();
                    }
                    else
                    {
                        this.BackColor = Color.Red;
                        MessageBox.Show("Transaction unsuccessfully");
                        myRFIDReader.Antenna = true;
                        this.BackColor = DefaultBackColor;
                        lbInfo.Text = "";
                    }

                }
                if (confirm == DialogResult.Cancel)
                {
                    MessageBox.Show("Transaction Canceled");
                    this.Dispose();
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }
            this.Dispose();
        }

        private void PaymentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }
            this.Dispose();
        }

        public void ScanOn()
        {
            myRFIDReader.open();
            myRFIDReader.waitForAttachment(3000);
            myRFIDReader.Antenna = true;
            ScannerOn = !ScannerOn;
        }

        public void ScanOff()
        {
            myRFIDReader.Antenna = false;
            myRFIDReader.close();
            ScannerOn = !ScannerOn;
        }
    }
}
