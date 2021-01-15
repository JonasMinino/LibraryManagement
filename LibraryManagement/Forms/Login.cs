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
using LibraryManagement.Forms;

namespace LibraryManagement
{
    public partial class Login : Form
    {
        private string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        SqlConnection con;
        public virtual string PlaceHolder { get; set; }
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Changes the username placeholder to empty if no username has been entered. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void txtBxUserName_Enter(object sender, EventArgs e)
        {
            if(txtBxUserName.Text=="Username") txtBxUserName.Text = "";
        }
        /// <summary>
        /// Changes the password placeholder to empty if no password has been entered. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxPassword_Enter(object sender, EventArgs e)
        {
            if (txtBxPassword.Text == "Password") txtBxPassword.Text = "";
        }
        /// <summary>
        /// Adds the username placeholder if there is no text in the username textbox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxUserName_Leave(object sender, EventArgs e)
        {
            if (txtBxUserName.Text == "") txtBxUserName.Text = "Username";
        }
        /// <summary>
        /// Adds the password placeholder if there is no text in the password textbox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBxPassword_Leave(object sender, EventArgs e)
        {
            if (txtBxPassword.Text == "") txtBxPassword.Text = "Password";
        }
        /// <summary>
        /// Checks for a username and password match against the login table. 
        /// Returns a warning message if no match is found. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtBxUserName.Text;
            string pass = txtBxPassword.Text;

            using (con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Select * from Login Where Username=@user and Password=@pass", con);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

                using(SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.HasRows)
                    {
                        this.Hide(); (new Main()).ShowDialog(); this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There was no match with thats Username and Password", "Unmatched", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
        }
        /// <summary>
        /// Opens the sign up 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide(); (new SignUp()).ShowDialog(); this.Close();
        }
        /// <summary>
        /// Opens the forgot password form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
