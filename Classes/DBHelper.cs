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
                        inside = (reader[5]) as bool? ?? false; //if null it will be false...
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
       
    }
}
