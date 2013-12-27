using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Classes
{
    public class DBHelper
    {
        public MySqlConnection connection;

        public DBHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi276088;" +
                                    "user id=dbi276088;" +
                                    "password=rBKKYV4r7a;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        public Visitor getVisitor(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitor_id;
                String rfid;
                String first_name;
                String last_name;
                decimal balance;

                while (reader.Read())
                {
                    visitor_id = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    first_name = Convert.ToString(reader[2]);
                    last_name = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    TheVisitor = new Visitor(visitor_id, rfid, first_name, last_name, balance);
                }
                return TheVisitor;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public Visitor getVisitorEntrance(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, inside_event FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitor_id;
                String rfid;
                String first_name;
                String last_name;
                decimal balance;
                bool inside;

                while (reader.Read())
                {
                    visitor_id = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    first_name = Convert.ToString(reader[2]);
                    last_name = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    if (reader[5] == DBNull.Value)
                    {
                        inside = (reader[5]) as bool? ?? false; //if null it will be false (default)...
                    }
                    else
                    {
                        inside = Convert.ToBoolean(reader[5]);
                    }

                    TheVisitor = new VisitorAtEntrance(visitor_id, rfid, first_name, last_name, balance, inside);
                }
                return TheVisitor;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public Visitor getVisitorExit(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, inside_event FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitor_id;
                String rfid;
                String first_name;
                String last_name;
                decimal balance;
                bool inside;

                while (reader.Read())
                {
                    visitor_id = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    first_name = Convert.ToString(reader[2]);
                    last_name = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    if (reader[5] == DBNull.Value)
                    {
                        inside = (reader[5]) as bool? ?? false; //if null it will be false...
                    }
                    else
                    {
                        inside = Convert.ToBoolean(reader[5]);
                    }

                    TheVisitor = new VisitorAtExit(visitor_id, rfid, first_name, last_name, balance, inside);
                }
                return TheVisitor;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public Visitor getVisitorCamping(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, spot_id FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitor_id;
                String rfid;
                String first_name;
                String last_name;
                decimal balance;
                int spot_id;

                while (reader.Read())
                {
                    visitor_id = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    first_name = Convert.ToString(reader[2]);
                    last_name = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    if (reader[5] == DBNull.Value)
                    {
                        spot_id = (reader[5]) as int? ?? -1; //if null it will be -1 (default)...
                    }
                    else
                    {
                        spot_id = Convert.ToInt32(reader[5]);
                    }

                    TheVisitor = new VisitorAtCamping(visitor_id, rfid, first_name, last_name, balance, spot_id);
                }
                return TheVisitor;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool RemoveMoneyFromBalance(Visitor currentVisitor, Decimal amount)
        {
            try
            {
                String sql = "UPDATE visitor SET balance = balance - " + amount + " WHERE visitor_id = " + currentVisitor.Visitor_id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool AddMoneyToBalance(Visitor currentVisitor, Decimal amount)
        {
            try
            {
                String sql = "UPDATE visitor SET balance = balance + " + amount + " WHERE visitor_id = " + currentVisitor.Visitor_id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool setBalanceToZero(Visitor currentVisitor)
        {
            try
            {
                String sql = "UPDATE visitor SET balance = 0 WHERE visitor_id = " + currentVisitor.Visitor_id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool enterEvent(Visitor currentVisitor)
        {
            try
            {
                String sql = "UPDATE visitor SET inside_event = TRUE WHERE visitor_id = " + currentVisitor.Visitor_id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool exitEvent(Visitor currentVisitor)
        {
            try
            {
                String sql = "UPDATE visitor SET inside_event = FALSE WHERE visitor_id = " + currentVisitor.Visitor_id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public int countArticlesNotReturned(Visitor currentVisitor)
        {
            int count = 0;

            try
            {
                String sql = "SELECT count(*) FROM rental_details rd JOIN rental_transaction rt ON (rd.rent_id = rt.rent_id) JOIN visitor v ON (rt.visitor_id = v.visitor_id) WHERE rd.article_returned = false AND v.visitor_id = " + currentVisitor.Visitor_id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    count = Convert.ToInt32(reader[0]);
                }
                return count;
            }
            catch (MySqlException)
            {
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Product> GetAllProducts(int shopID)
        {
            try
            {
                String sql = "SELECT p.product_id, p.product_description, p.product_price, s.stock_quantity FROM Product p NATURAL JOIN Stock s WHERE s.shop_id = " + shopID + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                List<Product> tempList = new List<Product>();
                int productID;
                String productDescription;
                decimal productPrice;
                int quantity;

                while (reader.Read())
                {
                    productID = Convert.ToInt32(reader[0]);
                    productDescription = Convert.ToString(reader[1]);
                    productPrice = Convert.ToDecimal(reader[2]);
                    quantity = Convert.ToInt32(reader[3]);

                    Product tempItem = new Product(productID, productPrice, productDescription, quantity);
                    tempList.Add(tempItem);
                }
                return tempList;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Product> GetAllRentals()
        {
            try
            {
                String sql = "SELECT * FROM  article;";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                List<Rental> tempList = new List<Rental>();
                int productID;
                String productDescription;
                decimal productPrice;
                int quantity;
                string comment;

                while (reader.Read())
                {
                    productID = Convert.ToInt32(reader[0]);
                    productDescription = Convert.ToString(reader[1]);
                    productPrice = Convert.ToDecimal(reader[2]);
                    quantity = Convert.ToInt32(reader[3]);
                    comment = Convert.ToString(reader[4]);

                    Rental tempItem = new Rental(productID, productPrice, productDescription, quantity, comment);
                    tempList.Add(tempItem);
                }
                return tempList;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddMoneyPaypal(int id, decimal amount)
        {
            try
            {
                String sql = "UPDATE visitor SET balance = balance + " + amount + " WHERE visitor_id = " + id + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return;
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                connection.Close();
            }
        }

        public CampReservation getCampingReservation(int? spotid)
        {
            try
            {
                CampReservation Reservation = null;
                VisitorAtCamping TheVisitor = null;

                String sql = "SELECT booking_id, visitor_id, booking_date, spot_id, shouldbe_paid, amount_paid FROM camping_reservation WHERE spot_id = " + spotid + ";";

                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int bookingID;
                int visitorID;
                DateTime bookingDate;
                int spotID;
                Decimal shouldbePaid;
                Decimal amountPaid;

                while (reader.Read())
                {
                    bookingID = Convert.ToInt32(reader[0]);
                    visitorID = Convert.ToInt32(reader[1]);
                    bookingDate = Convert.ToDateTime(reader[2]);
                    spotID = Convert.ToInt32(reader[3]);
                    shouldbePaid = Convert.ToDecimal(reader[4]);
                    amountPaid = Convert.ToDecimal(reader[5]);

                    connection.Close();
                    connection.Open();

                    String visitorwhopaid = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, spot_id FROM visitor WHERE visitor_id = " + visitorID + ";";
                    MySqlCommand commandvisitor = new MySqlCommand(visitorwhopaid, connection);
                    MySqlDataReader readervisitor = commandvisitor.ExecuteReader();

                    int visitor_id;
                    String rfid;
                    String first_name;
                    String last_name;
                    decimal balance;
                    int spot_id;

                    while (readervisitor.Read())
                    {
                        visitor_id = Convert.ToInt32(readervisitor[0]);
                        rfid = Convert.ToString(readervisitor[1]);
                        first_name = Convert.ToString(readervisitor[2]);
                        last_name = Convert.ToString(readervisitor[3]);
                        balance = Convert.ToDecimal(readervisitor[4]);
                        spot_id = Convert.ToInt32(readervisitor[5]);

                        TheVisitor = new VisitorAtCamping(visitor_id, rfid, first_name, last_name, balance, spot_id);
                        Reservation = new CampReservation(bookingID, TheVisitor, bookingDate, spotID, shouldbePaid, amountPaid);

                        break;
                    }
                    break;
                }
                return Reservation;
            }
            catch (MySqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool PayCampingSpot(Decimal amount)
        {
            try
            {
                String sql = "UPDATE camping_reservation SET amount_paid = amount_paid + " + amount + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public String GetDate()
        {
            return DateTime.Now.ToString("yyyy-M-dd");
        }

        public bool ConfirmShopTransaction(int shopID, Visitor myVisitor, List<BasketItem> basketList, decimal amount)
        {
            try
            {
                String sqlTransaction = @"INSERT INTO transaction VALUES (NULL, ""\" + GetDate() + "\", " + myVisitor.Visitor_id + " , " + shopID + ") ;";
                sqlTransaction.Replace(@"\", string.Empty);
                // INSERT INTO transaction VALUES (0, "2013-07-08" , 7 , 1); works
                MySqlCommand commandTransaction = new MySqlCommand(sqlTransaction, connection);
                String sqlTransactionID = "SELECT MAX(trans_id) FROM transaction WHERE visitor_id = " + myVisitor.Visitor_id + " GROUP BY visitor_id;";
                MySqlCommand commandTransactionID = new MySqlCommand(sqlTransactionID, connection);

                connection.Open();
                commandTransaction.ExecuteNonQuery();
                int transactionID = (int)commandTransactionID.ExecuteScalar();
                foreach (BasketItem basketItem in basketList)
                {
                    String sqlTransDetails = "INSERT INTO transaction_details (trans_id, product_id, quantity) VALUES (" + transactionID + ", " + basketItem.Product.ProductID + ", " + basketItem.Quantity + ") ;";
                    MySqlCommand commandTransDetails = new MySqlCommand(sqlTransDetails, connection);
                    commandTransDetails.ExecuteNonQuery();
                    String sqlUpdateStock = "UPDATE stock set stock_quantity = " + basketItem.Quantity + " WHERE product_id = " + basketItem.Product.ProductID + " AND shop_id = " + shopID + " ;";
                    MySqlCommand commandUpdateStock = new MySqlCommand(sqlUpdateStock, connection);
                    commandUpdateStock.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
