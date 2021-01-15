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
        /// Gives a choice to add a second copy to the records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
