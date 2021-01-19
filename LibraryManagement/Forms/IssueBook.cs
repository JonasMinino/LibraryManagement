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
        /// Loads the book ids into the id combo box.
        /// Sets the due date to 10 days from today. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IssueBook_Load(object sender, EventArgs e)
        {
            cmbBookId.DataSource = BookHelper.GetIdList().ToArray();
            dtpDueDate.Value = dtpDueDate.Value.AddDays(10);
        }
    }
}
