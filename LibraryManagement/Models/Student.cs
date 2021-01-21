using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }

        public Student(int? id, string name, string last,string birth)
        {
            StudentId = id;
            FirstName = name;
            LastName = last;
            DateofBirth = birth;
        }
    }
}
