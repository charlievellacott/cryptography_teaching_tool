using CryptographyTeachingTool.Cryptography;
using CryptographyTeachingTool.Cryptography.Hash;
using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.UI.Basic;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyTeachingTool.Login
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void SignInButtonClick(object sender, EventArgs e)
        {
            // This method takes the username and password, validates them,
            // hashes the password and calls the GetUser method in the UserRepo
            // to see if a user exists with these correct details.

            string username = usernameBox.Text;
            string inputPass = passwordBox.Text;
            if (username != "" && inputPass != "")
            {
                SHA256Hash SHA = new SHA256Hash();
                string hashedPass = SHA.Hash(inputPass);

                User currentUser = UserRepo.GetUser(username, hashedPass);
                if (currentUser == null)
                { 
                    // This branch is only reached if there is an issue with the database beyond the user's details being incorrect
                    // Messages for issues are displayed inside the GetUser method
                    passwordBox.Text = ""; // This resets the password box
                }
                else
                {
                    GeneralDashboardForm dashboardForm = new GeneralDashboardForm(currentUser);
                    dashboardForm.Show();
                    this.Hide();
                }
                
            }
        }

        private void SignUpLabelClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // This method opens up the sign up window and hides the current login page

            SignUpForm signupForm = new SignUpForm(this);
            signupForm.Show();
            this.Hide();
        }

    }
}

