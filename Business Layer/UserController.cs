using PoppelOrderingSystem_INF2011S_Project.Database_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Business_Layer
{
    public class UserController
    {
        private UsersDB userDB;
        public UserController()
        {
            userDB = new UsersDB();
        }

        public bool AuthenticateUser( string username, string password )
        {
            bool login = userDB.AuthenticateUser(username, password);
            Console.WriteLine(login);

            return login;   
        }
        
        public MarkettingClerk GetAuthenticatedUser( string username, string password)
        {
            if (AuthenticateUser(username, password))
            {
                return userDB.GetAuthenticatedUser(username, password);
            }
            return null;
        }
    }
}
