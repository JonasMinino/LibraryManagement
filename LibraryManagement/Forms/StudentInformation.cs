using LibraryManagement.Helper;
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
    public partial class StudentInformation : Form
    {
        public StudentInformation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the Student Information form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Loads the current students from the Student table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentInformation_Load(object sender, EventArgs e)
        {
            StudentHelper.LoadStudents(dgvStudents);
        }
        /// <summary>
        /// Opens the add student form.
        ///Closes the current form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide(); (new AddStudent()).ShowDialog(); this.Close();
        }
        /// <summary>
        /// Opens the update student form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentHelper.currentId = int.Parse(dgvStudents.CurrentRow.Cells["StudentId"].Value.ToString());
            (new UpdateStudent()).ShowDialog();
        }
        /// <summary>
        /// Displays a warning.
        /// Deletes the selected record from the Student table. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            StudentHelper.currentId = int.Parse(dgvStudents.CurrentRow.Cells["StudentId"].Value.ToString());
            DialogResult result = MessageBox.Show("Are you sure you want to delete the record for: " + StudentHelper.currentId + " " + dgvStudents.CurrentRow.Cells["FirstName"].Value.ToString() + " , " + dgvStudents.CurrentRow.Cells["LastName"].Value.ToString() + "?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK) if (StudentHelper.DeleteRecord() > 0) StudentHelper.LoadStudents(dgvStudents);
        }
        /// <summary>
        /// Reloads the data grid view when the search bar is empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text)) StudentHelper.LoadStudents(dgvStudents);
        }
        /// <summary>
        /// Searches the student table for a specific term. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            StudentHelper.SearchStudent(txtSearch.Text, dgvStudents);
        }
    }
}
