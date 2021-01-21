using LibraryManagement.Helper;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the Add Student form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Checks if the student is already in the system.
        /// Sends a message if the student exits.
        /// Adds a new student to the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student(null, txtFirstName.Text, txtLastName.Text, dtpDOB.Value.ToString());
            if (StudentHelper.ValidateStudent(student)) MessageBox.Show("There's anothe student with duplicate information.", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else             
                if (StudentHelper.AddStudent(student) > 0) MessageBox.Show("The student: " + student.FirstName + " , " + student.LastName + " has been added.", "Student Added", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            
        }
    }
}
