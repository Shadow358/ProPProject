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
    public partial class Reservations : Form
    {
        DBHelper dbhelper;
        List<CampReservation> allreservations;
        CampReservation reservation;

        //Constructor of this form.
        public Reservations(List<CampReservation> reservations)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dbhelper = new DBHelper();
            allreservations = reservations;

            foreach (CampReservation item in allreservations)
            {
                lbReservations.Items.Add(item.ToString());
            }
        }

        /// <summary>
        /// Choosing a reservation from the list.
        /// If no reservation is choosed, then an errormessage is show.
        /// If a reservation is chosen then an instance of the ReservationsForm is created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e)
        {
            //If a line in the listbox is selected (reservation is selected)
            if (!lbReservations.SelectedIndex.Equals(-1))
            {
                reservation = allreservations[lbReservations.SelectedIndex];
                //cadAdd is how many visitors can be added to the reservations.
                int canAdd = (6 - dbhelper.CountVisitorsWithSpotID(reservation.SpotID));

                //If canAdd is 6 that means the reservation is just an empty reservation so it will be automatically deleted.
                //then this form is disposed.
                if (canAdd == 6)
                {
                    MessageBox.Show("Empty reservation. This reservation will be deleted.");
                    dbhelper.DeleteReservation(reservation.SpotID);
                    this.Dispose();
                    return;
                }

                //If canAdd is 0 then the reservation is full. No more visitors can be added to this reservation.
                if (canAdd == 0)
                {
                    MessageBox.Show("This reservation contains max (6) visitor already");
                    this.Dispose();
                }
                //if canAdd is between 1 and 5, create an instance of the ReservationForm.
                else
                {
                    this.Dispose();
                    ReservationForm reservationformexisting = new ReservationForm(reservation, canAdd);
                    reservationformexisting.ShowDialog(this.Owner);
                }
            }
            //If no reservation is selected.
            else
            {
                MessageBox.Show("No reservation was selected!");
            }
        }

        /// <summary>
        /// When button Cancel is clicked, this form is disposed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// When form closed, this form is displosed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reservations_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
