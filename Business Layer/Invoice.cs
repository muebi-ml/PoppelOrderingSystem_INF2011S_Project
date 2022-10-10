using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Invoice
    {
        #region Attributes
        private string invoiceID;
        #endregion

        #region Constructor 
        public Invoice( string invoiceID )
        {
            this.invoiceID = invoiceID;
        }
        #endregion

        #region Property Methods
        public string InvoiceID
        {
            get { return invoiceID; }
        }
        #endregion 
    }
}