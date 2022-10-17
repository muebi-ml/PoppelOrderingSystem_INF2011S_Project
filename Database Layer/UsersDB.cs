using PoppelOrderingSystem_INF2011S_Project.Business_Layer;
using PoppelOrderingSystem_INF2011S_Project.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem_INF2011S_Project.Database_Layer
{
    internal class UsersDB: Database
    {

        public UsersDB() : base()
        {

        }

        public bool AuthenticateUser ( string username, string password )
        {
            string query = "SELECT * FROM MarkettingClerk WHERE ( username = @username AND password = @password )";
            // 

            SqlDataReader reader;
            SqlCommand command = new SqlCommand(query, cnMain);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            MarkettingClerk clerk = new MarkettingClerk();

            bool login = false;

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();   
                
                while (reader.Read() )
                {
                    login = true;
                    Console.WriteLine("WE ARE HERE");
                }
                cnMain.Close();
                Console.WriteLine("WE ARE HERE");
                return login;
            }
            catch ( Exception ex)
            {
                Console.Write( ex.Message );
                cnMain.Close();
            }

            return login;
        }

        public MarkettingClerk GetAuthenticatedUser( string username, string password )
        {
            string query = "SELECT * FROM MarkettingClerk WHERE ( username = @username AND password = @password )";
            // 

            SqlDataReader reader;
            SqlCommand command = new SqlCommand(query, cnMain);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            MarkettingClerk clerk = new MarkettingClerk();

            try
            {
                cnMain.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    clerk.ClerkID = reader.GetInt16(0);
                    clerk.FirstName = reader.GetString(1).Trim();
                    clerk.LastName = reader.GetString(2).Trim();
                    clerk.Email = reader.GetString(3).Trim();
                    clerk.Phone = reader.GetString(4).Trim();
                    clerk.Username = reader.GetString(5).Trim();
                    clerk.Password = reader.GetString(6).Trim();
                }
                cnMain.Close();
                Console.WriteLine("WE ARE HERE");
                return clerk;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                cnMain.Close();
            }

            
            return clerk;
        }
    }
}
