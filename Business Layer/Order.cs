using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Order
    {
        #region Attributes
        private string orderID;
        private Customer customer;
        private Payment payment;
        private MarkettingClerk clerk;
        private DateTime date;
        private Collection<Product> orderItems;
        private Invoice invoice;
        private PickingList pickingList;
        private DeliveryNote deliveryNote;
        private double discount, orderTotal;
        #endregion

        #region Constructor
        public Order ( string orderID, Customer customer, MarkettingClerk clerk)
        {
            this.orderID = orderID;
            this.customer = customer;
            this.clerk = clerk;
            this.discount = 0;
            this.orderTotal = 0;
        }
        #endregion

        #region Property Methods
        public string OrderID
        {
            get { return orderID; }
            set { this.OrderID = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { this.discount = value; }
        }

        public double OrderTotal
        {
            get { return orderTotal; }
        }
        #endregion
    }
}