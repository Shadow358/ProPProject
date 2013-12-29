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

        private void Reservations_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (!lbReservations.SelectedIndex.Equals(-1))
            {
                reservation = allreservations[lbReservations.SelectedIndex];
                int canAdd = (6 - dbhelper.CountVisitorsWithSpotID(reservation.SpotID));

                if (canAdd == 6)
                {
                    MessageBox.Show("Empty reservation. This reservation will be deleted.");
                    dbhelper.DeleteReservation(reservation.SpotID);
                    this.Dispose();
                    return;
                }

                if (canAdd == 0)
                {
                    MessageBox.Show("This reservation contains max (6) visitor already");
                    this.Dispose();
                }
                else
                {
                    this.Dispose();
                    ReservationForm reservationformexisting = new ReservationForm(reservation, canAdd);
                    reservationformexisting.ShowDialog(this.Owner);
                }
            }
            else
            {
                MessageBox.Show("No reservation was selected!");
            }
        }
    }
}
