using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.Data.SqlClient;
using CryptographyTeachingTool.UI.Demos;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.UI.Demonstrations;
using CryptographyTeachingTool.Data.Repositories;

namespace CryptographyTeachingTool.UI.Basic
{
    public class NavigationalPagesTemplate : BaseFormsPage
    {
        /// <summary>
        /// This class inherits from the BaseFormsPage class and is in place to add few
        /// further elements to the forms page. A back-to-dashboard button, a flow layout panel and a table layout 
        /// panel are added to the screen in the initializer. If this class is told so in the constructor,
        /// it will also add a combo box, which serves as a drop-down menu for selecting the exam board.
        /// </summary>

        protected Button BackToDashboardbtn;
        protected FlowLayoutPanel flowLayoutPanel;

        // Base contains the currentUser object
        private string level;
        private ComboBox examBoardSelector;
        private TableLayoutPanel tableLayoutPanel;

        // The following constant stores the padding of the layout panel from windows edges.
        // Thus how much space there is between the key elements and the edge of the window.
        private int FLOW_LAYOUT_PADDING = 12; 

        public NavigationalPagesTemplate(User user, string Level) : base(user, true)
        {
            // This constructor is used to create a page suitable for viewing the lessons in any syllabus
            this.level = Level;
            BackToDashboardbtn = InitalizeBacktoDashboardButton();
            flowLayoutPanel = InitalizeFlowPanel();
            InitializeComponent();
        }

        public NavigationalPagesTemplate(User user, string Level, bool addComponents) : base(user, true)
        {
            // This constructor is called from the LessonPage constructor to set up the page
            // for displaying a chosen lesson. This means displaying its text, workprompt,
            // various navigational buttons and an image if nessisary.
            this.level = Level;
            BackToDashboardbtn = InitalizeBacktoDashboardButton();
            flowLayoutPanel = InitalizeFlowPanel();
        }

        public NavigationalPagesTemplate(User user, bool helpButtonVis) : base(user, helpButtonVis)
        {
            // This is a default constructor for this class that calls the BaseFormsTemplate constructor
            // passing if the user intends to make the help button visible.
            // This constructor is not in current use - however is still a default so nessisary to be kept
            // for future development.
            BackToDashboardbtn = InitalizeBacktoDashboardButton();
            flowLayoutPanel = InitalizeFlowPanel();
        }

        public NavigationalPagesTemplate(User user) : base(user, true)
        {
            // This is a default constructor for this class that calls the BaseFormsTemplate constructor
            // passing that the user does want the help button visible (as not specified).
            // This constructor is not in current use - however is still a default so nessisary to be kept
            // for future development.
            BackToDashboardbtn = InitalizeBacktoDashboardButton();
            flowLayoutPanel = InitalizeFlowPanel();
        }

        private Button InitalizeBacktoDashboardButton()
        {
            // This method is used to create a back to dashboard button in the bottom right corner of the users display.
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
            btn.Click += BackToDashboardButtonClick;
            return btn;
        }

        private FlowLayoutPanel InitalizeFlowPanel()
        {
            // This method is called by all of the current constructors to create a flowlayout panel
            // which fits in the center of the screen with a padding of 12 from the edges.
            // The BUTTON_HEIGHTS constant is stored in the BaseFormsPage which creates both the
            // help and back to dashboard buttons from it, thus if these need to change size so will
            // the padding and layout panel.
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Location = new Point(FLOW_LAYOUT_PADDING, FLOW_LAYOUT_PADDING); 
            flowLayoutPanel.Size = new Size(
                this.ClientSize.Width - 2 * FLOW_LAYOUT_PADDING,
                this.ClientSize.Height - 3 * FLOW_LAYOUT_PADDING - BUTTON_HEIGHTS); // the button heights are stored in the baseforms page
                                                                                    // so this will automatically adjust as the height of
                                                                                    // the buttons do 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Padding = new Padding(5);
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.TabIndex = 1;
            Controls.Add(flowLayoutPanel);

            Label label = new Label
            {
                Text = "Please select an Exam Board.",
                Height = 50,
                Width = flowLayoutPanel.ClientSize.Width - 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White
            };
            flowLayoutPanel.Controls.Add(label);

            return flowLayoutPanel;
        }

