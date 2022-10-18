namespace PoppelOrderingSystem_INF2011S_Project.Presentation_Layer
{
    partial class GenerateExpiryForm
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
            this.generateListButton = new System.Windows.Forms.Button();
            this.expiredListView = new System.Windows.Forms.ListView();
            this.productCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateListButton
            // 
            this.generateListButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.generateListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateListButton.Location = new System.Drawing.Point(228, 80);
            this.generateListButton.Name = "generateListButton";
            this.generateListButton.Size = new System.Drawing.Size(137, 40);
            this.generateListButton.TabIndex = 0;
            this.generateListButton.Text = "generate";
            this.generateListButton.UseVisualStyleBackColor = false;
            this.generateListButton.Click += new System.EventHandler(this.generateList_Click);
            // 
            // expiredListView
            // 
            this.expiredListView.BackColor = System.Drawing.Color.MediumAquamarine;
            this.expiredListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productCode,
            this.productName,
            this.expiryDate,
            this.quantity});
            this.expiredListView.HideSelection = false;
            this.expiredListView.Location = new System.Drawing.Point(28, 126);
            this.expiredListView.Name = "expiredListView";
            this.expiredListView.Size = new System.Drawing.Size(549, 407);
            this.expiredListView.TabIndex = 1;
            this.expiredListView.UseCompatibleStateImageBehavior = false;
            this.expiredListView.View = System.Windows.Forms.View.Details;
            // 
            // productCode
            // 
            this.productCode.Text = "Product Code";
            this.productCode.Width = 148;
            // 
            // productName
            // 
            this.productName.Text = "Product Name";
            this.productName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productName.Width = 148;
            // 
            // expiryDate
            // 
            this.expiryDate.Text = "Expiry Date ";
            this.expiryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.expiryDate.Width = 148;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generate Expired Products Report";
            // 
            // GenerateExpiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(605, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expiredListView);
            this.Controls.Add(this.generateListButton);
            this.Name = "GenerateExpiryForm";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateExpiryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateListButton;
        private System.Windows.Forms.ListView expiredListView;
        private System.Windows.Forms.ColumnHeader productCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader expiryDate;
        private System.Windows.Forms.ColumnHeader quantity;
    }
}