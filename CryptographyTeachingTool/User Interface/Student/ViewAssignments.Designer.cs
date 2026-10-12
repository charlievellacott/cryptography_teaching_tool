namespace CryptographyTeachingTool.UI.Student
{
    partial class ViewAssignments
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
            AssignmentPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // AssignmentPanel
            // 
            AssignmentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AssignmentPanel.FlowDirection = FlowDirection.TopDown;
            AssignmentPanel.Location = new Point(14, 16);
            AssignmentPanel.Margin = new Padding(3, 4, 3, 4);
            AssignmentPanel.Name = "AssignmentPanel";
            AssignmentPanel.Size = new Size(640, 304);
            AssignmentPanel.TabIndex = 0;
            // 
            // ViewAssignments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(667, 336);
            Controls.Add(AssignmentPanel);
            ForeColor = Color.FromArgb(220, 221, 225);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewAssignments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewAssignments";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel AssignmentPanel;
    }
}