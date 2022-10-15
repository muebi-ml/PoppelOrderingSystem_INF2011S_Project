using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using PoppelOrderingSystem_INF2011S_Project.DatabaseLayer;

namespace PoppelOrderingSystem_INF2011S_Project.Database_Layer
{
    public class CustomerDB : Database
    {
        #region Data Members 

        #region Query Strings And Tables
        private static string customerTable = "Customer";
        private static string accountTable = "Account";
        private string customersQueryString = "SELECT * FROM " + customerTable;
        private string accountsQueryString = "SELECT * FROM " + accountTable;
        #endregion

        #region Collections
        private Collection<Customer> customers;
        private Collection<Account> accounts;
        #endregion

        #endregion

        #region Constructor
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            accounts = new Collection<Account>();
            FillDataSet( customersQueryString, customerTable );
            FillDataSet( accountsQueryString, accountTable );
        }
        #endregion


        #region Fill Data methods
        private void FillCustomers( SqlDataReader reader )
        {
            // Fill the customers collection
            Customer customer;

            while ( reader.Read() )
            {

                customer = new Customer();

                customer.CustomerID = reader.GetInt16(0);
                customer.FirstName = reader.GetString(1).Trim();
                customer.LastName = reader.GetString(2).Trim();
                customer.Phone = reader.GetString(3).Trim();
                customer.Email = reader.GetString(4).Trim();
                customer.AddressID = reader.GetInt16(5);
                customer.AccountID = reader.GetInt16(6);

                // Add customer to collection
                customers.Add(customer);
            }
        }

        private void FillRow( DataRow row , Customer customer )
        {
            
            row["customerID"] = customer.CustomerID;
            row["firstName"] = customer.FirstName;
            row["lastName"] = customer.LastName;
            row["phone"] = customer.Phone;
            row["email"] = customer.Email;
            row["accountID"] = customer.AccountID;
            row["addressID"] = customer.AddressID;
        }

        public void DataSetChange( Customer customer )
        {
            string table = customerTable;
            DataRow row = dsMain.Tables[customerTable].NewRow();
            FillRow( row, customer );
            dsMain.Tables[customerTable].Rows.Add( row );
        }

        public bool UpdateDataSource( Customer customer )
        {
            bool success = true;

            Create_Insert_Command(customer);

            success = UpdateDataSource(customersQueryString, customerTable);
            return success;
        }

