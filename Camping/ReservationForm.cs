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

namespace Camping
{
    public partial class ReservationForm : Form
    {
        RFID myRFIDReader;
        DBHelper dbhelper;
        int visitorIndex;
        Visitor[] myScannedvisitors;
        IList<Visitor> mySavedvisitors;
        Button[] scansavedeleteButtons;
        TextBox[] textboxesVisitors;
        decimal totalamount;
        bool ScannerOn;
        int[] visitorIDs;
        List<String> campingSpots;
        CampReservation thereservation;
        Visitor mypayingvisitor;

        //Constructor for existing reservation
        //The constructor knows the cadAdd Value, depending how much the value is, when initilalize the form, it hides buttons and textboxes.
        public ReservationForm(CampReservation reservation, int canAdd)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dbhelper = new DBHelper();
            thereservation = reservation;
            visitorIDs = new int[6];
            totalamount = reservation.ShouldBePaid - reservation.AmountPaid;
            ScannerOn = false;
            myScannedvisitors = new Visitor[6];
            mySavedvisitors = new Visitor[6];
            textboxesVisitors = new TextBox[6] { tbVisitor1, tbVisitor2, tbVisitor3, tbVisitor4, tbVisitor5, tbVisitor6 };
            scansavedeleteButtons = new Button[18] { 
                btScanVisitor1, btScanVisitor2, btScanVisitor3, btScanVisitor4, btScanVisitor5, btScanVisitor6, 
                btSaveVisitor1, btSaveVisitor2, btSaveVisitor3, btSaveVisitor4, btSaveVisitor5, btSaveVisitor6, 
                btDeleteVisitor1, btDeleteVisitor2, btDeleteVisitor3, btDeleteVisitor4, btDeleteVisitor5, btDeleteVisitor6 };
            btReset.Hide();
            btConfirm.Hide();
            btDone.Hide();
            btCancel.Hide();
            btConfirmExistingReservation.Hide();
            labelAvailSpot.Hide();
            lbAvailSpot.Hide();
            lblpayingvisitor.Hide();
            tbVisitor1Balance.Hide();
            lbl1.Hide();
            tbVisitor1.Hide();
            btScanVisitor1.Hide();
            btSaveVisitor1.Hide();
            btDeleteVisitor1.Hide();
            lbConfirm.Hide();
            lbInfoScanTag.Hide();
            tbTotalAmount.Text = totalamount.ToString();
            tbBalance.Text = thereservation.Visitor.Balance.ToString();
            lbSpotString.Text = "Reservation spotID: " + reservation.SpotID;
            lbInfoScanTag.Text = "Scan: (" + reservation.Visitor.ToString() + ") for payment.\nReady to scan tag...";
            lblInfo.Text = canAdd.ToString() + " visitor(s) can be add to\nthis existing reservation.\nSave visitors before clicking 'Done'.";

            if (canAdd == 1)
            {
                lbl2.Hide();
                tbVisitor2.Hide();
                btScanVisitor2.Hide();
                btSaveVisitor2.Hide();
                btDeleteVisitor2.Hide();

                lbl3.Hide();
                tbVisitor3.Hide();
                btScanVisitor3.Hide();
                btSaveVisitor3.Hide();
                btDeleteVisitor3.Hide();

                lbl4.Hide();
                tbVisitor4.Hide();
                btScanVisitor4.Hide();
                btSaveVisitor4.Hide();
                btDeleteVisitor4.Hide();

                lbl5.Hide();
                tbVisitor5.Hide();
                btScanVisitor5.Hide();
                btSaveVisitor5.Hide();
                btDeleteVisitor5.Hide();
            }

            if (canAdd == 2)
            {
                lbl2.Hide();
                tbVisitor2.Hide();
                btScanVisitor2.Hide();
                btSaveVisitor2.Hide();
                btDeleteVisitor2.Hide();

                lbl3.Hide();
                tbVisitor3.Hide();
                btScanVisitor3.Hide();
                btSaveVisitor3.Hide();
                btDeleteVisitor3.Hide();

                lbl4.Hide();
                tbVisitor4.Hide();
                btScanVisitor4.Hide();
                btSaveVisitor4.Hide();
                btDeleteVisitor4.Hide();
            }

