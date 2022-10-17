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
        private bool isNew;
        #endregion

        #region Constructor
        public CustomerDetailsForm(bool isNew )
        {
            this.isNew = isNew;
            InitializeComponent();
            customerController = new CustomerController();
            ShowLabels(this.isNew); // hide labels
            ShowTextBoxes(this.isNew); // hide text boxes
            ShowSubmitButton(isFormCompleted());
            ShowCustomerID();
        }

        #endregion

        private void ShowCustomerID()
        {
            customerIDTextBox.Visible = !this.isNew;
            customerIDLabel.Visible = !this.isNew;
        }

        private void showSubmitExistingCustomerForm()
        {
            if ( customerIDTextBox.Text.Length == 6)
            {
                submitButton.Enabled = true;
            }
            else
            {
                submitButton.Enabled = false;
            }
            
        }

        private void CustomerDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if (isNew)
            {
                string firstName = firstNameTextBox.Text.Trim();
                string lastName = lastNameTextBox.Text.Trim();
                string email = emailTextBox.Text.Trim();
                string street = streetNameTextBox.Text.Trim();
                string phone = phoneNumberTextBox.Text.Trim();
                string town = townTextBox.Text.Trim();
                string city = cityTextBox.Text.Trim();
                int code = int.Parse( postalCodeTextBox.Text.Trim().TrimStart(new char[] {'0'} ) );
                Customer customer = new Customer(firstName, lastName, phone, email);
                Address address = new Address(street, town, city, code);
                Account account = new Account();
                account.AccountName = firstName;

                customerController.CreateCustomer(customer, account, address);


                //MessageBox.Show("Customer details successfully submitted!");
            }
            else
            {
                int customerID = int.Parse(customerIDTextBox.Text.Trim().TrimStart(new char[] { '0' }));
                if ( customerController.DoesCustomerExist(customerID))
                {
                    Customer customer;

                    customer = customerController.FindCustomerByID(customerID);
                    MessageBox.Show(customer.ToString());
                    
                }
                else
                {
                    MessageBox.Show("Customer ID " + customerID.ToString() + " does not exist. Please ensure you have entered the correct details or create a new customer." );
                }
                
            }
            /* after adding customer details click submit to submit data into the database */
            PopulateCustomer(customer);
            
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
        private void customerIDTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            // allows only numbers
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
            {
                e.Handled = true;
            }
            showSubmitExistingCustomerForm();
        }
        private void phoneNumberTextBox_KeyPress( object sender, KeyPressEventArgs e )
        {
            // allows only numbers
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ( (char) Keys.Back) )
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void firstNameTextBox_KeyPress( object sender , KeyPressEventArgs e )
        {
            // allows only letters
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != ((char)Keys.Back)) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void lastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only letters
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != ((char)Keys.Back)) && e.KeyChar != ' ' )
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void emailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only letters
            if ( !char.IsLetter(e.KeyChar) && (e.KeyChar != '@') && ( e.KeyChar != ((char)Keys.Back) ) && e.KeyChar != '.' && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void streetNameTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar != (char)Keys.Back && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',' )
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void townTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            if ( !char.IsLetter(e.KeyChar) && e.KeyChar != ((char)Keys.Back) )
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void cityTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void postalCodeTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
            {
                e.Handled = true;
            }
            ShowSubmitButton(isFormCompleted());
        }

        private void ShowSubmitButton( bool show )
        {
            submitButton.Enabled = show;
        }

        private bool isFormCompleted()
        {
            bool complete = false;

            if (firstNameTextBox.Text.Length == 0)
            {
                return complete;
            }
            if (lastNameTextBox.Text.Length == 0)
            {
                return complete;
            }
            if (emailTextBox.Text.Length == 0)
            {
                return complete;
            }
            if (phoneNumberTextBox.Text.Length < 10)
            {
                return complete;

            }
            if (streetNameTextBox.Text.Length == 0)
            {
                return complete;
            }
            if (cityTextBox.Text.Length == 0)
            {
                return complete;
            }
            if (postalCodeTextBox.Text.Length == 0)
            {
                return complete;
            }

            if (postalCodeTextBox.Text.Length == 0)
            {
                return complete;
            }

            complete = true;

            return complete;
        }

        // a method to hide/show all customer labels
        private void ShowLabels(bool value)
        {
            enterDetailsLabel.Visible = value;
            
            firstNameLabel.Visible = value;
            lastNameLabel.Visible = value;
            phoneNumberLabel.Visible = value;
            emailLabel.Visible = value;
            addressLabel.Visible = value;
        }

        // a method to hide/show all textboxes

        private void  ShowTextBoxes(bool value)
        {
            
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
            //customer.CustomerID = int.Parse(customerIDTextBox.Text);
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.Email = emailTextBox.Text;

        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
