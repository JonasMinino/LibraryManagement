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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads issued books into the data grid view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            BookHelper.LoadIssuedBooks(dgvViewIssuedBooks);
        }
        /// <summary>
        /// Closes the return book form//
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Updates the Books and Issued books table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
           if(BookHelper.ReturnBook(int.Parse(dgvViewIssuedBooks.CurrentRow.Cells["BookId"].Value.ToString()))>0)
            {
                BookHelper.LoadIssuedBooks(dgvViewIssuedBooks);
            }
        }
        /// <summary>
        /// Reloads the data grid view when search textbox is empty. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text)) BookHelper.LoadIssuedBooks(dgvViewIssuedBooks);
        }
        /// <summary>
        /// Populates the data grid view with records matching the search term.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BookHelper.SearchIssuedBooks(txtSearch.Text, dgvViewIssuedBooks);
        }
    }
}
