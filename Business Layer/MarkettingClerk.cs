using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class MarkettingClerk: Person
    {
        #region Attributes
        private int clerkID;
        private string username;
        private string password;    


        public MarkettingClerk() : base()
        {
            this.username = "";
            this.password = "";
        }
        #endregion

        public MarkettingClerk( int clerkID ) : base()
        {
            this.clerkID = clerkID;
        }

        public MarkettingClerk(int clerkID, string username, string password ): base()
        {

        }
        #region Property Methods
        public int ClerkID
        {
            get { return clerkID; }
            set { clerkID = value; }    
        }

        public string Username
        {
            get { return username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return password; }    
            set { this.password = value; }
        }
        #endregion

        #region To String () 
        public override string ToString()
        {
            return "Marketting Clerk ID: " + clerkID.ToString() + "\n" + base.ToString();
        }
        #endregion
    }
}
