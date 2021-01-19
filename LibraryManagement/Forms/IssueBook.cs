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
        ///Load student ids into the id combo box.
        ///Sets the due date to 10 days from today. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IssueBook_Load(object sender, EventArgs e)
        {
            BookHelper.LoadActive(dgvIssueBook);
            //TODO: load student ids into the id combobox.
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

    }
}
