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
        DBHelper dbhelper;
        CampReservation reservation;
        Visitor myvisitor;

        //Default constructor
        public PaymentForm()
        {
            InitializeComponent();
        }

        //Constructor
        public PaymentForm(CampReservation reservation, VisitorAtCamping myvisitor)
        {
            this.dbhelper = new DBHelper();
            this.reservation = reservation;
            this.myvisitor = myvisitor;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            tbAmountToPay.Text = (reservation.ShouldBePaid - reservation.AmountPaid).ToString();

            try
            {
                tbVname.Text = myvisitor.ToString();
                tbVbalance.Text = myvisitor.Balance.ToString();
                lbInfo.Text = "This visitor booked the reservation.\n\nClick 'Confirm Payment' to confirm payment.";
            }
            catch (Exception)
            {
                MessageBox.Show("Error, could not start");
            }
        }

        private void btConfirmPayment_Click(object sender, EventArgs e)
        {
            try
            {
                lbInfo.Text = "";

                if (reservation.ShouldBePaid - reservation.AmountPaid > myvisitor.Balance)
                {
                    this.BackColor = Color.Red;
                    MessageBox.Show("Visitor does not have enough money on his/her account.");
                }
                else
                {
                    if (dbhelper.UpdatePaymentCampingAndBalance(myvisitor, reservation.ShouldBePaid - reservation.AmountPaid, reservation.SpotID))
                    {
                        MessageBox.Show("Transaction successful!");
                    }
                    else
                    {
                        Console.Beep(2000, 500);
                        MessageBox.Show("An error has occured, please try again.");
                    }
                }
                this.Dispose();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PaymentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
