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
            BookHelper.ReturnBook(int.Parse(dgvViewIssuedBooks.CurrentRow.Cells["BookId"].Value.ToString()));
        }
    }
}
