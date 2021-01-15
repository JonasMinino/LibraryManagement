using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using LibraryManagement.Models;
using LibraryManagement.Helper;

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
        /// <summary>
        /// Shows a warning message if any of the three textboxes is missing. 
        /// Checks if the username entered is already in use. 
        /// Checks if the email entered is already in use. 
        /// Enters a new user into the login table. 
        /// Displays a message if the user was successfully added.
        /// Closes the signup form and opens a the login form after the succesful addition of a user. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {            
            if (txtBxUserName.Text=="Username" || txtBxPassword.Text=="Password" || txtBxEmail.Text=="Email") MessageBox.Show("All fields must be entered in order to sign up.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                User user = new User(0, txtBxUserName.Text, txtBxPassword.Text, txtBxEmail.Text);

                if (!LoginHelper.ValidateUser(txtBxUserName.Text)) MessageBox.Show("Username is already in use.", "Username Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!LoginHelper.ValidateEmail(txtBxEmail.Text)) MessageBox.Show("Email is already in use.", "Email Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    if (LoginHelper.InsertUser(user) > 0)
                    {  MessageBox.Show("A new account was created", "New Account!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide(); (new Login()).ShowDialog(); this.Close();
                    }
                    
            }         
        }
    }
}
