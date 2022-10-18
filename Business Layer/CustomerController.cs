using PoppelOrderingSystem_INF2011S_Project.Database_Layer;
using PoppelOrderingSystem_INF2011S_Project.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class CustomerController
    {
        #region Data attributes 
        private Collection<Customer> customers;
        private Collection<Order> orders;

        private CustomerDB customerDB;
        #endregion

        #region Constructor
        public CustomerController()
        {
            customerDB = new CustomerDB();  
            customers = customerDB.Customers;
        }
        #endregion

        #region CRUD METHODS 
        public void UpdataCustomerDatabase( Customer customer , Database.DatabaseOperation databaseOperation )
        {
            customerDB.UpdateCustomerDatabase(customer, databaseOperation);
            UpdateDataSource();
        }

        public bool DoesCustomerExist( int id )
        {
            return customerDB.CustomerExists(id);
        }
        public int CreateCustomer( Customer customer, Account account, Address address )
        {
            customerDB.addCustomer(customer, account, address);
            UpdateDataSource();

            return customerDB.getLatestCustomerID();
        }

        public Customer FindCustomerByID( int id )
        {
            return customerDB.getCustomer(id);
        }

        public void UpdateAccountTable( Account account, Database.DatabaseOperation operation )
        {
            customerDB.UpdateAccountDatabase(account, operation);
        }

        public Account GetCustomerAccount( Customer customer )
        {
            return customerDB.getAccountWithID(customer);
        }
        #endregion

        #region Collection Updates 
        public void UpdateDataSource()
        {
            customers = customerDB.Customers;
        }

        public Collection<Customer> Customers
        {
            get { return customers; }   
        }
        #endregion

        #region Address Crud 

        public Address getAddressByID(int id )
        {
            return customerDB.getAddressWithID(id);
        }
        #endregion
    }
}
