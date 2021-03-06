﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using Classes;
namespace PayPalConverter
{
    public partial class PayPalConverter : Form
    {
        DBHelper dbh = new DBHelper();

        public PayPalConverter()
        {
            InitializeComponent();

        }
        private void bt_Process_Click(object sender, EventArgs e)
        {
            //Declerations
            List<String> myList = new List<String>();
            List<String> VisitorsIDs = new List<String>();
            List<Decimal> Amounts = new List<Decimal>();
            int bankaccount;
            string startdate;
            string enddate;
            int nrOfDeposits;
            int listcount;
            decimal totalAmount = 0;
            lb_End.Items.Clear();
            lb_Start.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            string filename = "";
            string path = "";
            string fullpath = "";
            try
            {
                //Gets the filename and path from the OpenFileDialog
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = System.IO.Path.GetFileName(ofd.FileName);
                    path = System.IO.Path.GetDirectoryName(ofd.FileName);
                }

                //Combines the filename and the path
                fullpath = path + "\\" + filename;
                //Populates the Input Listbox with the data from the text file. Each row of the textfile becomes a line in the listbox
                FileInfo file = new FileInfo(fullpath);
                StreamReader stRead = file.OpenText();
                while (!stRead.EndOfStream)
                {
                    lb_Start.Items.Add(stRead.ReadLine());
                }

                //Adds each line of the Input listbox to a List<>
                foreach (String item in lb_Start.Items)
                {
                    myList.Add(item);
                }
                bankaccount = Convert.ToInt32(myList.ElementAt(0));
                startdate = (myList.ElementAt(1));
                enddate = (myList.ElementAt(2));
                nrOfDeposits = Convert.ToInt32(myList.ElementAt(3));
                listcount = lb_Start.Items.Count;
                //Calculates the total amount that the visitor has added to their account for the period
                for (int i = 4; i < listcount; i++)
                {
                    String[] temp = myList.ElementAt(i).Split(' ');
                    totalAmount += Convert.ToDecimal(temp[1]);
                    VisitorsIDs.Add(temp[0]);
                    Amounts.Add(Convert.ToDecimal(temp[1]));
                }


                //Populates the Output listbox with general information
                lb_End.Items.Add("Bank Account: " + bankaccount.ToString());
                lb_End.Items.Add("Start Period: " + startdate.ToString());
                lb_End.Items.Add("End Period: " + enddate.ToString());
                lb_End.Items.Add("Number Of Deposits: " + nrOfDeposits.ToString());

                //Updates the Database
                for (int i = 0; i < VisitorsIDs.Count; i++)
                {
                    dbh.AddMoneyPaypal(Convert.ToInt16(VisitorsIDs.ElementAt(i)), Amounts.ElementAt(i));
                    lb_End.Items.Add("Visitor: " + VisitorsIDs.ElementAt(i) + " " + "Added: " + Amounts.ElementAt(i));
                }

            }
            catch (IOException)
            {
                MessageBox.Show("Cannot load file");
            }
            catch (Exception)
            {
                MessageBox.Show("File: " + filename + " cannot be processed to the database" + ", Connection error");
            }
            finally
            {
                MessageBox.Show("Have a nice day!");
            }
        }
    }
}