using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class OrderItem
    {
        #region Data Members 
        private Product product;
        private Order order;
        private int quantity;
        private double subTotal;
        private int orderID;
        private int productCode;

        public OrderItem()
        {
        }
        #endregion

        #region Constructor 
        public OrderItem( Order order, Product product, int quantity )
        {
            this.order = order;
            this.product = product; 
            this.quantity = quantity;
            this.subTotal = (double) quantity * product.Price;
            this.productCode = product.ProductCode;
            this.orderID = order.OrderID;
        }
        #endregion

        #region Property Methods 
        public Product Product { get { return product; } }
        public Order Order { get { return order; } }
        public int Quantity { 
            get { return quantity; } 
            set { quantity = value; }   
        
        }
        public double SubTotal { get { return subTotal; } }

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }    
        }

        public int ProductCode
        {
            get { return productCode;  }
            set
            {
                productCode = value;
            }   
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return "Product Code: " + productCode +
                    "\nOrder ID: " + orderID +
                    "\nQuantity: " + quantity;
        }
        #endregion
    }
}
