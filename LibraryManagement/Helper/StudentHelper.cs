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
        public static int currentId = 0;
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
        /// <summary>
        /// Checks if a student is a duplicate in the Student table. 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static bool ValidateStudent(Student student)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE FirstName=@fName AND LastName=@lName AND DateofBirth=@dob", con);
                cmd.Parameters.AddWithValue("fName", student.FirstName);
                cmd.Parameters.AddWithValue("lName", student.LastName);
                cmd.Parameters.AddWithValue("dob", student.DateofBirth);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows) return true;
                }              
            }
            return false;
        }
        /// <summary>
        /// Adds a new student to the Student table. 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int AddStudent(Student student)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Student (FirstName, LastName, DateofBirth) VALUES(@first, @last, @dob)", con);
                cmd.Parameters.AddWithValue("first", student.FirstName);
                cmd.Parameters.AddWithValue("last", student.LastName);
                cmd.Parameters.AddWithValue("dob", student.DateofBirth);

                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Loads students from the Student table into a data grid view. 
        /// </summary>
        /// <param name="dgv"></param>
        public static void LoadStudents(DataGridView dgv)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
        /// <summary>
        /// Retrieves a single record from the Student table.  
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSigleStudent()
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE StudentId=@id", con);
                cmd.Parameters.AddWithValue("id", currentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// Updates a singe student's record in the Student table.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int UpdateStudent(Student student)
        {
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName=@first, LastName=@last, DateofBirth=@dob WHERE StudentId=@id", con);
                cmd.Parameters.AddWithValue("first", student.FirstName);
                cmd.Parameters.AddWithValue("last", student.LastName);
                cmd.Parameters.AddWithValue("dob", student.DateofBirth);
                cmd.Parameters.AddWithValue("id", currentId);
                return cmd.ExecuteNonQuery();
            }            
        }
        /// <summary>
        /// Deletes a single record from the Student table using the current id.
        /// </summary>
        /// <returns></returns>
        public static int DeleteRecord()
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE StudentId=@id", con);
                cmd.Parameters.AddWithValue("id", currentId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
