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

        private static string orderTbl = "Order";
        private string orderQuery = "SELECT * FROM " + orderTbl;

        private static string productTbl = "Product";
        private string productQuery = "SELECT * FROM " + productTbl;

        /* Collections */
        private Collection<Order> orders;
        private Collection<Product> products;
        #endregion

        #region Constructor
        public OrderDB() : base()
        {
            orders = new Collection<Order>();
            products = new Collection<Product>();

            FillDataSet(orderQuery, orderTbl);
            FillDataSet(productQuery, productTbl);
            Add2Collection(productTbl);
        }
        #endregion

        // Products methods
        #region Add products to collection method

        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Product object
            DataRow myRow = null;
            Product product;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Product object
                    product = new Product();

                    //Obtain product attributes from the specific field in the row in the table

                    product.ProductCode = Convert.ToString(myRow["productCode"]).TrimEnd();
                    product.ProductName = Convert.ToString(myRow["productName"]).TrimEnd();
                    product.Price = Convert.ToDouble(myRow["price"]);
                    product.ExpiryDate = Convert.ToDateTime(myRow["expiryDate"]);
                    product.InStockLevel = Convert.ToInt16(myRow["inStock"]);
                    product.ProductType = (Product.Category)Convert.ToInt16(myRow["categoryID"]);

                    
                    // add order to collection
                    products.Add(product);
                }
            }
        }
        #endregion

        #region Display all products from collection
        public void DisplayProducts()
        {
            Console.WriteLine("{0} Products:", products.Count);
            Console.WriteLine();
            foreach (Product item in products)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        #endregion

        #region Get Product By Name
        public Product getProductByName( string pname )
        {
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM " + productTbl + " WHERE productName = " + pname.Trim();

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
                    product.ProductCode = reader.GetString(0).Trim();
                    product.ProductName = reader.GetString(1).Trim();
                    product.Price = reader.GetDouble(2);
                    product.ExpiryDate = reader.GetDateTime(3);
                    product.InStockLevel = reader.GetInt16(4);
                    //product.ProductType = reader.GetInt16(5);
                 
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
        #endregion

        // Order methods

        #region Fill Data methods
        private void FillRow(DataRow row, Order order)
        {

            row["orderNumber"] = order.OrderID;
            row["orderDate"] = order.OrderDate;
            row["requiredDate"] = order.RequiredDate;
            row["shippedDate"] = order.ShippedDate;
            row["status"] = order.OrderStatus;
            row["customerID"] = order.CustomerID;

        }

        public void DataSetChange(Order order)
        {
            DataRow row = dsMain.Tables[orderTbl].NewRow();
            FillRow(row, order);
            dsMain.Tables[orderTbl].Rows.Add(row);
        }

        public bool UpdateDataSource(Order order)
        {
            bool success = true;

            Create_Insert_Command(order);

            success = UpdateDataSource(orderQuery, orderTbl);
            return success;
        }
        #endregion

        #region CRUD Operations for Order
        public void addOrder(Order order)
        {
            string insert = "INSERT INTO [Order] ( orderNumber, orderDate, requiredDate, shippedDate, status, customerID ) VALUES " +
                            "( @orderNumber, @orderDate, @requiredDate, @shippedDate, @status, @customerID)";

            SqlCommand command = new SqlCommand(insert, cnMain);

            command.CommandType = CommandType.Text;
            command.CommandText = insert;
            command.Connection = cnMain;

            command.Parameters.AddWithValue("@orderNumber", order.OrderID);
            command.Parameters.AddWithValue("@orderDate", order.OrderDate);
            command.Parameters.AddWithValue("@requiredDate", order.RequiredDate);
            command.Parameters.AddWithValue("@shippedDate", order.ShippedDate);
            command.Parameters.AddWithValue("@status", order.OrderStatus);
            command.Parameters.AddWithValue("@customerID", order.CustomerID);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Order Added Successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                cnMain.Close();
            }
        }

        public void updateOrder(Order order)
        {
            string updateString = "UPDATE Order SET orderDate = @orderDate, " +

              "requiredDate = @requiredDate, shippedDate = @shippedDate, status = @status " 
                +

              "WHERE orderNumber = @orderNumber";

            SqlCommand command = new SqlCommand(updateString, cnMain);

            command.Parameters.AddWithValue("@orderNumber", order.OrderID);
            command.Parameters.AddWithValue("@orderDate", order.OrderDate);
            command.Parameters.AddWithValue("@requiredDate", order.RequiredDate);
            command.Parameters.AddWithValue("@shippedDate", order.ShippedDate);
            command.Parameters.AddWithValue("@status", order.OrderStatus);

            try
            {
                cnMain.Open();
                int row = command.ExecuteNonQuery();
                Console.WriteLine("Order" + order.OrderID + "Update Sucessfully Successfully\nRow {0} affected", row);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error- Generated. Details: " + ex.ToString());
            }
            finally
            {
                cnMain.Close();
            }

        }
        #endregion

        #region Get order by OrderNumber
        public Order getOrderByOrderNumber(int orderID)
        {
            /**Find Customer by ID*/
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM " + orderTbl + " WHERE orderNumber = " + orderID;

            Order order;

            try
            {
                order = new Order();
                command = new SqlCommand(query, cnMain);
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    order.OrderID = reader.GetInt16(0);
                    order.OrderDate = reader.GetString(1).Trim();
                    order.RequiredDate = reader.GetString(2).Trim();
                    order.ShippedDate = reader.GetString(3).Trim();
                    order.OrderStatus = (Order.Status)reader.GetInt16(4);
                    order.CustomerID = reader.GetInt16(5);

                }
                cnMain.Close();
                return order;
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find order with orderNumber: " + orderID + "\n" + ex.ToString());
                return null;
            }

        }
        #endregion

        #region Parameters
        private void Build_Insert_Parameters(Order order)
        {
            SqlParameter parameter = default(SqlParameter);
            parameter = new SqlParameter("@orderNumber", SqlDbType.Int, 8, "orderNumber");
            daMain.InsertCommand.Parameters.Add(parameter);


            parameter = new SqlParameter("@orderDate", SqlDbType.VarChar, 50, "orderDate");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@requiredDate", SqlDbType.VarChar, 50, "requiredDate");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@shippedDate", SqlDbType.VarChar, 50, "shippedDate");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@status", SqlDbType.Int, 1, "status");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@customerID", SqlDbType.Int, 8, "customerID");
            daMain.InsertCommand.Parameters.Add(parameter);
        }

        private void Create_Insert_Command(Order order)
        {
            string insert = "INSERT INTO Order ( orderNumber, orderDate, requiredDate, shippedDate, status, customerID ) ";
            string values = "VALUES ( @orderNumber, @orderDate, @requiredDate, @shippedDate, @status, @customerID ) ";
            string insertCommand = insert + values;

            daMain.InsertCommand = new SqlCommand(insertCommand, cnMain);

            Build_Insert_Parameters(order);
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
