using CryptographyTeachingTool.MainClasses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CryptographyTeachingTool.Data.Repositories
{
    class UserRepo : DataClasses
    {
        /// <summary>
        /// Instead of running queries on forms pages I will modularise the process 
        /// of querying the users table (on my database) through this class. 
        /// This will result in better encapsulation, code reuse and maintainability.
        /// </summary>
        
        static public User GetUser(string username, string hashedInput)
        {
            // This static method is used to return get a user's details from the database and
            // then return an instance of the User object with their details.

            // Note: when null is returned the result will be caught at a lower layer and processed accordingly.
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "SELECT HashedPass, UserID, Username, Firstname, Role FROM Users WHERE Username = @username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPass = reader.GetString(0);

                                if (hashedInput == hashedPass)
                                {
                                    int uID = reader.GetInt32(1);
                                    string uName = reader.GetString(2);
                                    string fName = reader.GetString(3);
                                    string role = reader.GetString(4);
                                    int loginTime = SaveLoginTime(uID);
                                    User currentUser = new User(uID, uName, fName, role, loginTime);
                                    return currentUser;
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username or Password.");
                                    return null; 
                                }
                            // Note: when null is returned the result will be caught at a lower layer and processed accordingly.
                            }
                            else
                            {
                                MessageBox.Show("There is no account with this username please sign up first.");
                                return null;
                            }

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Note: when null is returned the result will be caught at a lower layer and processed accordingly.
                if (ex.Number == 40 || ex.Number == 53 || ex.Number == -1 || ex.Number == -2 || ex.Number == 2)
                {
                    MessageBox.Show($"Our database could not be reached - please check your internet and try again.");
                    return null; 
                }
                else
                {
                    MessageBox.Show($"A database related error has occured: \n{ex.Message}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return null;
            }
        }

        static public void SignOut(int userID, int loginID)
        {
            // This method is called whenever a forms page that inherits from the BaseFormsPage closes.
            // It adds a log-out time to the row associated with the user's current log-in.

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "UPDATE AuditLog SET LogoutTime = @logoutTime WHERE LogoutTime is NULL and LoginID = @loginID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uID", userID);
                        command.Parameters.AddWithValue("@loginID", loginID);
                        command.Parameters.AddWithValue("@logoutTime", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
        }
        
        static public bool UserExists(string username)
        {
            // This static method is used to check for a username in the Users table, if it exists it returns True and otherwise False
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "SELECT Username FROM Users WHERE Username = @uname;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uname", username);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            { return true; }
                            else
                            { return false; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return false;
            }
        }
        
        static public bool CreateUser(string username, string hashedPassword, string firstname, string secondname, string role)
        {
            // This method is used to create an entry to the Users table with the required information passed in as arguments.
            // It returns True if the result was a success
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, HashedPass, Firstname, Surname, Role)" +
                        "VALUES (@uname, @pword, @fname, @sname, @role);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@uname", username);
                            command.Parameters.AddWithValue("@pword", hashedPassword);
                            command.Parameters.AddWithValue("@fname", firstname);
                            command.Parameters.AddWithValue("@sname", secondname);
                            command.Parameters.AddWithValue("@role", role);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Thank you for signing up, please now log in to continue");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"There has been an error, please try again soon:\n{ex.Message}");
                            return false;
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 40)
                {
                    MessageBox.Show($"Our database could not be reached - please check your internet a try again.");
                    return false;
                }
                else
                {
                    MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return false;
            }
        }
        
        static private int SaveLoginTime(int userID)
        {
            // This method is used to create an inital entrance to the LoginAudit table, which saves the time a specific user logs-in.
            // The SignOut method in the User object is used to add the log-out time to this entry.
            DateTime dateTime = DateTime.Now;
            int loginID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "INSERT INTO AuditLog(UserID, LoginTime) Values(@uID, @time);" +
                    "SELECT CAST(SCOPE_IDENTITY() as int);"; // this is a simple way of getting the assignmentID instead of requerying
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uID", userID);
                        command.Parameters.AddWithValue("@time", dateTime);
                        loginID = Convert.ToInt32(command.ExecuteScalar()); // the execute scalar acts as the execute non query in this case
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
            return loginID;
        }

        static public int GetCurrentUserTotal(User currentUser)
        {
            // This static method returns the total time spent by a single user on the application.
            // It does this through the audit log, with the user's ID being used to filter the table down.
            try
            {
                int total = 0;
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "SELECT COALESCE(SUM(DATEDIFF(MINUTE, LoginTime, LogoutTime)), 0) " + // COALESCE means if there are no entries 0 is used
                        "FROM AuditLog WHERE UserID = @uID AND LogoutTime IS NOT NULL;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uID", currentUser.userID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                total = reader.GetInt32(0);
                            }
                        }
                    }
                }
                return total;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return 0;
            }
        }
        static public int GetAvgUserTotal()
        {
            // This static method is used to return the average total time spent by each user on the application.
            // It works this out using the audit table and the number of users on the application.
            try
            {
                int total = 0;
                int count = 0;
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "SELECT COALESCE(SUM(DATEDIFF(MINUTE, LoginTime, LogoutTime)), 0), COALESCE(COUNT(DISTINCT UserID), 0) " + // distinct ensures we don't count only
                        "FROM AuditLog WHERE LogoutTime IS NOT NULL;";                                                                       // the number of entries (instead users)
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                total = reader.GetInt32(0);
                                count = reader.GetInt32(1);
                            }
                        }
                    }
                }
                if (total > 0 && count > 0) { return total / count; }
                else { return 0; }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return 0;
            }
        }
    }
}
