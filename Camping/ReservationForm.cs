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
            lbInfoScanTag.Text = "Please scan tag: (" + reservation.Visitor.ToString() + ")\nReady to scan tag...";
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
            campingSpots = dbhelper.GetAvailableSpots();

            try
            {
                foreach (String item in campingSpots)
                {
                    lbAvailSpot.Items.Add(item);
                }
                tbTotalAmount.Text = totalamount.ToString();

                myRFIDReader = new RFID();
                myRFIDReader.Tag += new TagEventHandler(ReadTag);
            }
            catch (PhidgetException)
            {
                MessageBox.Show("Error, could not start");
            }
        }

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

        public void ScanOn()
        {
            myRFIDReader.open();
            myRFIDReader.waitForAttachment(3000);
            myRFIDReader.Antenna = true;
            ScannerOn = !ScannerOn;
        }

        public void ScanOff()
        {
            myRFIDReader.Antenna = false;
            myRFIDReader.close();
            ScannerOn = !ScannerOn;
        }

        public void ScanButtonsMethod()
        {
            myScannedvisitors[visitorIndex] = null;

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
                            MessageBox.Show("Cannot add visitor,\nvisitor was just saved to this reservation!");
                            DeleteButtonsMethod();
                            return;
                        }
                    }
                }

                //If reservation already exist (Then you are working with an existing reservation, it check first if the visitor
                //that you are trying to add is already in the reservation.
                if (thereservation != null)
                {
                    if (dbhelper.GetVisitorIDsReservation(thereservation.SpotID).Any(id => id == myScannedvisitors[visitorIndex].VisitorID))
                    {
                        MessageBox.Show("This visitor already belongs to this reservation.");
                        DeleteButtonsMethod();
                    }
                    else
                    {
                        textboxesVisitors[visitorIndex].BackColor = Color.PaleGreen;
                        mySavedvisitors[visitorIndex] = myScannedvisitors[visitorIndex];
                        totalamount = totalamount + 20;
                        tbTotalAmount.Text = totalamount.ToString();
                    }
                }
                else
                {
                    textboxesVisitors[visitorIndex].BackColor = Color.PaleGreen;
                    mySavedvisitors[visitorIndex] = myScannedvisitors[visitorIndex];
                    totalamount = totalamount + 20;
                    tbTotalAmount.Text = totalamount.ToString();
                }
            }
        }

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

        private void btScanVisitor1_Click(object sender, EventArgs e)
        {
            visitorIndex = 0;
            ScanButtonsMethod();
            tbVisitor1Balance.Text = "";
        }

        private void btScanVisitor2_Click(object sender, EventArgs e)
        {
            visitorIndex = 1;
            ScanButtonsMethod();
        }

        private void btScanVisitor3_Click(object sender, EventArgs e)
        {
            visitorIndex = 2;
            ScanButtonsMethod();
        }

        private void btScanVisitor4_Click(object sender, EventArgs e)
        {
            visitorIndex = 3;
            ScanButtonsMethod();
        }

        private void btScanVisitor5_Click(object sender, EventArgs e)
        {
            visitorIndex = 4;
            ScanButtonsMethod();
        }

        private void btScanVisitor6_Click(object sender, EventArgs e)
        {
            visitorIndex = 5;
            ScanButtonsMethod();
        }

        private void btSaveVisitor1_Click(object sender, EventArgs e)
        {
            visitorIndex = 0;

            if (dbhelper.GetCampingReservationVisitorIDs().Any(id => id == myScannedvisitors[visitorIndex].VisitorID))
            {
                MessageBox.Show("This visitor cannot pay for this reservation.\nVisitor already has a booked reservation.");
                DeleteButtonsMethod();
            }
            else
            {
                SaveButtonsMethod();
            }
        }

        private void btSaveVisitor2_Click(object sender, EventArgs e)
        {
            visitorIndex = 1;
            SaveButtonsMethod();
        }

        private void btSaveVisitor3_Click(object sender, EventArgs e)
        {
            visitorIndex = 2;
            SaveButtonsMethod();
        }

        private void btSaveVisitor4_Click(object sender, EventArgs e)
        {
            visitorIndex = 3;
            SaveButtonsMethod();
        }

        private void btSaveVisitor5_Click(object sender, EventArgs e)
        {
            visitorIndex = 4;
            SaveButtonsMethod();
        }

        private void btSaveVisitor6_Click(object sender, EventArgs e)
        {
            visitorIndex = 5;
            SaveButtonsMethod();
        }

        private void btDeleteVisitor1_Click(object sender, EventArgs e)
        {
            visitorIndex = 0;
            DeleteButtonsMethod();
        }

        private void btDeleteVisitor2_Click(object sender, EventArgs e)
        {
            visitorIndex = 1;
            DeleteButtonsMethod();
        }

        private void btDeleteVisitor3_Click(object sender, EventArgs e)
        {
            visitorIndex = 2;
            DeleteButtonsMethod();
        }

        private void btDeleteVisitor4_Click(object sender, EventArgs e)
        {
            visitorIndex = 3;
            DeleteButtonsMethod();
        }

        private void btDeleteVisitor5_Click(object sender, EventArgs e)
        {
            visitorIndex = 4;
            DeleteButtonsMethod();
        }

        private void btDeleteVisitor6_Click(object sender, EventArgs e)
        {
            visitorIndex = 5;
            DeleteButtonsMethod();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (mySavedvisitors[0] == null)
                {
                    MessageBox.Show("Visitor who is paying is not saved.");
                    btCancel.PerformClick();
                    return;
                }

                if (mySavedvisitors.All(visitor => visitor == null))
                {
                    MessageBox.Show("No visitor is saved in the reservation.");
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
                        if (dbhelper.MakeCampingReservation(mySavedvisitors[0].VisitorID, spotID, totalamount, totalamount)
                            && dbhelper.VisitorSpotIDUpdate(visitorIDs, spotID)
                            && dbhelper.RemoveMoneyFromBalance(mySavedvisitors[0], totalamount))
                        {
                            MessageBox.Show("Transaction was successfully!");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Unsuccessfully, something went wrong.");
                            btCancel.PerformClick();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Visitor does not have enough money to pay for camping spot.");
                        btCancel.PerformClick();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, please try again.");
            }
        }

        private void Booking_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ScannerOn)
            {
                ScanOff();
            }
            this.Dispose();
        }

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

        private void btConfirmExistingReservation_Click(object sender, EventArgs e)
        {
            if (mySavedvisitors.All(visitor => visitor == null))
            {
                MessageBox.Show("No visitor is saved in the reservation.");
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

                    if (dbhelper.RemoveMoneyFromBalance(mypayingvisitor, totalamount) && dbhelper.VisitorSpotIDUpdate(visitorIDs, thereservation.SpotID) && dbhelper.UpdatePaymentCampingSpot(totalamount, thereservation.SpotID))
                    {
                        MessageBox.Show("Transaction was successfully!");
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot complete transaction.\nBalance of visitor: " + mypayingvisitor.Balance.ToString() + " Euros.\nAmount to pay is bigger than balance.");

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
                MessageBox.Show("Please select a camping spot.");
            }
        }

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

        private void btScanPayingVisitor_Click(object sender, EventArgs e)
        {

        }
    }
}
