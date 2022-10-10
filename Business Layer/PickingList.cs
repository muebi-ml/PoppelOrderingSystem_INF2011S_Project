using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class PickingList
    {
        #region Attributes 
        private string pickingListID;
        private DateTime date;
        private Collection<Product> products;
        #endregion

        #region Constructor 
        public PickingList( string pickingListID )
        {
            this.pickingListID = pickingListID;
            this.date = DateTime.Now;
            this.products = new Collection<Product>();
        }
        #endregion

        #region Property Method 
        public string PickingListID
        {
            get { return pickingListID; }
        }

        public Collection<Product> Products
        {
            get { return products; }
            set { this.products = value; }
        }
        #endregion

    }
}