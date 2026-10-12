namespace CryptographyTeachingTool.UI.Basic
{
    partial class LessonPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // BackToDashboardbtn
            // 
            BackToDashboardbtn.Location = new Point(838, 548);
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(47, 54, 64);
            button1.ForeColor = Color.FromArgb(220, 221, 225);
            button1.Location = new Point(572, 550);
            button1.Name = "button1";
            button1.Size = new Size(170, 38);
            button1.TabIndex = 2;
            button1.Text = "Read Out-Loud";
            button1.UseVisualStyleBackColor = false;
            button1.Click += TextToSpeech;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(47, 54, 64);
            button2.ForeColor = Color.FromArgb(220, 221, 225);
            button2.Location = new Point(748, 548);
            button2.Name = "button2";
            button2.Size = new Size(84, 40);
            button2.TabIndex = 3;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = false;
            button2.Click += StopSpeech;
            // 
            // LessonPage
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "LessonPage";
            Controls.SetChildIndex(BackToDashboardbtn, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(button2, 0);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}