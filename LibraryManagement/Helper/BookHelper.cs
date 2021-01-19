using LibraryManagement.Forms;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManagement.Helper
{
    public static class BookHelper
    {
        private static SqlConnection con;
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public static int CurrentId = 0;
        /// <summary>
        /// Validates if there's a book record with the same title, author, publisher and year.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static bool ValidateBook(Book book)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE Title=@title AND Author=@author AND Publisher=@publisher AND Year=@year", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) return true;
                rdr.Close();
            }

            return false;
        }
        /// <summary>
        /// Returns the id of the duplicate book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static int GetBookId(Book book)
        {
            int id=0;
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE Title=@title AND Author=@author AND Publisher=@publisher AND Year=@year", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows) while (rdr.Read()) id = int.Parse(rdr["BookId"].ToString());
                }             

            }
            return id;
        }
        /// <summary>
        /// Adds a copy to a duplicate record. 
        /// </summary>
        /// <param name="id"></param>
        public static int AddCopy(int id)
        {
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Books SET Copies=Copies+1 WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Inserts a new record into the books table.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static int InsertBook(Book book)
        {
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (Title, Author, Publisher, Year, ISBN, Type, Copies, Checkedout) VALUES(@title, @author,@publisher, @year, @isbn, @type, @copies, @check)", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@type", book.Type);
                cmd.Parameters.AddWithValue("@copies", book.NumberOfCopies);
                cmd.Parameters.AddWithValue("@check", book.CheckedOut);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Retrieves the data from the books table and displays it in the data grid view.
        /// Changes the background color of the checkedout cell if the book is checkedout or not. 
        /// Bolds the text of the checkout cell. 
        /// </summary>
        /// <param name="dgv"></param>
        public static void CurrentBooksData(DataGridView dgv)
        {
            using(con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["Checkedout"].Value.ToString() == "NO")
                    {
                        row.Cells["Checkedout"].Style.BackColor = Color.FromArgb(184, 244, 191);
                        row.Cells["Checkedout"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells["Checkedout"].Style.BackColor = Color.Salmon;
                        row.Cells["Checkedout"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                }

            }
        }
        /// <summary>
        /// Returns a single row of data based on a book id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetSingleRow(int id)
        {
            using (con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("@id", CurrentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// Updates a book record in the Books table. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateRecord(Book book)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Books SET Title=@title, Author=@author, Publisher=@pub, Year=@year, ISBN=@isbn, Type=@type, Copies=@copies, Checkedout=@check WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("@id", book.BookId);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@pub", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@type", book.Type);
                cmd.Parameters.AddWithValue("@copies", book.NumberOfCopies);
                cmd.Parameters.AddWithValue("@check", book.CheckedOut);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Deletes the record of the selected row from the books table by id.
        /// </summary>
        /// <param name="id"></param>
        public static int DeleteRecord()
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("@id", CurrentId);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Gets the list of titles, authors, publishers, and years from the books table. 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSourceList()
        {
            List<string> list = new List<string>();

            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Title, Author, Publisher, Year, ISBN FROM Books", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            list.Add(rdr["Title"].ToString());
                            list.Add(rdr["Author"].ToString());
                            list.Add(rdr["Publisher"].ToString());
                            list.Add(rdr["Year"].ToString());
                            list.Add(rdr["ISBN"].ToString());
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Finds rows based on a string and updates the Data Grid View. 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="dgv"></param>
        public static void SearchRecords(string search, DataGridView dgv)
        {
            using(con=new SqlConnection(conString))
            {
                con.Open();                
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE Title LIKE @search or Author LIKE @search or Publisher LIKE @search or  Year LIKE @search or ISBN LIKE @search", con);
                cmd.Parameters.AddWithValue("search", string.Format("%{0}%", search));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;                
            }

        }
    }
}
