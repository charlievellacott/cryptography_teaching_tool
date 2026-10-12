using CryptographyTeachingTool.MainClasses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CryptographyTeachingTool.Data.Repositories
{
    class LessonRepo : DataClasses
    {
        /// <summary>
        /// Similarly to the User Repo this class will be used to perform necessary select or insert into queries, 
        /// but this time relating to the Lesson Syllabus and Lesson Details tables.
        /// </summary>

        static public Lesson GetLessonByID(int lessonID)
        {
            // This static method is used to obtain, create and return the information needed for a lesson inside an instance of the Lesson object.
            // The information is then used to display the lesson to the user in the LessonViewer page.
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = $"SELECT Text, Title, WorkPrompt, Image FROM DefinedLessons WHERE lessonID = @lessonID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lessonID", lessonID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string text = reader.GetString(0);
                                string title = reader.GetString(1);
                                string workPrompt = reader.GetString(2);

                                if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                                {
                                    byte[] imageData = (byte[])reader["Image"];
                                    Lesson lesson = new Lesson(lessonID, text, title, workPrompt, imageData);
                                    return lesson;
                                }
                                else
                                {
                                    Lesson lesson = new Lesson(lessonID, text, title, workPrompt);
                                    return lesson;
                                }
                            }
                            else { return null; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
                return null;
            }
        }
        static public List<Lesson> GetLessonsBySyllabus(string section, string examBoard, Dictionary<string, int> lessonLevels)
        {
            // This static method is used to obtain, create and return a list of instances of the Lesson object
            // which contain the lessons that are to be displayed to the user given their selected exam board.
            List<Lesson> allLessons = new List<Lesson>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query = "SELECT SyllabusLessons.LessonID, SyllabusLessons.LessonNo, DefinedLessons.Title " +
                        $"FROM SyllabusLessons, DefinedLessons " +
                        $"WHERE SyllabusLessons.LessonID = DefinedLessons.LessonID AND SyllabusLessons.LessonLevel = @level AND SyllabusLessons.ExamBoard = @exam " +
                        $"ORDER BY lessonNO";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@level", lessonLevels[section]);
                        command.Parameters.AddWithValue("@exam", examBoard);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int lessonID = reader.GetInt32(reader.GetOrdinal("lessonID"));
                                int lessonNo = reader.GetInt32(reader.GetOrdinal("LessonNo"));
                                string title = reader.GetString(reader.GetOrdinal("Title"));
                                Lesson lesson = new Lesson(lessonID, lessonNo, title);
                                allLessons.Add(lesson);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: \n{ex.Message}");
            }
            return allLessons;
        }
    }
}
