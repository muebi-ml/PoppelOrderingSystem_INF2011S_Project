using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Account
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
        private int accountID;
        private string accountName;
        private Collection<Order> orders;
        private Collection<Payment> payments;
        private CreditStatus creditStatus;
        private double creditBalance;
        private double creditLimit;
        #endregion

        #region Constructor
        public Account ( int accountID, string accountName) 
        {
            this.accountID = accountID;
            this.accountName = accountName;
            this.orders = new Collection<Order>(); 
            this.payments = new Collection<Payment>();
            this.creditStatus = CreditStatus.UNASSIGNED;
            this.creditBalance = 0;
            this.creditLimit = 0;
            
        }

        public Account()
        {
            this.AccountID = 0;
            this.accountName = "";
            this.creditStatus = CreditStatus.UNASSIGNED;
            this.creditBalance = 0;
            this.creditLimit = 0;

        }

        public Account( string accountName, CreditStatus creditStatus, double creditBalance, double creditLimit )
        {
            this.accountName = accountName;
            this.creditBalance= creditBalance;
            this.creditLimit= creditLimit;
            this.creditStatus= creditStatus;
        }
        #endregion

        #region Property Methods
        public int AccountID
        {
            get { return this.accountID; }
            set { this.accountID = value; }
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
            set { this.creditLimit = value; }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return "Account ID: " + this.AccountID + "\nAccount Name: " + this.accountName +
                    "\nCredit status: " + this.creditStatus.ToString() + "\nCredit Balance: " + this.creditBalance +
                    "\nCredit Limit: " + this.creditLimit;
        }
        #endregion
    }
}
