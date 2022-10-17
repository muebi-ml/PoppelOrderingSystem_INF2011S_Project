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
        #region Order status
        public enum Status
        {
            NOSTATUS = 0,
            SHIPPED = 1,
            ONHOLD = 2,
            RETURNED = 3,
            INPROCESS = 4,
            CONFIRMED = 5
        }
        #endregion

        #region Attributes
        // order table attributes
        private int orderID;
        private DateTime orderDate;
        private DateTime deliveryDate;
        private DateTime shippedDate;
        private Status status;
        private int customerID;
        private int clerkID;
        private int pickingListID;
        private int deliveryID;

        private string orderName;
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

        #region Constructors
        public Order ( int orderID, Customer customer, MarkettingClerk clerk)
        {
            this.orderID = orderID;
            this.customer = customer;
            this.clerk = clerk;
            this.discount = 0;
            this.orderTotal = 0;
            this.deliveryID = 0;
            this.pickingListID = 0;
        }

        public Order( int orderID, int customerID, int clerkID, double orderTotal, Status status, DateTime orderDate) 
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.clerkID = clerkID;
            this.orderTotal = orderTotal;
            this.orderDate = orderDate;
            this.status = status;
          
        }

        public Order(int customerID, int clerkID, double orderTotal, Status status, DateTime orderDate )
        {
            this.orderID = 0;
            this.customerID = customerID;
            this.clerkID = clerkID;
            this.orderTotal = orderTotal;
            this.orderDate = orderDate;

        }

        public Order()
        {
            clerkID=0;
            orderTotal=0;
        }

        #endregion

        #region Property Methods
        public int PickingListID
        {
            get { return pickingListID; }
            set { pickingListID = value; }
        }
        public int OrderID
        {
            get { return orderID; }
            set { this.OrderID = value; }
        }

        public DateTime OrderDate
        {
            set { orderDate = value; }
            get { return orderDate; }
        }

        public DateTime DeliveryDate
        {
            set { deliveryDate = value; }
            get { return deliveryDate; }
        }

        public DateTime ShippedDate
        {
            set { shippedDate = value; }
            get { return shippedDate; }
        }

        public Status OrderStatus
        {
            set { status = value; }
            get { return status; }
        }

        public int CustomerID
        {
            set { customerID = value; }
            get{ return customerID; }
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

        public int ClerkID
        {
            get { return clerkID; }
            set { clerkID = value; }
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return  "Order Number: " + this.orderID +
                    "\nCustomer ID " + this.customerID +
                    "\nProcessed By Clerk: " + this.clerkID +
                    "\nOrder Date: " + this.orderDate + 
                    "\nOrder Total: " + this.orderTotal +
                    "\nRequired Date: " + this.deliveryDate + 
                    "\nShipped Date: " + this.shippedDate + 
                    "\nStatus: " + this.status ;
        }
        #endregion
    }
}