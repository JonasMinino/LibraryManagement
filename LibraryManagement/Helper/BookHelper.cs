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
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (Title, Author, Publisher, Year, ISBN, Type, Copies, Checkedout) VALUES(@title, @author,@publisher, @year, @isbn, @type, @copies, @available, @over)", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@type", book.Type);
                cmd.Parameters.AddWithValue("@copies", book.NumberOfCopies);
                cmd.Parameters.AddWithValue("@available", book.Available);
                cmd.Parameters.AddWithValue("@over", book.Overdue);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Retrieves the data from the books table and displays it in the data grid view.
        /// Changes the background color of the available and overdue cells  if they are 0 or overdue. 
        /// Bolds the text of the checkout cell. 
        /// </summary>
        /// <param name="dgv"></param>
        public static void CurrentBooksData(DataGridView dgv)
        {
            using(con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT BookId,Title,Author,Publisher,Year,ISBN,Type,Copies,Available FROM Books", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (int.Parse(row.Cells["Available"].Value.ToString()) > 0)
                    {
                        row.Cells["Available"].Style.BackColor = Color.FromArgb(184, 244, 191);
                        row.Cells["Available"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells["Available"].Style.BackColor = Color.Salmon;
                        row.Cells["Available"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                }
            }
        }
        /// <summary>
        /// Checks if the current date is higher than the due date. 
        /// Changes the overdue value in the books table.
        /// </summary>
        private static void CheckDueDate()
        {
            
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Books SET Overdue=@over WHERE DueDate < @today", con);
                cmd.Parameters.AddWithValue("@over", "YES");
                cmd.Parameters.AddWithValue("today", DateTime.Today);
                cmd.ExecuteNonQuery();       
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
                SqlCommand cmd = new SqlCommand("UPDATE Books SET Title=@title, Author=@author, Publisher=@pub, Year=@year, ISBN=@isbn, Type=@type, Copies=@copies, Available=@available, Overdue=@overdue WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("@id", book.BookId);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@pub", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@type", book.Type);
                cmd.Parameters.AddWithValue("@copies", book.NumberOfCopies);
                cmd.Parameters.AddWithValue("@available", book.Available);
                cmd.Parameters.AddWithValue("@overdue", book.Overdue);
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
        /// <summary>
        /// Returns a list of ids in the Books table.
        /// </summary>
        /// <returns></returns>
        public static List<int> GetIdList()
        {
            List<int> list = new List<int>();

            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows) while (rdr.Read()){ list.Add(int.Parse(rdr["BookId"].ToString())); }
                }
            }
            return list;
        }
        /// <summary>
        /// Loads the active books that haven't been checked out into a data grid view. 
        /// </summary>
        /// <param name="dgv"></param>
        public static void LoadActive(DataGridView dgv)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT BookId,Title,Author,Publisher,Year,ISBN,Type,Copies,Available FROM Books WHERE Available>@value", con);
                cmd.Parameters.AddWithValue("value", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (int.Parse(row.Cells["Available"].Value.ToString()) > 0)
                    {
                        row.Cells["Available"].Style.BackColor = Color.FromArgb(184, 244, 191);
                        row.Cells["Available"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }                    
                }
            }
        }
        /// <summary>
        /// Adds a book into the issued book table
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static int IssueBook(IssuedBook book)
        {
            using(con =new SqlConnection(conString))
            {
                //Adds a book to the issued books table//
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO IssuedBooks (StudentId, StudentName, title, Author, DateIssued, DueDate, Overdue, Returned) VALUES(@sId, @sName, @title, @author, @date, @due, @over, @return)", con);
                cmd.Parameters.AddWithValue("@sid", book.StudentId);
                cmd.Parameters.AddWithValue("@sName", book.StudentName);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@date", book.DateIssued);
                cmd.Parameters.AddWithValue("@due", book.DueDate);
                cmd.Parameters.AddWithValue("@over", book.Overdue);
                cmd.Parameters.AddWithValue("@return", book.Returned);
                cmd.ExecuteNonQuery();

                //Updates the available value in the books table//
                cmd.CommandText = "UPDATE Books SET Available=@ava, DueDate=@due Where BookId=@id";
                cmd.Parameters.AddWithValue("ava", book.Available);
                cmd.Parameters.AddWithValue("id", CurrentId);

                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Gets the available copies of the record from the books table. 
        /// </summary>
        /// <param name="copies"></param>
        /// <returns></returns>
        public static int GetAvailable(int copies)
        {
            int ava = 0;
            using(con=new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE BookId=@current", con);
                cmd.Parameters.AddWithValue("current", CurrentId);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows) while (rdr.Read()) { ava = copies - int.Parse(rdr["Available"].ToString()); }
                }
            }
            return ava;
        }
        /// <summary>
        /// Gets the overdue value of the a specific record in the books table. 
        /// </summary>
        /// <returns></returns>
        public static string GetOverdue()
        {
            string over = "";
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("id", CurrentId);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows) while (rdr.Read()) { over = rdr["Overdue"].ToString(); }
                }
            }
            return over;
        }
        /// <summary>
        /// Returns the due date from a specific record in the book table. 
        /// </summary>
        /// <returns></returns>
        public static string GetDueDate()
        {
            string due = "";
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("id", CurrentId);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows) while (rdr.Read()) { due = rdr["DueDate"].ToString(); }
                }
            }
            return due;
        }
        /// <summary>
        /// Loads the books from the issued books table into a specific data grid view. 
        /// Changes the overdue value to yes if the due date is less than today's date.
        /// Formats the overdue cell with red or green background depending on the value. 
        /// </summary>
        /// <param name="dgv"></param>
        public static void LoadIssuedBooks(DataGridView dgv)
        {
            using(con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM IssuedBooks WHERE Returned=@return", con);
                cmd.Parameters.AddWithValue("return", 0);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if(DateTime.Parse(row.Cells["DueDate"].Value.ToString()) < DateTime.Today)
                    {
                        row.Cells["Overdue"].Value = "YES";
                    }

                    if (row.Cells["Overdue"].Value.ToString()=="NO")
                    {
                        row.Cells["Overdue"].Style.BackColor = Color.FromArgb(184, 244, 191);
                        row.Cells["Overdue"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells["Overdue"].Style.BackColor = Color.Salmon;
                        row.Cells["Overdue"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                    }
                }
            }

        }
        /// <summary>
        /// Updates the return value of Issued Books table.
        /// Reloads the issued books table.
        /// Updates the available value in the Books table. 
        /// </summary>
        /// <param name="bookId"></param>
        public static void ReturnBook(int bookId)
        {
            int available = 0;
            using(con= new SqlConnection(conString))
            {
                //Sets the returned value to 1//
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE IssuedBooks SET Returned=@ret", con);
                cmd.Parameters.AddWithValue("ret", 1);
                cmd.ExecuteNonQuery();

                //Gets the available value from the Books table//
                cmd.CommandText = "Select * FROM Books WHERE BookId=@id";
                cmd.Parameters.AddWithValue("id", bookId);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.HasRows) while (rdr.Read()) { available = int.Parse(rdr["Avaialable"].ToString()); }
                }

                //Adds 1 to avaiable and updates the Books table.//
                available++;
                cmd.CommandText = "UPDATE Books SET Available=@ava WHERE BookId=@id";
                cmd.Parameters.AddWithValue("ava", available);
                cmd.ExecuteNonQuery();

                //Reload the Return Book data grid view.//
                ReturnBook rb = new ReturnBook();
                LoadIssuedBooks(rb.dgvViewIssuedBooks);
            }

        }


    }
}
