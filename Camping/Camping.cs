using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Phidgets;
using Phidgets.Events;
using Classes;

namespace Camping
{
    public partial class Camping : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        Visitor myvisitor;
        CampReservation reservation;
        //This bool is to check if the scanner is on or off.
        bool ScannerOn;

        public Camping()
        {
            InitializeComponent();
            dbhelper = new DBHelper();
            //When camping instance is created, the ScannerOn is set to false.
            ScannerOn = false;

            ///Create a RFID object
            ///Event for Tag (reading tag)
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
                lbOnOff.Text = "RFID-Reader is OFF";
                lbInfo.Text = "";
            }
            catch (PhidgetException)
            {
                lbOnOff.Text = "Error, could not start";
            }
        }

        /// <summary>
        /// When a RFID comes close the the RFID Scanner it scannes it.
        /// Check if the visitor can enter the Camping Area or not.
        /// If visitor SPOTID is 'NULL', then the visitor does not have a camping spot id and cannot enter.
        /// If visitor has a spotid, check if the spot is fully paid, if it is then the visitor can enter, if not
        /// then the reservation has to be paid for.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadTag(object sender, TagEventArgs e)
        {
            timer.Stop();
            ClearReset();

            Console.Beep(2500, 200);
            try
            {
                myvisitor = dbhelper.GetVisitorCamping(e.Tag);

                if (((VisitorAtCamping)myvisitor).SpotID == "NULL")
                {
                    tbBalance.Text = myvisitor.Balance.ToString();
                    tbVisitor.Text = myvisitor.ToString();
                    Console.Beep(2000, 500);
                    this.BackColor = Color.Orange;
                    lbInfo.Text = "Visitor cannot enter camping!";
                    myRFIDReader.Antenna = false;
                    MessageBox.Show("Visitor does not have a camping spot!");
                    ClearReset();
                    lbInfo.Text = "Ready to scan a tag...";
                    myRFIDReader.Antenna = true;
                }
                else
                {
                    //If visitor has an spotid and if the reservation is paid for completely.
                    reservation = dbhelper.GetCampingReservation(((VisitorAtCamping)myvisitor).SpotID);
                    if (reservation.AmountPaid == reservation.ShouldBePaid)
                    {
                        timer.Start();
                        this.BackColor = Color.Green;
                        lbInfo.Text = "Visitor can enter camping!";
                        tbSpotid.Text = reservation.SpotID.ToString();
                        tbBalance.Text = myvisitor.Balance.ToString();
                        tbVisitor.Text = myvisitor.ToString();
                        tbSpotPaidBy.Text = reservation.Visitor.ToString();
                    }
                    //if the reservation is not fully paid.
                    else
                    {
                        Console.Beep(2000, 500);
                        this.BackColor = Color.Red;
                        tbSpotid.Text = reservation.SpotID.ToString();
                        tbBalance.Text = myvisitor.Balance.ToString();
                        tbVisitor.Text = myvisitor.ToString();
                        tbSpotPaidBy.Text = reservation.Visitor.ToString();
                        lbInfo.Text = "Visitor cannot enter yet...!";

                        DialogResult dialogResult = MessageBox.Show("Reservation not (completely) paid.\n" + "Amount to pay: " + (reservation.ShouldBePaid - reservation.AmountPaid) + " Euros.\nClick 'OK' to check who can pay.", "Attention", MessageBoxButtons.OKCancel);
                        //Dialog: if clicked OK, continue to go to payment.
                        if (dialogResult == DialogResult.OK)
                        {
                            //If visitor is the one who booked the reservation then an instance of the payment form is created 
                            //and the visitor can continue to pay the reservation.
                            if (reservation.Visitor.VisitorID == myvisitor.VisitorID)
                            {
                                lbOnOff.Text = "RFID-Reader is OFF";
                                lbInfo.Text = "";
                                ClearReset();

                                PaymentForm paymentform = new PaymentForm(reservation, (VisitorAtCamping)myvisitor);
                                paymentform.ShowDialog(this);

                                lbOnOff.Text = "RFID-Reader is ON";
                                lbInfo.Text = "Ready to scan a tag...";
                            }
                            //If visitor is not the one who booked the reservation then a message is shown to the user.
                            else
                            {
                                MessageBox.Show("Camping reservation not booked by this visitor.\nPlease scan reservation visitor (" + reservation.Visitor.ToString() + ") for payment.");
                                lbInfo.Text = "Ready to scan a tag...";
                                ClearReset();
                            }
                        }

                        //Dialog: if clicked Cancel, then clear the textboxes.
                        if (dialogResult == DialogResult.Cancel)
                        {
                            lbInfo.Text = "Ready to scan a tag...";
                            ClearReset();
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error, something went wrong when connecting to the database.\nPlease try again.");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No visitor found with this tag.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error, something went wrong.\nPlease try again.");
            }
        }

        /// <summary>
        /// Clear the textboxes and make the formcolor to default.
        /// </summary>
        public void ClearReset()
        {
            tbSpotid.Clear();
            tbBalance.Clear();
            tbVisitor.Clear();
            tbSpotPaidBy.Clear();
            this.BackColor = DefaultBackColor;
        }

        /// <summary>
        /// This method is to open the RFID reader and make the antenna true
        /// it also make the ScannerOn the the oposite bool.
        /// </summary>
        public void ScanOn()
        {
            myRFIDReader.open();
            myRFIDReader.waitForAttachment(3000);
            myRFIDReader.Antenna = true;
            ScannerOn = !ScannerOn;
        }

        /// <summary>
        /// This method is to make the antenna of the RFID reader false an also close the RFID reader.
        /// It also make the ScannerOn the the oposite bool.
        /// </summary>
        public void ScanOff()
        {
            myRFIDReader.Antenna = false;
            myRFIDReader.close();
            ScannerOn = !ScannerOn;
        }

        /// <summary>
        /// When button ON is clicked, open the RFID reader, make antenna true.
        /// clear the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ScannerOn == false)
                {
                    ScanOn();
                }

                lbOnOff.Text = "RFID-Reader is ON";
                lbInfo.Text = "Ready to scan a tag...";
                ClearReset();
            }
            catch (PhidgetException)
            {
                MessageBox.Show("no RFID-reader opened.");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// When button OFF is clicked, make antenna of the RFID false, and close RFID reader.
        /// clear the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (ScannerOn)
                {
                    ScanOff();
                }
                lbOnOff.Text = "RFID-Reader is OFF";
                lbInfo.Text = "";
                ClearReset();
            }
            catch (PhidgetException)
            {

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// timer tickes. Stop the timer and clear the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            lbInfo.Text = "Ready to scan a tag...";
            ClearReset();
        }

        /// <summary>
        /// When button is clicked, if scanner is still on, turn off, clear textboxes and create an instance of the ReservationForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreateNewReservation_Click(object sender, EventArgs e)
        {
            timer.Stop();
            try
            {
                if (ScannerOn)
                {
                    ScanOff();
                }

                lbOnOff.Text = "RFID-Reader is OFF";
                lbInfo.Text = "";
                ClearReset();

                ReservationForm reservationform = new ReservationForm();
                reservationform.ShowDialog(this);
            }
            catch (PhidgetException x)
            {
                MessageBox.Show(x.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, please try again.");
            }
        }

        /// <summary>
        /// When button is clicked, if scanner is still on, turn off, clear textboxes.
        /// If there does not exist a reseration, show a message that there are no reservations available.
        /// else, create an instance of the Reservations form and pass with it in the constructor the list of the reservations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btUpdateExistingReservation_Click(object sender, EventArgs e)
        {
            timer.Stop();
            try
            {
                if (ScannerOn)
                {
                    ScanOff();
                }

                lbOnOff.Text = "RFID-Reader is OFF";
                lbInfo.Text = "";
                ClearReset();

                List<CampReservation> allreservations = dbhelper.GetAllReservations();

                if (allreservations.Count == 0)
                {
                    MessageBox.Show("There are no camping reservations!");
                }
                else
                {
                    Reservations loadreservations = new Reservations(allreservations);
                    loadreservations.ShowDialog(this);
                }
            }
            catch (PhidgetException x)
            {
                MessageBox.Show(x.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, please try again.");
            }
        }
    }
}
