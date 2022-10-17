namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    partial class OrderParentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.manageOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completedOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageOrdersToolStripMenuItem,
            this.manageInventoryToolStripMenuItem,
            this.catalogueToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(126, 453);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // manageOrdersToolStripMenuItem
            // 
            this.manageOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewOrderToolStripMenuItem,
            this.modifyOrderToolStripMenuItem,
            this.completedOrdersToolStripMenuItem});
            this.manageOrdersToolStripMenuItem.Name = "manageOrdersToolStripMenuItem";
            this.manageOrdersToolStripMenuItem.Size = new System.Drawing.Size(113, 19);
            this.manageOrdersToolStripMenuItem.Text = "Manage Orders";
            // 
            // createNewOrderToolStripMenuItem
            // 
            this.createNewOrderToolStripMenuItem.Name = "createNewOrderToolStripMenuItem";
            this.createNewOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createNewOrderToolStripMenuItem.Text = "Create new order";
            this.createNewOrderToolStripMenuItem.Click += new System.EventHandler(this.createNewOrderToolStripMenuItem_Click);
            // 
            // modifyOrderToolStripMenuItem
            // 
            this.modifyOrderToolStripMenuItem.Name = "modifyOrderToolStripMenuItem";
            this.modifyOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modifyOrderToolStripMenuItem.Text = "Modify order";
            // 
            // completedOrdersToolStripMenuItem
            // 
            this.completedOrdersToolStripMenuItem.Name = "completedOrdersToolStripMenuItem";
            this.completedOrdersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.completedOrdersToolStripMenuItem.Text = "Completed orders";
            // 
            // manageInventoryToolStripMenuItem
            // 
            this.manageInventoryToolStripMenuItem.Name = "manageInventoryToolStripMenuItem";
            this.manageInventoryToolStripMenuItem.Size = new System.Drawing.Size(113, 19);
            this.manageInventoryToolStripMenuItem.Text = "Manage Inventory";
            // 
            // catalogueToolStripMenuItem
            // 
            this.catalogueToolStripMenuItem.Name = "catalogueToolStripMenuItem";
            this.catalogueToolStripMenuItem.Size = new System.Drawing.Size(113, 19);
            this.catalogueToolStripMenuItem.Text = "Catalogue";
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(126, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(506, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(126, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(506, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // OrderParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "OrderParentForm";
            this.Text = "Poppel Order Management System";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem manageOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completedOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogueToolStripMenuItem;
    }
}



