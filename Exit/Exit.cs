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

        private void ReadTag(object sender, TagEventArgs e)
        {
            try
            {
                timer.Stop();
                myvisitor = dbhelper.GetVisitorExit(e.Tag);
                Console.Beep(2500, 200);
                tbName.Text = myvisitor.ToString();
                tbBalance.Text = myvisitor.Balance.ToString();
                timer.Start();

                if (myvisitor.Balance > 0)
                {
                    btCash.Show();
                }

                if (((VisitorAtExit)myvisitor).Inside == true)
                {
                    if (((VisitorAtExit)myvisitor).CountNotReturnedArticles == 0)
                    {
                        dbhelper.ExitEvent(myvisitor);
                        this.BackColor = Color.Green;
                        lbInfo.Text = "Visitor can exit!";
                    }
                    else
                    {
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
                    this.BackColor = Color.DarkSeaGreen;
                    lbInfo.Text = "Visitor already checked out or never checked in...";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error, something went wrong.\nPlease try again.");
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

        private void btCash_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Stop();
                myRFIDReader.Antenna = false;
                if (myvisitor.Balance > 0)
                {
                    DialogResult dialogResult = MessageBox.Show
                            ("Visitor still has " + myvisitor.Balance + " Euros on his/her account.\nClick OK to confirm that the visitor\nhas received his/her money.\nClick Cancel to cancel this transaction.",
                            "Money back?", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (dbhelper.SetBalanceToZero(myvisitor))
                        {
                            MessageBox.Show("Transaction completed.");
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

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            ClearReset();
        }

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