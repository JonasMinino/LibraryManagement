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
    }
}
