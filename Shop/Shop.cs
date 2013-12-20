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

namespace Shop
{
    public partial class Shop : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        Visitor myvisitor;
        List<Product> shopList;
        List<BasketItem> basketList = new List<BasketItem>();

        int shopID = EnterShopID.shopId;

        public Shop()
        {
            InitializeComponent();
            // Connect to shop
            dbhelper = new DBHelper();

            try
            {
                ShowProductsDatabase();
                tbCurCost.Text = "0.00";
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                myRFIDReader.Antenna = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error, could not start");
            }
        }

        private void ShowProductsDatabase()
        {
            shopList = dbhelper.GetAllProducts(shopID);
            foreach (Product item in shopList)
            {
                libProducts.Items.Add(item.ToString());
            }
        }

        private void ReadTag(object sender, TagEventArgs e)
        {
            try
            {
                myvisitor = dbhelper.getVisitor(e.Tag);
                Console.Beep(2500, 200);
                if (myvisitor.Balance > 0)
                {
                    tbName.Text = myvisitor.ToString();
                    tbCurBalance.Text = myvisitor.Balance.ToString();
                    myRFIDReader.Antenna = false;
                }
                else
                {
                    MessageBox.Show("Balance is 0\nVisitor should transfer money to his/her account.");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No visitor found with this tag.");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void ShowShopListBox()
        {
            foreach (Product item in shopList)
            {
                libProducts.Items.Add(item.ToString());
            }
        }

        public void ShowBasketListBox()
        {
            foreach (BasketItem item in basketList)
            {
                libBasket.Items.Add(item.ToString());
            }
        }

        // If text in search box is changed, it updates the listbox with items which contain the criteria
        private void tbProductSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                libProducts.Items.Clear();
                List<Product> tempList = new List<Product>();
                foreach (Product item in shopList)
                {
                    if (item.ProductName.Contains(tbProductSearch.Text))
                    {
                        tempList.Add(item);
                    }
                }
                foreach (Product item in tempList)
                {
                    libProducts.Items.Add(item.ToString());
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btCancelTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                tbName.Text = "";
                tbCurBalance.Text = "";
                tbProductSearch.Text = "";
                myvisitor = null;
                myRFIDReader.Antenna = true;
                libProducts.Items.Clear();
                basketList.Clear();
                libBasket.Items.Clear();
                ShowProductsDatabase();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btProductsToBasket_Click(object sender, EventArgs e)
        {
            try
            {
                if (libProducts.SelectedItem != null)
                {
                    foreach (Product item in shopList)
                    {
                        if (item.ToString().Equals(libProducts.SelectedItem.ToString()))
                        {
                            //if basketList is empty
                            if (!basketList.Any())
                            {
                                BasketItem basketitem = new BasketItem(item, 1, item.ProductPrice * 1);
                                basketList.Add(basketitem);
                                item.StockInShop--;
                            }
                            else
                            {
                                if (basketList.All(bitem => bitem.Product.ProductID != item.ProductID))
                                {
                                    basketList.Add(new BasketItem(item, 1, item.ProductPrice * 1));
                                    item.StockInShop--;
                                    ShowShopListBox();
                                    ShowBasketListBox();
                                }
                                else
                                {
                                    foreach (BasketItem bitem in basketList)
                                    {
                                        if (bitem.Product.ProductID == item.ProductID)
                                        {
                                            bitem.Quantity++;
                                            item.StockInShop--;
                                            ShowShopListBox();
                                            ShowBasketListBox();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                libProducts.Items.Clear();
                libBasket.Items.Clear();
                ShowShopListBox();
                ShowBasketListBox();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void libProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (libProducts.SelectedItem != null)
                {

                    foreach (Product item in shopList)
                    {
                        if (item.ToString().Equals(libProducts.SelectedItem.ToString()))
                        {
                            //if basketList is empty
                            if (!basketList.Any())
                            {
                                BasketItem basketitem = new BasketItem(item, 1, item.ProductPrice * 1);
                                basketList.Add(basketitem);
                                item.StockInShop--;
                            }
                            else
                            {
                                if (basketList.All(bitem => bitem.Product.ProductID != item.ProductID))
                                {
                                    basketList.Add(new BasketItem(item, 1, item.ProductPrice * 1));
                                    item.StockInShop--;
                                    ShowShopListBox();
                                    ShowBasketListBox();
                                }
                                else
                                {
                                    foreach (BasketItem bitem in basketList)
                                    {
                                        if (bitem.Product.ProductID == item.ProductID)
                                        {
                                            bitem.Quantity++;
                                            item.StockInShop--;
                                            ShowShopListBox();
                                            ShowBasketListBox();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                libProducts.Items.Clear();
                libBasket.Items.Clear();
                ShowShopListBox();
                ShowBasketListBox();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Shop_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
