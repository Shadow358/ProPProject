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
    public partial class PayEntrance : Form
    {
        DBHelper dbhelper;
        VisitorAtEntrance myvisitor;

        //When an instance of this form is created it should pass a VisitorAtEntrance throught the constructor.
        public PayEntrance(VisitorAtEntrance currentvisitor)
        {
            InitializeComponent();

            try
            {
                ///assign the visitor with the visitor passed throught the constructor so it can be used everywhere in this form.
                ///Show labels of how much visitor has to pay, and put the amount in the numericUpDown value.
                myvisitor = currentvisitor;
                this.StartPosition = FormStartPosition.CenterScreen;
                dbhelper = new DBHelper();
                lbVisitorName.Text = "Visitor: " + myvisitor.ToString();
                lbInfo.Text = "Visitor needs to pay at least " + (-(myvisitor.Balance) + 10) + " euros (ticket fee)\nbefore he/she can enter the event.";
                numericUpDown.Value = (-(myvisitor.Balance) + 10);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// When Pay is clicked, if amount that should be paid or more is inserted in the numericUpDown then it's successfull.
        /// If not then show an error message to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPay_Click(object sender, EventArgs e)
        {
            if (numericUpDown.Value >= (-(myvisitor.Balance) + 10))
            {
                if (dbhelper.AddMoneyToBalance(myvisitor, numericUpDown.Value - 10))
                {
                    MessageBox.Show("Transaction successful!");
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Visitor needs to pay at least " + (-(myvisitor.Balance) + 10) + " euros.", "Attention");
            }
        }

        /// <summary>
        /// Click on cancel dispose of this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// When Form is closed, form is disposed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayEntrance_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
