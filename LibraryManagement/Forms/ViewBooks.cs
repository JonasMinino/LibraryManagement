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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewBooks_Load(object sender, EventArgs e)
        {
            BookHelper.CurrentBooksData(dgvViewBooks);
            AddAutoCompleteSource();
        }
        /// <summary>
        /// Adds the autocomplete source for the search textbox.
        /// </summary>
        private void AddAutoCompleteSource()
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(BookHelper.GetSourceList().ToArray());
            txtSearch.AutoCompleteCustomSource = source;
        }
        /// <summary>
        /// Closes the current form and opens the Add Book Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            (new AddBook()).ShowDialog(); 
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
        /// <summary>
        /// Asks the user if they are sure they want to delete the record. 
        /// Deletes the selected record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Gets the selected row id, title and author//
            BookHelper.CurrentId = int.Parse(dgvViewBooks.CurrentRow.Cells["BookId"].Value.ToString());
            string title = dgvViewBooks.CurrentRow.Cells["Title"].Value.ToString();
            string author = dgvViewBooks.CurrentRow.Cells["Author"].Value.ToString();

            //Asks the user if they are sure they want to delete the record.//
            DialogResult result = MessageBox.Show("Are you sure you want to delete " + title + " by: " + author +"?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //Deletes the record and updates the data grid view//
            if (result == DialogResult.Yes) if (BookHelper.DeleteRecord() > 0) BookHelper.CurrentBooksData(dgvViewBooks);           

        }
        /// <summary>
        /// Closes the current form//
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Refreshes the data grid view if there is no text in the search textbox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") BookHelper.CurrentBooksData(dgvViewBooks);
        }
    }
}
