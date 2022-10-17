using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using PoppelOrderingSystem_INF2011S_Project.Database_Layer;
using PoppelOrderingSystem_INF2011S_Project.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem_INF2011S_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new OrderParentForm()); // form test run
/*
<<<<<<< HEAD
=======
=======
            //Application.Run(new Form1());

>>>>>>> e4fecefbf2141cf2c9cb477481c83e1a12a083d0

            /*CustomerDB db = new CustomerDB();
            
            


            CustomerDB customerDB = new CustomerDB();

            Customer customer = customerDB.getCustomer(4785300);

            Console.WriteLine(customer);

            Console.WriteLine(customerDB.getAccountWithID(customer));


            Console.WriteLine("test if update works");
            Customer customer2 = new Customer("990404", "Mukhethwa", "Muebi", "0608055010", "muebiml1999@gmail.com", 5, 4);
            customer2.AccountID = 3;
            db.updateCustomerDetails(customer2);
            Console.WriteLine(db.getCustomer(2)); 


            // Test run to display all products
            OrderDB order = new OrderDB();

            Console.WriteLine("Show all products");
            Console.WriteLine();
            order.DisplayProducts();

            // Test run to add Order
            
            Order ord = new Order(10200,"2022/03/12","2022/04/12","2022/04/12",Order.Status.In_Process,3);

            order.addOrder(ord);

            Console.WriteLine(order.getOrderByOrderNumber(10200));

            
<<<<<<< HEAD
>>>>>>> karabo-code **/
=======

>>>>>>> e4fecefbf2141cf2c9cb477481c83e1a12a083d0
        }
    }
}
