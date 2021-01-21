using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class IssuedBook
    {
        public int? IssueId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public string StudentName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
        public int Copies { get; set; }
        public int Available { get; set; }
        public string Overdue { get; set; }
        public int Returned { get; set; }

        public IssuedBook (int? issueId, int studentId, int bookId, string name, string title, string author, DateTime issuedDate, DateTime dueDate, int copies, int available, string overdue, int returned)
        {
            IssueId = issueId;
            StudentId = studentId;
            BookId = bookId;
            StudentName = name;
            Title = title;
            Author = author;
            DateIssued = issuedDate;
            DueDate = dueDate;
            Copies = copies;
            Available = available;
            Overdue = overdue;
            Returned = returned;
        }
    }
}
