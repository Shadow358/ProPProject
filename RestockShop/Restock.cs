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
        // Fetches the products from the database and stores it in a list 
        private void showProductsDatabase() 
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
            try
            {  // Cheching for valid imputs
                if (tb_productID.Text == "")
                {
                    MessageBox.Show("Please enter a product ID", "Product ID Error");
                }
                else if (!dbh.CheckIfShopExists(Convert.ToInt16(tb_ShopID.Text)))
                {
                    MessageBox.Show("Please enter a valid product ID", "Product ID Error");
                }
                else if (tb_Quantity.Text == "")
                {
                    MessageBox.Show("Please enter a quantity", "Quantity Error");
                }
                else if (Convert.ToInt16(tb_Quantity.Text) < 0)
                {
                    MessageBox.Show("Please enter a positive number for quantity", "Quantity Error");
                }
                else
                {
                    //Fetches the parameters from the text boxes
                    shopID = Convert.ToInt16(tb_ShopID.Text);
                    int quantity = Convert.ToInt16(tb_Quantity.Text);
                    int productID = Convert.ToInt16(tb_productID.Text);
                    //Executes the query from the DBHelper class
                    dbh.RestockShop(shopID, productID, quantity);
                    //Populates the list box withe the updated info
                    lb_items.Items.Add("Shop ID :" + shopID);
                    foreach (Product item in productList)
                    {
                        lb_items.Items.Add(item.ToString());
                    }

                }
            }
            
            catch 
            {
                MessageBox.Show("Please enter only numbers");
            }
            bt_load.PerformClick();
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dbh.CheckIfShopExists(Convert.ToInt16(tb_ShopID.Text)))
                {
                    MessageBox.Show("Please enter a valid Shop ID");
                }
                else
                {
                    //Fetches the list of products of the wanted shop and populates the listbox with it
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
            catch 
            {
                MessageBox.Show("Please enter only numbers");
            }
        }
    }
}
