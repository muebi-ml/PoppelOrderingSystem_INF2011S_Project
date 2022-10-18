using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    public partial class OrderSummary : Form
    {

        private Order order;
        private Customer customer;
        private Address address;
        private MarkettingClerk clerk;

        public OrderSummary(Customer customer, MarkettingClerk clerk, Order order, Address address)
        {
            InitializeComponent();

            
            this.customer = customer;
            this.clerk = clerk;
            this.order = order;
            this.address = address;

            DisableTextBoxes();
            ShowSummary();
        }

        private void DisableTextBoxes()
        {
            customerIDTextBox.Enabled = false;
            orderIDTextBox.Enabled = false;
            completedByTextBox.Enabled = false;
            dateTextBox.Enabled = false;
            
            streetNameTextBox.Enabled = false;
            townTextBox.Enabled = false;
            cityTextBox.Enabled = false;
            postalCodeTextBox.Enabled = false;
            deliverByDate.Enabled = false;
        }
        private void ShowSummary()
        {
            customerIDTextBox.Text = customer.CustomerID.ToString();
            orderIDTextBox.Text = order.OrderID.ToString();
            completedByTextBox.Text = clerk.FirstName + " " + clerk.LastName;
            dateTextBox.Text = order.OrderDate.ToShortDateString();
            streetNameTextBox.Text = address.StreetName;
            townTextBox.Text = address.Town;
            cityTextBox.Text = address.City;
            postalCodeTextBox.Text = address.PostalCode.ToString();
            deliverByTextBox.Text = order.DeliveryDate.ToShortDateString();
        }
    }
}
