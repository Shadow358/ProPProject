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

namespace RestockShop
{
    public partial class Restock : Form
    {
        DBHelper dbh;
        List<Product> productList = new List<Product>();

        int shopID = 1;

        public Restock()
        {
            InitializeComponent();
            dbh = new DBHelper();
            
            tb_ShopID.Text = "1";
            shopID = Convert.ToInt16(tb_ShopID.Text) ;
            showProductsDatabase();
        }

        private void showProductsDatabase() // Fetches the products from the database and stores it in a list 
        {
            shopID = Convert.ToInt16(tb_ShopID.Text);
            productList = dbh.GetAllProducts(shopID);
           
        }

        private void Restock_Load(object sender, EventArgs e)
        {

        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            lb_items.Items.Clear();
           
            shopID =  Convert.ToInt16(tb_ShopID.Text);
            int quantity = Convert.ToInt16(tb_Quantity.Text);
            int productID = Convert.ToInt16(tb_productID.Text);

            dbh.RestockShop(shopID, productID, quantity);
            
            lb_items.Items.Add("Shop ID :" + shopID);
            foreach (Product item in productList)
            {
                lb_items.Items.Add(item.ToString());
            }
            bt_load.PerformClick();
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            showProductsDatabase();
            lb_items.Items.Clear();
            shopID = Convert.ToInt16(tb_ShopID.Text);
            lb_items.Items.Add("Shop ID :" + shopID);
            foreach (Product item in productList)
            {
                lb_items.Items.Add(item.ToString());
            }
        }
    }
}
