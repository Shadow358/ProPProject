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
    public partial class Camping : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        Visitor myvisitor;
        CampReservation reservation;
        bool ScannerOn;

        public Camping()
        {
            InitializeComponent();
            dbhelper = new DBHelper();
            ScannerOn = false;

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

        private void ReadTag(object sender, TagEventArgs e)
        {
            timer.Stop();
            ClearReset();

            Console.Beep(2500, 200);
            try
            {
                myvisitor = dbhelper.getVisitorCamping(e.Tag);

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
                    reservation = dbhelper.getCampingReservation(((VisitorAtCamping)myvisitor).SpotID);
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

                        if (dialogResult == DialogResult.OK)
                        {
                            if (reservation.Visitor.Visitor_id == myvisitor.Visitor_id)
                            {
                                lbOnOff.Text = "RFID-Reader is OFF";
                                lbInfo.Text = "";
                                ClearReset();

                                PaymentForm paymentform = new PaymentForm(reservation, (VisitorAtCamping)myvisitor);
                                paymentform.ShowDialog(this);

                                lbOnOff.Text = "RFID-Reader is ON";
                                lbInfo.Text = "Ready to scan a tag...";
                            }
                            else
                            {
                                MessageBox.Show("Camping reservation not booked by this visitor.\nPlease scan reservation visitor (" + reservation.Visitor.ToString() + ") for payment.");
                                lbInfo.Text = "Ready to scan a tag...";
                                ClearReset();
                            }
                        }

                        if (dialogResult == DialogResult.Cancel)
                        {
                            lbInfo.Text = "Ready to scan a tag...";
                            ClearReset();
                        }
                    }
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

        public void ClearReset()
        {
            tbSpotid.Clear();
            tbBalance.Clear();
            tbVisitor.Clear();
            tbSpotPaidBy.Clear();
            this.BackColor = DefaultBackColor;
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
            return;
        }

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

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            lbInfo.Text = "Ready to scan a tag...";
            ClearReset();
        }

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
