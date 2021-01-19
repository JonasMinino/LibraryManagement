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
