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
        #endregion

        #region ToString
        public override string ToString()
        {
            return 
                base.ToString() + "\nCustomerID: " + customerID + 
                "\nAccountID: " + accountID;
        }
        #endregion
    }
}
