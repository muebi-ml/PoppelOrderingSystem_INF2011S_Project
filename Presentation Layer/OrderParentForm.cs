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
    public partial class OrderParentForm : Form
    {
        private int childFormNumber = 0;
        private OrderController OrderController;
        private CustomerController CustomerController;
        private MarkettingClerk clerk;

        public OrderParentForm()
        {
            InitializeComponent();
            OrderController = new OrderController();
            CustomerController = new CustomerController();

            CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(false, false);
            customerDetailsForm.continueButton.Click += new EventHandler( this.continueButton_Click );

            //frmChild.btnClickMeToo.Click += new
            //EventHandler(frmMain.btnClickMe_Click);

            Customer c = CustomerDetailsForm.globalCustomer;
        }

        public OrderParentForm(MarkettingClerk clerk)
        {
            this.clerk = clerk;
            OrderController = new OrderController();
            CustomerController = new CustomerController();
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }


        private void continueButton_Click( object sender , EventArgs e )
        {
            MessageBox.Show("Yaya");
            Console.WriteLine("Hello");
        }


        #region On Click Events 
        
        #endregion










        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void createNewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // after clicking "Create new order" strip display CreateAnOrder form
            CreateAnOrder orderform = new CreateAnOrder(false);
            orderform.Show();
           
            
        }
    }
}
