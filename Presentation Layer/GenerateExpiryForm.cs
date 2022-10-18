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
    public partial class GenerateExpiryForm : Form
    {
        private OrderController controller;
        private Collection<Product> products;
        
        public GenerateExpiryForm( OrderController controller )
        {
            InitializeComponent();

            this.controller = controller;
            products = controller.GenerateExpiredProducts();
        }

        private void generateList_Click(object sender, EventArgs e)
        {
            generateListButton.Enabled = false;

            ListViewItem productDetails;
            foreach ( Product product in products)
            {
                productDetails = new ListViewItem();
                productDetails.Text = product.ProductCode.ToString();
                productDetails.SubItems.Add(product.ProductName);
                productDetails.SubItems.Add(product.ExpiryDate.ToShortDateString());
                productDetails.SubItems.Add(product.InStockLevel.ToString());

                expiredListView.Items.Add(productDetails);

            }
        }
    }
}
