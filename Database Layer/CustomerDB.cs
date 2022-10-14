using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public Account getCustomeWithAccountID( int id )
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

                    switch ( status )
                    {
                        case ("")
                    }
                    account.CreditStatus = reader.GetString(2).Trim();


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
                return customer;
            }
            catch ( Exception ex )
            {
                cnMain.Close();
                MessageBox.Show("Cannot find customer with id: " + id + "\n" + ex.ToString());
                return null;
            }
         
        }
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
