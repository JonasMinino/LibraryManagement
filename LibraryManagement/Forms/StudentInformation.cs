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
    public partial class StudentInformation : Form
    {
        public StudentInformation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the Student Information form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Loads the current students from the Student table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentInformation_Load(object sender, EventArgs e)
        {
            StudentHelper.LoadStudents(dgvStudents);
        }
        /// <summary>
        /// Opens the add student form.
        ///Closes the current form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide(); (new AddStudent()).ShowDialog(); this.Close();
        }
        /// <summary>
        /// Opens the update student form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentHelper.currentId = int.Parse(dgvStudents.CurrentRow.Cells["StudentId"].Value.ToString());
            (new UpdateStudent()).ShowDialog();
        }
       
    }
}
