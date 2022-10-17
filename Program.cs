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
            Application.Run(new OrderParentForm());        

        }
    }
}
