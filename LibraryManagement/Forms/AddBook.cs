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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the add book form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Checks for missing needed information from the textboxes. 
        /// Checks if there is already a duplicate copy of the book.
        /// Adds a the new record if there is none.
        /// Gives a choice to add a second copy to the same record.
        /// Displays a message that a new record or second copy has been added. 
        /// Clears the fields after a new record is added.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checks if Title and Author fields are empty.//
            if (txtTitle.Text == "" || txtAuthor.Text == "") MessageBox.Show("Are you mising the Title, or Author?", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Book book = new Book(null, txtTitle.Text, txtAuthor.Text, txtPublisher.Text, txtYear.Text.ToString(), txtISBN.Text, cbxType.Text, 1, "NO");

                //Checks if there is a record with the same Title, Author, and Publisher.//
                if (BookHelper.ValidateBook(book))
                {
                    DialogResult result = MessageBox.Show("There is already a copy of a book with the same Title, Author, Publisher, and Year. Are you entering another copy?", "Duplicate Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes) if (BookHelper.AddCopy(BookHelper.GetBookId(book)) > 0)
                        {
                            DialogResult res = MessageBox.Show("You have added another copy of: " + txtTitle.Text + " by: " + txtAuthor.Text, "Successfuly Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Clears all fields after clicking ok.//
                            if (res == DialogResult.OK)
                            {
                                txtAuthor.Clear();
                                txtTitle.Clear();
                                txtYear.Clear();
                                txtPublisher.Clear();
                                txtISBN.Clear();
                                cbxType.SelectedIndex = -1;
                            }                            
                        }
                }
                else {//Message showing that a new record was added.//
                    if (BookHelper.InsertBook(book) > 0) 
                    {
                        DialogResult result = MessageBox.Show("A new book record has been added.", "Record Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        //Clears all fields after clicking ok.//
                        if(result == DialogResult.OK)
                        {
                            txtAuthor.Clear();
                            txtTitle.Clear();
                            txtYear.Clear();
                            txtPublisher.Clear();
                            txtISBN.Clear();
                            cbxType.SelectedIndex = -1;
                        }
                    }
                }
            }
        }
    }
}
