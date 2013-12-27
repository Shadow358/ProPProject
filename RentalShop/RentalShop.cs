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


namespace RentalShop
{
    public partial class RentalShop : Form
    {
        RFID myRFIDReader = null;
        DBHelper dbhelper;
        Visitor myVisitor;
        List<Rental> productList = new List<Rental>();
        List<BasketItem> basketList = new List<BasketItem>();
        List<Rental> productToDeleteList = new List<Rental>();
        List<BasketItem> basketItemToDeleteList = new List<BasketItem>();

        public RentalShop()
        {
            InitializeComponent();
            // Connect to shop
            dbhelper = new DBHelper();

            showProductsDatabase();
            tbCurDeposit.Text = "0.00";

            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(readTag);
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(1000);
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
            addItemToBasket();
        }

        private void libProducts_DoubleClick(object sender, EventArgs e) // Adds the double clicked item of the productList to the basket
        {
            addItemToBasket();
        }

        private void btDeleteItem_Click(object sender, EventArgs e) // Deletes an item from the basket (works on the same idea as the addItemToBasket
        {
            int selectedIndex = libBasket.SelectedIndex;
            if (!selectedIndex.Equals(-1)) // Check if an item is selected
            {
                BasketItem tempBasketItem = basketList[selectedIndex];
                if (productList.All(product => tempBasketItem.Product.ProductID != product.ProductID))
                {
                    Product tempProduct = new Product(tempBasketItem.Product.ProductID, tempBasketItem.TotalPrice, tempBasketItem.Product.ProductName, tempBasketItem.Quantity);
                    productList.Add(tempProduct);
                    productList.Sort(productListInOrder);
                    basketList.Remove(tempBasketItem);
                    showListboxes();
                    setSelected("basket", selectedIndex);
                    return;
                }
                else
                {
                    Product tempProduct = findProduct(tempBasketItem);
                    if (tempProduct != null)
                    {
                        tempProduct.StockInShop = tempProduct.StockInShop + tempBasketItem.Quantity;
                        basketList.Remove(tempBasketItem);
                        showListboxes();
                        setSelected("basket", selectedIndex);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Can't add, something went wrong");
                        return;
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

        private void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = basketList.Sum(basketItem => (basketItem.TotalPrice * basketItem.Quantity));
                /* if (dbhelper.ConfirmShopTransaction(shopID, myVisitor, basketList, amount) && dbhelper.RemoveMoneyFromBalance(myVisitor, amount))
                {
                    btCancelTransaction_Click(sender, e); // And reset the application, so a new visitor can scan it's bracelet
                    MessageBox.Show("Transaction succesful!");
                }*/
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void addItemToBasket() // Adds the item to the basket
        {
            if (myVisitor != null)
            {
                int selectedIndex = libProducts.SelectedIndex;
                if (!selectedIndex.Equals(-1)) // Check if an item is selected
                {
                    Product tempProduct = productList[selectedIndex];
                    if (!(myVisitor.Balance < Convert.ToDecimal(tbCurDeposit.Text) + tempProduct.ProductPrice)) // If the user has enough balance
                    {
                        if (basketList.All(bitem => bitem.Product.ProductID != tempProduct.ProductID))
                        { // If the basket is empty, create, add and decrease quantity (old item)
                            BasketItem basketitem = new BasketItem(tempProduct, 1, tempProduct.ProductPrice); // Create new basketitem
                            basketList.Add(basketitem); // Add to list
                            tempProduct.StockInShop--; // Decrease quantity
                            showListboxes();
                            setSelected("product", selectedIndex);
                            return;
                        }
                        else
                        {
                            BasketItem tempBasketItem = findBasketItem(tempProduct);
                            if (tempBasketItem != null)
                            {
                                tempBasketItem.Quantity++;
                                tempProduct.StockInShop--;
                                showListboxes();
                                setSelected("product", selectedIndex);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Can't add, something went wrong");
                                return;
                            }
                        }
                    }
                    else
                        MessageBox.Show("YOU SHALL NOT PASS!");
                }
            }
        }

        private void showProductsDatabase() // Fetches the products from the database and stores it in a list 
        {
            productList = dbhelper.GetAllRentals;
            foreach (Product item in productList) /////////////////PUT THIS IN A TRY CATCH, ERROR IF DATABASE NOT CONNECED!!!!
            {
                libProducts.Items.Add(item.ToString());
            }
        }

        private void showListboxes() // Adds the items to the listboxes, or deletes them if the quantity is 0, furthermore it calculated the price of the basket
        {
            decimal tempAmount = 0.00M;

            libBasket.Items.Clear();
            libProducts.Items.Clear();
            foreach (BasketItem item in basketList)
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

            // Only if the todeletelists contain something, delete that from that list
            if (basketItemToDeleteList.Count != 0)
            {
                basketList.Remove(basketItemToDeleteList[0]);
                basketItemToDeleteList.Clear();
            }
            if (productToDeleteList.Count != 0)
            {
                productList.Remove(productToDeleteList[0]);
                productToDeleteList.Clear();
            }

            tbCurDeposit.Text = tempAmount.ToString();
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
            List<Rental> tempList = new List<Rental>();
            foreach (Rental product in productList)
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

        private int productListInOrder(Product product, Product otherProduct)
        {
            return (product.ProductID).CompareTo(otherProduct.ProductID);
        }

        private Product findProduct(BasketItem item)
        {
            foreach (Product product in productList)
            {
                if (item.Product.ProductID.Equals(product.ProductID))
                    return product;
            }
            return null;
        }

        private BasketItem findBasketItem(Product product)
        {
            foreach (BasketItem item in basketList)
            {
                if (product.ProductID.Equals(item.Product.ProductID))
                    return item;
            }
            return null;
        }
    }
}
