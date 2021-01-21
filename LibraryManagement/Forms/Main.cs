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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Opens the Add New Book form if not opened already. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AddBook"]==null)(new AddBook()).ShowDialog();           
        }
        /// <summary>
        /// Opens a new View Books form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ViewBooks()).ShowDialog();
        }
        /// <summary>
        /// Opens the Issue Book form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new IssueBook()).ShowDialog();
        }
        /// <summary>
        /// Opens the Return Book form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ReturnBook()).ShowDialog();
        }
    }
}
