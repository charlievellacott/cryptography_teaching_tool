using CryptographyTeachingTool.MainClasses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace CryptographyTeachingTool.Data.Repositories
{
    class AssignmentRepo : DataClasses
    {
        /// <summary>
        /// This repository class will have the greatest number of methods, it will be used to modularise 
        /// and abstract the process of creating assignments, uploading and downloading files, 
        /// uploading marks and getting the average time spent by users on the application.
        /// </summary>

        static public List<Assignment> GetAssignmentsForTeacher(User currentUser)
        {
            // This static method is used to obtain, create and return a list of assignments that have been set by the current teacher.
            // The assignments will then be displayed on the teacher's dashboard.
            List<Assignment> allAssignments = new List<Assignment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = $"SELECT Title, DateSet, TotalMarks FROM DefinedAssignments WHERE TeacherID = @teacherID ORDER BY DateSet DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@teacherID", currentUser.userID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader.GetString(reader.GetOrdinal("Title"));
                                DateTime dateSet = reader.GetDateTime(reader.GetOrdinal("DateSet"));
                                int totalMarks = reader.GetInt32(reader.GetOrdinal("TotalMarks"));

                                Assignment assignment = new Assignment(title, dateSet, totalMarks);
                                allAssignments.Add(assignment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
            return allAssignments;
        }

        static public List<Assignment> GetAssignmentsForStudent(User currentUser)
        {
            // This static method is used to obtain, create and return a list of assignments that have been set for the current student.
            // The assignments will then be displayed on the student's assignment viewer page.
            List<Assignment> allAssignments = new List<Assignment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    // where user id matches get teacher fname . surname set by, date, TotalMarks
                    string query = $"SELECT DefinedAssignments.Title, DefinedAssignments.DateSet, DefinedAssignments.TotalMarks, DefinedAssignments.AssignmentID, Users.Firstname, Users.Surname " +
                        $"FROM DefinedAssignments " +
                        $"INNER JOIN Users ON DefinedAssignments.TeacherID = Users.UserID " +
                        $"INNER JOIN LinkedAssignments ON LinkedAssignments.AssignmentID = DefinedAssignments.AssignmentID " +
                        $"WHERE LinkedAssignments.UserID = @userID " +
                        $"ORDER BY DateSet";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userID", currentUser.userID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader.GetString(reader.GetOrdinal("Title"));
                                DateTime dateSet = reader.GetDateTime(reader.GetOrdinal("DateSet"));
                                int totalMarks = reader.GetInt32(reader.GetOrdinal("TotalMarks"));
                                string firstname = reader.GetString(reader.GetOrdinal("Firstname"));
                                string surname = reader.GetString(reader.GetOrdinal("Surname"));
                                int assignmentID = reader.GetInt32(reader.GetOrdinal("AssignmentID"));

                                Assignment assignment = new Assignment(title, dateSet, totalMarks, firstname, surname, assignmentID);
                                allAssignments.Add(assignment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
            return allAssignments;
        }

        static public List<Assignment> GetResults(User currentUser)
        {
            // This static method is used to obtain, create and return a list of all assignments set by the current teacher
            // and their results.
            List<Assignment> allAssignments = new List<Assignment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = $"SELECT Mark, DefinedAssignments.Title, DefinedAssignments.DateSet, Users.Firstname, Users.Surname, DefinedAssignments.TotalMarks " +
                        "FROM LinkedAssignments " +
                        "INNER JOIN Users ON Users.UserID = LinkedAssignments.UserID " +
                        "INNER JOIN DefinedAssignments ON DefinedAssignments.AssignmentID = LinkedAssignments.AssignmentID " +
                        "WHERE DefinedAssignments.TeacherID = @teacherid AND Mark IS NOT NULL " +
                        "ORDER BY DefinedAssignments.DateSet";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@teacherid", currentUser.userID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string title = reader.GetString(reader.GetOrdinal("Title"));
                                DateTime dateSet = reader.GetDateTime(reader.GetOrdinal("DateSet"));
                                int actualMarks = reader.GetInt32(reader.GetOrdinal("Mark"));
                                int totalMarks = reader.GetInt32(reader.GetOrdinal("TotalMarks"));
                                string fullname = $"{reader.GetString(reader.GetOrdinal("Firstname"))} {reader.GetString(reader.GetOrdinal("Surname"))}";

                                Assignment assignment = new Assignment(title, dateSet, totalMarks, actualMarks, fullname);
                                allAssignments.Add(assignment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
            return allAssignments;
        }

        static public void CreateAssignment(User currentUser, Assignment assignment, string[] users)
        {
            // This static method is used to create an entry to the Assignments table, thus creating an assignment
            // for the current teacher. Along with storing the appropriate data it also assigns the assignment to all necessary students.
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING)) // uploads the asignment data for both tables
                {
                    int assignmentID = -1;
                    connection.Open();
                    string query = "INSERT INTO DefinedAssignments (TeacherID, Title, DateSet, OriginalFile, TotalMarks, FileName) " +
                        "VALUES (@userID, @title, @today, @binFile, @maxMarks, @filename); " +
                        "SELECT CAST(SCOPE_IDENTITY() as int);"; // this is a simple way of getting the assignmentID instead of requerying
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userID", currentUser.userID);
                        command.Parameters.AddWithValue("@title", assignment.title);
                        command.Parameters.AddWithValue("@today", assignment.dateSet);
                        command.Parameters.AddWithValue("@binFile", assignment.binFile);
                        command.Parameters.AddWithValue("@maxMarks", assignment.totalMarks);
                        command.Parameters.AddWithValue("@filename", assignment.fileName);
                        assignmentID = Convert.ToInt32(command.ExecuteScalar()); // the execute scalar acts as the execute non query in this case
                    }

                    int[] IDs = new int[users.Length];
                    for (int i = 0; i < users.Length; i++)
                    {
                        // This loop goes through all of the associated users
                        // and creates a link between the assignment and them
                        string user = users[i];
                        query = $"SELECT UserID FROM Users WHERE Username = @user";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@user", user);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    IDs[i] = reader.GetInt32(0);
                                }
                                else
                                {
                                    MessageBox.Show($"Could not find {user}");
                                }
                            }
                        }
                    }

                    query = "INSERT INTO LinkedAssignments (AssignmentID, UserID) " +
                        "VALUES (@assignmentID, @userID)";
                    foreach (int id in IDs)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@assignmentID", assignmentID);
                            command.Parameters.AddWithValue("@userID", id);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (assignmentID <= 0)
                    {
                        MessageBox.Show("Assignment setting failed - could not obtain AssignmentID.");
                    }
                    else
                    {
                        MessageBox.Show("Assignment set.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
        }

        static public void UpdateMarks(int marks, int uID)
        {
            // This static method is used to update the Marks field of the LinkedAssignments table,
            // thus allowing a student to share their marks with their teacher.
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = $"UPDATE LinkedAssignments SET Mark = @marks WHERE assignmentID = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@marks", marks);
                    command.Parameters.AddWithValue("@id", uID);
                    command.ExecuteNonQuery();
                }
            }
        }

        static public bool CanAddToAssignment(string username, ListBox StudentsList)
        {
            // This static method is used to validate each username added to the list of people
            // an assignment is to be set to. It validates them to ensure that their username
            // exists, is a student rather than a teacher and has not already been added.
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = $"SELECT Role FROM Users WHERE Username = '{username}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetString(0) != "Student")
                                {
                                    MessageBox.Show("This is a teacher - you cannot set assignments to your teacher!");
                                }
                                else if (StudentsList.Items.Contains(username))
                                {
                                    MessageBox.Show("This student is already on the list.");
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("This username cannot be found please check it before trying again.");
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return false;
            }
        }

        static public void DownloadFile(int assignmentID)
        {
            // This static method is used to save the file uploaded by a teacher to an assignment.
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                string query = $"SELECT OriginalFile, FileName FROM DefinedAssignments " +
                    $"WHERE DefinedAssignments.AssignmentID = @ID ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", assignmentID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] fileBytes = (byte[])reader["OriginalFile"]; // gets a byte array of the file
                            string filename = reader.GetString(1);
                            string downloadPath = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                                "Downloads", filename); // this finds the users profile path then append the
                                                        // dowloads folder and file name onto the string
                            File.WriteAllBytes(downloadPath, fileBytes);
                            MessageBox.Show("Sucessfully saved to your downloads folder.");
                        }
                    }
                }
            }

        }
    }
}
