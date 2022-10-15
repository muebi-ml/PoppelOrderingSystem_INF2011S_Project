using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using PoppelOrderingSystem_INF2011S_Project.Database_Layer;
using System;
using System.Collections.Generic;
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
            //Application.Run(new Form1());

            
            CustomerDB db = new CustomerDB();
            
            

            Customer customer = new Customer("990404", "Mukhethwa", "Muebi", "0608055010", "mbxmuk002@myuct.ac.za", 5, 4);
            customer.AccountID = 3;

            db.addCustomer(customer);

            Console.WriteLine("Added Employee");

            Console.WriteLine("This is a test run");
            Console.WriteLine(db.getCustomer(5));

            Console.WriteLine("test if update works");
            Customer customer2 = new Customer("990404", "Mukhethwa", "Muebi", "0608055010", "muebiml1999@gmail.com", 5, 4);
            customer2.AccountID = 3;
            db.updateCustomerDetails(customer2);
            Console.WriteLine(db.getCustomer(5));
        }
    }
}
