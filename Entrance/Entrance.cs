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
            try
            {
                myvisitor = dbhelper.getVisitorEntrance(e.Tag);
                Console.Beep(2500, 200);
                tbName.Text = myvisitor.ToString();
                tbBalance.Text = myvisitor.Balance.ToString();

                if (((VisitorAtEntrance)myvisitor).Inside == false)
                {
                    if (myvisitor.Balance >= 0)
                    {
                        ((VisitorAtEntrance)myvisitor).enterEvent();
                        this.BackColor = Color.Green;
                        lbInfo.Text = "Visitor can enter!";
                        timer.Start();
                    }
                    else
                    {
                        this.BackColor = Color.Red;
                        Console.Beep(2000, 500);
                        lbInfo.Text = "Visitor cannot enter!";
                        myRFIDReader.Antenna = false;
                        DialogResult dialogResult = MessageBox.Show
                            ("Visitor did not pay (whole) ticket for event.\nAmount to be paid: " + -(myvisitor.Balance - 10) + " Euros cash.\nClick OK if visitor wants to pay now.",
                            "Pay to enter...", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            DialogResult confirm = MessageBox.Show("Click OK to confirm if you received payment or Cancel to cancel this transaction", "Confirm", MessageBoxButtons.OKCancel);

                            if (confirm == DialogResult.OK)
                            {
                                myvisitor.setBalanceToZero();
                                MessageBox.Show("Transaction completed.\nPlease scan the RFID again.");
                            }
                            else if (confirm == DialogResult.Cancel)
                            {
                                MessageBox.Show("Canceled");
                            }
                        }
                        myRFIDReader.Antenna = true;
                        this.BackColor = DefaultBackColor;
                        lbInfo.Text = "Ready to scan a tag...";
                        tbBalance.Text = "";
                        tbName.Text = "";
                    }
                }
                else
                {
                    this.BackColor = Color.Red;
                    Console.Beep(2000, 500);
                    myRFIDReader.Antenna = false;
                    MessageBox.Show("Visitor already inside!");
                    myRFIDReader.Antenna = true;
                    lbInfo.Text = "Ready to scan a tag...";
                    tbBalance.Text = "";
                    tbName.Text = "";
                    this.BackColor = DefaultBackColor;
                }
                myvisitor = null;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No visitor found with this RFID");
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

        private void BtOff_Click(object sender, EventArgs e)
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
            tbBalance.Text = "";
            tbName.Text = "";
        }
    }
}
