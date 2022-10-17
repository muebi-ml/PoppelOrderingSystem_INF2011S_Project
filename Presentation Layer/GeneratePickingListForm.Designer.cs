namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    partial class GeneratePickingListForm
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
            this.orderIDLabel = new System.Windows.Forms.Label();
            this.pickingListLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pickingListView = new System.Windows.Forms.ListView();
            this.productCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // orderIDLabel
            // 
            this.orderIDLabel.AccessibleName = "orderIDLabel";
            this.orderIDLabel.AutoSize = true;
            this.orderIDLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.orderIDLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderIDLabel.Location = new System.Drawing.Point(28, 27);
            this.orderIDLabel.Name = "orderIDLabel";
            this.orderIDLabel.Size = new System.Drawing.Size(88, 18);
            this.orderIDLabel.TabIndex = 0;
            this.orderIDLabel.Text = "Order ID";
            // 
            // pickingListLabel
            // 
            this.pickingListLabel.AutoSize = true;
            this.pickingListLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickingListLabel.Location = new System.Drawing.Point(147, 75);
            this.pickingListLabel.Margin = new System.Windows.Forms.Padding(3, 25, 3, 25);
            this.pickingListLabel.Name = "pickingListLabel";
            this.pickingListLabel.Size = new System.Drawing.Size(142, 22);
            this.pickingListLabel.TabIndex = 1;
            this.pickingListLabel.Text = "Picking List";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(132, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 23);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(284, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "generate";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pickingListView
            // 
            this.pickingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productCode,
            this.Quantity});
            this.pickingListView.HideSelection = false;
            this.pickingListView.Location = new System.Drawing.Point(31, 125);
            this.pickingListView.Name = "pickingListView";
            this.pickingListView.Size = new System.Drawing.Size(363, 383);
            this.pickingListView.TabIndex = 6;
            this.pickingListView.UseCompatibleStateImageBehavior = false;
            this.pickingListView.View = System.Windows.Forms.View.Details;
            // 
            // productCode
            // 
            this.productCode.Text = "Product Code";
            this.productCode.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 150;
            // 
            // GeneratePickingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(422, 536);
            this.Controls.Add(this.pickingListView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pickingListLabel);
            this.Controls.Add(this.orderIDLabel);
            this.Name = "GeneratePickingListForm";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.Text = "GeneratePickingListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderIDLabel;
        private System.Windows.Forms.Label pickingListLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView pickingListView;
        private System.Windows.Forms.ColumnHeader productCode;
        private System.Windows.Forms.ColumnHeader Quantity;
    }
}