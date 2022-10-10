using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class DeliveryNote
    {
        #region Attributes 
        private string deliveryNoteID;
        #endregion

        #region Constructor
        public DeliveryNote ( string deliveryNoteID )
        {
            this.deliveryNoteID = deliveryNoteID;
        }
        #endregion

        #region Property Methods
        public string DeliveryNoteID
        {
            get { return deliveryNoteID; }
        }
        #endregion
    }
}