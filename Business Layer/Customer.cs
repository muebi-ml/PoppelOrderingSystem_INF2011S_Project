using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Customer: Person
    {
        
        #region Attributes 
        private int addressID, accountID;
        private int customerID;
        private Address address;
        private Account account;

        #endregion

        #region Constructors
        public Customer(string personID, string firstName, string lastName, string phone, string email, int customerID, int addressID) : base(personID, firstName, lastName, phone, email)
        {
            this.customerID = customerID;
            this.addressID = addressID;
            
        }

        public Customer ( int customerID, string personID, string firstName, string lastName): base( personID, firstName, lastName )
        {
            this.customerID = customerID;
            addressID = 0;
            
        }

        public Customer() : base()
        {
            customerID = 0;
            addressID = 0;
        }

        public Customer ( string firstName, string lastName, string phone, string email) : base( firstName, lastName, phone, email )
        {
            customerID = 0;
            addressID = 0;
            address = null;
            account = new Account();
        }
        #endregion

        #region Property Methods
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        } 

        public int AddressID
        {
            get { return addressID; }
            set { addressID = value; }
        }

        public int AccountID { 
            get { return accountID; }
            set { accountID = value; }  
        }

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public Address Address
        {
            get { return address; } 
            set { address = value; }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            bool missingAddress = false;
            bool missingAccount = false;
            bool missingBoth = false;

            if ( address == null )
            {
                missingAddress = true;
            }
            if ( account == null )
            {
                missingAccount = true;
                if ( missingAddress)
                {
                    missingBoth = true;
                }
            }

            if ( missingBoth )
            {
                return
                 "\nCustomer ID: " + customerID + "\n" + base.ToString() + 
                 "\nAccount ID: " + accountID;
            }
            else if ( missingAddress)
            {
                return
                 "\nCustomer ID: " + customerID + "\n" + base.ToString() +
                 "\n" + account.ToString() ;
            }
            else if ( missingAccount )
            {
                return
                 "\nCustomer ID: " + customerID + "\nAccount ID: " + accountID.ToString() + "\n" + base.ToString() +
                 "\n" + address.ToString();
            }
            else
            {
                return "\nCustomer ID: " + customerID + "\n" + base.ToString() + "\n" 
                    + address.ToString() + "\n" + account.ToString();
            }
        }
        #endregion
    }
}
