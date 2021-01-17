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
    public partial class UpdateBook : Form
    {
        public UpdateBook()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads the fields from the selected record. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBook_Load(object sender, EventArgs e)
        {
            DataTable dt = BookHelper.GetSingleRow(BookHelper.CurrentId);
            foreach(DataRow row in dt.Rows)
            {
                txtTitle.Text = row["Title"].ToString();
                txtAuthor.Text = row["Author"].ToString();
                txtPublisher.Text = row["Publisher"].ToString();
                txtYear.Text = row["Year"].ToString();
                txtISBN.Text = row["ISBN"].ToString();
                cmbCheckedOut.SelectedIndex = cmbCheckedOut.FindStringExact(row["Checkedout"].ToString());
                cmbType.SelectedIndex = cmbType.FindStringExact(row["Type"].ToString());
            }
        }
        /// <summary>
        /// Closes the Update Book form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
