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
        public static Customer globalCustomer = new Customer();
        private CustomerController customerController;
        private bool isNew;
        private bool isCreatingNewOrder;
        private Customer customer;
        #endregion

        #region Constructor
        public CustomerDetailsForm(bool isNew, bool isCreatingNewOrder )
        {
            this.isNew = isNew;
            this.isCreatingNewOrder = isCreatingNewOrder;
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

        private void ShowCustomerID( bool show )
        {
            customerIDTextBox.Visible = show;
            customerIDLabel.Visible = show;
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

        private void DisplayCustomer( Customer cust )
        {
            customerIDTextBox.Text = cust.CustomerID.ToString();
            firstNameTextBox.Text = cust.FirstName;
            lastNameTextBox.Text = cust.LastName;
            customerIDTextBox.Enabled = false;
            firstNameTextBox.Enabled = false;
            lastNameTextBox.Enabled = false;
            
            if ( cust.Phone.Length > 10 )
            {
                string phone = cust.Phone;
                phone = phone.TrimStart(new char[] { '+', '2', '7' });
                phoneNumberTextBox.Text = "0"+phone;
            }
            else
            {
                phoneNumberTextBox.Text = cust.Phone;
            }
            phoneNumberTextBox.Enabled = false;
            emailTextBox.Text = cust.Email;
            streetNameTextBox.Text = cust.Address.StreetName;
            townTextBox.Text = cust.Address.Town;
            cityTextBox.Text = cust.Address.City;
            postalCodeTextBox.Text = cust.Address.PostalCode.ToString();

            emailTextBox.Enabled = false;
            streetNameTextBox.Enabled = false;
            townTextBox.Enabled = false;
            cityTextBox.Enabled = false;
            postalCodeTextBox.Enabled = false;

            ShowTextBoxes(true);
            ShowCustomerID(true);
            ShowLabels(true);

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
                customer = new Customer(firstName, lastName, phone, email);
                Address address = new Address(street, town, city, code);
                Account account = new Account();
                account.AccountName = firstName;

                int customerID = customerController.CreateCustomer(customer, account, address);
                customer = customerController.FindCustomerByID(customerID);
                globalCustomer = customer;
                DisplayCustomer(customer);
                submitButton.Enabled = false;
                enterDetailsLabel.Text = "Showing Customer Details";


            }
            else
            {
                int customerID = int.Parse(customerIDTextBox.Text.Trim().TrimStart(new char[] { '0' }));
                if ( customerController.DoesCustomerExist(customerID))
                {
                    Customer cust;

                    cust = customerController.FindCustomerByID(customerID);
                    DisplayCustomer(cust);
                    submitButton.Enabled = false;
                    customer = cust;
                    //MessageBox.Show(customer.ToString());

                }
                else
                {
                    MessageBox.Show("Customer ID " + customerID.ToString() + " does not exist. Please ensure you have entered the correct details or create a new customer." );
                }
                
            }

        }

        private void continueButton_Click(object sender, EventArgs e)
        {

            if ( isCreatingNewOrder )
            {
                MainOrderingForm mainOrderingForm = new MainOrderingForm();

                mainOrderingForm.PassBackCustomer( customer );
                Console.WriteLine(customer.ToString());
                this.Close();
            }

            else
            {
                this.Close();
            }
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
            if ( isCreatingNewOrder )
            {
                DialogResult result = MessageBox.Show("Do you wish to cancel this operation", "?", MessageBoxButtons.YesNo );
                if ( result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                
                DialogResult result = MessageBox.Show("Do you wish to cancel this operation", "?", MessageBoxButtons.YesNo );
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            this.Close();
        }
    }
}
