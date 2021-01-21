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
        public int Available { get; set; }
        public string DueDate { get; set; }
        public string Overdue { get; set; }

        public Book(Nullable<int> id, string title, string author, string publisher, string year, string isbn, string type, int copies, int available, string due, string overdue)
        {
            BookId = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            Year = year;
            ISBN = isbn;
            Type = type;
            NumberOfCopies = copies;
            Available = available;
            DueDate = due;
            Overdue = overdue;            
        }


    }
}
