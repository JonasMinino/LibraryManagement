using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        public Nullable<int> BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string ISBN { get; set; }
        public string Type { get; set; }
        public int NumberOfCopies { get; set; }
        public string CheckedOut { get; set; }

        public Book(Nullable<int> id, string title, string author, string publisher, string year, string isbn, string type, int copies, string checkout)
        {
            BookId = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            Year = year;
            ISBN = isbn;
            Type = type;
            NumberOfCopies = copies;
            CheckedOut = checkout;            
        }


    }
}
