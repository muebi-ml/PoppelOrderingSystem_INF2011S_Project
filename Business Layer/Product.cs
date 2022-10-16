using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Product
    {

        #region Category
        public enum Category
        {
            UNSPECIFIED = 0,
            SOFTDRINK = 1,
            CONFECTIONARY = 2,
            BRANDED = 3,
            UNBRANDED = 4
        }
        #endregion
        #region Attributes
        private int productCode;
        private string productName;
        private string productDescription;
        private Category productType;
        private int inStockLevel, reservedLevel;
        private bool onSpecial;
        private double price;
        private DateTime expiryDate;
        private double discountPrice;
        #endregion

        #region Constructor 
        public Product ( int productCode, string productName, string productDescription, Category productType, double price)
        {
            this.productCode = productCode;
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;
            this.productType = productType;
            this.discountPrice = 0.0;
            this.onSpecial = false;
            this.inStockLevel = 0;
            this.reservedLevel = 0;

        }

        public Product()
        {
            productCode = 0;
            productType = Category.UNSPECIFIED;
        }
        #endregion

        #region Property Methods 
        public int ProductCode
        {
            set { productCode = value; }
            get { return productCode; }
        }

        public int InStockLevel
        {
            get { return inStockLevel;}
            set { inStockLevel = value; }
        }

        public int ReservedLevel
        {
            get { return this.reservedLevel;}
            set { this.reservedLevel += value; }
        }

        public double DiscountPrice
        {
            get { return this.discountPrice;}
            set { this.discountPrice = value; }
        }

        public Category ProductType
        {
            get { return this.productType; }
            set
            {
                this.productType = value;
            }
        }

        public string ProductDescription
        {
            get { return this.productDescription; }
            set
            {
                this.productDescription = value;
            }
        }

        public bool OnSpecial
        {
            set { this.onSpecial = value; }
            get { return this.onSpecial; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                this.price = value;
            }
        }

        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }

        public DateTime ExpiryDate
        {
            set { this.expiryDate = value; }
            get { return this.expiryDate; }
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return  "Product Code: " + this.productCode + 
                    "\nProduct Name: "+ this.productName +
                    "\nPrice: " + this.price + 
                    "\nExpiry Date: " + expiryDate + 
                    "\nIn Stock: " + this.inStockLevel + 
                    "\nCategory Type: " + this.productType;
        }
        #endregion
    }
}