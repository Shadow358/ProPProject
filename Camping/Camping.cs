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

        public Camping()
        {
            InitializeComponent();
            dbhelper = new DBHelper();

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

        //This is used so that the reservation can be used in the PaymentForm.
        public CampReservation GetcurrentReservation()
        {
            return this.reservation;
        }

        private void ReadTag(object sender, TagEventArgs e)
        {
            if (btPayBooked.Visible)
            {
                btPayBooked.Visible = false;
            }

            Console.Beep(2500, 200);
            try
            {
                myvisitor = dbhelper.getVisitorCamping(e.Tag);

                if (((VisitorAtCamping)myvisitor).SpotID == -1)
                {
                    Console.Beep(2000, 500);
                    this.BackColor = Color.Orange;
                    lbInfo.Text = "Visitor cannot enter camping!";
                    myRFIDReader.Antenna = false;
                    MessageBox.Show("Visitor does not have a camping spot!");
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
                        tbVisitor.Text = myvisitor.ToString();
                        tbSpotPaidBy.Text = reservation.Visitor.ToString();
                    }
                    else
                    {
                        Console.Beep(2000, 500);
                        this.BackColor = Color.Red;
                        tbSpotid.Text = reservation.SpotID.ToString();
                        tbVisitor.Text = myvisitor.ToString();
                        tbSpotPaidBy.Text = reservation.Visitor.ToString();
                        lbInfo.Text = "Visitor cannot enter yet!";
                        btPayBooked.Visible = true;
                        DialogResult dialogResult = MessageBox.Show("Reservation not (completely) paid.\n" + "Amount to pay: " + (reservation.ShouldBePaid - reservation.AmountPaid) + " Euros.\nClick on 'Pay now'", "Attention", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.Cancel)
                        {
                            btPayBooked.Visible = false;
                            this.BackColor = DefaultBackColor;
                            lbInfo.Text = "Ready to scan a tag...";
                            tbSpotid.Text = "";
                            tbVisitor.Text = "";
                            tbSpotPaidBy.Text = "";
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

        private void btOn_Click(object sender, EventArgs e)
        {
            try
            {
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                myRFIDReader.Antenna = true;
                lbOnOff.Text = "RFID-Reader is ON";
                lbInfo.Text = "Ready to scan a tag...";
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
                myRFIDReader.Antenna = false;
                myRFIDReader.close();
                lbOnOff.Text = "RFID-Reader is OFF";
                lbInfo.Text = "";
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
            this.BackColor = DefaultBackColor;
            lbInfo.Text = "Ready to scan a tag...";
            tbSpotid.Text = "";
            tbVisitor.Text = "";
            tbSpotPaidBy.Text = "";
        }

        private void btPayBooked_Click(object sender, EventArgs e)
        {
            try
            {
                myRFIDReader.Antenna = false;
                myRFIDReader.close();
                lbOnOff.Text = "RFID-Reader is OFF";
                lbInfo.Text = "";
                this.BackColor = DefaultBackColor;

                PaymentForm paymentform = new PaymentForm(reservation, (VisitorAtCamping)myvisitor);
                paymentform.ShowDialog(this);

                btPayBooked.Visible = false;
            }
            catch (PhidgetException)
            {

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
