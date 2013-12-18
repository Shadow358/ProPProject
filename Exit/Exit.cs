﻿using System;
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
                myvisitor = dbhelper.getVisitorExit(e.Tag);
                Console.Beep(2500, 200);
                tbName.Text = myvisitor.ToString();
                tbBalance.Text = myvisitor.Balance.ToString();
                btCash.Visible = true;

                if (((VisitorAtExit)myvisitor).Inside == true)
                {
                    if (((VisitorAtExit)myvisitor).CountNotReturnedArticles == 0)
                    {
                        ((VisitorAtExit)myvisitor).exitEvent();
                        this.BackColor = Color.Green;
                        lbInfo.Text = "Visitor can exit!";
                    }
                    else
                    {
                        if (((VisitorAtExit)myvisitor).CountNotReturnedArticles > 0)
                        {
                            btCash.Visible = false;
                            this.BackColor = Color.Red;
                            Console.Beep(2000, 500);
                            lbInfo.Text = "Visitor cannot exit!";
                            myRFIDReader.Antenna = false;
                            MessageBox.Show("Visitor has to return " + ((VisitorAtExit)myvisitor).CountNotReturnedArticles + " item(s)\nbefore he/she can exit!");
                            myRFIDReader.Antenna = true;
                        }
                    }
                }
                else
                {
                    this.BackColor = Color.DarkOliveGreen;
                    lbInfo.Text = "Visitor already checked out or never checked in...";
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No visitor found with this RFID");
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
                this.BackColor = DefaultBackColor;
            }
            catch (PhidgetException x)
            {
                MessageBox.Show(x.Message);
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
                myRFIDReader.Antenna = false;
                if (myvisitor.Balance > 0)
                {
                    DialogResult dialogResult = MessageBox.Show
                            ("Visitor still has " + myvisitor.Balance + " Euros on his/her account\nClick OK if visitor wants his/her\nmoney back in cash.",
                            "Money back?", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        DialogResult confirm = MessageBox.Show("Click OK to confirm if you gave the visitor cash back or Cancel to cancel this transaction", "Confirm", MessageBoxButtons.OKCancel);

                        if (confirm == DialogResult.OK)
                        {
                            myvisitor.setBalanceToZero();
                            MessageBox.Show("Transaction completed.");
                        }
                        else if (confirm == DialogResult.Cancel)
                        {
                            MessageBox.Show("Canceled");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Visitor does not have money on account to cash out");
                }
                myvisitor = null;
                lbInfo.Text = "Ready to scan a tag...";
                tbBalance.Text = "";
                tbName.Text = "";
                myRFIDReader.Antenna = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
