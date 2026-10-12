using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptographyTeachingTool.UI;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using CryptographyTeachingTool.UI.Basic;
using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.MainClasses;

namespace CryptographyTeachingTool.UI.Teacher
{
    public partial class SetAssignments : Form
    {
        private User currentUser;
        private TeachersDashboard teacherDash;

        public SetAssignments(User user, TeachersDashboard dash)
        {
            currentUser = user;
            teacherDash = dash;
            InitializeComponent();
        }

        private void AddStudentButtonClick(object sender, EventArgs e)
        {
            // This method adds the students username - as entered in the username box
            // - to the list of students that the assignment is to be set to

            try
            {
                string username = StudentNameText.Text;
                if (AssignmentRepo.CanAddToAssignment(username, StudentsList))
                {
                    StudentsList.Items.Add(username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }

        private void RemoveStudentButtonClick(object sender, EventArgs e)
        {
            // This method removes a student's username from the StudentsList
            // after validating to ensure that it does exist

            try
            {
                string username = StudentNameText.Text;
                if (StudentsList.Items.Contains(username))
                {
                    StudentsList.Items.Remove(username);
                }
                else
                {
                    MessageBox.Show("That student is not on the list");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }

        private void BrowseButtonClick(object sender, EventArgs e)
        {
            // This method opens a browsing menu for teachers to select their file easily.
            // It saves only the path.
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Title = "Select the assignments file";
                    // using varbinary allows for around 2gb to be stored on my dataframe
                    // therefore there is no need to filter the files.
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = dialog.FileName;
                        PathText.Text = path;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }

        private void AddAssignmentButtonClick(object sender, EventArgs e)
        {
            // This method validates and stores all assignment information, calling the 
            // CreateAssignment method from the AssignmentRepo to add the information to the database
            try
            {
                string[] users = StudentsList.Items.Cast<string>().ToArray();
                string title = TitleTextBox.Text;
                string path = PathText.Text;
                int userID = currentUser.userID;
                string name = Path.GetFileName(path); // this includes the '.extention'
                byte[] binFile;
                if (name.Length <= 0) // only reads the file if one is attached
                {
                    return;
                }
                else
                {
                    binFile = File.ReadAllBytes(path); // converts the selected file to bytes and stores it
                }
                int maxMarks = Convert.ToInt16(TotalMarks.Value);
                DateTime today = DateTime.Now;

                Assignment assignment = new Assignment(title, today, maxMarks, binFile, name);
                AssignmentRepo.CreateAssignment(currentUser, assignment, users);
                teacherDash.FetchAsignmentsSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