        protected void AddLessons(string section, string examBoard)
        {
            // This method is used to get lessons for a specific syllabus and examboard from the database 
            // and display them in an appropriate manner to the user. In addition, methods are dynamically
            // assigned to actions such as clicking on a specific lesson's link, thus opening the LessonPage
            // and displaying the correct information.
            flowLayoutPanel.Controls.Clear();

            List<Lesson> lessonList = LessonRepo.GetLessonsBySyllabus(section, examBoard, LESSON_LEVELS);
            foreach (Lesson lesson in lessonList)
            {
                LinkLabel lessonLink = new LinkLabel(); // creating the link lable to add to the flow panel
                lessonLink.Text = lesson.lessonNo + ". " + lesson.title;
                lessonLink.TextAlign = ContentAlignment.MiddleCenter;
                lessonLink.Font = new Font("Segoe UI", 17, FontStyle.Bold);
                lessonLink.Tag = lessonLink.Font.Size;

                lessonLink.LinkColor = Color.FromArgb(220, 221, 225);
                lessonLink.VisitedLinkColor = Color.FromArgb(251, 197, 49);
                lessonLink.ActiveLinkColor = Color.FromArgb(251, 197, 49);

                lessonLink.AutoSize = false;
                lessonLink.Width = flowLayoutPanel.ClientSize.Width - 10;
                lessonLink.Height = 50; // needs to fit the font
                lessonLink.TextAlign = ContentAlignment.MiddleCenter;

                lessonLink.Margin = new Padding(5); // this is the spacing between lines

                // The appropriate methods are assigned dynamically after fetching
                // the lessons from the database. If not a demo, then the constructor
                // for LessonPage with the user, lessonID and section parameters being passed in.

                lessonLink.LinkClicked += (sender, e) =>
                {
                    if (level == "DEMOS")
                    {
                        // This section dynamically (at runtime) assigns each demo label an 
                        // action so that the correct action is performed. For example
                        // the correct demonstration page is opened.
                        if (lesson.title.ToLower().Contains("caesar"))
                        {
                            CaesarDemo ceasar = new CaesarDemo(currentUser);
                            ceasar.Show();
                            this.Hide();
                        }
                        else if (lesson.title.ToLower().Contains("railfence"))
                        {
                            RailfenceDemo vernam = new RailfenceDemo(currentUser);
                            vernam.Show();
                            this.Hide();
                        }
                        else if (lesson.title.ToLower().Contains("vernam"))
                        {
                            VernamDemo railfence = new VernamDemo(currentUser);
                            railfence.Show();
                            this.Hide();
                        }
                        else if (lesson.title.ToLower().Contains("256"))
                        {
                            SHADemo sha = new SHADemo(currentUser);
                            sha.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown Teaching Tool");
                        }
                    }
                    else
                    {
                        // This assigns any non demo pages the action of opening a lesson page
                        // with the lessonID to be queried in the DefinedLessons table
                        LessonPage newLesson = new LessonPage(currentUser, lesson, section);
                        newLesson.Show();
                        this.Hide();
                    }
                };

                flowLayoutPanel.Controls.Add(lessonLink); // Adds the label to the screen
            }

            if (flowLayoutPanel.Controls.Count == 0)
            {
                // If empty then an appropriate message is displayed
                Label label = new Label
                {
                    Text = "No lessons have been added for this exam board yet.",
                    Height = 50,
                    Width = flowLayoutPanel.ClientSize.Width - 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    ForeColor = Color.White
                };
                flowLayoutPanel.Controls.Add(label);
            }
        }

        protected void DisplayLesson(string text, string prompt)
        {
            // This method is used for adding the lesson details to the screen.
            // The lesson text and work prompt are added as part of this method.

            // Create the lesson text
            Label lessonText = new Label();
            lessonText.Text = text;
            lessonText.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lessonText.ForeColor = Color.FromArgb(220, 221, 225);
            lessonText.AutoSize = true;
            lessonText.Dock = DockStyle.Top;
            // Create the work prompt
            Label workPrompt = new Label();
            workPrompt.Text = prompt;
            workPrompt.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            workPrompt.ForeColor = Color.FromArgb(220, 221, 225);
            workPrompt.AutoSize = true;
            workPrompt.Dock = DockStyle.Top;
            // Add them to the screen
            flowLayoutPanel.Controls.Add(lessonText); 
            flowLayoutPanel.Controls.Add(workPrompt);
        }

        private void InitializeComponent()
        {
            // This method is used to add the exam board selector and flow laybout panel to the window.

            examBoardSelector = new ComboBox();
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // examBoardSelector
            // 
            examBoardSelector.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            examBoardSelector.BackColor = Color.FromArgb(47, 54, 64);
            examBoardSelector.ForeColor = Color.FromArgb(220, 221, 225);
            examBoardSelector.FormattingEnabled = true;
            examBoardSelector.Items.AddRange(EXAM_BOARDS);
            examBoardSelector.Location = new Point(328, 6);
            examBoardSelector.Name = "examBoardSelector";
            examBoardSelector.Size = new Size(319, 33);
            examBoardSelector.TabIndex = 0;
            examBoardSelector.SelectedIndexChanged += ExamBoardChanged;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.Controls.Add(examBoardSelector, 1, 0);
            tableLayoutPanel.Location = new Point(12, 546);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(976, 42);
            tableLayoutPanel.TabIndex = 2;
            // 
            // NavigationalPagesTemplate
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(tableLayoutPanel);
            Name = "NavigationalPagesTemplate";
            Text = "Navigational Page";
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void BackToDashboardButtonClick(object? sender, EventArgs e)
        {
            // This button is used to close the current window and open the general dashboard window,
            // thus returning the user back to the dashboard from whereever the button was pressed.
            GeneralDashboardForm dashboard = new GeneralDashboardForm(currentUser);
            dashboard.Show();
            this.Hide();
        }

        private void ExamBoardChanged(object sender, EventArgs e)
        {
            // This button triggers the AddLessons method, which means that the lessons shown are changed
            // each time the syllabus is changed.
            string examBoard = examBoardSelector.Text;
            AddLessons(level, examBoard);
        }
    }
}
