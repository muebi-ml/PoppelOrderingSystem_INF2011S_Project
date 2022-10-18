using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    public partial class MainOrderingForm : Form
    {
        
        private int currentMax = 0;
        #region Static Objects 
        private static MarkettingClerk loggedInAs;
        private static Collection<OrderItem> cart;
        private static bool loggedIn = false;
        private static bool isCurrentlyMakingOrder = false;
        private static Customer currentCustomer;
        private static Product currentProduct;
        private static bool orderComplete = false;
        
        #endregion

        #region Data Members
        private OrderController orderController;
        private CustomerController customerController;
        private Collection<Product> products;
        #endregion
        #region Constructor
        public MainOrderingForm()
        {
            InitializeComponent();
            this.orderController = new OrderController();
            this.customerController = new CustomerController();           
            
            clerkNameTextBox.Enabled = false;
            employeeIDTextBox.Enabled = false;

            if ( !loggedIn )
            {
                cart = new Collection<OrderItem>();
            }
            EnablePanel();
            disableTextBoxes();
            products = orderController.GetProduucts();

            

        }
        #endregion

        #region Method to access clerkObject
        private void LoginAs()
        {

        }
        #endregion


        #region Product List View Methods

        #endregion

        #region Panel Methods 
        private void EnablePanel()
        {
            if ( !loggedIn )
            {
                rightOrderPanel.Enabled = false;
                productPanel.Enabled = false;
            }
            else
            {
                rightOrderPanel.Enabled = true;
                productPanel.Enabled = true;
            }
        }
        #endregion
        private void cancelOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to checkout cart now ?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int orderID = orderController.createOrder(currentCustomer, loggedInAs, cart, GetOrderTotal() );

                Console.WriteLine("Order: " + orderID.ToString() + " created Succesfully");

                Account account = customerController.GetCustomerAccount(currentCustomer);
                Address address = customerController.getAddressByID(currentCustomer.AddressID);
                Order order = orderController.GetOrderByID(orderID);

                OrderSummary orderSummaryForm = new OrderSummary(currentCustomer, loggedInAs, order, address);
                orderComplete = true;

                int count = cart.Count;
                cart.Clear();
                ClearProDuctFields();
                orderSummaryForm.ShowDialog();

                for (int i = 0; i < count; i++ )
                {
                    productListView.Items.RemoveAt(i);
                }
                
            }else
            {

            }
            
        }

        private bool CheckCustomerEligibility( Customer customer )
        {
            Account account = customerController.GetCustomerAccount(customer);

            if ( account.Status == Account.CreditStatus.BLACKLISTED )
            {
                return false;
            }
            else if( account.CreditLimit > SubTotal() && cart.Count > 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void generateExpiredProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateExpiryForm formExpiry = new GenerateExpiryForm(orderController);

            formExpiry.ShowDialog();
        }

        private void ShowAddToCartButton( bool yes)
        {
            if ( yes )
            {
                addToCartButton.Enabled = true;
            }
            else
            {
                addToCartButton.Enabled = false;    
            }
        }

        private void generatePickingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratePickingListForm pickingListForm = new GeneratePickingListForm();

            pickingListForm.ShowDialog();
        }

        private void PopulateOrderItems()
        {
            ListViewItem productDetails;
            if ( cart.Count > 0 )
            {
                foreach( OrderItem item in cart )
                {
                    productDetails = new ListViewItem();

                    productDetails.Text = item.Product.ProductName.ToString();
                    productDetails.SubItems.Add(item.SubTotal.ToString());
                    
                }
            }
        }

        private void MainOrderingForm_Load(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                clerkNameTextBox.Text = loggedInAs.FirstName + " " + loggedInAs.LastName;
                employeeIDTextBox.Text = loggedInAs.ClerkID.ToString();
                loginButton.Text = "logout";

            }
            if (isCurrentlyMakingOrder)
            {
                PopulateCustomerDetails();
                PopulateProductListView();
                
                isCurrentlyMakingOrder = false;
            }
            EnablePanel();
        }

        internal void RecieveData( MarkettingClerk clerk )
        {
            loggedInAs = clerk;

            clerkNameTextBox.Text = clerk.FirstName + " " + clerk.LastName;
            employeeIDTextBox.Text = clerk.ClerkID.ToString();
            clerkNameTextBox.Enabled = false;
            employeeIDTextBox.Enabled = false;
            loggedIn = true;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MainLoginForm loginForm = new MainLoginForm();
            loginForm.ShowDialog();
        }

        private void MainOrderingForm_Activated(object sender, EventArgs e)
        {
            if ( loggedIn)
            {
                clerkNameTextBox.Text = loggedInAs.FirstName + " " + loggedInAs.LastName;
                employeeIDTextBox.Text = loggedInAs.ClerkID.ToString();
                loginButton.Text = "logout";

            }
            if ( isCurrentlyMakingOrder )
            {
                if ( CheckCustomerEligibility(currentCustomer) )
                {
                    PopulateCustomerDetails();
                    PopulateProductListView();
                    InitialiseOrderPanel();
                }
                else
                {
                    MessageBox.Show("Customer cannot create an order at this moment. Credit status == BLACKLISTED ");
                }

                isCurrentlyMakingOrder = false;
                
            }
            EnablePanel();
        }

        private void createANewCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(true, false);
                customerDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: User not logged in.\nPlease login.");
            }
        }

        private void PopulateProductListView()
        {
            productListView.Refresh();
            ListViewItem listViewItem;

            foreach(Product product in products )
            {
                listViewItem = new ListViewItem();

                listViewItem.Text = product.ProductCode.ToString();
                listViewItem.SubItems.Add(product.ProductName);
                listViewItem.SubItems.Add(product.Price.ToString());
                listViewItem.SubItems.Add(product.InStockLevel.ToString());
                listViewItem.SubItems.Add(product.ExpiryDate.ToShortDateString());

                productListView.Items.Add(listViewItem);
            }
        }

        private void viewCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(false, false);
                customerDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: User not logged in.\nPlease login.");
            }
        }

        internal void PassBackCustomer( Customer globalCustomer)
        {
            currentCustomer = globalCustomer;
            isCurrentlyMakingOrder = true;

            Console.WriteLine(currentCustomer.ToString());
        }

        private void PopulateCustomerDetails()
        {
            customerIDTextBox.Enabled = true;
            customerNameTextBox.Enabled = true;
            accountNumberTextBox.Enabled = true;
            creditStatusTextBox.Enabled = true;
            creditLimitTextBox.Enabled = true;
            creditBalanceTextBox.Enabled = true;
            Account account = customerController.GetCustomerAccount(currentCustomer);
            customerIDTextBox.Text = currentCustomer.CustomerID.ToString();
            customerNameTextBox.Text = currentCustomer.FirstName + " " + currentCustomer.LastName;
            creditBalanceTextBox.Text = account.CreditBalance.ToString();
            creditLimitTextBox.Text = account.CreditLimit.ToString();
            accountNumberTextBox.Text = account.AccountID.ToString();
            creditStatusTextBox.Text = account.Status.ToString();

            disableTextBoxes();
            
        }

        private void disableTextBoxes()
        {
            customerIDTextBox.Enabled = false;
            customerNameTextBox.Enabled = false;
            accountNumberTextBox.Enabled = false;
            creditStatusTextBox.Enabled = false;
            creditLimitTextBox.Enabled = false;
            creditBalanceTextBox.Enabled = false;

            productCodeTextBox.Enabled = false;
            productNameTextBox.Enabled = false;
            availableItemsTextBox.Enabled = false;
            vatTextBox.Enabled = false;
            orderTotalTextBox.Enabled = false;
            amountDueTextBox.Enabled = false;
        }

        private void createNewOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                CreateAnOrder createAnOrder = new CreateAnOrder(true);
                createAnOrder.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please login before creating a new order.");
            }
            
        }

        private void existingCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if ( loggedIn )
            {
                CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(false, true);
                customerDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please login before creating a new order.");
            }
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(true, true);
                customerDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please login before creating a new order.");
            }
        }

        private void generateExpiredItemsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( loggedIn )
            {
                GenerateExpiryForm generateExpiryForm = new GenerateExpiryForm(orderController);
                generateExpiryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: User not logged in.\nPlease login.");
            }
        }

        private void generatePickingListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                GeneratePickingListForm generatePickingListForm = new GeneratePickingListForm();
                generatePickingListForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: User not logged in.\nPlease login.");
            }
        }

        #region Order Methods 
        private double GetOrderTotal()
        {
            double total = 0;   
            if ( cart.Count > 0)
            {
                foreach ( OrderItem item in cart )
                {
                    total += item.SubTotal;
                }
            }
            return total;
        }

        private double getVat()
        {
            double vat = GetOrderTotal() * 0.15;
            return Math.Round(vat, 2);
        }

        private double SubTotal()
        {
            return getVat() + GetOrderTotal();
        }
        #endregion

        private void productListView_SelectedIndexChanged( object sender, EventArgs e )
        {
             
            if ( productListView.SelectedItems.Count > 0 )
            {
                int productCode = int.Parse(productListView.SelectedItems[0].Text);

                currentProduct = orderController.GetProductByID(productCode);

                PopulateProductPanel();
            }
        }

        private void PopulateProductPanel()
        {
            productCodeTextBox.Enabled = false;
            productCodeTextBox.Text = currentProduct.ProductCode.ToString();
            productNameTextBox.Enabled = false;
            productNameTextBox.Text = currentProduct.ProductName;
            availableItemsTextBox.Enabled = false;
            availableItemsTextBox.Text = currentProduct.InStockLevel.ToString();
            quantityTextBox.Enabled = true;
        }

        public void quantityTextBox_KeyPress( object sender, KeyPressEventArgs e )
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void InitialiseOrderPanel()
        {
            orderTotalTextBox.Text = "0.00";
            vatTextBox.Text = "0.00";
            amountDueTextBox.Text = "0.00";
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            
            if ( quantityTextBox.Text.Length < 1 )
            {
                MessageBox.Show("Please enter quantity before adding product to cart.");
            }
            int quantity = int.Parse(quantityTextBox.Text.TrimStart(new char[] { '0' }));
            if ( currentProduct.InStockLevel < quantity )
            {
                MessageBox.Show("Quantity cannot exceed the number of available units.");
                quantityTextBox.Text = "";
            }
            else if(!CheckCustomerEligibility(currentCustomer))
            {
                MessageBox.Show("The customer has exceeded their credit limit.");
            }
            else
            {
                OrderItem item = new OrderItem();
                item.Quantity = quantity;
                item.Product = currentProduct;


                AddToCart(item);
                ClearProDuctFields();
                UpdateOrderTotals();
            }
        }

        private void ClearProDuctFields()
        {
            productCodeTextBox.Enabled = false;
            productCodeTextBox.Text = "";
            productNameTextBox.Enabled = false;
            productNameTextBox.Text = "";
            availableItemsTextBox.Enabled = false;
            availableItemsTextBox.Text = "";
            quantityTextBox.Enabled = false;
            quantityTextBox.Text = "";
        }

        private void UpdateOrderTotals()
        {
            double vat = getVat();
            double orderTotal = GetOrderTotal();
            double amountDue = vat + orderTotal;

            orderTotalTextBox.Text = orderTotal.ToString();
            vatTextBox.Text = vat.ToString();
            amountDueTextBox.Text = amountDue.ToString();
        }
        private void PopulateOrderListView(OrderItem item )
        {
            ListViewItem listViewItem;

            listViewItem = new ListViewItem();

            listViewItem.Text = item.Product.ProductName;
            listViewItem.SubItems.Add(item.Quantity.ToString());
            listViewItem.SubItems.Add(Math.Round(item.SubTotal, 2).ToString());
            orderListView.Items.Add(listViewItem);
        }

        private void AddToCart( OrderItem itemToAdd )
        {
            if ( isInCart(itemToAdd) )
            {
                foreach( OrderItem item in cart )
                {
                    if ( item.Product.ProductCode == itemToAdd.Product.ProductCode )
                    {
                        item.Quantity += itemToAdd.Quantity;
                        int index = FindItemIndex(itemToAdd);
                        orderListView.Items[index].SubItems[1].Text = item.Quantity.ToString();
                        orderListView.Items[index].SubItems[2].Text = item.SubTotal.ToString();
                    }
                }
                
            }
            else
            {
                cart.Add(itemToAdd);
                PopulateOrderListView(itemToAdd);
            }
            
        }

        private int FindItemIndex(OrderItem itemToAdd )
        {
            int index = 0;
            bool found = false;

            foreach(OrderItem item in cart)
            {
                if ( item.Product.ProductCode == itemToAdd.Product.ProductCode)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        private bool isInCart(OrderItem itemToAdd)
        {
            bool flag = false;

            foreach (OrderItem item in cart)
            {
                if ( item.Product.ProductCode == itemToAdd.Product.ProductCode )
                {
                    flag = true;
                }
            }

            return flag;
        }
    }
}
