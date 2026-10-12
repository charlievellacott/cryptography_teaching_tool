using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.MainClasses
{
    public class Lesson
    {
        /// <summary>
        /// This class will be used to hold details of currently retrieved lessons – 
        /// this is especially useful as a list of lesson objects can be returned from various 
        /// methods in the Lesson Repo class.
        /// </summary>

        // The attributes below correspond to each column in the DefinedLessons table of
        // the database and are part of this object, so they can be sent around
        // the application together (in an encapsulated manner).
        public int lessonID;
        public string text;
        public string title;
        public string workPrompt;
        public byte[] imageData;
        public int lessonNo;

        public Lesson(int lessonID, string text, string title, string workPrompt)
        {
            // This constructor is used when adding a lesson to the lesson viewer when the lesson does not have an image.
            this.lessonID = lessonID;
            this.text = text;
            this.title = title;
            this.workPrompt = workPrompt;
        }
        public Lesson(int lessonID, string text, string title, string workPrompt, byte[] imageData)
        {
            // This constructor is used when adding a lesson to the lesson viewer when the lesson does have an image.
            this.lessonID = lessonID;
            this.text = text;
            this.title = title;
            this.workPrompt = workPrompt;
            this.imageData = imageData;
        }
        public Lesson(int lessonID, int lessonNo, string title)
        {
            // This constructor is used to create a lesson instance for each lesson to be displayed in the lesson selector page.
            this.lessonID = lessonID;
            this.lessonNo = lessonNo;
            this.title = title;
        }
    }
}
