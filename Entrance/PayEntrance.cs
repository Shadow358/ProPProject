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

        public PayEntrance(VisitorAtEntrance currentvisitor)
        {
            InitializeComponent();

            myvisitor = currentvisitor;
            this.StartPosition = FormStartPosition.CenterScreen;
            dbhelper = new DBHelper();
            lbVisitorName.Text = "Visitor: " + myvisitor.ToString();
            lbInfo.Text = "Visitor needs to pay at least " + (-(myvisitor.Balance) + 10) + " euros (ticket fee)\nbefore he/she can enter the event.";
            numericUpDown.Value = (-(myvisitor.Balance) + 10);
        }

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

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PayEntrance_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
