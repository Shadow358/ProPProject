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
            List<String> myList = new List<String>();
            int visitor_id;
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
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = System.IO.Path.GetFileName(ofd.FileName);
                    path = System.IO.Path.GetDirectoryName(ofd.FileName);
                }
                fullpath = path + "\\" + filename;


                FileInfo file = new FileInfo(fullpath);
                StreamReader stRead = file.OpenText();
                while (!stRead.EndOfStream)
                {
                    lb_Start.Items.Add(stRead.ReadLine());
                }


               

                foreach (String item in lb_Start.Items)
                {
                    myList.Add(item);
                }
                visitor_id = Convert.ToInt32(myList.ElementAt(0));
                startdate = (myList.ElementAt(1));
                enddate = (myList.ElementAt(2));
                nrOfDeposits = Convert.ToInt32(myList.ElementAt(3));
                listcount = lb_Start.Items.Count;
                for (int i = 4; i < listcount; i++)
                {
                    String[] temp = myList.ElementAt(i).Split(' ');
                    totalAmount += Convert.ToDecimal(temp[1]);
                }

                dbh.AddMoneyPaypal(visitor_id, totalAmount);
                lb_End.Items.Add("VisitorID: " + visitor_id.ToString());
                lb_End.Items.Add("Start Period: " + startdate.ToString());
                lb_End.Items.Add("End Period: " + enddate.ToString());
                lb_End.Items.Add("Number Of Deposits: " + nrOfDeposits.ToString());
                lb_End.Items.Add("Total Amount Added: " + totalAmount.ToString());
            }


            catch (IOException)
            {
                MessageBox.Show("Cannot load file");
            }
            catch
            {
                MessageBox.Show("File: " + filename + "cannot be processed");
            }
            finally
            {
                MessageBox.Show("Have a nice day!");
            }
            }
        }
    }

