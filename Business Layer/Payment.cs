using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Payment
    {
        #region Enum Payment Type
        public enum PaymentType
        {
            CREDIT = 0,
            EFT = 1,
            CREDITCARD = 2,
        }
        #endregion

        #region Attributes 
        private string paymentID;
        private PaymentType type;
        private System.DateTime date;
        #endregion
        #region Constructor
        public Payment( string paymentID )
        {
            this.paymentID = paymentID;
            this.type = PaymentType.CREDIT;
            this.date = System.DateTime.Now;
        }
        #endregion

        #region Property Methods 
        public string PaymentID
        {
            get { return paymentID; }
        }

        public DateTime Date
        {
            get { return date; }

        }

        public PaymentType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        #endregion
    }
}