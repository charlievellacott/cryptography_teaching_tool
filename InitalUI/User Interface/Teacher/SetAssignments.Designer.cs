namespace CryptographyTeachingTool.UI.Teacher
{
    partial class SetAssignments
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            StudentNameText = new TextBox();
            AddStudentBtn = new Button();
            RemoveStudentBtn = new Button();
            StudentsList = new ListBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            TotalMarks = new NumericUpDown();
            label3 = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            label2 = new Label();
            BrowseBtn = new Button();
            tableLayoutPanel9 = new TableLayoutPanel();
            label4 = new Label();
            PathText = new TextBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            label1 = new Label();
            TitleTextBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TotalMarks).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel1.Location = new Point(14, 16);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.1810074F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.76261F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.7596436F));
            tableLayoutPanel1.Size = new Size(354, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(StudentsList, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 4);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 79.0419159F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20.9580841F));
            tableLayoutPanel2.Size = new Size(348, 204);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(StudentNameText, 0, 0);
            tableLayoutPanel3.Controls.Add(AddStudentBtn, 1, 0);
            tableLayoutPanel3.Controls.Add(RemoveStudentBtn, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 165);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(342, 35);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // StudentNameText
            // 
            StudentNameText.BackColor = Color.FromArgb(47, 54, 64);
            StudentNameText.Dock = DockStyle.Fill;
            StudentNameText.ForeColor = Color.FromArgb(220, 221, 225);
            StudentNameText.Location = new Point(3, 4);
            StudentNameText.Margin = new Padding(3, 4, 3, 4);
            StudentNameText.Name = "StudentNameText";
            StudentNameText.Size = new Size(165, 27);
            StudentNameText.TabIndex = 0;
            StudentNameText.Text = "Username...";
            // 
            // AddStudentBtn
            // 
            AddStudentBtn.BackColor = Color.FromArgb(47, 54, 64);
            AddStudentBtn.ForeColor = Color.FromArgb(220, 221, 225);
            AddStudentBtn.Location = new Point(174, 4);
            AddStudentBtn.Margin = new Padding(3, 4, 3, 4);
            AddStudentBtn.Name = "AddStudentBtn";
            AddStudentBtn.Size = new Size(78, 27);
            AddStudentBtn.TabIndex = 1;
            AddStudentBtn.Text = "Add";
            AddStudentBtn.UseVisualStyleBackColor = false;
            AddStudentBtn.Click += AddStudentButtonClick;
            // 
            // RemoveStudentBtn
            // 
            RemoveStudentBtn.BackColor = Color.FromArgb(47, 54, 64);
            RemoveStudentBtn.ForeColor = Color.FromArgb(220, 221, 225);
            RemoveStudentBtn.Location = new Point(259, 4);
            RemoveStudentBtn.Margin = new Padding(3, 4, 3, 4);
            RemoveStudentBtn.Name = "RemoveStudentBtn";
            RemoveStudentBtn.Size = new Size(79, 27);
            RemoveStudentBtn.TabIndex = 2;
            RemoveStudentBtn.Text = "Remove";
            RemoveStudentBtn.UseVisualStyleBackColor = false;
            RemoveStudentBtn.Click += RemoveStudentButtonClick;
            // 
            // StudentsList
            // 
            StudentsList.BackColor = Color.FromArgb(47, 54, 64);
            StudentsList.Dock = DockStyle.Fill;
            StudentsList.ForeColor = Color.FromArgb(220, 221, 225);
            StudentsList.FormattingEnabled = true;
            StudentsList.Location = new Point(3, 4);
            StudentsList.Margin = new Padding(3, 4, 3, 4);
            StudentsList.Name = "StudentsList";
            StudentsList.Size = new Size(342, 153);
            StudentsList.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(button1, 0, 0);
            tableLayoutPanel4.Controls.Add(button2, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 395);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(348, 51);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(47, 54, 64);
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.FromArgb(220, 221, 225);
            button1.Location = new Point(3, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(168, 43);
            button1.TabIndex = 0;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += CloseButtonClick;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(47, 54, 64);
            button2.Dock = DockStyle.Fill;
            button2.ForeColor = Color.FromArgb(220, 221, 225);
            button2.Location = new Point(177, 4);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(168, 43);
            button2.TabIndex = 1;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = false;
            button2.Click += AddAssignmentButtonClick;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel8, 0, 2);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 216);
            tableLayoutPanel5.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25.78125F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 45.3125F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 28.333334F));
            tableLayoutPanel5.Size = new Size(348, 171);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.1946316F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.80537F));
            tableLayoutPanel8.Controls.Add(TotalMarks, 1, 0);
            tableLayoutPanel8.Controls.Add(label3, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 125);
            tableLayoutPanel8.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(342, 42);
            tableLayoutPanel8.TabIndex = 2;
            // 
            // TotalMarks
            // 
            TotalMarks.BackColor = Color.FromArgb(47, 54, 64);
            TotalMarks.ForeColor = Color.FromArgb(220, 221, 225);
            TotalMarks.Location = new Point(102, 4);
            TotalMarks.Margin = new Padding(3, 4, 3, 4);
            TotalMarks.Name = "TotalMarks";
            TotalMarks.Size = new Size(234, 27);
            TotalMarks.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(47, 54, 64);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(220, 221, 225);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 42);
            label3.TabIndex = 0;
            label3.Text = "Max Marks";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 3;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.4242439F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.5757561F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tableLayoutPanel7.Controls.Add(label2, 0, 0);
            tableLayoutPanel7.Controls.Add(BrowseBtn, 1, 0);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel9, 2, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 48);
            tableLayoutPanel7.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(342, 69);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(47, 54, 64);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(220, 221, 225);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 69);
            label2.TabIndex = 0;
            label2.Text = "File";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BrowseBtn
            // 
            BrowseBtn.BackColor = Color.FromArgb(47, 54, 64);
            BrowseBtn.Dock = DockStyle.Fill;
            BrowseBtn.ForeColor = Color.FromArgb(220, 221, 225);
            BrowseBtn.Location = new Point(67, 4);
            BrowseBtn.Margin = new Padding(3, 4, 3, 4);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new Size(81, 61);
            BrowseBtn.TabIndex = 1;
            BrowseBtn.Text = "Browse";
            BrowseBtn.UseVisualStyleBackColor = false;
            BrowseBtn.Click += BrowseButtonClick;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(label4, 0, 0);
            tableLayoutPanel9.Controls.Add(PathText, 0, 1);
            tableLayoutPanel9.Location = new Point(154, 4);
            tableLayoutPanel9.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 32.608696F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 67.391304F));
            tableLayoutPanel9.Size = new Size(183, 61);
            tableLayoutPanel9.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.ForeColor = Color.FromArgb(220, 221, 225);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(177, 19);
            label4.TabIndex = 0;
            label4.Text = "Path...";
            // 
            // PathText
            // 
            PathText.BackColor = Color.FromArgb(47, 54, 64);
            PathText.Dock = DockStyle.Fill;
            PathText.ForeColor = Color.FromArgb(220, 221, 225);
            PathText.Location = new Point(3, 23);
            PathText.Margin = new Padding(3, 4, 3, 4);
            PathText.Name = "PathText";
            PathText.Size = new Size(177, 27);
            PathText.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.1946316F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.80537F));
            tableLayoutPanel6.Controls.Add(label1, 0, 0);
            tableLayoutPanel6.Controls.Add(TitleTextBox, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 4);
            tableLayoutPanel6.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(342, 36);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(47, 54, 64);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(220, 221, 225);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 36);
            label1.TabIndex = 0;
            label1.Text = "Title";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TitleTextBox
            // 
            TitleTextBox.BackColor = Color.FromArgb(47, 54, 64);
            TitleTextBox.Dock = DockStyle.Fill;
            TitleTextBox.ForeColor = Color.FromArgb(220, 221, 225);
            TitleTextBox.Location = new Point(102, 4);
            TitleTextBox.Margin = new Padding(3, 4, 3, 4);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(237, 27);
            TitleTextBox.TabIndex = 1;
            // 
            // SetAssignments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(382, 482);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SetAssignments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SetAssignments";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TotalMarks).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox StudentNameText;
        private Button AddStudentBtn;
        private Button RemoveStudentBtn;
        private ListBox StudentsList;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel8;
        private NumericUpDown TotalMarks;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label2;
        private Label label1;
        private TextBox TitleTextBox;
        private Button BrowseBtn;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label4;
        private TextBox PathText;
    }
}