using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using Control.Users.Entities;

namespace Control.Users.Controller
{
    public class UserController : BaseController
    {
        public Boolean IsUserNameUnique(String username)
        {
            String commandText = @"SELECT * FROM BASE_USER WHERE User_Name = @USERNAME";
            SqlCommand command = new SqlCommand(commandText,Connection);
            command.Parameters.Add("@USERNAME",SqlDbType.VarChar);
            command.Parameters["@USERNAME"].Value = username;

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            
            Connection.Open();
            Boolean returnValue = adapter.SelectCommand.ExecuteReader().HasRows;
            Connection.Close();
            return !returnValue;
        }
            
        public Boolean UserRegister(String username, String password, String email)
        {
            try
            {
                String commandText =
                    "INSERT INTO BASE_USER (Creation_Date, Update_Date, User_Name, Password, Email, User_Type_Id) VALUES(CURRENT_TIMESTAMP,CURRENT_TIMESTAMP, @USERNAME, @PASSWORD, @EMAIL, 1)";
                SqlCommand command = new SqlCommand(commandText, Connection);
                command.Parameters.Add("@USERNAME", SqlDbType.VarChar);
                command.Parameters.Add("@PASSWORD", SqlDbType.VarChar);
                command.Parameters.Add("@EMAIL", SqlDbType.VarChar);
                command.Parameters["@USERNAME"].Value = username;
                command.Parameters["@PASSWORD"].Value = password;
                command.Parameters["@EMAIL"].Value = email;

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = command;
                Connection.Open();
                if (adapter.InsertCommand.ExecuteNonQuery() > 0)
                {
                    Connection.Close();
                    return true;
                }
                else
                {
                    Connection.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                Connection.Close();
                throw;
            }
        }
        
        public Boolean UserLogin(String userName, String password)
        {
            try
            {
                String commandText = @"SELECT PASSWORD FROM BASE_USER WHERE USER_NAME=@USERNAME";
                SqlCommand command = new SqlCommand(commandText, Connection);
                command.Parameters.Add("@USERNAME", SqlDbType.VarChar);
                command.Parameters["@USERNAME"].Value = userName;
            
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                }
                else
                {
                    Connection.Close();
                    return false;
                }

                String passwordFromDb = reader["PASSWORD"].ToString();
            
                Connection.Close();
                if (passwordFromDb != null && passwordFromDb.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Connection.Close();
                throw;
            }
        }

        public HttpCookie GetAuthorityCookieWithUsername(String userName)
        {
            HttpCookie cookie = new HttpCookie("Authority");
            List<String> authorities = GetUserAuthoritiesAsStringList(userName);
            
            cookie["userName"] = userName;
            foreach (String authority in authorities)
            {
                cookie[authority] = authority;
            }

            return cookie;
        }

        private List<String> GetUserAuthoritiesAsStringList(String userName)
        {
            String commandText = @"SELECT A.Authority_Name as AN FROM Base_User AS BU INNER JOIN Authority AS A ON A.ID = BU.User_Type_Id WHERE BU.User_Name = @USERNAME";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.Parameters.Add("@USERNAME", SqlDbType.VarChar);
            command.Parameters["@USERNAME"].Value = userName;
            
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<String> authorities = new List<String>();

            while (reader.Read())
            {
                authorities.Add(reader["AN"].ToString());
            }
            
            Connection.Close();

            return authorities;
        }
    }
}