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
        RFID myRFIDReader = null;
        DBHelper dbhelper;
        Visitor myVisitor;
        List<Product> productList = new List<Product>();
        List<BasketItem> basketList = new List<BasketItem>();
        List<Product> productToDeleteList = new List<Product>();
        List<BasketItem> basketItemToDeleteList = new List<BasketItem>();

        //int shopID = EnterShopID.shopId; for testing purposes:
        int shopID = 1;

        public Shop()
        {
            InitializeComponent();
            // Connect to shop
            dbhelper = new DBHelper();

            try
            {
                showProductsDatabase();
                tbCurCost.Text = "0.00";
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(readTag);
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                myRFIDReader.Antenna = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error, could not start");
            }
        }

        private void readTag(object sender, TagEventArgs e) // Gets the visitor which is going to pay
        {
            try
            {
                myVisitor = dbhelper.getVisitor(e.Tag);
                Console.Beep(2500, 200);
                if (myVisitor.Balance > 0)
                {
                    tbName.Text = myVisitor.ToString();
                    tbCurBalance.Text = myVisitor.Balance.ToString();
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

        private void btProductsToBasket_Click(object sender, EventArgs e) // Adds the selected item of the productList to the basket
        {
            if (myVisitor != null)
                addItemToBasket();
        }

        private void libProducts_DoubleClick(object sender, EventArgs e) // Adds the double clicked item of the productList to the basket
        {
            if (myVisitor != null)
                addItemToBasket();
        }

        private void btDeleteItem_Click(object sender, EventArgs e) // Deletes an item from the basket (works on the same idea as the addItemToBasket
        {
            int selectedIndex = libBasket.SelectedIndex;
            if (libBasket.SelectedItem != null)
            { // Check if an item is selected
                foreach (BasketItem item in basketList)
                {
                    if (item.ToString().Equals(libBasket.SelectedItem.ToString()))
                    { // Check for the right basketItem
                        if (productList.All(product => item.Product.ProductID != product.ProductID))
                        {
                            Product tempProduct = new Product(item.Product.ProductID, item.TotalPrice, item.Product.ProductName, item.Quantity);
                            productList.Add(tempProduct);
                            basketList.Remove(item);
                            showListboxes();
                            setSelected("basket", selectedIndex);
                            return;
                        }
                        else
                        {
                            foreach (Product product in productList)
                            {
                                if (item.Product.ProductID.Equals(product.ProductID))
                                {
                                    product.StockInShop = product.StockInShop + item.Quantity;
                                    basketList.Remove(item);
                                    showListboxes();
                                    setSelected("basket", selectedIndex);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btIncreaseQuantity_Click(object sender, EventArgs e) // Increases the quantity of an item in the basket, and decreases the quantity of the corresponding item in the productList
        {
            int selectedIndex = libBasket.SelectedIndex;
            if (libBasket.SelectedItem != null)
            { // Check if an item is selected
                foreach (BasketItem item in basketList)
                {
                    if (item.ToString().Equals(libBasket.SelectedItem.ToString()))
                    { // Check for the right basketItem
                        if (myVisitor.Balance > Convert.ToDecimal(tbCurCost.Text) + item.TotalPrice)
                        {
                            if (productList.All(product => item.Product.ProductID != product.ProductID))
                            {
                                MessageBox.Show("Can't increase quantity, out of stock!");
                                return;
                            }
                            else
                            {
                                foreach (Product product in productList)
                                {
                                    if (item.Product.ProductID.Equals(product.ProductID))
                                    {
                                        if (product.StockInShop != 0)
                                        {
                                            product.StockInShop--;
                                            item.Quantity++;
                                            showListboxes();
                                            setSelected("basket", selectedIndex);
                                            return;
                                        }
                                        else
                                            MessageBox.Show("YOU SHALL NOT PASS!");
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("Can't add item, balance is too low!");
                    }
                }
            }
        }

        private void btDecreaseQuantity_Click(object sender, EventArgs e) // Decrease the quantity of an item in the basket, and increase the quantity of the corresponding item in the productList
        {
            int selectedIndex = libBasket.SelectedIndex;
            if (libBasket.SelectedItem != null)
            { // Check if an item is selected
                foreach (BasketItem item in basketList)
                {
                    if (item.ToString().Equals(libBasket.SelectedItem.ToString()))
                    { // Check for the right basketItem
                        if (productList.All(product => item.Product.ProductID != product.ProductID))
                        {
                            Product tempProduct = new Product(item.Product.ProductID, item.TotalPrice, item.Product.ProductName, 1);
                            productList.Add(tempProduct);
                            item.Quantity--;
                            showListboxes();
                            setSelected("basket", selectedIndex);
                            return;
                        }
                        else
                        {
                            foreach (Product product in productList)
                            {
                                if (item.Product.ProductID.Equals(product.ProductID))
                                {
                                    product.StockInShop++;
                                    item.Quantity--;
                                    showListboxes();
                                    setSelected("basket", selectedIndex);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btCancelTransaction_Click(object sender, EventArgs e) // "Resets" the application
        {
            try
            {
                tbName.Text = "";
                tbCurBalance.Text = "";
                tbProductSearch.Text = "";
                myVisitor = null;
                myRFIDReader.Antenna = true;
                basketList.Clear();
                showListboxes();
                libProducts.Items.Clear();
                showProductsDatabase();
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
                foreach (Product item in productList){ // Check for all products in the list
                    if (item.ToString().Equals(libProducts.SelectedItem.ToString())){ // Checks for the right item
                        //if basketList is empty
                        if (!basketList.Any()){ // If the basket is empty, create, add and decrease quantity (old item)
                            BasketItem basketitem = new BasketItem(item, 1, item.ProductPrice); // Create new basketitem
                            basketList.Add(basketitem); // Add to list
                            item.StockInShop--; // Decrease quantity
                            showListboxes();
                            setSelected("product", selectedIndex);
                            return;}
                        else{
                            if (basketList.All(bitem => bitem.Product.ProductID != item.ProductID)){ // If there doesn't exist such an item yet, create, add and decrease quantity of item in shop
                                basketList.Add(new BasketItem(item, 1, item.ProductPrice));
                                item.StockInShop--;
                                showListboxes();
                                setSelected("product", selectedIndex);
                                return;}
                            else{
                                foreach (BasketItem bitem in basketList){ // Check get the right item, increase quantity of item in basket, decrease quantity of item in shop
                                    if (bitem.Product.ProductID == item.ProductID){
                                        bitem.Quantity++;
                                        item.StockInShop--;
                                        showListboxes();
                                        setSelected("product", selectedIndex);
                                        return;}}}}}}}
        }

        private void showProductsDatabase() // Fetches the products from the database and stores it in a list 
        {
            productList = dbhelper.GetAllProducts(shopID);
            foreach (Product item in productList)
            {
                libProducts.Items.Add(item.ToString());
            }
        }

        private void showListboxes() // Clears and shows all items in both listboxes, and updates the price of the basket
        {
            decimal tempAmount = 0.00M;
            libBasket.Items.Clear();
            libProducts.Items.Clear();
            foreach (BasketItem item in basketList) // Calculate the price of the basket
            {
                if (item.Quantity.Equals(0))
                    basketItemToDeleteList.Add(item);
                else
                {
                    tempAmount += (item.TotalPrice * item.Quantity);
                    libBasket.Items.Add(item.ToString());
                }
            } 
            foreach (Product product in productList)
            {
                if (product.StockInShop.Equals(0))
                    productToDeleteList.Add(product);
                else
                    libProducts.Items.Add(product.ToString());
            }
            tbCurCost.Text = tempAmount.ToString();
            basketItemToDeleteList.Clear();
            productToDeleteList.Clear();
        }

        private void setSelected(string list, int place) // Sets the selected items in the listboxes, gotta fix the "length" in the program, so that the whole line can be selected 
        {
            if (list.Equals("basket") && !libBasket.Items.Count.Equals(0)) // Checks if there are items to select
            {
               if (place == libBasket.Items.Count) // If the item was the last in the list, then place it to the new last
                    place--;
                libBasket.SetSelected(place, true);
            }
            else if (list.Equals("product") && !libProducts.Items.Count.Equals(0)) // See above
            {
                if (place == libProducts.Items.Count)
                    place--;
                libProducts.SetSelected(place, true);
            }
        }

        private void tbProductSearch_TextChanged(object sender, EventArgs e) // If text in search box is changed, it updates the listbox with items which contain the criteria
        {
            libProducts.Items.Clear();
            List<Product> tempList = new List<Product>();
            foreach (Product product in productList)
            {
                if (product.ProductName.Contains(tbProductSearch.Text))
                {
                    tempList.Add(product);
                }
            }
            foreach (Product product in tempList)
            {
                libProducts.Items.Add(product.ToString());
            }
        }

        private void shop_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            /* What it should do: 
             * - Update Transaction, insert a transaction for this user
             * - Update Transaction_Details, for each item
             * - Update Stock, for each item
             * - Update Visitor, set balance
             */
            
            try
            {
                
                btCancelTransaction_Click(sender, e); // And reset the application, so a new visitor can scan it's bracelet
                MessageBox.Show("Transaction succesful!");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
