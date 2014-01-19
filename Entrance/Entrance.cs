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

namespace Entrance
{
    public partial class Entrance : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        Visitor myvisitor;

        public Entrance()
        {
            InitializeComponent();
            //create dbHelper --> database connection and methods.
            dbhelper = new DBHelper();

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
        /// Each time a tag comes close the the RFID-Reader it reads the tag and check if a visitor have paid and can enter the event or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">e.Tag is the string of the tag to be read.</param>
        private void ReadTag(object sender, TagEventArgs e)
        {
            //if timer is still running, stop it before a visitor's tag is read.
            timer.Stop();
            try
            {
                Console.Beep(2500, 200);
                //scanned visitor.
                myvisitor = dbhelper.GetVisitorEntrance(e.Tag);
                tbName.Text = myvisitor.ToString();
                tbBalance.Text = myvisitor.Balance.ToString();

                //if visitor is not inside.
                if (((VisitorAtEntrance)myvisitor).Inside == false)
                {
                    //if visitor's balance is more then 0.
                    if (myvisitor.Balance >= 0)
                    {
                        if (dbhelper.EnterEvent(myvisitor))
                        {
                            this.BackColor = Color.Green;
                            lbInfo.Text = "Visitor can enter!";
                            timer.Start();
                        }
                    }
                    //else visitor's balance is less then 0, means that he/she did not pay (fully) for ticket.
                    else
                    {
                        Console.Beep(2000, 500);
                        tbBalance.Text = "";
                        lbInfo.Text = "Visitor cannot enter yet!";
                        this.BackColor = Color.Orange;
                        myRFIDReader.Antenna = false;
                        DialogResult dialogResult = MessageBox.Show
                            ("Visitor did not pay (whole) ticket for event.\nClick OK if visitor wants to pay cash now.",
                            "Pay to enter...", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            PayEntrance payentrance = new PayEntrance(((VisitorAtEntrance)myvisitor));
                            payentrance.ShowDialog(this);
                        }
                        myRFIDReader.Antenna = true;
                        ClearReset();
                    }
                }
                //If visitor is already inside the event.
                else
                {
                    Console.Beep(2000, 500);
                    lbInfo.Text = "Visitor cannot enter!";
                    this.BackColor = Color.Red;
                    myRFIDReader.Antenna = false;
                    MessageBox.Show("Visitor already inside!");
                    myRFIDReader.Antenna = true;
                    ClearReset();
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
        /// When button ON is clicked, open the RFID reader, make antenna true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When button OFF is clicked, make antenna of the RFID false, and close RFID reader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ///If user try to turn Reader OFF and there is no Reader to turn off.
                ///Catch the PhidgetException, but do not notify user.
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// timer tick, stops the timer and perform the method ClearReset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            ClearReset();
        }

        /// <summary>
        /// Clears color, and labels and make myvisitor null.
        /// </summary>
        public void ClearReset()
        {
            lbInfo.Text = "Ready to scan a tag...";
            this.BackColor = DefaultBackColor;
            tbBalance.Text = "";
            tbName.Text = "";
            myvisitor = null;
        }
    }
}