using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class EnterShopID : Form
    {
        int shopID;

        public EnterShopID()
        {
            InitializeComponent();
        }

        private void btConfirmShopID_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                this.shopID = Convert.ToInt32(tbShopID.Text);

                //if the shopID inserted is in the table shop in database (SELECT BLAH BLAH...)
                //Then Make the shop object and open the ShowDialog.
                Shop shop = new Shop(shopID);
                shop.ShowDialog();

                //If the shopID is not in the shoptable
                //Then just show an error message and let them insert a shop again.
                
                //The this.Close() is in the finally.
            }
            catch (Exception)
            {
                tbShopID.Text = "";
            }
            finally
            {
                this.Close();
            }
        }
    }
}
