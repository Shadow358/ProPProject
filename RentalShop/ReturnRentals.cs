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
    public partial class ReturnRentals : Form
    {
        DBHelper dbhelper;
        Visitor myVisitor;
        List<Rental> productList = new List<Rental>();
        List<Rental> basketList = new List<Rental>();

        public ReturnRentals(Visitor currVisitor)
        {
            InitializeComponent();
            dbhelper = new DBHelper();
            myVisitor = currVisitor;
            tbNameReturn.Text = myVisitor.ToString();
            showRentalsVisitor();
        }

        private void libProductsRented_DoubleClick(object sender, EventArgs e)
        {
            addItemToBasket();
        }

        private void btProductsToBasket_Click(object sender, EventArgs e)
        {
            addItemToBasket();
        }

        private void addItemToBasket()
        {
            int selectedIndex = libProductsRented.SelectedIndex;
            if (!selectedIndex.Equals(-1)) // Check if an item is selected
            {
                Rental tempProduct = productList[selectedIndex];
                Rental basketitem = new Rental(tempProduct.ProductID, tempProduct.ProductPrice, tempProduct.ProductName, tempProduct.StockInShop, tempProduct.Comment); // Create new basketitem
                basketList.Add(basketitem); // Add to list
                productList.Remove(tempProduct); /// Delete from list
                tempProduct.StockInShop--; // Decrease quantity
                showListboxes();
                setSelected("product", selectedIndex);
                return;
            }
        }

        private void showRentalsVisitor()
        {
            try
            {
                productList = dbhelper.GetAllRentalsOfVisitor(myVisitor);
                foreach (Rental item in productList)
                {
                    libProductsRented.Items.Add(item.ToString());
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void btCancelReturnal_Click(object sender, EventArgs e)
        {
            ReturnRentals.ActiveForm.Close();
        }

        private void btConfirmReturnal_Click(object sender, EventArgs e)
        {
            try
            {
                if (myVisitor != null && basketList.Count > 0)
                {
                    decimal amount = Convert.ToDecimal(tbMoneyToRestore.Text);
                    if (dbhelper.ConfirmRentalReturnal(basketList) && dbhelper.AddMoneyToBalance(myVisitor, amount))
                    {
                        MessageBox.Show("Returnal succesful!");
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            finally
            {
                ReturnRentals.ActiveForm.Close();
            }
        }

        private void btDeleteReturningItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = libItemsRetuning.SelectedIndex;
            if (!selectedIndex.Equals(-1)) // Check if an item is selected
            {
                Rental tempBasketItem = basketList[selectedIndex];
                Rental tempProduct = new Rental(tempBasketItem.ProductID, tempBasketItem.ProductPrice, tempBasketItem.ProductName, tempBasketItem.StockInShop, tempBasketItem.Comment);
                productList.Add(tempProduct);
                basketList.Remove(tempBasketItem);
                showListboxes();
                setSelected("basket", selectedIndex);
                return;
            }
            else
            {
                MessageBox.Show("Can't remove, something went wrong, probably the list is empty or you didn't select anything");
                return;
            }
        }

        private void setSelected(string list, int place) // Sets the selected items in the listboxes, gotta fix the "length" in the program, so that the whole line can be selected 
        {
            if (list.Equals("basket") && !libItemsRetuning.Items.Count.Equals(0)) // Checks if there are items to select
            {
                if (place == libItemsRetuning.Items.Count) // If the item was the last in the list, then place it to the new last
                    place--;
                libItemsRetuning.SetSelected(place, true);
            }
            else if (list.Equals("product") && !libProductsRented.Items.Count.Equals(0)) // See above
            {
                if (place == libProductsRented.Items.Count)
                    place--;
                libProductsRented.SetSelected(place, true);
            }
        }

        private void showListboxes() // Adds the items to the listboxes, or deletes them if the quantity is 0, furthermore it calculated the price of the basket
        {
            decimal tempAmount = 0.00M;

            libItemsRetuning.Items.Clear();
            libProductsRented.Items.Clear();
            foreach (Rental item in basketList)
            {
                tempAmount += (item.ProductPrice);
                libItemsRetuning.Items.Add(item.ToString());
            }
            foreach (Rental product in productList)
            {
                libProductsRented.Items.Add(product.ToString());
            }

            tbMoneyToRestore.Text = tempAmount.ToString();
        }

        private void btAddComment_Click(object sender, EventArgs e)
        {
            int selectedIndex = libItemsRetuning.SelectedIndex;
            if (!selectedIndex.Equals(-1)) // Check if an item is selected
            {
                basketList[selectedIndex].Comment = tbComment.Text;
                showListboxes();
                setSelected("basket", selectedIndex);
            }
        }
    }
}
