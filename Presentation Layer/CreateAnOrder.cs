/* Create an order form:
 * it displays two options "New Customer" and "Existing Customer"
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    public class CreateAnOrder : Form
    {
        private System.Windows.Forms.Button newCustomerOption;
        private System.Windows.Forms.Button existingCustomerButton;
        private bool isCreatingOrder;

        public CreateAnOrder(bool isCreatingOrder)
        {
            InitializeComponent();
            this.isCreatingOrder = isCreatingOrder;
        }

        private void InitializeComponent()
        {
            this.existingCustomerButton = new System.Windows.Forms.Button();
            this.newCustomerOption = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // existingCustomerButton
            // 
            this.existingCustomerButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.existingCustomerButton.Location = new System.Drawing.Point(231, 30);
            this.existingCustomerButton.Name = "existingCustomerButton";
            this.existingCustomerButton.Size = new System.Drawing.Size(99, 133);
            this.existingCustomerButton.TabIndex = 1;
            this.existingCustomerButton.Text = "Existing Customer";
            this.existingCustomerButton.UseVisualStyleBackColor = false;
            this.existingCustomerButton.Click += new System.EventHandler(this.existingCustomerButton_Click);
            // 
            // newCustomerOption
            // 
            this.newCustomerOption.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.newCustomerOption.Location = new System.Drawing.Point(86, 30);
            this.newCustomerOption.Name = "newCustomerOption";
            this.newCustomerOption.Size = new System.Drawing.Size(99, 133);
            this.newCustomerOption.TabIndex = 2;
            this.newCustomerOption.Text = "New Customer";
            this.newCustomerOption.UseVisualStyleBackColor = false;
            this.newCustomerOption.Click += new System.EventHandler(this.newCustomerOption_Click);
            // 
            // CreateAnOrder
            // 
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(420, 240);
            this.Controls.Add(this.newCustomerOption);
            this.Controls.Add(this.existingCustomerButton);
            this.Name = "CreateAnOrder";
            this.Text = "Create a new order";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.ResumeLayout(false);

        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {

        }

        private void existingCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(false, isCreatingOrder);
            customerDetailsForm.Show();
            this.Hide();
        }

        private void newCustomerOption_Click(object sender, EventArgs e)
        {
            // after choosing "New Customer" option open CustomerDetailsForm
            CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(true,isCreatingOrder);
            customerDetailsForm.Show();
            this.Hide();

        }
    }
}
