using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class Login : Form
    {
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
    }
}
