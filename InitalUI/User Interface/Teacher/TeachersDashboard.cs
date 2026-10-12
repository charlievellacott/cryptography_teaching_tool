using CryptographyTeachingTool.Data.Repositories;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.UI.Basic;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace CryptographyTeachingTool.UI.Teacher
{
    public partial class TeachersDashboard : Form
    {
        private Button dash;
        private User currentUser;
        public TeachersDashboard(User user)
        {
            FormClosed += BackToDashboardbtn_Click;
            currentUser = user;
            InitializeComponent();
            dash = InitalizeBacktoDashBtn();
            dash.BringToFront();
            TeacherName.Text = $"Teacher: {user.username}";
            FetchAsignmentsSet();
            FetchResults();
        }

        public void FetchAsignmentsSet()
        {
            // This method is used to get the assignments set by the currently logged in teacher
            // and then display them on the screen 

            RecentAsignmentsPanel.Controls.Clear();

            List<Assignment> assignmentList = AssignmentRepo.GetAssignmentsForTeacher(currentUser);
            foreach (Assignment assignment in assignmentList)
            {
                Panel bubble = CreateAssignmentBubble(assignment.title, assignment.dateSet, assignment.totalMarks);
                bubble.Width = RecentAsignmentsPanel.ClientSize.Width - bubble.Margin.Horizontal;
                RecentAsignmentsPanel.Controls.Add(bubble); // adding to the flow panel
            }
        }

        private void FetchResults()
        {
            // This method is used to get the marks from students with assignments associated to
            // the currently logged in teacher and then display them on the screen 

            List<Assignment> assignments = AssignmentRepo.GetResults(currentUser);
            foreach (Assignment assignment in assignments)
            {
                Panel bubble = CreateResultsBubble(assignment.title, assignment.dateSet, assignment.actualMarks, assignment.totalMarks, assignment.fullname);
                bubble.Width = RecentResultsPanel.ClientSize.Width - bubble.Margin.Horizontal;
                RecentResultsPanel.Controls.Add(bubble); // adding to the flow panel
            }
        }

        private Panel CreateAssignmentBubble(string title, DateTime dateSet, int totalMarks)
        {
            // This method creates a a bubble which displays all of the key information of currently set assignments 

            Panel bubble = new Panel();
            bubble.AutoSize = false;
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
            lblTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.AutoSize = true;
            Label lblDate = new Label();
            lblDate.Text = $"Date: {dateSet:dd MMM yyyy}";
            lblDate.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblDate.AutoSize = true;
            Label lblMarks = new Label();
            lblMarks.Text = $"Total Marks: {totalMarks}";
            lblMarks.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblMarks.AutoSize = true;

            FlowLayoutPanel FlowLayout = new FlowLayoutPanel(); // this controls how the info in the bubble is layed out 
            FlowLayout.FlowDirection = FlowDirection.TopDown;
            FlowLayout.AutoSize = false;
            FlowLayout.Dock = DockStyle.Fill;
            FlowLayout.WrapContents = false;
            FlowLayout.Controls.Add(lblTitle);
            FlowLayout.Controls.Add(lblDate);
            FlowLayout.Controls.Add(lblMarks);

            bubble.Controls.Add(FlowLayout); // adds the text inside the bubble
            bubble.MaximumSize = new Size(RecentAsignmentsPanel.ClientSize.Width - 50, 999);
            return bubble;
        }

        private Panel CreateResultsBubble(string title, DateTime dateSet, int actualMarks, int totalMarks, string name) // using similar code to the help page bubbles
        {
            // This method creates a bubble which displays a result from a student on a recently set assignment

            Panel bubble = new Panel();
            bubble.AutoSize = false;
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
            lblTitle.Text = $"{name} : {dateSet:dd MMM yyyy}";
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.AutoSize = true;
            Label lblDate = new Label();
            lblDate.Text = $"{title}";
            lblDate.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblDate.AutoSize = true;
            Label lblMarks = new Label();
            lblMarks.Text = $"Marks: {actualMarks}/{totalMarks}";
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

            bubble.Controls.Add(FlowLayout); // adds the text inside the bubble
            bubble.MaximumSize = new Size(RecentResultsPanel.ClientSize.Width - 50, 999);
            return bubble;
        }

        private Button InitalizeBacktoDashBtn()
        {
            // This method creates the back to dashboard button 

            Button btn = new Button();
            btn.Text = "Back";
            btn.Size = new Size(150, 40);
            btn.BackColor = Color.FromArgb(47, 54, 64);
            btn.ForeColor = Color.FromArgb(220, 221, 225);
            btn.Location = new Point(
                this.ClientSize.Width - btn.Width - 10,
                this.ClientSize.Height - btn.Height - 10); // bottom right corner
            Controls.Add(btn);
            btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn.Click += BackToDashboardbtn_Click;
            return btn;
        }

        private void BackToDashboardbtn_Click(object? sender, EventArgs e)
        {
            // This method is assigned to the press of the back to dashboard button
            // it simply closes the current form and opens the dashboard

            GeneralDashboardForm dashboard = new GeneralDashboardForm(currentUser);
            dashboard.Show();
            this.Hide();
        }

        private void SetAssignments_Click(object sender, EventArgs e)
        {
            // This method opens up the SetAssignment window over the top of the teacher dashboard

            SetAssignments assignments = new SetAssignments(currentUser, this);
            assignments.Show();
        }
    }
}
