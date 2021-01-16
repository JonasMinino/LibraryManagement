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
    public static class AddBookHelper
    {
        private static SqlConnection con;
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
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
            int id = 0;
            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE Title=@title AND Author=@author AND Publisher=@publisher, AND Year=@year)", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.Year);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) id = int.Parse(rdr["BookId"].ToString());
                rdr.Close();
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
    }
}
