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
    public partial class MainLoginForm : Form
    {
        private UserController userController;
        private MarkettingClerk clerk;
        private bool invalid;
        
        public MainLoginForm()
        {
            InitializeComponent();
            invalid = false;
            userController = new UserController();
            clerk = new MarkettingClerk();
            ClearTextBoxes();
            ActivateLoginButton();
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if ( userController.AuthenticateUser(username, password))
            {
                clerk = userController.GetAuthenticatedUser(username, password);
                OrderParentForm parentForm = new OrderParentForm(clerk);
                ClearTextBoxes();
                parentForm.Show();
                this.Hide();
            }
            else
            {
                loginPrompt.Text = "Invalid username and password";
                ShowLoginPrompt();
                ClearTextBoxes();
                invalid = true; 
                usernameTextBox.BackColor = Color.PaleVioletRed;
                passwordTextBox.BackColor = Color.PaleVioletRed;
                ActivateLoginButton();
            }
            OrderParentForm orderParentForm = new OrderParentForm();
        }

        private void usernameTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            ActivateLoginButton();
            if (invalid)
            {
                invalid = false;
                ClearBackToWhite();
                ShowLoginPrompt();
            }
            else
            {
                removeLoginPrompt();
            }
        }

        private void passwordTextBox_KeyPress ( object sender, KeyPressEventArgs e )
        {
            ActivateLoginButton();

            if ( invalid)
            {
                invalid = false;
                ClearBackToWhite();
                ShowLoginPrompt();
            }
            else
            {
                removeLoginPrompt();
            }
        }

        private void ClearTextBoxes()
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }
        
        private void removeLoginPrompt()
        {
            loginPrompt.Hide();
        }

        private void ShowLoginPrompt()
        {
            loginPrompt.Show();
        }

        private void ClearBackToWhite()
        {
            usernameTextBox.BackColor = Color.AntiqueWhite;
            passwordTextBox.BackColor = Color.AntiqueWhite;
        }

        private void ActivateLoginButton()
        {
            if ( usernameTextBox.Text.Length > 5 && passwordTextBox.Text.Length > 5 )
            {
                loginButton.Enabled = true;
            }
            else
            {
                loginButton.Enabled = false;
            }
            
        }
    }
}
