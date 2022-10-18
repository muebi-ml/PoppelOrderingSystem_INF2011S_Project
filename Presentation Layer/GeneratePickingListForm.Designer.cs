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
            this.orderNumberTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.pickingListView = new System.Windows.Forms.ListView();
            this.productCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // orderIDLabel
            // 
            this.orderIDLabel.AccessibleName = "orderIDLabel";
            this.orderIDLabel.AutoSize = true;
            this.orderIDLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.orderIDLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderIDLabel.Location = new System.Drawing.Point(63, 28);
            this.orderIDLabel.Name = "orderIDLabel";
            this.orderIDLabel.Size = new System.Drawing.Size(71, 15);
            this.orderIDLabel.TabIndex = 0;
            this.orderIDLabel.Text = "Order ID";
            // 
            // pickingListLabel
            // 
            this.pickingListLabel.AutoSize = true;
            this.pickingListLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickingListLabel.Location = new System.Drawing.Point(136, 75);
            this.pickingListLabel.Margin = new System.Windows.Forms.Padding(3, 25, 3, 25);
            this.pickingListLabel.Name = "pickingListLabel";
            this.pickingListLabel.Size = new System.Drawing.Size(142, 22);
            this.pickingListLabel.TabIndex = 1;
            this.pickingListLabel.Text = "Picking List";
            // 
            // orderNumberTextBox
            // 
            this.orderNumberTextBox.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.orderNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderNumberTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderNumberTextBox.Location = new System.Drawing.Point(140, 26);
            this.orderNumberTextBox.Name = "orderNumberTextBox";
            this.orderNumberTextBox.Size = new System.Drawing.Size(138, 19);
            this.orderNumberTextBox.TabIndex = 4;
            this.orderNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orderNumberTextBox_KeyPressed);
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.generateButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.generateButton.FlatAppearance.BorderSize = 0;
            this.generateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.generateButton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(284, 21);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(110, 32);
            this.generateButton.TabIndex = 5;
            this.generateButton.Text = "generate";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // pickingListView
            // 
            this.pickingListView.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pickingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productCode,
            this.Quantity,
            this.productName});
            this.pickingListView.HideSelection = false;
            this.pickingListView.Location = new System.Drawing.Point(49, 125);
            this.pickingListView.Name = "pickingListView";
            this.pickingListView.Size = new System.Drawing.Size(320, 383);
            this.pickingListView.TabIndex = 6;
            this.pickingListView.UseCompatibleStateImageBehavior = false;
            this.pickingListView.View = System.Windows.Forms.View.Details;
            // 
            // productCode
            // 
            this.productCode.Text = "Product Code";
            this.productCode.Width = 85;
            // 
            // Quantity
            // 
            this.Quantity.DisplayIndex = 2;
            this.Quantity.Text = "Quantity";
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.Width = 85;
            // 
            // productName
            // 
            this.productName.DisplayIndex = 1;
            this.productName.Text = "Product Name";
            this.productName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productName.Width = 150;
            // 
            // GeneratePickingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(422, 536);
            this.Controls.Add(this.pickingListView);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.orderNumberTextBox);
            this.Controls.Add(this.pickingListLabel);
            this.Controls.Add(this.orderIDLabel);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "GeneratePickingListForm";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeneratePickingListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label orderIDLabel;
        private System.Windows.Forms.Label pickingListLabel;
        private System.Windows.Forms.TextBox orderNumberTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ListView pickingListView;
        private System.Windows.Forms.ColumnHeader productCode;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader productName;
    }
}