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
        public EnterShopID()
        {
            InitializeComponent();
        }

        public static int shopId;

        private void btConfirmShopID_Click(object sender, EventArgs e)
        {
            try
            {
                shopId = Convert.ToInt32(tbShopID.Text);
                this.Hide();
                Shop form = new Shop();
                form.Show();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                tbShopID.Text = "";
            }
        }
    }
}
