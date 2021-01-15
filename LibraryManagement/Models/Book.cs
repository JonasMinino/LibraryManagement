﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        private int? BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public int ISBN { get; set; }
        public string Type { get; set; }
        public int NumberOfCopies { get; set; }
        public int CheckedOut { get; set; }

        public Book(int? id, string title, string author, string publisher, string year, int isbn, string type, int copies, int checkout)
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