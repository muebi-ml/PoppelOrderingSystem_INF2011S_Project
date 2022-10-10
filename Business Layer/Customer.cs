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
        private string customerID, address;

        #endregion

        #region Constructors
        public Customer(string personID, string firstName, string lastName, string phone, string email, string customerID, string address) : base(personID, firstName, lastName, phone, email)
        {
            this.customerID = customerID;
            this.address = address;
            
        }

        public Customer ( string customerID, string personID, string firstName, string lastName): base( personID, firstName, lastName )
        {
            this.customerID = customerID;
            address = "";
            
        }
        #endregion

        #region Property Methods
        public string CustomerID
        {
            get { return customerID; }
            
        } 

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion
    }
}
