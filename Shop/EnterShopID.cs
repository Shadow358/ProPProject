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
                this.shopID = Convert.ToInt32(tbShopID.Text);
                Shop shop = new Shop(shopID);
                shop.ShowDialog(); 
                
                this.Close();


            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                tbShopID.Text = "";
            }
        }
    }
}
