using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using CryptographyTeachingTool;
using CryptographyTeachingTool.Cryptography;
using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.Cryptography.Hash;

namespace CryptographyTeachingTool.Login
{
    public partial class SignUpForm : Form
    {
        private LoginForm loginSender;

        private int NUMBER_LOWER_LIMIT = 48;
        private int NUMBER_UPPER_LIMIT = 57;
        private int UPPERCASE_LOWER_LIMIT = 65;
        private int UPPERCASE_UPPER_LIMIT = 90;
        private int LOWERCASE_LOWER_LIMIT = 97;
        private int LOWERCASE_UPPER_LIMIT = 122;

        private int MIN_PASS_LENGTH = 8;
        private int MIN_UPPER_COUNT = 1;
        private int MIN_LOWER_COUNT = 1;
        private int MIN_NUMB_COUNT = 1;
        private int MIN_SPECIAL_COUNT = 1;

        public SignUpForm(LoginForm loginForm)
        {
            loginSender = loginForm;
            InitializeComponent();
            this.FormClosed += OnFormClosed; // this ensures that if the form is closed via the red cross the login page is returned to
        }

        private void OnFormClosed(object? sender, FormClosedEventArgs e)
        {
            loginSender.Show();
        }

        private void SignUpButtonClick(object sender, EventArgs e)
        {
            // This method takes all the user's input, validates it
            // (including calling the UserExists method as part of the
            // UserRepo class to check the username is unique) and then if suitable
            // an entry to the Users database is created with the added details.
            // Note the password is also validated as part of this window.

            string fname = firstnameBox.Text;
            string sname = surnameBox.Text;
            string uname = usernameBox.Text;
            SHA256Hash SHA = new SHA256Hash();
            string hashedPass = SHA.Hash(Password.Text);
            string role = roleSelect.Text;

            // validation
            bool isValid = true;

            int upperCount = 0;
            int lowerCount = 0;
            int numbCount = 0;
            int specialCount = 0;
            foreach (char c in Password.Text) // This counts and checks each character to ensures that each password meets the correct criterion 
            {
                if (Convert.ToInt16(c) >= NUMBER_LOWER_LIMIT && Convert.ToInt16(c) <= NUMBER_UPPER_LIMIT)
                {
                    numbCount++;
                }
                else if (Convert.ToInt16(c) >= UPPERCASE_LOWER_LIMIT && Convert.ToInt16(c) <= UPPERCASE_UPPER_LIMIT)
                {
                    upperCount++;
                }
                else if (Convert.ToInt16(c) >= LOWERCASE_LOWER_LIMIT && Convert.ToInt16(c) <= LOWERCASE_UPPER_LIMIT)
                {
                    lowerCount++;
                }
                else
                {
                    specialCount++;
                }
            }

            if (fname == "" || sname == "" || uname == "" || Password.Text == "")
            {
                MessageBox.Show("Please fill in all details before submitting, none should be blank.");
                isValid = false;
            }
            // If the counts do no match the criterion then the data is not stored and a message is displayed explaining why
            else if (Password.Text.Length < MIN_PASS_LENGTH) { MessageBox.Show("Your password must be at least 8 characters in length"); isValid = false; }
            else if (upperCount < MIN_UPPER_COUNT) { MessageBox.Show("Your password must have an uppercase letter in"); isValid = false; }
            else if (lowerCount < MIN_LOWER_COUNT) { MessageBox.Show("Your password must have a lowercase letter in"); isValid = false; }
            else if (numbCount < MIN_NUMB_COUNT) { MessageBox.Show("Your password must have a number in"); isValid = false; }
            else if (specialCount < MIN_SPECIAL_COUNT) { MessageBox.Show("Your password must have a special character in"); isValid = false; }

            // storing the data
            if (isValid)
            {
                if (!UserRepo.UserExists(uname))
                {
                    if (UserRepo.CreateUser(uname, hashedPass, fname, sname, role)) // this returns true if the user has been sucessfully created
                    {                                                               // any errors are displayed as part of the CreateUser method
                        loginSender.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("The username you have entered is already in use");
                }
            }
        }
    }
}

