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
            //Console.WriteLine("Creating a new customer....\n");
            // Test new customer
            Address address = new Address("22 Rochester Rd", "Observatory", "Cape Town", 7925);
            Account account = new Account( "Zero Shop", Account.CreditStatus.BLACKLISTED, 1200.99, 2400.75);
            Customer customer = new Customer("Mukhethwa", "Muebi", "+27606683825", "muebiml1999@gmail.com");

            db.addCustomer( customer, account, address );
            Customer customer2 = db.getCustomer(db.getLatestCustomerID());

            //Console.WriteLine( customer2.ToString() );

            //Console.WriteLine("\nUpdating Customer \n");
            customer2.Email = "mbxmuk002@myuct.ac.za";
            customer2.FirstName = "Lucky";
            db.editCustomer(customer2);
            //Console.WriteLine( db.getCustomer(db.getLatestCustomerID() ).ToString() ) ;

            Console.WriteLine("\nPrinting Account for customer2");
            Console.WriteLine(db.getAccountWithID(customer2));  
            
            Account ac = db.getAccountWithID( customer2 );
            ac.AccountName = "Venda Langa";
            ac.CreditBalance = 0;
            db.editCustomerAccount(ac);

            Console.WriteLine("\nPrinting Updated Account details for customer2");
            Console.WriteLine(db.getAccountWithID(customer2));

        }
    }
}
