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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads the selected student information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            var dt = StudentHelper.GetSigleStudent();
            foreach(DataRow row in dt.Rows)
            {
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                dtpDOB.Value = DateTime.Parse(row["DateofBirth"].ToString());
            }
        }
        /// <summary>
        /// Closes the Update Student Form//
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Updates a single student record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student(null, txtFirstName.Text, txtLastName.Text, dtpDOB.Value.ToString("MM/dd/yyyy"));
            if (!StudentHelper.ValidateStudent(student))
            {
                if (StudentHelper.UpdateStudent(student) > 0)
                {
                    DialogResult result = MessageBox.Show("The record for " + student.FirstName + " , " + student.LastName + " has been updated.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        StudentInformation si = (StudentInformation)Application.OpenForms["StudentInformation"];
                        StudentHelper.LoadStudents(si.dgvStudents);
                        this.Close();
                    }
                }
            }
        }
    }
}
