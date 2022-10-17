using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PoppelOrderingSystem_INF2011S_Project.DatabaseLayer;
using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PoppelOrderingSystem_INF2011S_Project.Database_Layer
{
    public class OrderDB : Database
    {
        #region Data members
        /* Collections */
        private Collection<Order> orders;
        private Collection<Product> products;
        #endregion

        #region Constructor
        public OrderDB() : base()
        {
            orders = new Collection<Order>();
            products = new Collection<Product>();
            readOrders();
            addProductsToCollection();
        }
        #endregion

        #region Order Crud Operations

        public void readOrders()
        {
            string query = "SELECT * FROM dbo.[Order]";
            SqlCommand command = new SqlCommand(query, cnMain );
            SqlDataReader reader;
            Order order;

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read() )
                {
                    int orderID = reader.GetInt32(0);
                    int customerID = reader.GetInt32(1);
                    int clerkID = reader.GetInt16(2);
                    double orderTotal = reader.GetSqlMoney(3).ToDouble();

                    Order.Status status = Order.Status.NOSTATUS;
                    switch ( (int) reader.GetInt16(4) )
                    {
                        case ((int) Order.Status.NOSTATUS):
                            status = Order.Status.NOSTATUS;
                            
                            break;
                        case ((int) Order.Status.ONHOLD):
                            status = Order.Status.ONHOLD;
                            
                            break;
                        case ((int) Order.Status.INPROCESS):
                            status = Order.Status.INPROCESS;
                            
                            break;
                        case ((int) Order.Status.CONFIRMED):
                            status = Order.Status.CONFIRMED;
                            
                            break;
                        case ((int ) Order.Status.SHIPPED):
                            status = Order.Status.SHIPPED;
                            
                            break;
                        case ((int)Order.Status.RETURNED):
                            status = Order.Status.RETURNED;
                            
                            break;
                    }

                    
                    DateTime date = reader.GetDateTime(5);
                    date = DateTime.Now;
                    
                    order = new Order( orderID, customerID, clerkID, orderTotal, status, date );
                    orders.Add( order );
                    

                }
                cnMain.Close();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.Message );
            }
            finally
            {
                cnMain.Close();
            }
        }
        public void createOrder( Order order )
        {
            string query = "INSERT INTO dbo.[Order] ( customerID, clerkID, orderTotal, orderStatus, dateCompleted ) " +
                            "VALUES ( @customerID, @clerkID, @orderTotal, @orderStatus, @dateCompleted )";

            SqlCommand command = new SqlCommand(query, cnMain);

            command.Parameters.AddWithValue("@customerID", order.CustomerID);
            command.Parameters.AddWithValue("@clerkID", order.ClerkID);
            command.Parameters.AddWithValue("@orderTotal", order.OrderTotal);
            Order.Status status = order.OrderStatus;
            switch (status)
            {
                case (Order.Status.NOSTATUS):
                    command.Parameters.AddWithValue("@orderStatus", 0); ;
                    break;
                case (Order.Status.ONHOLD):
                    command.Parameters.AddWithValue("@orderStatus", 2);
                    break;
                case (Order.Status.INPROCESS):
                    command.Parameters.AddWithValue("@orderStatus", 4);
                    break;
                case (Order.Status.CONFIRMED):
                    command.Parameters.AddWithValue("@orderStatus", 5);
                    break;
                case (Order.Status.SHIPPED):
                    command.Parameters.AddWithValue("@orderStatus", 1);
                    break;
                case (Order.Status.RETURNED):
                    command.Parameters.AddWithValue("@orderStatus", 3);
                    break;
            }

            command.Parameters.AddWithValue("@dateCompleted", order.OrderDate);

            try
            {
                cnMain.Open();
                
                command.ExecuteNonQuery();
                MessageBox.Show("Order Created Succesfully.");
                orders.Add(order);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("An error occured while trying to create order.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnMain.Close();
            }


        }

        public void editOrder( Order order )
        {
            string query =  "UPDATE Order SET orderTotal = @orderTotal, orderStatus = @orderStatus " +
                            "WHERE orderID = @orderID";

            SqlCommand command = new SqlCommand(query, cnMain);

            command.Parameters.AddWithValue("@orderID", order.OrderID);
            command.Parameters.AddWithValue("@orderTotal", order.OrderTotal);
            command.Parameters.AddWithValue("@orderStatus", (int) order.OrderStatus);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                cnMain.Close(); 
                MessageBox.Show("Order Created Succesfully.");
                orders.Add(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to create order.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnMain.Close();
            }
        }

        public int getLatestOrderID()
        {
            string query = "SELECT MAX( orderID ) FROM dbo.[Order]";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();
                int orderID = -1;
                while (reader.Read())
                {
                    orderID = reader.GetInt32(0);
                    
                }

                cnMain.Close();
                return orderID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                cnMain.Close();
            }
        }

        public Order getOrderByID( int id )
        {
            string query = "SELECT * FROM dbo.[Order]";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;
            Order order = null;

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int orderID = reader.GetInt32(0);
                    int customerID = reader.GetInt32(1);
                    int clerkID = reader.GetInt16(2);
                    double orderTotal = reader.GetSqlMoney(3).ToDouble();

                    Order.Status status = Order.Status.ONHOLD;
                    switch ( (int) reader.GetInt16(4) )
                    {
                        case ((int)Order.Status.NOSTATUS):
                            status = Order.Status.NOSTATUS;
                            break;
                        case ((int)Order.Status.ONHOLD):
                            status = Order.Status.ONHOLD;
                            break;
                        case ((int)Order.Status.INPROCESS):
                            status = Order.Status.INPROCESS;
                            break;
                        case ((int)Order.Status.CONFIRMED):
                            status = Order.Status.CONFIRMED;
                            break;
                        case ((int)Order.Status.SHIPPED):
                            status = Order.Status.SHIPPED;
                            break;
                        case ((int)Order.Status.RETURNED):
                            status = Order.Status.RETURNED;
                            break;
                    }
                    

                    Console.WriteLine("executing query");
                    DateTime date = reader.GetDateTime(5);
                    Console.WriteLine("executing query");
                    order = new Order(orderID, customerID, clerkID, orderTotal, status, date);

                }
                cnMain.Close();

                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                cnMain.Close();
            }
            finally
            {
                cnMain.Close();
            }
            return null;
        }
        #endregion

        #region Product CRUD Operations
        public Product getProductByName(string pname)
        {
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM Product WHERE productName = " + pname.Trim();

            Product product = null;
            command = new SqlCommand(query, cnMain);
            command.Parameters.AddWithValue("@productName", pname);


            try
            {
                product = new Product();
                command = new SqlCommand(query, cnMain);
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product.ProductCode = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1).Trim();
                    product.Price = reader.GetDouble(2);
                    product.ExpiryDate = reader.GetDateTime(3);
                    product.InStockLevel = reader.GetInt16(4);
                    product.ProductType = (Product.Category) reader.GetInt16(5);

                }
                cnMain.Close();
                return product;
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find product with name: " + pname + "\n" + ex.ToString());
                return null;
            }

        }
        public void addProductsToCollection()
        {
            string query = "SELECT * FROM Product WHERE expiryDate > GETDATE()";
            SqlCommand command = new SqlCommand( query, cnMain);
            SqlDataReader reader;
            Product product;

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();
                

                while (reader.Read())
                {
                    product = new Product();

                    product.ProductCode = reader.GetInt32(0);
                    switch( reader.GetInt16(1) )
                    {
                        case ( (int) Product.Category.SOFTDRINK ):
                            product.ProductType = Product.Category.SOFTDRINK;
                            break;
                        case ((int)Product.Category.BRANDED):
                            product.ProductType = Product.Category.BRANDED;
                            break;
                        case ((int)Product.Category.UNSPECIFIED):
                            product.ProductType = Product.Category.UNSPECIFIED;
                            break;
                        case ((int)Product.Category.UNBRANDED):
                            product.ProductType = Product.Category.UNBRANDED;
                            break;
                        case ((int)Product.Category.CONFECTIONARY):
                            product.ProductType = Product.Category.CONFECTIONARY;
                            break;
                        default:
                            product.ProductType = Product.Category.UNSPECIFIED;
                            break;

                    }
                    product.ProductName = reader.GetString(2);
                    product.ProductDescription = reader.GetString(3);
                    product.Price = reader.GetSqlMoney(4).ToDouble();
                    product.InStockLevel = reader.GetInt16(5);
                    product.ExpiryDate = reader.GetDateTime(6);

                    products.Add(product);
                }
                cnMain.Close();
            }
            catch( Exception ex )
            {
                MessageBox.Show("Failed To load products " + ex.Message);
                
            }
            finally
            {
                cnMain.Close();
            }

        }

        public Collection<Product> GenerateExpiryReport()
        {
            string query = "SELECT * FROM Product WHERE expiryDate < GETDATE()";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;
            Product product;
            Collection<Product> expired = new Collection<Product>();

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();


                while (reader.Read())
                {
                    product = new Product();

                    product.ProductCode = reader.GetInt32(0);
                    switch (reader.GetInt16(1))
                    {
                        case ((int)Product.Category.SOFTDRINK):
                            product.ProductType = Product.Category.SOFTDRINK;
                            break;
                        case ((int)Product.Category.BRANDED):
                            product.ProductType = Product.Category.BRANDED;
                            break;
                        case ((int)Product.Category.UNSPECIFIED):
                            product.ProductType = Product.Category.UNSPECIFIED;
                            break;
                        case ((int)Product.Category.UNBRANDED):
                            product.ProductType = Product.Category.UNBRANDED;
                            break;
                        case ((int)Product.Category.CONFECTIONARY):
                            product.ProductType = Product.Category.CONFECTIONARY;
                            break;
                        default:
                            product.ProductType = Product.Category.UNSPECIFIED;
                            break;

                    }
                    product.ProductName = reader.GetString(2);
                    product.ProductDescription = reader.GetString(3);
                    product.Price = reader.GetSqlMoney(4).ToDouble();
                    product.InStockLevel = reader.GetInt16(5);
                    product.ExpiryDate = reader.GetDateTime(6);

                    expired.Add(product);
                }
                cnMain.Close();

                return expired;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To generate expired Products " + ex.Message);
            }
            finally
            {
                cnMain.Close(); 
            }
            return expired;

        }

        public Product getProductByCode( int id )
        {
            string query = "SELECT * FROM Product WHERE productCode = @productCode";
            SqlCommand command = new SqlCommand( query, cnMain );
            command.Parameters.AddWithValue("@productCode", id);
            Product product = null;
            try
            {
                cnMain.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while ( reader.Read() )
                {
                    product = new Product();

                    product.ProductCode = reader.GetInt32(0);
                    product.ProductType = (Product.Category)reader.GetInt16(1);
                    product.ProductName = reader.GetString(2);
                    product.ProductDescription = reader.GetString(3);
                    product.Price= reader.GetSqlMoney(4).ToDouble();
                    product.InStockLevel= reader.GetInt16(5);
                    product.ExpiryDate = reader.GetDateTime(6);
                }

                cnMain.Close();
                return product;
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Failed to get product with id {0}.", id.ToString() );
                Console.WriteLine(ex.Message);
                cnMain.Close();
                return null;
            }
            return null;
        }
        #endregion

        #region OrderItem CRUD Operations
        public Collection<OrderItem> getOrderItemsByOrderID( int id )
        {
            string query = "SELECT * FROM OrderItem WHERE orderID = @orderID";
            SqlCommand command = new SqlCommand(query, cnMain );
            command.Parameters.AddWithValue("orderID", id);
            SqlDataReader reader;
            OrderItem item;
            Collection<OrderItem> items = new Collection<OrderItem>();

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while ( reader.Read() )
                {
                    Order order = getOrderByID(reader.GetInt32(0));
                    Product product = getProductByCode( reader.GetInt32(1));
                    int quantity = reader.GetInt32(2);

                    item = new OrderItem(order, product, quantity);

                    items.Add(item);
                }
                cnMain.Close();
                return items;
            }
            catch ( Exception ex )
            {
                Console.WriteLine("Exception: " + ex.Message);
                cnMain.Close();
            }
            return items;
        }

        public void AddOrderItems( Collection<OrderItem> items )
        {
            string query = "INSERT INTO OrderItem ( orderID, productCode, quantity, itemTotal ) " +
                            "VALUES ( @orderID, @productCode, @quantity, @itemTotal )";
            
            try
            {

                foreach( OrderItem item in items )
                {
                    SqlCommand command = new SqlCommand(query, cnMain);
                    command.Parameters.AddWithValue("@orderID", item.OrderID);
                    command.Parameters.AddWithValue("@productCode", item.ProductCode);
                    command.Parameters.AddWithValue("@quantity", item.Quantity);
                    command.Parameters.AddWithValue("@itemTotal", item.SubTotal);

                    cnMain.Open();
                    command.ExecuteNonQuery();
                    cnMain.Close();
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine("Failed to add order items");
                cnMain.Close();
            }
        }
        #endregion

        #region Picking List CRUD 
        public Collection<OrderItem> GeneratePickingList( int orderID )
        {
            Collection<OrderItem> items = new Collection<OrderItem> ();

            string query = "SELECT * FROM OrderItem WHERE orderID = @orderID";


            SqlDataReader reader;
            OrderItem item;
            SqlCommand command = new SqlCommand( query, cnMain );
            command.Parameters.AddWithValue("@orderID", orderID);
            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while ( reader.Read() )
                {
                    item = new OrderItem();
                    item.OrderID = orderID;
                    item.ProductCode = reader.GetInt32(2);
                    item.Quantity = reader.GetInt16(3);

                    items.Add(item);    
                }
                cnMain.Close();

                foreach ( OrderItem orderItem in items )
                {
                    
                    Product product = getProductByCode( orderItem.ProductCode );
                    orderItem.Product = product;

                }
                return items;
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);  
                cnMain.Close( );    
            }
            return items;

        }
        #endregion

        #region Property methods
        public Collection<Product> Products
        {
            get { return products; }
        }

        public Collection<Order> Orders
        {
            get { return orders; }
        }
        #endregion
    }
}
