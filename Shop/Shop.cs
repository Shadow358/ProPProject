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
        List<Item> shopList;
        List<Item> basketList;

        int shopID;

        public Shop()
        {
            InitializeComponent();
            // Connect to shop
            dbhelper = new DBHelper();

             EnterShopID form = new EnterShopID();
             form.Show();
            
            Shop thisShop = new Shop();
            thisShop.Hide();
            try
            {
                shopID = 1;
                shopList = dbhelper.GetAllArticles(shopID);
                foreach (Item item in shopList)
                {
                    libProducts.Items.Add(item.ToString());
                }
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
                    MessageBox.Show("Your balance is 0\nPlease transfer money to your account");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No visitor found with this RFID");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        // If text in search box is changed, it updates the listbox with items which contain the criteria
        private void tbProductSearch_TextChanged(object sender, EventArgs e)
        {
            libProducts.Items.Clear();
            List<Item> tempList = new List<Item>();
            foreach (Item item in shopList)
            {
                if (item.ItemName.Contains(tbProductSearch.Text))
                {
                    tempList.Add(item);
                }
            }
            foreach (Item item in tempList)
            {
                libProducts.Items.Add(item.ToString());
            }
        }

        private void btCancelTransaction_Click(object sender, EventArgs e)
        {
            myRFIDReader.Antenna = true;
        }

        private void libProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (libProducts.SelectedItem != null)
            {
                // put items in temp list, then if transaction is completed, update database and then store the new list in the shopList
                foreach(Item item in shopList)
                {
                    if (libProducts.SelectedItem.Equals(item.ToString()))
                    {
                        item.StockInShop = item.StockInShop - 1;
                        basketList = new List<Item>();
                        basketList.Add(item);
                        foreach (Item bitem in basketList)
                        {
                            libBasket.Items.Add(bitem);
                        }
                    }
                }
            }
            libProducts.Update();
        }

        private void libProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
