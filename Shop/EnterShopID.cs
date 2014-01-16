using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

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

                DBHelper dbhelper = new DBHelper();
                if (dbhelper.CheckIfShopExists(shopID)) // Check if the shop exists
                {
                    Shop shop = new Shop(shopID);
                    shop.ShowDialog(); // Open the shop
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This shop does not exists. Please select an existing shopid");
                    this.Show(); // Try again
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}
