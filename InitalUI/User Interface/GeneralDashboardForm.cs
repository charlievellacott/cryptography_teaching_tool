using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.Login;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.UI;
using CryptographyTeachingTool.UI.Student;
using CryptographyTeachingTool.UI.Teacher;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyTeachingTool.UI.Basic
{
    public partial class GeneralDashboardForm : BaseFormsPage
    {
        // Base forms contains currentUserUser object
        public GeneralDashboardForm(User user) : base(user, false)
        {
            InitializeComponent();
            InitalizeHelpButton();
            if (currentUser.role == "Teacher") { TeacherDashboardbtn.Visible = true; AssignmentsButton.Visible = false; }
            else { TeacherDashboardbtn.Visible = false; AssignmentsButton.Visible = true; }
            WelcomeMessage.Text = $"Welcome, {currentUser.firstName}!";
            notUserTxt.Text = $"not {currentUser.firstName}?";
        }

        private void GeneralDashboardFormClosed(object sender, FormClosedEventArgs e)
        {
            currentUser.SignOut();
            Application.Exit();
        }

        // These following buttons are used for creating an instance of NavigationalPagesTemplate
        // and adding it to the screen. When the instance is created the appropraite level (eg GCSE)
        // is passed in as a parameter - along side the current user object.

        private void GCSEButtonClick(object sender, EventArgs e)
        {
            NavigationalPagesTemplate gcse = new NavigationalPagesTemplate(currentUser, "GCSE");
            gcse.Show();
            this.Hide();
        }

        private void AlevelButtonClick(object sender, EventArgs e)
        {
            NavigationalPagesTemplate alevel = new NavigationalPagesTemplate(currentUser, "ALEVEL");
            alevel.Show();
            this.Hide();
        }

        private void DemoButtonClick(object sender, EventArgs e)
        {
            NavigationalPagesTemplate demos = new NavigationalPagesTemplate(currentUser, "DEMOS");
            demos.Show();
            this.Hide();
        }

        private void FurtherButtonClick(object sender, EventArgs e)
        {
            NavigationalPagesTemplate further = new NavigationalPagesTemplate(currentUser, "FURTHER");
            further.Show();
            this.Hide();
        }

        private void TeacherDashboardButtonClick(object sender, EventArgs e)
        {
            TeachersDashboard tDash = new TeachersDashboard(currentUser);
            tDash.Show();
            this.Hide();
        }

        private void GeneralDashboardFormLoad(object sender, EventArgs e)
        {
            // This method queries for and renders the appropriate progress information 
            // of the current user into a progress bar

            int currentUserTotal = UserRepo.GetCurrentUserTotal(currentUser);
            int avgUserTotal = UserRepo.GetAvgUserTotal();

            progressBar.Maximum = Math.Max(avgUserTotal * 2, 1); // this is just incase when desigining the application there are no entries
            progressBar.Value = Math.Min(currentUserTotal, progressBar.Maximum); // this min statement is for the rare occasions when an individual is double the average

            userTime.Text = "Your time spent: " + currentUserTotal + "mins";
            avgTime.Text = "Average user time spent: " + avgUserTotal + "mins";

        }

        private void AssignmentsButtonClick(object sender, EventArgs e)
        {
            ViewAssignments assignments = new ViewAssignments(currentUser);
            assignments.Show();
        }

        private void SignOutButtonClick(object sender, EventArgs e)
        {
            // This method logs a user out - calling the SignOut method to 
            // add the signout time to the audit log

            currentUser.SignOut();
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
