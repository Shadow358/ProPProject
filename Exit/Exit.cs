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
    public partial class Exit : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        Visitor myvisitor;

        public Exit()
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
        /// Each time a tag comes close the the RFID-Reader it reads the tag and check if a visitor can exit or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadTag(object sender, TagEventArgs e)
        {
            try
            {
                //Hide the button Cash and stop timer.
                btCash.Hide();
                timer.Stop();
                //visitor scanned.
                myvisitor = dbhelper.GetVisitorExit(e.Tag);
                Console.Beep(2500, 200);
                tbName.Text = myvisitor.ToString();
                tbBalance.Text = myvisitor.Balance.ToString();
                timer.Start();

                //if visitor has money, then show the button Cash.
                if (myvisitor.Balance > 0)
                {
                    btCash.Show();
                }

                //if visitor is inside.
                if (((VisitorAtExit)myvisitor).Inside == true)
                {
                    //If visitor does not have any articles still rented.
                    if (((VisitorAtExit)myvisitor).CountNotReturnedArticles == 0)
                    {
                        //If connection to database is successfull and query is done successfully (true) then visitor exit.
                        if (dbhelper.ExitEvent(myvisitor))
                        {
                            this.BackColor = Color.Green;
                            lbInfo.Text = "Visitor can exit!";
                        }
                    }
                    else
                    {
                        //if visitor has rented articles, then the visitor cannot exit the event.
                        if (((VisitorAtExit)myvisitor).CountNotReturnedArticles > 0)
                        {
                            Console.Beep(2000, 500);
                            this.BackColor = Color.Red;
                            timer.Stop();
                            lbInfo.Text = "Visitor cannot exit!";
                            myRFIDReader.Antenna = false;
                            MessageBox.Show("Visitor has to return " + ((VisitorAtExit)myvisitor).CountNotReturnedArticles + " item(s)\nbefore he/she can exit!", "Attention");
                            myRFIDReader.Antenna = true;
                            ClearReset();
                        }
                    }
                }
                else
                {
                    //If visitor already exited or never checked in, display a DarkSeeGreen color to the user.
                    this.BackColor = Color.DarkSeaGreen;
                    lbInfo.Text = "Visitor already checked out or never checked in...";
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
                ClearReset();
                lbInfo.Text = "Ready to scan a tag...";
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
        /// When button is pressed, then it gives the user the choice to give visitor his/her rest of the money he/she haves.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCash_Click(object sender, EventArgs e)
        {
            try
            {
                //stop timer and make RFID Reader antenna false, so the user cannot keep scanning during this proccess.
                timer.Stop();
                myRFIDReader.Antenna = false;
                if (myvisitor.Balance > 0)
                {
                    //Dialog to show how much money is still available for user to give to the visitor.
                    DialogResult dialogResult = MessageBox.Show
                            ("Visitor still has " + myvisitor.Balance + " Euros on his/her account.\nClick OK to confirm that the visitor\nhas received his/her money.\nClick Cancel to cancel this transaction.",
                            "Money back?", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        //Using the method in dbhelper to set visitor's balance to 0.00 euros.
                        if (dbhelper.SetBalanceToZero(myvisitor))
                        {
                            MessageBox.Show("Transaction successful!");
                        }
                    }
                }
                ClearReset();
                myRFIDReader.Antenna = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no scanned tag.");
                myRFIDReader.Antenna = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Please turn RFID-Reader ON.");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// When timer tickes, stop it and clear all textboxes with the method ClearReset.
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
            btCash.Hide();
        }
    }
}