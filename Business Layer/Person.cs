using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class Person
    {

        #region Attributes 
        string firstName, lastName, phone;
        #endregion

        #region Property Methods 
        public string FirstName { 
            get { return firstName; } 
            set { firstName = value; } 
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        #endregion
    }
}
