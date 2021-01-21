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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }
        /// <summary>
        ///Loads active books into the data grid view. 
        ///Load selected student ids into the id combo box.
        ///Loads student names in the student name combo box.
        ///Sets the due date to 10 days from today. 
        ///Initializes the id combo box to index -1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IssueBook_Load(object sender, EventArgs e)
        {
            BookHelper.LoadActive(dgvIssueBook);
            StudentHelper.LoadNames(cmbStudentName);
            cmbId.SelectedIndex = -1;
            dtpDueDate.Value = dtpDueDate.Value.AddDays(10);

        }
        /// <summary>
        /// Reloads the data if the search bar is empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text=="") BookHelper.LoadActive(dgvIssueBook);
        }
        /// <summary>
        /// Displays the records that match the text in the search bar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BookHelper.SearchRecords(txtSearch.Text, dgvIssueBook);
        }
        /// <summary>
        /// Closes the Issue Book form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Issues the book to a specific student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIssue_Click(object sender, EventArgs e)
        {
            int available = int.Parse(dgvIssueBook.CurrentRow.Cells["Available"].Value.ToString());
            string title = dgvIssueBook.CurrentRow.Cells["Title"].Value.ToString();
            string student = cmbStudentName.SelectedItem.ToString();
            BookHelper.CurrentId = int.Parse(dgvIssueBook.CurrentRow.Cells["BookId"].Value.ToString());


            if ( available > 0)
            {
                available--;

                IssuedBook book = new IssuedBook(null, int.Parse(cmbId.SelectedItem.ToString()), int.Parse(dgvIssueBook.CurrentRow.Cells["BookId"].Value.ToString()), student , title , dgvIssueBook.CurrentRow.Cells["Author"].Value.ToString(), DateTime.Today.ToString("MM/dd/yyyy"), dtpDueDate.Value.ToString("MM/dd/yyyy"), int.Parse(dgvIssueBook.CurrentRow.Cells["Copies"].Value.ToString()), available, "NO", 0);

                if (BookHelper.IssueBook(book) > 0)
                {
                    DialogResult result = MessageBox.Show("A copy of " + title + " was issued to student: " + student, "Book Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        BookHelper.LoadActive(dgvIssueBook);
                        cmbId.SelectedIndex = -1;
                        cmbStudentName.SelectedIndex = -1;
                        dtpDueDate.Value = DateTime.Today.AddDays(10);
                    }
                }
            }
        }
        /// <summary>
        /// Populates the id combo box based on the name picked from the student name combo box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentName.SelectedIndex > -1)
                StudentHelper.LoadIds(cmbStudentName.SelectedItem.ToString(), cmbId);
        }
    }
}
