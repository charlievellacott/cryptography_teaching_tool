using CryptographyTeachingTool.Help;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.UI;
using CryptographyTeachingTool.UI.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyTeachingTool.UI.Demonstrations
{
    public partial class DemosBasePage : Form
    {
        protected User currentUser;
        protected Button helpbtn;
        protected Button backbtn;

        public DemosBasePage(User user)
        {
            this.currentUser = user;
            ClientSize = new Size(1142, 750);
            helpbtn = InitalizeHelpButton();
            backbtn = InitalizeBacktoDashBtn();
            helpbtn.BringToFront();
            backbtn.BringToFront();
            this.FormClosed += ClosingWindow;
        }

        private Button InitalizeHelpButton()
        {
            // This method creates the help button for all forms pages that run this method.
            // It adds it to the bottom left corner and assigns the HelpButtonClick method at runtime

            Button btn = new Button();
            btn.Text = "Help";
            btn.Size = new Size(150, 40);
            btn.Location = new Point(10, this.ClientSize.Height - btn.Height - 10); // bottom left corner
            btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn.Click += HelpButtonClick;
            btn.BackColor = Color.FromArgb(47, 54, 64);
            btn.ForeColor = Color.FromArgb(220, 221, 225);
            Controls.Add(btn);
            return btn;
        }
        private void HelpButtonClick(object? sender, EventArgs e)
        {
            // This method is run when the help button is pressed.
            // It simply opens the help form as a new window

            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }

        private Button InitalizeBacktoDashBtn()
        {
            // This method adds a back to dashboard button into the bottom right corner of the window
            // It assigns the BackToDashboardButton method at runtime


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
            btn.Click += BackToDashboardButton;
            return btn;
        }
        private void BackToDashboardButton(object? sender, EventArgs e)
        {
            // This method is called when the back to dashboard button is pressed
            // It opens the general dashboard and closes the current page. 

            GeneralDashboardForm dash = new GeneralDashboardForm(currentUser);
            dash.Show();
            this.Hide();
        }

        protected void ClosingWindow(object sender, FormClosedEventArgs e)
        {
            // This method opens the general dashboard when the current window is closed via the cross
            // in the top right hand corner of the window
            GeneralDashboardForm dash = new GeneralDashboardForm(currentUser);
            dash.Show();
            this.Hide();
        }

    }
}
