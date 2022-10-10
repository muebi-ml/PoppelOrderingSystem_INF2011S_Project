using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Account: Customer
    {
        #region Credit Status enum
        public enum CreditStatus
        {
            UNASSIGNED = 0,
            OKAY = 1,
            BLACKLISTED = 2
        }
        #endregion

        #region Attributes 
        private string accountID, accountName;
        private Collection<Order> orders;
        private Collection<Payment> payments;
        private CreditStatus creditStatus;
        private double creditBalance, creditLimit;
        #endregion

        #region Constructor
        public Account ( string accountID, string accountName, string customerID, string personID, string firstName, string lastName ) : base(customerID, personID, firstName, lastName)
        {
            this.accountID = accountID;
            this.accountName = accountName;
            this.orders = new Collection<Order>(); 
            this.payments = new Collection<Payment>();
            this.creditStatus = CreditStatus.UNASSIGNED;
            this.creditBalance = 0;
            this.creditLimit = 0;
            
        }
        #endregion

        #region Property Methods
        public string AccountID
        {
            get { return this.accountID; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { this.accountName = value; }
        }
        public CreditStatus Status
        {
            get { return this.creditStatus; }
            set { this.creditStatus = value; }
        }

        public double CreditBalance
        {
            get { return this.creditBalance; }
            set { this.creditBalance = value; }
        }

        public double CreditLimit
        {
            get { return this.creditLimit; }
            set {  this.CreditLimit = value; }
        }
        #endregion
    }
}
