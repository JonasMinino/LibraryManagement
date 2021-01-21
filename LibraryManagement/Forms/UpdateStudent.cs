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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads the selected student information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            var dt = StudentHelper.GetSigleStudent();
            foreach(DataRow row in dt.Rows)
            {
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                dtpDOB.Value = DateTime.Parse(row["DateofBirth"].ToString());
            }
        }
    }
}
