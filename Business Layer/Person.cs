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
        string personID, firstName, lastName, phone, email;
        #endregion

        #region Constructors 
        public Person ( string personID, string firstName, string lastName, string phone, string email)
        {
            this.personID = personID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;

        }

        public Person ( string personID, string firstName, string lastName)
        {
            this.personID = personID;
            this.firstName = firstName;
            this.lastName = lastName;
            phone = "";
            email = "";
        }

        #endregion

        #region Property Methods 
        public string ID
        {
            get { return personID; }
        }
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

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion
    }
}
