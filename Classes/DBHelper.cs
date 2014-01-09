using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace Classes
{
    public class DBHelper
    {
        public MySqlConnection connection;

        /// <summary>
        /// Constructor created a connection for database
        /// </summary>
        public DBHelper()
        {
            String connectionInfo = "server=athena01.fhict.local;" +
                                    "database=dbi276088;" +
                                    "user id=dbi276088;" +
                                    "password=rBKKYV4r7a;" +
                                    "connect timeout=30;";

            connection = new MySqlConnection(connectionInfo);
        }

        //Methods
        /// <summary>
        /// Select VisitorAtExit from database
        /// </summary>
        /// <param name="rfidChip">Scanned rfidchip</param>
        /// <returns>Returns the visitor with the scanned rfidchip</returns>
        public Visitor GetVisitor(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitorid;
                String rfid;
                String firstname;
                String lastname;
                decimal balance;

                while (reader.Read())
                {
                    visitorid = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    firstname = Convert.ToString(reader[2]);
                    lastname = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    TheVisitor = new Visitor(visitorid, rfid, firstname, lastname, balance);
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

        /// <summary>
        /// Select VisitorAtEntrance from database
        /// </summary>
        /// <param name="rfidChip">Scanned rfidchip</param>
        /// <returns>Returns the visitor with the scanned rfidchip</returns>
        public Visitor GetVisitorEntrance(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, inside_event FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitorid;
                String rfid;
                String firstname;
                String lastname;
                decimal balance;
                bool inside;

                while (reader.Read())
                {
                    visitorid = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    firstname = Convert.ToString(reader[2]);
                    lastname = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    if (reader[5] == DBNull.Value)
                    {
                        inside = (reader[5]) as bool? ?? false; //if null it will be false.
                    }
                    else
                    {
                        inside = Convert.ToBoolean(reader[5]);
                    }

                    TheVisitor = new VisitorAtEntrance(visitorid, rfid, firstname, lastname, balance, inside);
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

        /// <summary>
        /// Select VisitorAtExit from database
        /// </summary>
        /// <param name="rfidChip">Scanned rfidchip</param>
        /// <returns>Returns the visitor with the scanned rfidchip</returns>
        public Visitor GetVisitorExit(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, inside_event FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitorid;
                String rfid;
                String firstname;
                String lastname;
                decimal balance;
                bool inside;

                while (reader.Read())
                {
                    visitorid = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    firstname = Convert.ToString(reader[2]);
                    lastname = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    if (reader[5] == DBNull.Value)
                    {
                        inside = (reader[5]) as bool? ?? false; //if null it will be false.
                    }
                    else
                    {
                        inside = Convert.ToBoolean(reader[5]);
                    }

                    TheVisitor = new VisitorAtExit(visitorid, rfid, firstname, lastname, balance, inside);
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

        /// <summary>
        /// Select VisitorAtCamping from database
        /// </summary>
        /// <param name="rfidChip">Scanned rfidchip</param>
        /// <returns>Returns the visitor with the scanned rfidchip</returns>
        public Visitor GetVisitorCamping(String rfidChip)
        {
            try
            {
                Visitor TheVisitor = null;
                rfidChip = "'" + rfidChip + "'";

                String sql = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, spot_id FROM visitor WHERE rfid_chip = " + rfidChip + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int visitorid;
                String rfid;
                String firstname;
                String lastname;
                decimal balance;
                String spotid;

                while (reader.Read())
                {
                    visitorid = Convert.ToInt32(reader[0]);
                    rfid = Convert.ToString(reader[1]);
                    firstname = Convert.ToString(reader[2]);
                    lastname = Convert.ToString(reader[3]);
                    balance = Convert.ToDecimal(reader[4]);

                    if (String.IsNullOrEmpty(Convert.ToString(reader[5])))
                    {
                        spotid = "NULL"; //if null it will be "NULL".
                    }
                    else
                    {
                        spotid = Convert.ToString(reader[5]);
                    }

                    TheVisitor = new VisitorAtCamping(visitorid, rfid, firstname, lastname, balance, spotid);
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

        /// <summary>
        /// Remove amount from visitor's balance
        /// </summary>
        /// <param name="currentVisitor">Visitor that amount will be deducted from balance</param>
        /// <param name="amount">Amount to be deducted from balance</param>
        /// <returns>Returns true if transaction is successful</returns>
        public bool RemoveMoneyFromBalance(Visitor currentVisitor, Decimal amount)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE visitor SET balance = balance - " + amount + " WHERE visitor_id = " + currentVisitor.VisitorID + ";";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adds amount to visitor's balance
        /// </summary>
        /// <param name="currentVisitor">Visitor that balance will be updated</param>
        /// <param name="amount">Amount to add to balance</param>
        /// <returns>Returns true if transaction is successful</returns>
        public bool AddMoneyToBalance(Visitor currentVisitor, Decimal amount)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE visitor SET balance = balance + " + amount + " WHERE visitor_id = " + currentVisitor.VisitorID + ";";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Sets visitor's balance to 0.00
        /// </summary>
        /// <param name="currentVisitor">Visitor that balance will be updated</param>
        /// <returns>returns true if transaction is successful</returns>
        public bool SetBalanceToZero(Visitor currentVisitor)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE visitor SET balance = 0 WHERE visitor_id = " + currentVisitor.VisitorID + ";";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Update visitor's status to inside event
        /// </summary>
        /// <param name="currentVisitor">Current visitor to update status</param>
        /// <returns>returns true if transaction is successful</returns>
        public bool EnterEvent(Visitor currentVisitor)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE visitor SET inside_event = TRUE WHERE visitor_id = " + currentVisitor.VisitorID + ";";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Update visitor's status to not-inside event 
        /// </summary>
        /// <param name="currentVisitor">Current visitor that status will be updated</param>
        /// <returns>returns true if transaction is successful</returns>
        public bool ExitEvent(Visitor currentVisitor)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE visitor SET inside_event = FALSE WHERE visitor_id = " + currentVisitor.VisitorID + ";";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Select number of articles that a visitor did NOT return to the rental shop
        /// </summary>
        /// <param name="currentVisitor">Current visitor that did not return items to rental shop</param>
        /// <returns>Returns a number of items that is not returned</returns>
        public int CountArticlesNotReturned(Visitor currentVisitor)
        {
            int count = 0;

            try
            {
                String sql = "SELECT count(*) FROM rental_details rd JOIN rental_transaction rt ON (rd.rent_id = rt.rent_id) JOIN visitor v ON (rt.visitor_id = v.visitor_id) WHERE rd.article_returned = false AND v.visitor_id = " + currentVisitor.VisitorID + ";";
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

        /// <summary>
        /// Select a list of products of the specified shop.
        /// </summary>
        /// <param name="shopid">The ID of the specified shop</param>
        /// <returns>Returns a list of products of the specified shop</returns>
        public List<Product> GetAllProducts(int shopid)
        {
            try
            {
                String sql = "SELECT p.product_id, p.product_description, p.product_price, s.stock_quantity FROM Product p NATURAL JOIN Stock s WHERE s.shop_id = " + shopid + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                List<Product> tempList = new List<Product>();
                int productid;
                String productdescription;
                decimal productprice;
                int quantity;

                while (reader.Read())
                {
                    productid = Convert.ToInt32(reader[0]);
                    productdescription = Convert.ToString(reader[1]);
                    productprice = Convert.ToDecimal(reader[2]);
                    quantity = Convert.ToInt32(reader[3]);

                    Product tempItem = new Product(productid, productprice, productdescription, quantity);
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

        /// <summary>
        /// Select a list of rentals of the rental shop.
        /// </summary>
        /// <returns>Returns a list of rentals of the rental shop</returns>
        public List<Rental> GetAllRentals()
        {
            try
            {
                String sql = "SELECT * FROM  article WHERE article_availability > 0;";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                List<Rental> tempList = new List<Rental>();
                int productid;
                String productdescription;
                decimal productprice;
                int quantity;
                string comment;

                while (reader.Read())
                {
                    productid = Convert.ToInt32(reader[0]);
                    productdescription = Convert.ToString(reader[1]);
                    productprice = Convert.ToDecimal(reader[2]);
                    quantity = Convert.ToInt32(reader[3]);
                    comment = Convert.ToString(reader[4]);

                    Rental tempItem = new Rental(productid, productprice, productdescription, quantity, comment);
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

        /// <summary>
        /// Select a list of rentals of a specified visitor
        /// </summary>
        /// <param name="myVisitor">The current visitor</param>
        /// <returns>Returns a list of rentals of the specified visitor</returns>
        public List<Rental> GetAllRentalsOfVisitor(Visitor myVisitor)
        {
            try
            {
                List<Rental> tempListRental = new List<Rental>();
                int productID;
                String productDescription;
                decimal productPrice;
                int quantity;
                string comment;

                String selectRentID = "SELECT rent_id FROM rental_transaction WHERE visitor_id = " + myVisitor.VisitorID + ";"; // Select all rent_id's of the visitor
                MySqlCommand commandRentID = new MySqlCommand(selectRentID, connection);

                connection.Open();
                MySqlDataReader readerRentID = commandRentID.ExecuteReader();

                List<Int32> transactionIDList = new List<Int32>(); // A list that will contain all the transaction ID's of the user

                while (readerRentID.Read())
                {
                    transactionIDList.Add(Convert.ToInt32(readerRentID[0]));
                }
                readerRentID.Close();
                if (transactionIDList.Count == 0) // If he doesn't have any rentals, return an empty list
                {
                    return tempListRental;
                }

                List<Int32> articleIDList = new List<Int32>(); // Now it's time to store all the article ID's

                foreach (Int32 transactionID in transactionIDList)
                {
                    String selectArticleID = "SELECT article_id FROM rental_details WHERE rent_id = " + transactionID + " AND article_returned = 0;";
                    MySqlCommand commandArticleID = new MySqlCommand(selectArticleID, connection);
                    MySqlDataReader readerArticleID = commandArticleID.ExecuteReader();
                    while (readerArticleID.Read())
                    {
                        articleIDList.Add(Convert.ToInt32(readerArticleID[0]));
                    }
                    readerArticleID.Close(); // Now we've got a list of all article ID's, time to get the articles and add them to the tempListRental
                }

                foreach (Int32 articleID in articleIDList)
                {
                    String selectArticle = "SELECT * FROM article WHERE article_id = " + articleID + ";";
                    MySqlCommand commandArticle = new MySqlCommand(selectArticle, connection);
                    MySqlDataReader readerArticle = commandArticle.ExecuteReader();
                    while (readerArticle.Read())
                    {
                        productID = Convert.ToInt32(readerArticle[0]);
                        productDescription = Convert.ToString(readerArticle[1]);
                        productPrice = Convert.ToDecimal(readerArticle[2]);
                        quantity = Convert.ToInt32(readerArticle[3]);
                        comment = Convert.ToString(readerArticle[4]);

                        Rental tempItem = new Rental(productID, productPrice, productDescription, quantity, comment);
                        tempListRental.Add(tempItem);
                    }
                    readerArticle.Close();
                }

                return tempListRental;
            }
            catch (MySqlException x)
            {
                MessageBox.Show(x.ToString());
                return null;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        //PRESLAV I'LL LEAVE THIS FOR YOU SINCE YOU HAVE TO FIX IT :) (for comments? I guess x Vincent)
        public void AddMoneyPaypal(int id, decimal amount)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                String sql = "UPDATE visitor SET balance = balance + " + amount + " WHERE visitor_id = " + id + ";";

                command.ExecuteNonQuery();
                mytransaction.Commit();
                return;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Return a camping reservation from the database with givin spotID
        /// </summary>
        /// <param name="spotid">spotID of the reservation</param>
        /// <returns>returns a camping reservation</returns>
        public CampReservation GetCampingReservation(String spotid)
        {
            try
            {
                CampReservation Reservation = null;
                VisitorAtCamping TheVisitor = null;

                String sql = "SELECT booking_id, visitor_id, booking_date, spot_id, shouldbe_paid, amount_paid FROM camping_reservation WHERE spot_id = '" + spotid + "';";

                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                int bookingId;
                int visitorId;
                DateTime bookingDate;
                String spotId;
                Decimal shouldbePaid;
                Decimal amountPaid;

                while (reader.Read())
                {
                    bookingId = Convert.ToInt32(reader[0]);
                    visitorId = Convert.ToInt32(reader[1]);
                    bookingDate = Convert.ToDateTime(reader[2]);
                    spotId = Convert.ToString(reader[3]);
                    shouldbePaid = Convert.ToDecimal(reader[4]);
                    amountPaid = Convert.ToDecimal(reader[5]);

                    connection.Close();
                    connection.Open();

                    String visitorwhopaid = "SELECT visitor_id, rfid_chip, first_name, last_name, balance, spot_id FROM visitor WHERE visitor_id = " + visitorId + ";";
                    MySqlCommand commandvisitor = new MySqlCommand(visitorwhopaid, connection);
                    MySqlDataReader readervisitor = commandvisitor.ExecuteReader();

                    int visitorid;
                    String rfid;
                    String firstname;
                    String lastname;
                    decimal balance;
                    String spot;

                    while (readervisitor.Read())
                    {
                        visitorid = Convert.ToInt32(readervisitor[0]);
                        rfid = Convert.ToString(readervisitor[1]);
                        firstname = Convert.ToString(readervisitor[2]);
                        lastname = Convert.ToString(readervisitor[3]);
                        balance = Convert.ToDecimal(readervisitor[4]);
                        spot = Convert.ToString(readervisitor[5]);

                        TheVisitor = new VisitorAtCamping(visitorid, rfid, firstname, lastname, balance, spot);
                        Reservation = new CampReservation(bookingId, TheVisitor, bookingDate, spotId, shouldbePaid, amountPaid);

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

        /// <summary>
        /// Selects the current time
        /// </summary>
        /// <returns>Returns the current time</returns>
        public String GetDate()
        {
            return DateTime.Now.ToString("yyyy-M-dd");
        }

        /// <summary>
        /// Tries to confirm the transaction of a shop
        /// </summary>
        /// <param name="shopID">The ID of the specified shop</param>
        /// <param name="myVisitor">The current visitor</param>
        /// <param name="basketList">The products the visitor wants to buy</param>
        /// <param name="amount">The amount the visitor has to pay</param>
        /// <returns>Returns true if successful</returns>
        public bool ConfirmShopTransaction(int shopID, Visitor myVisitor, List<BasketItem> basketList, decimal amount)
        {
            connection.Open();
            MySqlCommand commandTransaction = connection.CreateCommand();
            MySqlTransaction mytransaction;
            
            //Start sqlTransaction
            mytransaction = connection.BeginTransaction();
            commandTransaction.Connection = connection;
            commandTransaction.Transaction = mytransaction;

            try
            {
                /*String sqlTransaction = @"INSERT INTO transaction VALUES (NULL, ""\" + GetDate() + "\", " + myVisitor.VisitorID + " , " + shopID + ") ;";
                sqlTransaction.Replace(@"\", string.Empty);
                INSERT INTO transaction VALUES (0, "2013-07-08" , 7 , 1); also works*/
                commandTransaction.CommandText = @"INSERT INTO transaction VALUES (NULL, ""\" + GetDate() + "\", " + myVisitor.VisitorID + " , " + shopID + ") ;";
                commandTransaction.CommandText.Replace(@"\", string.Empty);
                commandTransaction.ExecuteNonQuery();

                String sqlTransactionID = "SELECT MAX(trans_id) FROM transaction WHERE visitor_id = " + myVisitor.VisitorID + " GROUP BY visitor_id;";
                MySqlCommand commandTransactionID = new MySqlCommand(sqlTransactionID, connection);

                int transactionID = (int)commandTransactionID.ExecuteScalar();
                foreach (BasketItem basketItem in basketList)
                {
                    commandTransaction.CommandText = "INSERT INTO transaction_details (trans_id, product_id, quantity) VALUES (" + transactionID + ", " + basketItem.Product.ProductID + ", " + basketItem.Quantity + ") ;";
                    commandTransaction.ExecuteNonQuery();
                    commandTransaction.CommandText = "UPDATE stock set stock_quantity = (stock_quantity -" + basketItem.Quantity + ") WHERE product_id = " + basketItem.Product.ProductID + " AND shop_id = " + shopID + " ;";
                    commandTransaction.ExecuteNonQuery();
                    /*String sqlTransDetails = "INSERT INTO transaction_details (trans_id, product_id, quantity) VALUES (" + transactionID + ", " + basketItem.Product.ProductID + ", " + basketItem.Quantity + ") ;";
                    MySqlCommand commandTransDetails = new MySqlCommand(sqlTransDetails, connection);
                    commandTransDetails.ExecuteNonQuery();
                    String sqlUpdateStock = "UPDATE stock set stock_quantity = " + basketItem.Quantity + " WHERE product_id = " + basketItem.Product.ProductID + " AND shop_id = " + shopID + " ;";
                    MySqlCommand commandUpdateStock = new MySqlCommand(sqlUpdateStock, connection);
                    commandUpdateStock.ExecuteNonQuery();*/
                }
                mytransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Tries to confirm the rental transaction of the rental shop
        /// </summary>
        /// <param name="myVisitor">The current visitor</param>
        /// <param name="basketList">The products the visitor wants to buy</param>
        /// <param name="amount">The amount the visitor has to pay</param>
        /// <returns>Returns true if successful</returns>
        public bool ConfirmRentalTransaction(Visitor myVisitor, List<Rental> basketList, decimal amount)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                String sqlTransaction = @"INSERT INTO rental_transaction VALUES (NULL, " + myVisitor.VisitorID + ", \"" + GetDate() + "\", " + amount + ") ;";
                sqlTransaction.Replace(@"\", string.Empty);
                MySqlCommand commandTransaction = new MySqlCommand(sqlTransaction, connection);

                String sqlTransactionID = "SELECT MAX(rent_id) FROM rental_transaction WHERE visitor_id = " + myVisitor.VisitorID + " GROUP BY visitor_id;";
                MySqlCommand commandTransactionID = new MySqlCommand(sqlTransactionID, connection);

                commandTransaction.ExecuteNonQuery();
                int transactionID = (int)commandTransactionID.ExecuteScalar();
                foreach (Rental basketItem in basketList)
                {
                    String sqlTransDetails = "INSERT INTO rental_details (article_id, rent_id, article_returned) VALUES (" + basketItem.ProductID + ", " + transactionID + ", " + 0 + ") ;";
                    MySqlCommand commandTransDetails = new MySqlCommand(sqlTransDetails, connection);
                    commandTransDetails.ExecuteNonQuery();
                    String sqlUpdateStock = "UPDATE article set article_availability = " + 0 + " WHERE article_id = " + basketItem.ProductID + ";";
                    MySqlCommand commandUpdateStock = new MySqlCommand(sqlUpdateStock, connection);
                    commandUpdateStock.ExecuteNonQuery();
                }
                mytransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Tries to confirm the returnal of rentals of users
        /// </summary>
        /// <param name="basketList">The rentals the visitor wants to bring back</param>
        /// <returns>Returns true if successful</returns>
        public bool ConfirmRentalReturnal(List<Rental> basketList)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                foreach (Rental item in basketList)
                {
                    String sqlUpdateArticle = "UPDATE article SET article_availability = 1, comment = \"" + item.Comment + "\" WHERE article_id = " + item.ProductID + " ;";
                    sqlUpdateArticle.Replace(@"\", string.Empty);
                    MySqlCommand commandUpdateArticle = new MySqlCommand(sqlUpdateArticle, connection);
                    String sqlUpdateRentalDetails = "UPDATE rental_details SET article_returned = 1 WHERE article_id = " + item.ProductID + ";";
                    MySqlCommand commandUpdateRentalDetails = new MySqlCommand(sqlUpdateRentalDetails, connection);
                    commandUpdateArticle.ExecuteNonQuery();
                    commandUpdateRentalDetails.ExecuteNonQuery();
                }
                mytransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Returns a list with all the available (free) camping spots
        /// </summary>
        /// <returns>Returns a list of strings</returns>
        public List<String> GetAvailableSpots()
        {
            try
            {
                String sql = "SELECT spot_id FROM camping_spot WHERE spot_id NOT IN (SELECT spot_id FROM camping_reservation);";
                MySqlCommand command = new MySqlCommand(sql, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                List<String> tempList = new List<String>();
                String spot_id;

                while (reader.Read())
                {
                    spot_id = Convert.ToString(reader[0]);

                    tempList.Add(spot_id);
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

        /// <summary>
        /// Update the camping reservation payment and also update the balance of the visitor who paid/reserved the camping spot.
        /// </summary>
        /// <param name="currentVisitor">The visitor who reserved and will pay the amount to be paid</param>
        /// <param name="amount">Amount that needs to be paid by the visitor</param>
        /// <param name="spotID">The spotID of the camping spot that needs to be updated</param>
        /// <returns>returns true if transaction was successful</returns>
        public bool UpdatePaymentCampingAndBalance(Visitor currentVisitor, Decimal amount, String spotID)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE camping_reservation SET amount_paid = amount_paid + " + amount + ", shouldbe_paid = amount_paid WHERE spot_id = '" + spotID + "';";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE visitor SET balance = balance - " + amount + " WHERE visitor_id = " + currentVisitor.VisitorID + ";";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Make a reservation, update the balance of the visitor who is paying and adds the spotID to the visitor's who are staying at the camping spot
        /// </summary>
        /// <param name="spotid">Campingspot for the reservation</param>
        /// <param name="paymentamount">Total amount to be paid</param>
        /// <param name="visitorIDs">VisitorIDs that will stay on the camping spot</param>
        /// <param name="currentVisitor">Currentvisitor that has to pay/booked the reservation</param>
        /// <returns>Returns true if the transaction is successful</returns>
        public bool MakeCampingReservationCompleteUpdate(String spotid, Decimal paymentamount, int[] visitorIDs, Visitor payingVisitor)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "INSERT INTO camping_reservation (visitor_id, booking_date, spot_id, shouldbe_paid, amount_paid) VALUES (" + payingVisitor.VisitorID + ", '" +
                    DateTime.Now.ToString("yyyy-M-dd") + "', '" + spotid + "', " + paymentamount + ", " + paymentamount + ");";
                command.ExecuteNonQuery();

                for (int i = 0; i < visitorIDs.Length; i++)
                {
                    if (visitorIDs[i] != 0)
                    {
                        command.CommandText = "UPDATE visitor SET spot_id = '" + spotid + "' WHERE visitor_id = " + visitorIDs[i] + ";";
                        command.ExecuteNonQuery();
                    }
                }

                command.CommandText = "UPDATE visitor SET balance = balance - " + paymentamount + " WHERE visitor_id = " + payingVisitor.VisitorID + ";";
                command.ExecuteNonQuery();

                mytransaction.Commit();

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

        /// <summary>
        /// Working with an existing camping reservation, adds visitors to the camping spot, deduct balance of the visitor who is paying
        /// </summary>
        /// <param name="spotid">The camping spot id of the reservation</param>
        /// <param name="paymentamount">The amount that needs to be paid</param>
        /// <param name="visitorIDs">The visitorIDs of the visitors that are going to be added to the reservation</param>
        /// <param name="currentVisitor">The visitor who is booked/reserved the reservation and is paying</param>
        /// <returns>returns true if transaction is successful</returns>
        public bool ExistingCampingReservationCompleteUpdate(String spotid, Decimal paymentamount, int[] visitorIDs, Visitor payingVisitor)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "UPDATE camping_reservation SET amount_paid = amount_paid + " + paymentamount + ", shouldbe_paid = amount_paid WHERE spot_id = '" + spotid + "';";
                command.ExecuteNonQuery();

                for (int i = 0; i < visitorIDs.Length; i++)
                {
                    if (visitorIDs[i] != 0)
                    {
                        command.CommandText = "UPDATE visitor SET spot_id = '" + spotid + "' WHERE visitor_id = " + visitorIDs[i] + ";";
                        command.ExecuteNonQuery();
                    }
                }

                command.CommandText = "UPDATE visitor SET balance = balance - " + paymentamount + " WHERE visitor_id = " + payingVisitor.VisitorID + ";";
                command.ExecuteNonQuery();

                mytransaction.Commit();

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

        /// <summary>
        /// Select the camping reservations from the database and put them in a list
        /// </summary>
        /// <returns>Returns a list of camping reservations</returns>
        public List<CampReservation> GetAllReservations()
        {
            try
            {
                List<CampReservation> templist = new List<CampReservation>();

                CampReservation Reservation = null;
                VisitorAtCamping TheVisitor = null;

                //for reservation
                int bookingID;
                int visitorID;
                DateTime bookingDate;
                String spotID;
                Decimal shouldbePaid;
                Decimal amountPaid;

                //for visitor that booked reservation
                int visitorid;
                String rfid;
                String firstname;
                String lastname;
                decimal balance;
                String spotid;

                connection.Open();

                String sql = "SELECT cr.booking_id, cr.visitor_id, cr.booking_date, cr.spot_id, cr.shouldbe_paid, cr.amount_paid, v.visitor_id, v.rfid_chip, v.first_name, v.last_name, v.balance, v.spot_id FROM camping_reservation cr JOIN visitor v ON (cr.visitor_id = v.visitor_id);";
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bookingID = Convert.ToInt32(reader[0]);
                    visitorID = Convert.ToInt32(reader[1]);
                    bookingDate = Convert.ToDateTime(reader[2]);
                    spotID = Convert.ToString(reader[3]);
                    shouldbePaid = Convert.ToDecimal(reader[4]);
                    amountPaid = Convert.ToDecimal(reader[5]);
                    visitorid = Convert.ToInt32(reader[6]);
                    rfid = Convert.ToString(reader[7]);
                    firstname = Convert.ToString(reader[8]);
                    lastname = Convert.ToString(reader[9]);
                    balance = Convert.ToDecimal(reader[10]);
                    spotid = Convert.ToString(reader[11]);

                    TheVisitor = new VisitorAtCamping(visitorid, rfid, firstname, lastname, balance, spotid);
                    Reservation = new CampReservation(bookingID, TheVisitor, bookingDate, spotID, shouldbePaid, amountPaid);

                    templist.Add(Reservation);
                }
                return templist;
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

        /// <summary>
        /// Count the number of visitors that has the same camping spot id
        /// </summary>
        /// <param name="spotID">The givin spotid to use in the database</param>
        /// <returns>returns an integer</returns>
        public int CountVisitorsWithSpotID(String spotID)
        {
            try
            {
                int count = 0;

                connection.Open();

                String sql = "SELECT COUNT(*) FROM visitor WHERE spot_id =  '" + spotID + "';";
                MySqlCommand command = new MySqlCommand(sql, connection);

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

        /// <summary>
        /// Deletes a reservation with a givin spotid
        /// </summary>
        /// <param name="spotID">Spotid of a camping spot</param>
        /// <returns>Returns true if transaction was successful</returns>
        public bool DeleteReservation(String spotID)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction mytransaction;

            //Start transaction
            mytransaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = mytransaction;

            try
            {
                command.CommandText = "DELETE FROM camping_reservation WHERE spot_id = '" + spotID + "';";
                command.ExecuteNonQuery();
                mytransaction.Commit();

                return true;
            }
            catch (Exception)
            {
                try
                {
                    mytransaction.Rollback();
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Returns all the visitorID's of visitors that reserved/booked a camping spot
        /// </summary>
        /// <returns>Returns a list of integers</returns>
        public List<int> GetCampingReservationVisitorIDs()
        {
            try
            {
                connection.Open();

                List<int> VisitorIDs = new List<int>();

                String sql = "SELECT visitor_id FROM camping_reservation";
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                int visitorid;

                while (reader.Read())
                {
                    visitorid = Convert.ToInt32(reader[0]);
                    VisitorIDs.Add(visitorid);
                }
                return VisitorIDs;
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

        /// <summary>
        /// Returns a list of visitorID's that belongs to a givin spotID
        /// </summary>
        /// <param name="spotid">The spotID that we want to know about.</param>
        /// <returns>Returns a list of integers</returns>
        public List<int> GetVisitorIDsReservation(String spotid)
        {
            try
            {
                connection.Open();

                List<int> VisitorIDs = new List<int>();
                spotid = "'" + spotid + "'";

                String sql = "SELECT visitor_id FROM visitor WHERE spot_id = " + spotid + ";";
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                int visitorid;

                while (reader.Read())
                {
                    visitorid = Convert.ToInt32(reader[0]);
                    VisitorIDs.Add(visitorid);
                }
                return VisitorIDs;
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
    }
}
