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
    public partial class GeneratePickingListForm : Form
    {

        private OrderController controller;
        private Collection<OrderItem> pickingList;
        public GeneratePickingListForm( OrderController controller )
        {
            InitializeComponent();
            this.controller = controller;
        }

        public GeneratePickingListForm()
        {
            InitializeComponent();
            this.controller = new OrderController();
            ShowGenerateButton();
        }

        private void orderNumberTextBox_KeyPressed( object sender, KeyPressEventArgs e )
        {
            // allows only numbers
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ((char)Keys.Back))
            {
                e.Handled = true;
            }
            ShowGenerateButton();
        }

        private void ShowGenerateButton()
        {
            if ( orderNumberTextBox.Text.Length > 4 )
            {
                generateButton.Enabled = true;
            }
            else
            {
                deactivateGenerateButton();
            }
        }

        private void deactivateGenerateButton()
        {
            generateButton.Enabled = false;
        }

        private void PopulateListView()
        {
            int id = int.Parse(orderNumberTextBox.Text.Trim());
            pickingList = controller.GeneratePickingList(id);

            if ( pickingList.Count == 0 )
            {
                MessageBox.Show("Order " + id.ToString() + " Was not found.");
                orderNumberTextBox.Clear();
            }
            else
            {
                ListViewItem productDetails;

                foreach (OrderItem item in pickingList)
                {
                    productDetails = new ListViewItem();

                    productDetails.Text = item.ProductCode.ToString() ;
                    productDetails.SubItems.Add(item.Quantity.ToString());
                    productDetails.SubItems.Add(item.Product.ProductName);

                    if ( item.Product != null )
                    {
                        Console.WriteLine(item.Product.ToString());
                    }

                    pickingListView.Items.Add(productDetails);
                }
            }


            

        }

        private void generateButton_Click( object sender, EventArgs e ) 
        {
            PopulateListView();
        }
    }
}
