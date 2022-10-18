using PoppelOrderingSystem_INF2011S_Project.Database_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class OrderController
    {
        #region Data Members 
        private OrderDB orderDB;
        private Collection<Product> products;
        private Collection<OrderItem> orderItems;
        private Collection<Product> orderProducts;
        private Collection<int> quantities;

        private double currentOrderTotal;
        #endregion

        #region Constructors
        public OrderController()
        {
            orderDB = new OrderDB();
            products = orderDB.Products;
            orderItems = new Collection<OrderItem>();
            orderProducts = new Collection<Product>();
        }
        #endregion

        #region CRUD Order
        public void addToOrder( Product product, int quantity)
        {
            orderProducts.Add(product);
            quantities.Add(quantity);
        }

        private int getIndex(Product product )
        {
            int index = 0;

            foreach( Product prod in orderProducts )
            {
                if ( product.ProductCode == prod.ProductCode)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        public void removeFromCart( Product product )
        {
            if ( orderProducts.Count > 0)
            {
                int index = getIndex(product);

                if ( index > 0)
                {
                    orderProducts.RemoveAt(index);
                    quantities.RemoveAt(index);
                }
            }
        }

        public void clearCart()
        {
            orderProducts.Clear();
        }

        private void CreateOrderItems(Order order)
        {
            int index = 0;
            foreach ( Product product in orderProducts)
            {
                int quantity = quantities.ElementAt(index);
                OrderItem orderItem = new OrderItem(order, product, quantity);
                orderItems.Add(orderItem);
            }
        }

        public void createOrder( Customer customer, MarkettingClerk clerk)
        {
            Order order = new Order();
            int orderID;
            order.ClerkID = clerk.ClerkID;
            order.CustomerID = customer.CustomerID;


            orderDB.createOrder(order);
            orderID = orderDB.getLatestOrderID();

            order = orderDB.getOrderByID(orderID);

            CreateOrderItems(order);

            orderDB.AddOrderItems(orderItems);

        }
        #endregion

        public int createOrder(Customer customer, MarkettingClerk clerk, Collection<OrderItem> myOrderItems, double orderTotal)
        {
            Order order = new Order();
            int orderID;
            order.ClerkID = clerk.ClerkID;
            order.CustomerID = customer.CustomerID;
            order.OrderDate = DateTime.Now;
            order.OrderTotal = orderTotal;


            orderDB.createOrder(order);
            orderID = orderDB.getLatestOrderID();

            order = orderDB.getOrderByID(orderID);

            Console.WriteLine(order.ToString());

            CreateOrderItems(order);

            AddOrderItemsToDB(myOrderItems, order );

            return orderID;

        }

        private void AddOrderItemsToDB(Collection<OrderItem> items, Order order )
        {
            foreach( OrderItem item in items )
            {
                item.OrderID = order.OrderID;
            }

            orderDB.AddOrderItems(items);

        }

        public Order GetOrderByID( int id )
        {
            return orderDB.getOrderByID(id);
        }

        #region CRUD Picking list
        public Collection<OrderItem> GeneratePickingList( int orderID )
        {
            return orderDB.GeneratePickingList(orderID);
        }
        #endregion

        #region Generate Expired Items List 
        public Collection<Product> GenerateExpiredProducts()
        {
            return orderDB.GenerateExpiryReport();
        }
        #endregion

        #region CRUD Products
        public Collection<Product> GetProduucts()
        {
            return orderDB.Products;
        }

        public Product GetProductByID(int id)
        {
            return orderDB.getProductByCode(id);
        }
        #endregion
    }
}
