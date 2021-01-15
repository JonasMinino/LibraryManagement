using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Helper
{
    public static class LoginHelper
    {
        private static SqlConnection con;
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        /// <summary>
        /// Checks if the username is already in use.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool ValidateUser(string user)
        {
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Username=@user", con);
                cmd.Parameters.AddWithValue("@user", user);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) return false;
                rdr.Close();
            }
            return true;
        }
        /// <summary>
        /// Checks if email is alredy in use.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string email)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Email=@email", con);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) return false;
                rdr.Close();
            }

            return true;
        }
        /// <summary>
        /// Inserts a new user in the Login table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int InsertUser(User user)
        {
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Login (Username, Password, Email) VALUES(@user, @pass, @email)", con);
                cmd.Parameters.AddWithValue("@user", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@email", user.Email);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }
        /// <summary>
        /// Validates the username and email against the login data. 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidateCredentials(string user, string email)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Username=@user AND Email=@email", con);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)  return true;
                rdr.Close();
            }
            return false;
        }
        public static string GetPassword(string user, string email)
        {
            string ans = "";
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE Username=@user AND Email=@email", con);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) ans = rdr["Password"].ToString();
                rdr.Close();
            }

            return ans;
        }
    }
}
