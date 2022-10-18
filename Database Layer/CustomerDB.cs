using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using PoppelOrderingSystem_INF2011S_Project.DatabaseLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PoppelOrderingSystem_INF2011S_Project.Database_Layer
{
    public class CustomerDB : Database
    {

        #region Attribute: Query Strings And Tables
        private static string customerTable = "Customer";
        private static string accountTable = "Account";
        private string customersQueryString = "SELECT * FROM " + customerTable;
        private string accountsQueryString = "SELECT * FROM " + accountTable;
        #endregion

        #region Collections
        private Collection<Customer> customers;
        private Collection<Account> accounts;
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

        #region Collection Methods 
        private void FillCustomers()
        {
            Customer customer;
            customers.Clear();
            string query = "SELECT * FROM Customer";
            SqlCommand command = new SqlCommand(query, cnMain);
            cnMain.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    customer = new Customer();

                    customer.CustomerID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1).Trim();
                    customer.LastName = reader.GetString(2).Trim();
                    customer.Phone = reader.GetString(3).Trim();
                    customer.Email = reader.GetString(4).Trim();
                    customer.AccountID = reader.GetInt32(5);
                    customer.AddressID = reader.GetInt16(6);

                    // Add customer to collection
                    customers.Add(customer);
                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
            finally
            {
                cnMain.Close();
            }

        }



        public Collection<Customer> getAllCustomers()
        {
            FillCustomers();
            return customers;
        }
        #endregion

        #region CRUD Operations Customer

        public void UpdateCustomerDatabase ( Customer customer, DatabaseOperation operation )
        {
            switch ( operation )
            {
                case (DatabaseOperation.UPDATE):
                    editCustomer( customer );
                    break;
                case (DatabaseOperation.DELETE):
                    deleteCustomer( customer );
                    break;
            }
        }
        private Account getAccountForCustomerID( int id )
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
        
        public void addCustomer( Customer customer, Account account, Address address )
        {
            string insert = "INSERT INTO Customer ( firstName, lastName, phone, email, addressID, accountID ) VALUES " +
                            "( @firstName, @lastName, @phone, @email, @addressID, @accountID )";

            SqlCommand command = new SqlCommand( insert, cnMain );

            command.CommandType = CommandType.Text;
            command.CommandText = insert;
            command.Connection = cnMain;

            account.AccountID = createAccount(account.AccountName, (int)account.Status, account.CreditBalance, account.CreditLimit);
            address.AddressID = createAddress(address.StreetName, address.Town, address.City, address.PostalCode);

            command.Parameters.AddWithValue("@firstName", customer.FirstName);
            command.Parameters.AddWithValue("@lastName", customer.LastName);
            command.Parameters.AddWithValue("phone", customer.Phone);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@addressID", address.AddressID);
            command.Parameters.AddWithValue("@accountID", account.AccountID);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                cnMain.Close();
                MessageBox.Show("Customer created successfully. " +
                                "\nCustomer ID: " + getLatestCustomerID() + 
                                "\nAccount number: " + account.AccountID);
                Console.WriteLine("Customer Added Successfully");
                customers.Add(customer);
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

        private void editCustomer( Customer customer )
        {
            string updateString = "UPDATE Customer SET firstName = @firstName, " +
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
            catch (Exception ex)
            {
                Console.WriteLine("Error- Generated. Details: " + ex.ToString());
            }
            finally
            {
                cnMain.Close();
            }
        }

        private void deleteCustomer( Customer customer )
        {
            string query = "DELETE FROM Customer WHERE customerID = @customerID";

            SqlCommand command = new SqlCommand(query, cnMain);

            command.Parameters.AddWithValue("@customerID", customer.CustomerID);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Customer Deleted Successfully");
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

        public int getLatestCustomerID()
        {
            string query = "SELECT MAX( customerID ) FROM Customer";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();
                int customerID = 0;
                while (reader.Read())
                {
                    customerID = reader.GetInt32(0);

                }
                cnMain.Close();
                return customerID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                cnMain.Close();
            }
        }

        private void updateCustomerDetails( Customer customer )
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

        public Customer getCustomer(int id)
        {
            /**Find Customer by ID*/
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM " + customerTable + " WHERE customerID = @customerID";

            Customer customer = new Customer();
            command = new SqlCommand(query, cnMain);
            command.Parameters.AddWithValue("@customerID", id);

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer.CustomerID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1).Trim();
                    customer.LastName = reader.GetString(2).Trim();
                    customer.Phone = reader.GetString(3).Trim();
                    customer.Email = reader.GetString(4).Trim();
                    customer.AccountID = reader.GetInt32(5);
                    customer.AddressID = reader.GetInt16(6);

                }
                cnMain.Close();

                customer.Account = getAccountWithID(customer);
                customer.Address = getAddressWithID( customer.AddressID );
                return customer;
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find customer with id: " + id + "\n" + ex.ToString());
                return null;
            }

        }
        #endregion

        public bool CustomerExists(int id)
        {
            /**Find Customer by ID*/
            SqlDataReader reader;
            SqlCommand command;
            string query = " SELECT * FROM " + customerTable + " WHERE customerID = @customerID";

            Customer customer = null;
            command = new SqlCommand(query, cnMain);
            command.Parameters.AddWithValue("@customerID", id);

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = new Customer();

                    customer.CustomerID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1).Trim();
                    customer.LastName = reader.GetString(2).Trim();
                    customer.Phone = reader.GetString(3).Trim();
                    customer.Email = reader.GetString(4).Trim();
                    customer.AccountID = reader.GetInt32(5);
                    customer.AddressID = reader.GetInt16(6);

                }
                cnMain.Close();
                if (customer != null)
                {
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find customer with id: " + id + "\n" + ex.ToString());
                
            }
            return false;

        }

        #region Crud Operations Accounts Table 
        public void UpdateAccountDatabase( Account account , DatabaseOperation operation )
        {
            switch ( operation )
            {
                case (DatabaseOperation.UPDATE):
                    editCustomerAccount(account);
                    break;
                case (DatabaseOperation.DELETE):
                    deleteCustomerAccount(account);
                    break;
            }
        }
        public Account getAccountWithID( Customer customer )
        {
            Account account = null;

            
            SqlCommand command;
            string query = "SELECT * FROM Account WHERE accountID = @accountID";

            command = new SqlCommand(query, cnMain);    
            command.Parameters.AddWithValue("@accountID", customer.AccountID);

            try
            {
                account = new Account();
                cnMain.Open();
                SqlDataReader reader = command.ExecuteReader();

                while ( reader.Read() )
                {
                    Console.WriteLine("Found something");
                    account.AccountID = reader.GetInt32(0);
                    account.AccountName = reader.GetString(1);
                    
                    switch ( reader.GetInt16(2) )
                    {
                        case ( (int) Account.CreditStatus.UNASSIGNED ):
                            account.Status = Account.CreditStatus.UNASSIGNED;
                            break;
                        case ((int)Account.CreditStatus.OKAY):
                            account.Status = Account.CreditStatus.OKAY;
                            break;
                        case ((int)Account.CreditStatus.BLACKLISTED):
                            account.Status = Account.CreditStatus.BLACKLISTED;
                            break;
                    }
                    account.CreditBalance = reader.GetSqlMoney(3).ToDouble();
                    account.CreditLimit = reader.GetSqlMoney(4).ToDouble();

                    
                }
                cnMain.Close();
                return account;
            }
            catch (Exception ex)
            {
                cnMain.Close();
                MessageBox.Show("Cannot find account with id: " + customer.CustomerID + "\n" + ex.ToString());
                return null;
            }
        }

        private int getAccountID()
        {
            string query = "SELECT MAX( accountID ) FROM Account";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;

            try
            {
                reader = command.ExecuteReader();
                int accountID = 0;
                while (reader.Read())
                {
                    accountID = reader.GetInt32(0);
                    
                }

                return accountID;
            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                cnMain.Close();
            }
        }

        private int createAccount( string accountName, int status, double balance, double limit )
        {
            string insertQuery =    "INSERT INTO Account ( accountName, creditStatus, creditBalance, creditLimit ) " +
                                    "VALUES ( @accountName, @creditStatus, @creditBalance, @creditLimit )";

            SqlCommand command = new SqlCommand( insertQuery , cnMain);

            command.Parameters.AddWithValue("@accountName", accountName);
            command.Parameters.AddWithValue("@creditStatus", status);
            command.Parameters.AddWithValue("@creditBalance", balance);
            command.Parameters.AddWithValue("@creditLimit", limit);
            
            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                int accountID = getAccountID();
                Console.WriteLine("Account Created successfully here's the account number: {0} ", accountID);
                cnMain.Close();
                return accountID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error- Generated. Details: " + ex.ToString());
                return 0;
            }
            finally
            {
                cnMain.Close();
            }
        }

        private void editCustomerAccount(Account account)
        {
            string query =  "UPDATE Account SET accountName = @accountName, creditStatus = @creditStatus, " +
                            "creditBalance = @creditBalance, creditLimit = @creditLimit " +
                            "WHERE accountID = @accountID";

            SqlCommand command = new SqlCommand(query, cnMain);

            command.Parameters.AddWithValue("@accountID", account.AccountID);
            command.Parameters.AddWithValue("@accountName", account.AccountName);
            command.Parameters.AddWithValue("@creditStatus", account.Status);
            command.Parameters.AddWithValue("@creditBalance", account.CreditBalance);
            command.Parameters.AddWithValue("@creditLimit", account.CreditLimit);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Customer Updated Successfully");
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

        private void deleteCustomerAccount( Account account )
        {
            string query = "DELETE FROM Account WHERE accountID = @accountID";

            SqlCommand command = new SqlCommand(query, cnMain);

            command.Parameters.AddWithValue("@accountID", account.AccountID);
            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Account deleted Successfully");
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
        #endregion

        #region CRUD OPERATIONS Address
        private int createAddress( string streetName, string town, string city, int postalCode)
        {
            string query =  "INSERT INTO Address ( streetName, town, city, postalCode ) Values " +
                            "( @streetName, @town, @city, @postalCode )";
            SqlCommand command = new SqlCommand(query, cnMain);

            command.Parameters.AddWithValue("@streetName", streetName);
            command.Parameters.AddWithValue("@town", town);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@postalCode", postalCode);

            try
            {
                cnMain.Open();
                command.ExecuteNonQuery();
                int addressID = getLatestAddressID();
                Console.WriteLine("Address created succesfully id: {0}", addressID);
                cnMain.Close();
                return addressID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                cnMain.Close();
            }
        }

        private int getLatestAddressID()
        {
            string query = "SELECT MAX( addressID ) FROM Address";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;

            try
            {
                reader = command.ExecuteReader();
                int addressID = 0;
                while (reader.Read())
                {
                    addressID = reader.GetInt16(0);

                }

                return addressID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                cnMain.Close();
            }
        }

        public Address getAddressWithID( int id )
        {
            string query = "SELECT * FROM Address WHERE addressID = @addressID";
            SqlCommand command = new SqlCommand(query, cnMain);
            SqlDataReader reader;
            Address address;

            command.Parameters.AddWithValue("@addressID", id);

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();
                string street = "";
                string town = "";
                string city = ""; 
                int postalCode = 0;
                while (reader.Read())
                {
                    street = reader.GetString(1);
                    town = reader.GetString(2);
                    city = reader.GetString(3);
                    postalCode = reader.GetInt16(4);

                      
                }
                address = new Address(street, town, city, postalCode);
                cnMain.Close();
                return address;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
            }
            finally
            {
                cnMain.Close();
            }

            return null;
        }
        #endregion

        #region Property Methods
        public Collection<Customer> Customers
        {
            get 
            {
                FillCustomers();   
                return customers; 
            }
        }

        public Collection<Account> Accounts
        {
            get { return accounts; }
        }
        #endregion

    }

}
