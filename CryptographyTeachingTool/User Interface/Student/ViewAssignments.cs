using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.MainClasses;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using CryptographyTeachingTool.UI.Basic;

namespace CryptographyTeachingTool.UI.Student
{
    public partial class ViewAssignments : Form
    {
        private User currentUser;

        public ViewAssignments(User user)
        {
            currentUser = user;
            InitializeComponent();
            AssignmentPanel.AutoScroll = true;
            FetchAsignmentsSet();
        }

        private void FetchAsignmentsSet()
        {
            // This method gets the assignments returned by the GetAssignmentsForStudent method of the AssignmentRepo
            // it then displays each of these on the page

            List<Assignment> allAssignments = AssignmentRepo.GetAssignmentsForStudent(currentUser);
            foreach(Assignment assignment in allAssignments)
            {
                Panel bubble = CreateAssignmentBubble(assignment.title, assignment.dateSet, assignment.totalMarks, assignment.firstname, assignment.surname, assignment.assignmentID);
                bubble.Width = AssignmentPanel.ClientSize.Width - bubble.Margin.Horizontal;
                AssignmentPanel.Controls.Add(bubble); // adding to the flow panel
            }
        }

        private Panel CreateAssignmentBubble(string title, DateTime dateSet, int totalMarks, string fName, string sName, int id) // using similar code to the help page bubbles
        {
            // This method is run to create an instance of a panel object that can be added to the
            // screen for displaying each assignment in a bubble like manner

            Panel bubble = new Panel();
            bubble.AutoSize = true;
            bubble.BackColor = Color.FromArgb(39, 60, 117);
            bubble.ForeColor = Color.FromArgb(245, 246, 250);
            bubble.BorderStyle = BorderStyle.None;
            bubble.Margin = new Padding(10);
            bubble.Padding = new Padding(15);

            bubble.Paint += (s, e) => // use paint to create the rounded corners
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 20; // controlling how round the cornersare
                    Rectangle rect = bubble.ClientRectangle;
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    bubble.Region = new Region(path);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen pen = new Pen(Color.FromArgb(245, 246, 250), 5))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            // write all the text
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblTitle.AutoSize = true;
            Label lblDate = new Label();
            lblDate.Text = $"{fName[0]}.{sName}, Date: {dateSet:dd MMM yyyy}";
            lblDate.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDate.AutoSize = true;
            Label lblMarks = new Label();
            lblMarks.Text = $"Total Marks: {totalMarks}";
            lblMarks.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblMarks.AutoSize = true;

            FlowLayoutPanel FlowLayout = new FlowLayoutPanel(); // this controls how the info in the bubble is layed out 
            FlowLayout.FlowDirection = FlowDirection.TopDown;
            FlowLayout.AutoSize = false;
            FlowLayout.Dock = DockStyle.Fill;
            FlowLayout.WrapContents = false;
            FlowLayout.Controls.Add(lblTitle);
            FlowLayout.Controls.Add(lblDate);
            FlowLayout.Controls.Add(lblMarks);

            // create the buttons
            Button addMarksBtn = new Button
            {
                Text = "Upload Marks",
                BackColor = Color.FromArgb(47, 54, 64),
                ForeColor = Color.FromArgb(220, 221, 225),
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(3, 3, 3, 3),
                Dock = DockStyle.Fill
            };
            Button downloadBtn = new Button
            {
                Text = "Download File",
                BackColor = Color.FromArgb(47, 54, 64),
                ForeColor = Color.FromArgb(220, 221, 225),
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(3, 3, 3, 3),
                Dock = DockStyle.Fill
            };

            addMarksBtn.Click += (s, e) => UploadMarks(s, e, id);
            downloadBtn.Click += (s, e) => DownloadFile(s, e, id);

            TableLayoutPanel buttons = new TableLayoutPanel // this is to ensure the buttons are equal and side by side
            {
                ColumnCount = 2,
                AutoSize = true,
                Dock = DockStyle.Top
            };
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttons.Controls.Add(addMarksBtn);
            buttons.Controls.Add(downloadBtn);

            FlowLayoutPanel bubbleLayout = new FlowLayoutPanel // add all components into one final layout panel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false,
                Dock = DockStyle.Fill
            };

            bubbleLayout.Controls.Add(FlowLayout); // adds the text inside the bubble
            bubbleLayout.Controls.Add(buttons);    // this adds the butons table layout into the bubble

            bubble.Controls.Add(bubbleLayout); 
            return bubble;
        }

        private void UploadMarks(object sender, EventArgs e, int id)
        {
            // This method opens the input marks form where the user can select their marks.

            InputMarksForm marks = new InputMarksForm(this, id);
            marks.Show();
        }

        private void DownloadFile(object sender, EventArgs e, int assignmentID)
        {
            // This method is assigned to the download button click event at run time.
            // Thus is called when the button is pressed

            AssignmentRepo.DownloadFile(assignmentID);
        }
    }
}
