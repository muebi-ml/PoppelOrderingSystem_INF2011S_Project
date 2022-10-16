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
            No_Status = 0,
            Shipped = 1,
            On_Hold = 2,
            Returned = 3,
            In_Process = 4,
            Confirmed = 5
        }
        #endregion

        #region Attributes
        // order table attributes
        private int orderID;
        private string orderDate;
        private string requiredDate;
        private string shippedDate;
        private Status status;
        private int customerID;



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
        }

        public Order( int orderID, string orderDate, string requiredDate, string shippedDate, Status status, int customerID)
        {
            this.orderID = orderID;
            this.orderDate = orderDate;
            this.requiredDate = requiredDate;
            this.shippedDate = shippedDate;
            this.status = Status.No_Status;
            this.customerID = customerID;
        }

        public Order()
        {
            this.orderID = 0;
            this.orderDate = "";
            this.requiredDate = "";
            this.shippedDate = "";
            this.status = Status.No_Status;
            this.customerID = 0;
        }
        #endregion

        #region Property Methods
        public int OrderID
        {
            get { return orderID; }
            set { this.OrderID = value; }
        }

        public string OrderDate
        {
            set { orderDate = value; }
            get { return orderDate; }
        }

        public string RequiredDate
        {
            set { requiredDate = value; }
            get { return requiredDate; }
        }

        public string ShippedDate
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
        #endregion

        #region To String
        public override string ToString()
        {
            return "Order Number: " + this.orderID + "\nOrder Date: " + this.orderDate + "\nRequired Date: " + this.requiredDate + "\nShipped Date: " + this.shippedDate + "\nStatus: " + this.status + "\nCustomer ID " + this.customerID;
        }
        #endregion
    }
}