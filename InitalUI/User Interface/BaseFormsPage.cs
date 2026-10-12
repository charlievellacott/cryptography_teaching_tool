using CryptographyTeachingTool.Help;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.UI.Basic
{
    public class BaseFormsPage : Form
    {
        /// <summary>
        /// The help button will be visible in almost all pages therefore instead of recreating the code for each page it is present; 
        /// I will create a class that inherits from ‘Form’ and initializes the help button. 
        /// Then for form that will have the help button, I can make that form inherit from this class.
        /// </summary>

        protected User currentUser; // This attribute holds all of the current users details so
                                    // they can be accessed by the UI and then reacted to on this level
        
        protected Button helpBtn;   // This stores the help button so that it can be added to the screen dynamically

        // The following dictionary stores the mappings/encodings used for each level in the code below.
        // It provides a fast way of converting between the string Level and then a integer representing the level.
        // This dictionary will allow for lesson levels to easily be added and interpretted from the database correctly.
        protected private Dictionary<string, int> LESSON_LEVELS = new Dictionary<string, int>
        {
            { "FURTHER", 3 },
            { "ALEVEL", 2 },
            { "GCSE", 1 },
            { "DEMOS", 0 }
        };

        // The following dictionary holds all of the Exam Boards that are individually recoginsed by the application
        protected string[] EXAM_BOARDS = { "AQA", "Edexcel", "OCR" };

        protected int BUTTON_HEIGHTS = 40;  // Provides a single constant for the height of buttons which is then used
                                            // when creating the button or padding for the display

        public BaseFormsPage(User user, bool isHelpBtnVis)
        {
            // This is the base (and only) constructor which adds the help button to the
            // page and assigns the ClosingApplication method to action of FormClosed
            currentUser = user;
            InitializeComponent();
            if ( isHelpBtnVis ) { helpBtn = InitalizeHelpButton(); }
            this.FormClosed += ClosingApplication;
        }

        protected virtual void ClosingApplication(object sender, FormClosedEventArgs e)
        {
            // This method is used to call the SignOut method of the user
            // (thus adding the signout time to an appropriate entry of the AuditLog table).
            currentUser.SignOut();
            Application.Exit();
        }

        protected Button InitalizeHelpButton()
        {
            // This method is used to create and add a help button into the botton-left corner of the pages.
            Button btn = new Button();
            btn.Text = "Help";
            btn.Size = new Size(150, BUTTON_HEIGHTS);
            btn.Location = new Point(10, this.ClientSize.Height - btn.Height - 10); // bottom-left corner
            btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn.Click += HelpButtonClick;
            btn.BackColor = Color.FromArgb(47, 54, 64);
            btn.ForeColor = Color.FromArgb(220, 221, 225);
            Controls.Add(btn);
            return btn;
        }

        private void InitializeComponent()
        {
            // This method creates a page of size 1000, 600 in the center of the screen
            SuspendLayout();
            // 
            // BaseFormsPage
            // 
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(1000, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimumSize = new Size(720, 432);
            Name = "BaseFormsPage";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        private void HelpButtonClick(object? sender, EventArgs e)
        {
            // This method creates and shows the help form page, it does not close the current page.
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
    }
}