            if (canAdd == 3)
            {
                lbl2.Hide();
                tbVisitor2.Hide();
                btScanVisitor2.Hide();
                btSaveVisitor2.Hide();
                btDeleteVisitor2.Hide();

                lbl3.Hide();
                tbVisitor3.Hide();
                btScanVisitor3.Hide();
                btSaveVisitor3.Hide();
                btDeleteVisitor3.Hide();
            }

            if (canAdd == 4)
            {
                lbl2.Hide();
                tbVisitor2.Hide();
                btScanVisitor2.Hide();
                btSaveVisitor2.Hide();
                btDeleteVisitor2.Hide();
            }

            //if canAdd == 5 -> Nothing extra to bo done.

            ///Create a RFID object
            ///Event for Tag (reading tag)
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error, could not start");
            }
        }

        //Constructor for creating a new reservation
        public ReservationForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dbhelper = new DBHelper();
            visitorIDs = new int[6];
            totalamount = 30.00M;
            ScannerOn = false;
            myScannedvisitors = new Visitor[6];
            mySavedvisitors = new Visitor[6];
            textboxesVisitors = new TextBox[6] { tbVisitor1, tbVisitor2, tbVisitor3, tbVisitor4, tbVisitor5, tbVisitor6 };
            scansavedeleteButtons = new Button[18] { btScanVisitor1, btScanVisitor2, btScanVisitor3, btScanVisitor4, btScanVisitor5, btScanVisitor6, btSaveVisitor1, btSaveVisitor2, btSaveVisitor3, btSaveVisitor4, btSaveVisitor5, btSaveVisitor6, btDeleteVisitor1, btDeleteVisitor2, btDeleteVisitor3, btDeleteVisitor4, btDeleteVisitor5, btDeleteVisitor6 };
            btCancelExistingReservation.Hide();
            btConfirm.Hide();
            btDoneExistingReservation.Hide();
            lbSpotString.Hide();
            lbBalance.Hide();
            tbBalance.Hide();
            btConfirmExistingReservation.Hide();
            lbConfirm.Hide();
            lbInfoScanTag.Hide();
            
            try
            {
                campingSpots = dbhelper.GetAvailableSpots();

                foreach (String item in campingSpots)
                {
                    lbAvailSpot.Items.Add(item);
                }
                tbTotalAmount.Text = totalamount.ToString();

                ///Create a RFID object
                ///Event for Tag (reading tag)
                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error, could not start");
            }
        }

        /// <summary>
        /// Read tags and create the visitor with that read tag. Then show the visitor in the textbox (depending on the index)
        /// index is specified when the button scan is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadTag(object sender, TagEventArgs e)
        {
            Console.Beep(2500, 200);
            try
            {
                myScannedvisitors[visitorIndex] = dbhelper.GetVisitorCamping(e.Tag);
                myRFIDReader.Antenna = false;
                textboxesVisitors[visitorIndex].Text = myScannedvisitors[visitorIndex].ToString();

                if (visitorIndex == 0)
                {
                    tbVisitor1Balance.Text = myScannedvisitors[0].Balance.ToString();
                }
            }
            catch (NullReferenceException x)
            {
                MessageBox.Show(x.Message);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// This method is to open the RFID reader and make the antenna true
        /// it also make the ScannerOn the the oposite bool.
        /// </summary>
        public void ScanOn()
        {
            myRFIDReader.open();
            myRFIDReader.waitForAttachment(3000);
            myRFIDReader.Antenna = true;
            ScannerOn = !ScannerOn;
        }

        /// <summary>
        /// This method is to make the antenna of the RFID reader false an also close the RFID reader.
        /// It also make the ScannerOn the the oposite bool.
        /// </summary>
        public void ScanOff()
        {
            myRFIDReader.Antenna = false;
            myRFIDReader.close();
            ScannerOn = !ScannerOn;
        }

        /// <summary>
        /// if there is already a visitor scanned with the specifiek visitorIndex it just becomes null.
        /// Turn scanner on. Clear the textbox with specifiek visitorIndex, and make the backcolor to default.
        /// </summary>
        public void ScanButtonsMethod()
        {
            myScannedvisitors[visitorIndex] = null;
            mySavedvisitors[visitorIndex] = null;

            if (ScannerOn == false)
            {
                ScanOn();
            }
            else
            {
                ScanOff();
                ScanOn();
            }
            textboxesVisitors[visitorIndex].Text = "";
            textboxesVisitors[visitorIndex].BackColor = DefaultBackColor;
        }

        /// <summary>
        /// If scanner is on, turn it off.
        /// if there is a savedvisitor at the specifiek index, check if that specifiek visitor is already saved in this reservation, if it is, then don't save
        /// the visitor, and show a propper message.
        /// If visitor already belongs to another reservation, show a propper message and don't save.
        /// Save the visitor only if visitor does not belong to any reservations, if this is success, then the total amount to pay should be updated.
        /// </summary>
        public void SaveButtonsMethod()
        {
            if (ScannerOn)
            {
                ScanOff();
            }

            if (myScannedvisitors[visitorIndex] != null)
            {
                //Go through the Savedvisitors list and check if the scanned visitor that is going to be saved is ALREADY saved on one of the other indexes.
                for (int i = 0; i < mySavedvisitors.Count; i++)
                {
                    if (mySavedvisitors[i] != null)
                    {
                        if (mySavedvisitors[i].VisitorID == myScannedvisitors[visitorIndex].VisitorID)
                        {
                            MessageBox.Show("Cannot add visitor.\nVisitor was just saved to this reservation!", "Attention");
                            DeleteButtonsMethod();
                            return;
                        }
                    }
                }

                ///If reservation already exist (Then you are working with an existing reservation, it check first if the visitor
                ///that you are trying to add is already in the reservation.)
                if (thereservation != null)
                {
                    if (dbhelper.GetVisitorIDsReservation(thereservation.SpotID).Any(id => id == myScannedvisitors[visitorIndex].VisitorID))
                    {
                        MessageBox.Show("This visitor already belongs to this reservation.", "Attention");
                        DeleteButtonsMethod();
                    }
                    else
                    {
                        if ((myScannedvisitors[visitorIndex] as VisitorAtCamping).SpotID == "NULL")
                        {
                            textboxesVisitors[visitorIndex].BackColor = Color.PaleGreen;
                            mySavedvisitors[visitorIndex] = myScannedvisitors[visitorIndex];
                            totalamount = totalamount + 20;
                            tbTotalAmount.Text = totalamount.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Cannot add visitor.\nVisitor already belongs to camping spot " + (myScannedvisitors[visitorIndex] as VisitorAtCamping).SpotID + ".", "Attention"); DeleteButtonsMethod();
                        }
                    }
                }
                else
                {
                    if ((myScannedvisitors[visitorIndex] as VisitorAtCamping).SpotID == "NULL")
                    {
                        textboxesVisitors[visitorIndex].BackColor = Color.PaleGreen;
                        mySavedvisitors[visitorIndex] = myScannedvisitors[visitorIndex];
                        totalamount = totalamount + 20;
                        tbTotalAmount.Text = totalamount.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cannot add visitor.\nVisitor already belongs to camping spot " + (myScannedvisitors[visitorIndex] as VisitorAtCamping).SpotID + ".", "Attention");
                        DeleteButtonsMethod();
                    }
                }
            }
        }

        /// <summary>
        /// If the visitor with that specifiek visitorIndex is saved then remove that visitor from the saved list and also the visitor from the scanned
        /// list with that specifiek visitorIndex.
        /// If there are no visitor with that specifiek visitorIndex saved, just remove that scanned visitor with that specifiek visitorIndex from the scanned list.
        /// Also when deleting a visitor from the saved visitor list, the totalamount to pay should be deducted.
        /// </summary>
        public void DeleteButtonsMethod()
        {
            if (mySavedvisitors[visitorIndex] != null)
            {
                myScannedvisitors[visitorIndex] = null;
                tbVisitor1Balance.Text = "";
                textboxesVisitors[visitorIndex].Text = "";
                textboxesVisitors[visitorIndex].BackColor = DefaultBackColor;
                mySavedvisitors[visitorIndex] = null;
                totalamount = totalamount - 20;
                tbTotalAmount.Text = totalamount.ToString();
            }
            else
            {
                myScannedvisitors[visitorIndex] = null;
                textboxesVisitors[visitorIndex].Text = "";
            }

            if (visitorIndex == 0)
            {
                tbVisitor1Balance.Text = "";
            }
        }

        /// <summary>
        /// visitorIndex = 0.
        /// Perform ScanButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btScanVisitor1_Click(object sender, EventArgs e)
        {
            visitorIndex = 0;
            ScanButtonsMethod();
            tbVisitor1Balance.Text = "";
        }

        /// <summary>
        /// visitorIndex = 1.
        /// Perform ScanButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btScanVisitor2_Click(object sender, EventArgs e)
        {
            visitorIndex = 1;
            ScanButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 2.
        /// Perform ScanButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btScanVisitor3_Click(object sender, EventArgs e)
        {
            visitorIndex = 2;
            ScanButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 3.
        /// Perform ScanButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btScanVisitor4_Click(object sender, EventArgs e)
        {
            visitorIndex = 3;
            ScanButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 4.
        /// Perform ScanButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btScanVisitor5_Click(object sender, EventArgs e)
        {
            visitorIndex = 4;
            ScanButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 5.
        /// Perform ScanButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btScanVisitor6_Click(object sender, EventArgs e)
        {
            visitorIndex = 5;
            ScanButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 0.
        /// Check if this paying visitor already booked another reservation, if not. than save, if so, dont save and show a proppermessage
        /// and also delete the reservation from the scanned list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveVisitor1_Click(object sender, EventArgs e)
        {
            visitorIndex = 0;

            if (dbhelper.GetCampingReservationVisitorIDs().Any(id => id == myScannedvisitors[visitorIndex].VisitorID))
            {
                MessageBox.Show("This visitor cannot pay for this reservation.\nVisitor already has a booked reservation.", "Attention");
                DeleteButtonsMethod();
            }
            else
            {
                SaveButtonsMethod();
            }
        }

        /// <summary>
        /// visitorIndex = 1.
        /// Perform SaveButtonMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveVisitor2_Click(object sender, EventArgs e)
        {
            visitorIndex = 1;
            SaveButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 2.
        /// Perform SaveButtonMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveVisitor3_Click(object sender, EventArgs e)
        {
            visitorIndex = 2;
            SaveButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 3.
        /// Perform SaveButtonMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveVisitor4_Click(object sender, EventArgs e)
        {
            visitorIndex = 3;
            SaveButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 4.
        /// Perform SaveButtonMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveVisitor5_Click(object sender, EventArgs e)
        {
            visitorIndex = 4;
            SaveButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 5.
        /// Perform SaveButtonMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveVisitor6_Click(object sender, EventArgs e)
        {
            visitorIndex = 5;
            SaveButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 0.
        /// Perform DeleteButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteVisitor1_Click(object sender, EventArgs e)
        {
            visitorIndex = 0;
            DeleteButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 1.
        /// Perform DeleteButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteVisitor2_Click(object sender, EventArgs e)
        {
            visitorIndex = 1;
            DeleteButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 2.
        /// Perform DeleteButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteVisitor3_Click(object sender, EventArgs e)
        {
            visitorIndex = 2;
            DeleteButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 3.
        /// Perform DeleteButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteVisitor4_Click(object sender, EventArgs e)
        {
            visitorIndex = 3;
            DeleteButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 4.
        /// Perform DeleteButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteVisitor5_Click(object sender, EventArgs e)
        {
            visitorIndex = 4;
            DeleteButtonsMethod();
        }

        /// <summary>
        /// visitorIndex = 5.
        /// Perform DeleteButtonsMethod.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteVisitor6_Click(object sender, EventArgs e)
        {
            visitorIndex = 5;
            DeleteButtonsMethod();
        }

        /// <summary>
        /// This button is for none-existing reservation.
        /// When clicked, if there is no saved visitor in list at index 0 then show propper message.
        /// if there are completely no visitor saved, show propper message.
        /// Else check if there is a spotid chosen, if there is not show propper message, if there is a spot chosen 
        /// then make the reservation and add all the visitors to the reservation (connect to database and do the insert queries into the database).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (mySavedvisitors[0] == null)
                {
                    MessageBox.Show("Visitor who is paying is not saved.", "Attention");
                    btCancel.PerformClick();
                    return;
                }

                if (mySavedvisitors.All(visitor => visitor == null))
                {
                    MessageBox.Show("No visitor is saved in the reservation.", "Attention");
                    btCancel.PerformClick();
                    return;
                }

                String spotID = null;

                if (!lbAvailSpot.SelectedIndex.Equals(-1))
                {
                    spotID = campingSpots[lbAvailSpot.SelectedIndex];

                    for (int i = 0; i < mySavedvisitors.Count; i++)
                    {
                        if (mySavedvisitors[i] != null)
                        {
                            visitorIDs[i] = mySavedvisitors[i].VisitorID;
                        }
                    }

                    if (totalamount <= mySavedvisitors[0].Balance)
                    {
                        if (dbhelper.MakeCampingReservationCompleteUpdate(spotID, totalamount, visitorIDs, mySavedvisitors[0]))
                        {
                            MessageBox.Show("Transaction successful!");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Error, something went wrong.");
                            btCancel.PerformClick();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Visitor does not have enough money to pay for camping spot.", "Attention");
                        btCancel.PerformClick();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, please try again.");
            }
        }

        /// <summary>
        /// If scanner is on, turn off, then dispose this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Booking_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }
            this.Dispose();
        }

        /// <summary>
        /// if scanner is on, then turn off, then clear all the visitor's scanned and saved list. 
        /// This button click should also clear the textboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReset_Click(object sender, EventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }

            foreach (TextBox item in textboxesVisitors)
            {
                item.Clear();
                item.BackColor = DefaultBackColor;
            }

            for (int i = 0; i < 6; i++)
            {
                mySavedvisitors[i] = null;
                myScannedvisitors[i] = null;
            }

            btDone.Show();
            btConfirm.Hide();
            lblInfo.Show();

            foreach (Button item in scansavedeleteButtons)
            {
                item.Enabled = true;
            }

            tbVisitor1Balance.Clear();
            totalamount = 30.00M;
            tbTotalAmount.Text = totalamount.ToString();
        }

        /// <summary>
        /// if the button btDoneExistingReservation.Visible is visible, then this form is disposed.
        /// if the button btDoneExistingReservation.Visible is not visible then make it visible and hide the btConfirmExistingReservation button and also
        /// make the buttons in the scansavedeleteButtons array true, also disable the event handler of the RFID and enable it back assigning it another target.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancelExistingReservation_Click(object sender, EventArgs e)
        {
            if (!btDoneExistingReservation.Visible)
            {
                btDoneExistingReservation.Show();
                btConfirmExistingReservation.Hide();
                foreach (Button item in scansavedeleteButtons)
                {
                    item.Enabled = true;
                }

                if (ScannerOn)
                {
                    ScanOff();
                }
                myRFIDReader.Tag -= new TagEventHandler(ReadTagPayingVisitor);
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
                lbConfirm.Hide();
                lbInfoScanTag.Hide();
            }
            else
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// Reads a tag, if the read visitor is not the one who booked the reservation, then show propper errormessage.
        /// else show the button btConfirmExistingReservation to let the user confirm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadTagPayingVisitor(object sender, TagEventArgs e)
        {
            Console.Beep(2500, 200);
            try
            {
                mypayingvisitor = dbhelper.GetVisitorCamping(e.Tag);

                if (mypayingvisitor.VisitorID == thereservation.Visitor.VisitorID)
                {
                    lbInfoScanTag.Hide();
                    lbConfirm.Show();
                    btConfirmExistingReservation.Show();
                    myRFIDReader.Antenna = false;
                }
                else
                {
                    lbInfoScanTag.Hide();
                    myRFIDReader.Antenna = false;
                    MessageBox.Show("Incorrect visitor, please scan visitor: " + thereservation.Visitor.ToString());
                    myRFIDReader.Antenna = true;
                    lbInfoScanTag.Show();
                    lbConfirm.Hide();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// if no visitor is scanned, show a message to scan atleast a visitor.
        /// else disable the event handler and assign to it another target (the one to scan the paying visitor) and turn scanner on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDoneExistingReservation_Click(object sender, EventArgs e)
        {
            if (mySavedvisitors.All(visitor => visitor == null))
            {
                MessageBox.Show("Please save a visitor before clicking 'Done'.");
                btCancel.PerformClick();
                return;
            }
            else
            {
                btDoneExistingReservation.Hide();
                lblInfo.Hide();
                lbInfoScanTag.Show();
                foreach (Button item in scansavedeleteButtons)
                {
                    item.Enabled = false;
                }

                try
                {
                    if (ScannerOn)
                    {
                        ScanOff();
                    }

                    myRFIDReader.Tag -= new TagEventHandler(ReadTag);
                    myRFIDReader.Tag += new TagEventHandler(ReadTagPayingVisitor);
                    ScanOn();
                }
                catch (PhidgetException)
                {
                    MessageBox.Show("Error, could not start");
                }
            }
        }

        /// <summary>
        /// if savedvisitor list is null then show propper message and disable the event handler and assign it back with the ReadTag target.
        /// else check if balance is more or equal to the amount to be paid, if it is, connect to database and add visitors to the reservation.
        /// if amount is more than balance then show propper message and make this btConfirmExistingReservation back invisable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btConfirmExistingReservation_Click(object sender, EventArgs e)
        {
            if (mySavedvisitors.All(visitor => visitor == null))
            {
                MessageBox.Show("No visitor is saved in the reservation.", "Attention");
                foreach (Button item in scansavedeleteButtons)
                {
                    item.Enabled = true;
                }
                btDoneExistingReservation.Show();

                if (ScannerOn)
                {
                    ScanOff();
                }
                myRFIDReader.Tag -= new TagEventHandler(ReadTagPayingVisitor);
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
                lbConfirm.Hide();
                btConfirmExistingReservation.Hide();
                lbInfoScanTag.Hide();
                return;
            }
            else
            {
                if (totalamount <= mypayingvisitor.Balance)
                {
                    for (int i = 0; i < mySavedvisitors.Count; i++)
                    {
                        if (mySavedvisitors[i] != null)
                        {
                            visitorIDs[i] = mySavedvisitors[i].VisitorID;
                        }
                    }

                    if (dbhelper.ExistingCampingReservationCompleteUpdate(thereservation.SpotID, totalamount, visitorIDs, mypayingvisitor))
                    {
                        MessageBox.Show("Transaction successful!");
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot complete transaction.\nBalance of visitor: " + mypayingvisitor.Balance.ToString() + " Euros.\nAmount to pay is bigger than balance.", "Attention");

                    foreach (Button item in scansavedeleteButtons)
                    {
                        item.Enabled = true;
                    }
                    btDoneExistingReservation.Show();

                    if (ScannerOn)
                    {
                        ScanOff();
                    }
                    myRFIDReader.Tag -= new TagEventHandler(ReadTagPayingVisitor);
                    myRFIDReader.Tag += new TagEventHandler(ReadTag);
                    lbConfirm.Hide();
                    btConfirmExistingReservation.Hide();
                    lbInfoScanTag.Hide();
                    return;
                }
            }
        }

        /// <summary>
        /// Button for none-existing reservation.
        /// if scanner is on, turn off. if no camping spot is selected, show propper message, else then hide this button and show the confirm button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDone_Click(object sender, EventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }

            if (!lbAvailSpot.SelectedIndex.Equals(-1))
            {
                btDone.Hide();
                btConfirm.Show();
                lblInfo.Hide();

                foreach (Button item in scansavedeleteButtons)
                {
                    item.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select a camping spot.", "Attention");
            }
        }

        /// <summary>
        /// Button for none-existing reservation.
        /// If the btDone is visible then dispose this form.
        /// else show the btDone and hide the btConfirm. also make all buttons back true (available to click).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            if (!btDone.Visible)
            {
                btDone.Show();
                btConfirm.Hide();
                lblInfo.Show();
                foreach (Button item in scansavedeleteButtons)
                {
                    item.Enabled = true;
                }

                if (ScannerOn)
                {
                    ScanOff();
                }
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
