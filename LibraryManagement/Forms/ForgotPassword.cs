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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Closes the forgot password form and opens the login form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide(); (new Login()).ShowDialog(); this.Close();
        }
        /// <summary>
        /// Checks if the username and email textboxes are empty. 
        /// Veryfies that there is a user with the given username and email.
        /// Writes the user's password in the answer  textbox if a match is found. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Username" || txtEmail.Text == "Email") MessageBox.Show("Please enter a Username and Email", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!LoginHelper.ValidateCredentials(txtUserName.Text, txtEmail.Text)) MessageBox.Show("Are you sure you have the right Username and Email?", "No Match found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    txtAnswer.Text = "Your password is: " + LoginHelper.GetPassword(txtUserName.Text, txtEmail.Text);
            }
        }
        /// <summary>
        /// Clears the placeholder on entering the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Username") txtUserName.Clear();
        }
        /// <summary>
        /// Rewrites the username placeholder if the textbox is empty. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "") txtUserName.Text = "Username";
        }
        /// <summary>
        /// Clears the email placeholder on enter. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email") txtEmail.Clear();
        }
        /// <summary>
        /// Rewrites the email placeholder if no email was entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "") txtEmail.Text = "Email";
        }
    }
}
