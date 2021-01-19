using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Helper
{
    public static class StudentHelper
    {
        private static SqlConnection con;
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public static void LoadNames(ComboBox combo)
        {
            List<string> list = new List<string>();
            using( con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName FROM Student ORDER BY LastName", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows) while (rdr.Read()) 
                    {
                        list.Add(string.Join(", ", rdr["LastName"].ToString(), rdr["FirstName"].ToString())); 
                    }
                }
            }

            string[] source = list.ToArray();
            combo.DataSource = source;
            combo.SelectedIndex = -1;
        }
        /// <summary>
        /// Loads a combo box with ids based on a student's firstname and lastname. 
        /// </summary>
        /// <param name="combo"></param>
        public static void LoadIds(string name, ComboBox combo)
        {
            string first = name.Substring(name.IndexOf(" ")+1);
            string last = name.Substring(0, name.IndexOf(","));
            List<int> ids = new List<int>();

            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE FirstName=@first AND  LastName=@last", con);
                cmd.Parameters.AddWithValue("first", first);
                cmd.Parameters.AddWithValue("last", last);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ids.Add(int.Parse(rdr["StudentId"].ToString()));
                        }
                    }
                }
                combo.DataSource = ids.ToArray();
            }
        }
        
    }
}
