using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoppelOrderingSystem_INF2011S_Project.Business_Layer; /* to connect the presentation layer with the database layer */

namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    public partial class CustomerDetailsForm : Form
    {

        #region Data members
        private Customer customer;
        private CustomerController customerController;
        #endregion

        #region Constructor
        public CustomerDetailsForm()
        {
            InitializeComponent();
            customerController = new CustomerController();
        }

        #endregion

        private void CustomerDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            /* after adding customer details click submit to submit data into the database */
            PopulateCustomer(customer);
            MessageBox.Show("Customer details successfully submitted!");
            customerController.UpdataCustomerDatabase(customer, 0); // DatabaseOperation state is to create a customer therefore CREATE = 0
            ClearAllCustomerTextboxes();
            ShowLabels(false); // hide labels
            ShowTextBoxes(false); // hide text boxes

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            /* after clicking the submit button click continue to open account details form */
            AccountDetailsForm accountDetails = new AccountDetailsForm();
            accountDetails.Show();

        }

        // a method to hide/show all customer labels
        private void ShowLabels(bool value)
        {
            enterDetailsLabel.Visible = value;
            customerIDLabel.Visible = value;
            firstNameLabel.Visible = value;
            lastNameLabel.Visible = value;
            phoneNumberLabel.Visible = value;
            emailLabel.Visible = value;
            addressLabel.Visible = value;
        }

        // a method to hide/show all textboxes

        private void  ShowTextBoxes(bool value)
        {
            customerIDTextBox.Visible = value;
            firstNameTextBox.Visible = value;
            lastNameTextBox.Visible = value;
            phoneNumberTextBox.Visible = value;
            emailTextBox.Visible = value;
            streetNameTextBox.Visible = value;
            townTextBox.Visible = value;
            cityTextBox.Visible = value;
            postalCodeTextBox.Visible = value;
        }

        // a method to clear all customer details textboxes
        private void ClearAllCustomerTextboxes()
        {
            customerIDTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            phoneNumberTextBox.Text = "";
            emailTextBox.Text = "";
            streetNameTextBox.Text = "";
            townTextBox.Text = "";
            cityTextBox.Text = "";
            postalCodeTextBox.Text = "";
        }


        // a method to hide/show all buttons
        private void ShowButtons(bool value)
        {
            cancelButton.Visible = value;
            continueButton.Visible = value;
        }

        // a method to populate customer object with text provided in the textboxes
        private void PopulateCustomer(Customer customer)
        {
            // instantiate customer object
            customer = new Customer();

            // populate customer attributes
            customer.CustomerID = int.Parse(customerIDTextBox.Text);
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.Email = emailTextBox.Text;

        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
