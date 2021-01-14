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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes signup form and opens login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide(); (new Login()).ShowDialog(); this.Close();
        }
        /// <summary>
        /// Clears the username placeholder if no username has been entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxUserName_Enter(object sender, EventArgs e)
        {
            if (txtBxUserName.Text == "Username") txtBxUserName.Clear();
        }
        /// <summary>
        /// Rewrites the username placeholder if no username has been entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxUserName_Leave(object sender, EventArgs e)
        {
            if (txtBxUserName.Text == "") txtBxUserName.Text = "Username";
        }
        /// <summary>
        /// Clears the password placeholder if no password has been entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxPassword_Enter(object sender, EventArgs e)
        {
            if (txtBxPassword.Text == "Password") txtBxPassword.Clear();
        }
        /// <summary>
        /// Rewrites the password placeholder if no password has been entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxPassword_Leave(object sender, EventArgs e)
        {
            if (txtBxPassword.Text == "") txtBxPassword.Text = "Password";
        }
        /// <summary>
        /// Clears the email placeholder if no email has been entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxEmail_Enter(object sender, EventArgs e)
        {
            if (txtBxEmail.Text == "Email") txtBxEmail.Clear();
        }
        /// <summary>
        /// Rewrites the email placeholder if no email has been entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxEmail_Leave(object sender, EventArgs e)
        {
            if (txtBxEmail.Text == "") txtBxEmail.Text = "Email";
        }
    }
}
