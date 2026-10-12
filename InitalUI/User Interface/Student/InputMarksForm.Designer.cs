namespace CryptographyTeachingTool.UI.Student
{
    partial class InputMarksForm
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
            label1 = new Label();
            marksInput = new NumericUpDown();
            DoneBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)marksInput).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.4553566F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.2232151F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.0982151F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(marksInput, 1, 0);
            tableLayoutPanel1.Controls.Add(DoneBtn, 2, 0);
            tableLayoutPanel1.Location = new Point(17, 20);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(640, 53);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(47, 54, 64);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(220, 221, 225);
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(328, 53);
            label1.TabIndex = 0;
            label1.Text = "Please enter the number of marks that you have achieved on this assignment.";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MarksInput
            // 
            marksInput.BackColor = Color.FromArgb(47, 54, 64);
            marksInput.Dock = DockStyle.Fill;
            marksInput.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            marksInput.ForeColor = Color.FromArgb(220, 221, 225);
            marksInput.Location = new Point(340, 5);
            marksInput.Margin = new Padding(4, 5, 4, 5);
            marksInput.Name = "MarksInput";
            marksInput.Size = new Size(153, 31);
            marksInput.TabIndex = 1;
            marksInput.TextAlign = HorizontalAlignment.Center;
            // 
            // DoneBtn
            // 
            DoneBtn.BackColor = Color.FromArgb(47, 54, 64);
            DoneBtn.Dock = DockStyle.Fill;
            DoneBtn.ForeColor = Color.FromArgb(220, 221, 225);
            DoneBtn.Location = new Point(501, 5);
            DoneBtn.Margin = new Padding(4, 5, 4, 5);
            DoneBtn.Name = "DoneBtn";
            DoneBtn.Size = new Size(135, 43);
            DoneBtn.TabIndex = 2;
            DoneBtn.Text = "Done";
            DoneBtn.UseVisualStyleBackColor = false;
            DoneBtn.Click += UpdateMarksButtonClick;
            // 
            // InputMarksForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(684, 93);
            Controls.Add(tableLayoutPanel1);
            ForeColor = Color.FromArgb(220, 221, 225);
            Margin = new Padding(4, 5, 4, 5);
            Name = "InputMarksForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Input your marks";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)marksInput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private NumericUpDown marksInput;
        private Button DoneBtn;
    }
}