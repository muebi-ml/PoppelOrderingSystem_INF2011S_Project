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
            Application.Run(new Form1());

            /**
            CustomerDB db = new CustomerDB();
            Console.WriteLine("This is a test run");
            Console.WriteLine(db.getCustomer(1));
            */
        }
    }
}
