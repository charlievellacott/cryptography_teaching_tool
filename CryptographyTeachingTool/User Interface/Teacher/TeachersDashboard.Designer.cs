using System.Windows.Forms;

namespace CryptographyTeachingTool.UI.Teacher
{
    partial class TeachersDashboard
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
            RecentAsignmentsPanel = new FlowLayoutPanel();
            RecentAssignLabel = new Label();
            TeacherName = new Label();
            button1 = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            RecentResultsPanel = new FlowLayoutPanel();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(TeacherName, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(976, 576);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(RecentAsignmentsPanel, 0, 1);
            tableLayoutPanel2.Controls.Add(RecentAssignLabel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 60);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(628, 513);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // RecentAsignmentsPanel
            // 
            RecentAsignmentsPanel.Dock = DockStyle.Fill;
            RecentAsignmentsPanel.FlowDirection = FlowDirection.TopDown;
            RecentAsignmentsPanel.Location = new Point(3, 79);
            RecentAsignmentsPanel.Name = "RecentAsignmentsPanel";
            RecentAsignmentsPanel.Size = new Size(622, 431);
            RecentAsignmentsPanel.TabIndex = 0;
            RecentAsignmentsPanel.WrapContents = false;
            RecentResultsPanel.WrapContents = false;
            RecentAsignmentsPanel.AutoScroll = true;
            RecentResultsPanel.AutoScroll = true;
            // 
            // RecentAssignLabel
            // 
            RecentAssignLabel.AutoSize = true;
            RecentAssignLabel.Dock = DockStyle.Fill;
            RecentAssignLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RecentAssignLabel.Location = new Point(3, 0);
            RecentAssignLabel.Name = "RecentAssignLabel";
            RecentAssignLabel.Size = new Size(622, 76);
            RecentAssignLabel.TabIndex = 1;
            RecentAssignLabel.Text = "The recent assignments you have set are below:";
            RecentAssignLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeacherName
            // 
            TeacherName.AutoSize = true;
            TeacherName.Dock = DockStyle.Fill;
            TeacherName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeacherName.Location = new Point(3, 0);
            TeacherName.Name = "TeacherName";
            TeacherName.Size = new Size(628, 57);
            TeacherName.TabIndex = 1;
            TeacherName.Text = "Teacher:";
            TeacherName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(47, 54, 64);
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(637, 3);
            button1.Name = "button1";
            button1.Size = new Size(336, 51);
            button1.TabIndex = 2;
            button1.Text = "Set Assignments";
            button1.UseVisualStyleBackColor = false;
            button1.Click += SetAssignments_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(RecentResultsPanel, 0, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(637, 60);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.551657F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 90.44834F));
            tableLayoutPanel3.Size = new Size(336, 513);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // RecentResultsPanel
            // 
            RecentResultsPanel.AutoScroll = true;
            RecentResultsPanel.Dock = DockStyle.Fill;
            RecentResultsPanel.FlowDirection = FlowDirection.TopDown;
            RecentResultsPanel.Location = new Point(3, 52);
            RecentResultsPanel.Name = "RecentResultsPanel";
            RecentResultsPanel.Size = new Size(330, 458);
            RecentResultsPanel.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(330, 49);
            label1.TabIndex = 0;
            label1.Text = "The recently uploaded results are displayed here.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeachersDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(1000, 600);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.FromArgb(220, 221, 225);
            Name = "TeachersDashboard";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Dashboard";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel RecentAsignmentsPanel;
        private Label TeacherName;
        private Button button1;
        private Label RecentAssignLabel;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel RecentResultsPanel;
        private Label label1;
    }
}