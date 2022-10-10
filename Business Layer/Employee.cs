using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Employee : Person
    {
        #region Attributes
        private string employeeID;
        #endregion
        #region Constructor
        public Employee(string employeeID, string personID, string firstName, string lastName, string phone, string email) : base(personID, firstName, lastName, phone, email)
        {
            this.employeeID = employeeID;
        }

        public Employee(string employeeID, string personID, string firstName, string lastName) : base(personID, firstName, lastName)    
        {
            this.employeeID = employeeID;
        }


        #endregion

        #region Property Methods
        public string EmployeeID
        {
            get { return employeeID; }
        }
        #endregion
    }
}
