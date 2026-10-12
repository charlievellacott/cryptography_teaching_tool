using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.MainClasses
{
    public class Assignment
    {
        /// <summary>
        /// This class will be used similarly to the above Lesson class – 
        /// it will be used to hold details of assignments retrieved from the Assignment Repo class. 
        /// This will also prevent numerous visits to the database.
        /// </summary>

        // The attributes below are collected from each column in the DefinedLessons,
        // SyllabusLessons and Users table of the database and are part of this object, so
        // they can be sent around the application together (in an encapsulated manner).
        // This is particularly useful when assignment details or results need to be displayed.
        public string title;
        public int assignmentID;
        public DateTime dateSet;
        public int totalMarks;
        public int actualMarks;
        public string fullname;
        public string firstname;
        public string surname;
        public byte[] binFile; // this stores the binary data of the file sent by the teacher
        public string fileName;

        public Assignment(string title, DateTime dateSet, int totalMarks)
        {
            // This constructor is used create an Assignment instance that stores the details of each assignment set by the current teacher for displaying on the teacher dashboard.
            this.title = title;
            this.dateSet = dateSet;
            this.totalMarks = totalMarks;
        }
        public Assignment(string title, DateTime dateSet, int totalMarks, int actualMarks, string fullname)
        {
            // This constructor is used to create an Assignment instance that stores the details of their
            // student's recent results for displaying on the teacher dashboard.
            this.title = title;
            this.dateSet = dateSet;
            this.totalMarks = totalMarks;
            this.actualMarks = actualMarks;
            this.fullname = fullname;
        }
        public Assignment(string title, DateTime dateSet, int totalMarks, byte[] binFile, string fileName)
        {
            // This constructor is used to create an Assignment instance that stores the details of an
            // assignment that is to be set by a teacher.
            this.title = title;
            this.dateSet = dateSet;
            this.totalMarks = totalMarks;
            this.binFile = binFile;
            this.fileName = fileName;
        }
        public Assignment(string title, DateTime dateSet, int totalMarks, string firstname, string surname, int assignmentID)
        {
            // This constructor is used to create an Assignment instance that stores the details of an
            // assignment set by a teacher for viewing on a student's assignment viewer.
            this.title = title;
            this.dateSet = dateSet;
            this.totalMarks = totalMarks;
            this.firstname = firstname;
            this.surname = surname;
            this.assignmentID = assignmentID;
        }
    }
}