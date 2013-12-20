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

        //int shopID = EnterShopID.shopId; for testing purposes:
        int shopID = 1;

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

        private void ShowListboxes()
        {
            libBasket.Items.Clear();
            libProducts.Items.Clear();
            ShowShopListBox();
            ShowBasketListBox();
        }

        private void ShowShopListBox()
        {
            foreach (Product item in shopList)
            {
                libProducts.Items.Add(item.ToString());
            }
        }

        private void ShowBasketListBox()
        {
            foreach (BasketItem item in basketList)
            {
                libBasket.Items.Add(item.ToString());
            }
        }

        private void setSelected(string list, int place)
        {
            if (list.Equals("basket") && !libBasket.Items.Count.Equals(0))
                libBasket.SetSelected(place, true);
            else if (list.Equals("products") && !libProducts.Items.Count.Equals(0))
                libProducts.SetSelected(place, true);
        }

        private void tbProductSearch_TextChanged(object sender, EventArgs e) // If text in search box is changed, it updates the listbox with items which contain the criteria
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

        private void btCancelTransaction_Click(object sender, EventArgs e) // Resets the application
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

        private void addItemToBasket() // Adds the item to the basket
        {
            int selectedIndex = libProducts.SelectedIndex;
            if (libProducts.SelectedItem != null){ // Check if an item is selected
                foreach (Product item in shopList){ // Check for all products in the list
                    if (item.ToString().Equals(libProducts.SelectedItem.ToString())){ // Checks for the right
                        //if basketList is empty
                        if (!basketList.Any()){
                            BasketItem basketitem = new BasketItem(item, 1, item.ProductPrice);
                            basketList.Add(basketitem);
                            item.StockInShop--;
                            ShowListboxes();
                            setSelected("product", selectedIndex);
                            return;}
                        else{
                            if (basketList.All(bitem => bitem.Product.ProductID != item.ProductID)){
                                basketList.Add(new BasketItem(item, 1, item.ProductPrice));
                                item.StockInShop--;
                                ShowListboxes();
                                setSelected("product", selectedIndex);
                                return;}
                            else{
                                foreach (BasketItem bitem in basketList){
                                    if (bitem.Product.ProductID == item.ProductID){
                                        bitem.Quantity++;
                                        item.StockInShop--;
                                        ShowListboxes();
                                        setSelected("product", selectedIndex);
                                        return;}}}}}}}
        }

        private void btDeleteItem_Click(object sender, EventArgs e) // Deletes an item from the basket
        {
            int selectedIndex = libBasket.SelectedIndex;
            if (libBasket.SelectedItem != null){ // Check if an item is selected
                foreach (BasketItem bitem in basketList){
                    if (bitem.ToString().Equals(libBasket.SelectedItem.ToString())){ // Check for the right basketItem
                        if (shopList.All(item => bitem.Product.ProductID != item.ProductID)){
                            Product tempItem = new Product(bitem.Product.ProductID, bitem.TotalPrice, bitem.Product.ProductName, bitem.Quantity);
                            shopList.Add(tempItem);
                            basketList.Remove(bitem);
                            ShowListboxes();
                            setSelected("basket", selectedIndex);
                            return;}
                        else{
                            foreach (Product item in shopList){
                                if (bitem.Product.ProductID.Equals(item.ProductID)){
                                    item.StockInShop = item.StockInShop + bitem.Quantity;
                                    basketList.Remove(bitem);
                                    ShowListboxes();
                                    setSelected("basket", selectedIndex);
                                    return;}}}}}}
        }

        private void btIncreaseQuantity_Click(object sender, EventArgs e) // Increases the quantity of an item in the basket, and decreases the quantity of the corresponding item in the shopList
        {
            int selectedIndex = libBasket.SelectedIndex;
            if (libBasket.SelectedItem != null)
            { // Check if an item is selected
                foreach (BasketItem bitem in basketList)
                {
                    if (bitem.ToString().Equals(libBasket.SelectedItem.ToString()))
                    { // Check for the right basketItem
                        if (shopList.All(item => bitem.Product.ProductID != item.ProductID))
                        {
                            MessageBox.Show("Can't increase quantity, out of stock!");
                            return;
                        }
                        else
                        {
                            foreach (Product item in shopList)
                            {
                                if (bitem.Product.ProductID.Equals(item.ProductID))
                                {
                                    item.StockInShop--;
                                    bitem.Quantity++;
                                    ShowListboxes();
                                    setSelected("basket", selectedIndex);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btDecreaseQuantity_Click(object sender, EventArgs e)
        {

        }

        private void btProductsToBasket_Click(object sender, EventArgs e)
        {
            try
            {
                addItemToBasket();
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
                addItemToBasket();
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
    }
}