        private Account getCustomeWithAccountID( int id )
        {
            Account account = new Account();
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM " + accountTable + " WHERE accountID = " + id;

            try
            {
                command = new SqlCommand(query, cnMain);
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    account.AccountID = reader.GetInt16(0);
                    account.AccountName = reader.GetString(1).Trim();

                    string status = reader.GetString(2).Trim();

                }
                return account;
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find customer with id: " + id + "\n" + ex.ToString());
                return null;
            }

        }
        #region CRUD Operations Customer
        public void addCustomer( Customer customer )
        {
            string insert = "INSERT INTO Customer ( customerID, firstName, lastName, phone, email, addressID, accountID ) VALUES " +
                            "( @customerID, @firstName, @lastName, @phone, @email, @addressID, @accountID )";

            SqlCommand command = new SqlCommand( insert, cnMain );

            command.CommandType = CommandType.Text;
            command.CommandText = insert;
            command.Connection = cnMain;

            command.Parameters.AddWithValue("@customerID", customer.CustomerID);
            command.Parameters.AddWithValue("@firstName", customer.FirstName);
            command.Parameters.AddWithValue("@lastName", customer.LastName);
            command.Parameters.AddWithValue("phone", customer.Phone);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@addressID", customer.AddressID);
            command.Parameters.AddWithValue("@accountID", customer.AccountID);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Customer Added Successfully");
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

        public void updateCustomerDetails( Customer customer )
        {
            string updateString =   "UPDATE Customer SET firstName = @firstName, " +
                                    "lastName = @lastName, phone = @phone, email = @email " +
                                    "WHERE customerID = @customerID";

            SqlCommand command = new SqlCommand(updateString, cnMain);

            command.Parameters.AddWithValue("@customerID", customer.CustomerID);
            command.Parameters.AddWithValue("@firstName", customer.FirstName);
            command.Parameters.AddWithValue("@lastName", customer.LastName);
            command.Parameters.AddWithValue("phone", customer.Phone);
            command.Parameters.AddWithValue("@email", customer.Email);

            try
            {
                cnMain.Open();
                int row = command.ExecuteNonQuery();
                Console.WriteLine("Customer" + customer.CustomerID + "Update Sucessfully Successfully\nRow {0} affected", row);
            }
            catch ( Exception ex )
            {
                Console.WriteLine("Error- Generated. Details: " + ex.ToString());
            }
            finally
            {
                cnMain.Close();
            }

        }
        #endregion


        #region Crud Operations Accounts Table 
        public Account getAccountWithID( int id )
        {
            Account account = null;

            /**Find Account by ID*/
            SqlDataReader reader;
            SqlCommand command;
            string query = "SELECT * FROM Customers WHERE accountID = @accountID";

            command = new SqlCommand(query, cnMain);    
            command.Parameters.AddWithValue("@accountID", id);

            try
            {
                account = new Account();
                command = new SqlCommand(query, cnMain);
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    account.AccountID = reader.GetInt16(0);
                    account.AccountName = reader.GetString(1);
                    if ( reader.GetString(2) == "OKAY")
                    {
                        account.Status = Account.CreditStatus.OKAY;
                    }
                    account.CreditLimit = int.Parse(reader.GetString(3));
                    account.CreditBalance = reader.GetDouble(5);

                }
                cnMain.Close();
                return account;
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find account with id: " + id + "\n" + ex.ToString());
                return null;
            }
        }
        #endregion

        public Customer getCustomer( int id )
        {
            /**Find Customer by ID*/
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM " + customerTable + " WHERE customerID = " + id;

            Customer customer;

            try
            {
                customer = new Customer();
                command = new SqlCommand(query, cnMain);
                cnMain.Open();
                reader = command.ExecuteReader();

                while ( reader.Read() )
                {
                    customer.CustomerID = reader.GetInt16(0);
                    customer.FirstName = reader.GetString(1).Trim();
                    customer.LastName = reader.GetString(2).Trim();
                    customer.Phone = reader.GetString(3).Trim();
                    customer.Email = reader.GetString(4).Trim();
                    customer.AddressID = reader.GetInt16(5);
                    customer.AccountID = reader.GetInt16(6);

                }
                cnMain.Close();
                return customer;
            }
            catch ( Exception ex )
            {
                cnMain.Close();
                MessageBox.Show("Cannot find customer with id: " + id + "\n" + ex.ToString());
                return null;
            }
         
        }

        #region Parameters

        private void Build_Insert_Parameters( Customer customer )
        {
            SqlParameter parameter = default( SqlParameter );
            parameter = new SqlParameter("@customerID", SqlDbType.Int, 8, "customerID" );
            daMain.InsertCommand.Parameters.Add(parameter);

            
            parameter = new SqlParameter("@firstName", SqlDbType.NVarChar, 50, "firstName");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@lastName", SqlDbType.NVarChar, 50, "lastName");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@phone", SqlDbType.NVarChar, 50, "phone");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@email", SqlDbType.NVarChar, 50, "email");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@addressID", SqlDbType.Int, 8, "addressID");
            daMain.InsertCommand.Parameters.Add(parameter);

            parameter = new SqlParameter("@accountID", SqlDbType.Int, 8, "accountID");
            daMain.InsertCommand.Parameters.Add(parameter);
        }

        private void Create_Insert_Command ( Customer customer )
        {
            string insert = "INSERT INTO Customer ( customerID, firstName, lastName, phone, email, addressID, accountID ) ";
            string values = "VALUES ( @customerID, @firstName, @lastName, @phone, @email, @addressID, @accountID )";
            string insertCommand = insert + values;

            daMain.InsertCommand = new SqlCommand(insertCommand, cnMain);

            Build_Insert_Parameters( customer );
        }
        #endregion
        #endregion

        #region Property Methods
        public Collection<Customer> Customers
        {
            get { return customers; }
        }

        public Collection<Account> Accounts
        {
            get { return accounts; }
        }
        #endregion

    }

}
