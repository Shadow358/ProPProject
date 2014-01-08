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
    public partial class Entrance : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        Visitor myvisitor;

        public Entrance()
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
            timer.Stop();
            try
            {
                Console.Beep(2500, 200);
                myvisitor = dbhelper.GetVisitorEntrance(e.Tag);
                tbName.Text = myvisitor.ToString();
                tbBalance.Text = myvisitor.Balance.ToString();

                if (((VisitorAtEntrance)myvisitor).Inside == false)
                {
                    if (myvisitor.Balance >= 0)
                    {
                        if (dbhelper.EnterEvent(myvisitor))
                        {
                            this.BackColor = Color.Green;
                            lbInfo.Text = "Visitor can enter!";
                            timer.Start();
                        }
                    }
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
            ClearReset();
        }

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