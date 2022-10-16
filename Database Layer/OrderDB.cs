using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PoppelOrderingSystem_INF2011S_Project.DatabaseLayer;
using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using System.Data;
using System.Diagnostics;
using static PoppelOrderingSystem_INF2011S_Project.Business_Layer.Product;

namespace PoppelOrderingSystem_INF2011S_Project.Database_Layer
{
    public class OrderDB : Database
    {
        #region Data members

        private string orderTbl = "Order";
        private string orderQuery = "SELECT * FROM Order";

        private string productTbl = "Product";
        private string productQuery = "SELECT * FROM Product";

        /* Collection to add products */
        private Collection<Order> orders;
        private Collection<Product> products;
        #endregion

        #region Constructor
        public OrderDB() : base()
        {
            orders = new Collection<Order>();
            products = new Collection<Product>();
            Add2Collection(productTbl);
        }
        #endregion

        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Product product;


            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Product object
                    product = new Product("", "", "", Category.UNSPECIFIED, 0.0);

                    //Obtain product attributes from the specific field in the row in the table

                    product.ProductCode = Convert.ToString(myRow["productCode"]).TrimEnd();
                    product.ProductName = Convert.ToString(myRow["productName"]).TrimEnd();
                    product.ProductDescription = Convert.ToString(myRow["productDescription"]).TrimEnd();
                    product.Price = Convert.ToDouble(myRow["price"]);
                    product.ExpiryDate = Convert.ToDateTime(myRow["expiryDate"]);
                    product.InStockLevel = Convert.ToInt16(myRow["inStock"]);
                    //product.ProductType = Convert.ToInt16(myRow["categoryID"]);

                    

                    products.Add(product);
                }
            }
        }





    }
}
