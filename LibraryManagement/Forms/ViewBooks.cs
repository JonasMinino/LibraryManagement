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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads data into the data grid view. 
        /// Changes the background color of the checkedout cell if the book is checkedout or not. 
        /// Bolds the text of the checkout cell. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewBooks_Load(object sender, EventArgs e)
        {
            BookHelper.CurrentBooksData(dgvViewBooks); 
        }
        /// <summary>
        /// Closes the current form and opens the Add Book Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide(); (new AddBook()).ShowDialog(); this.Close();
        }
        /// <summary>
        /// Changes the value of the current id variable.
        /// Opens the Update Book Form.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BookHelper.CurrentId = int.Parse(dgvViewBooks.CurrentRow.Cells["BookId"].Value.ToString());
            (new UpdateBook()).ShowDialog();
        }
    }
}
