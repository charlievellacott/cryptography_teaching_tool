namespace CryptographyTeachingTool.Login
{
    partial class SignUpForm
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
            surnameBox = new TextBox();
            firstnameBox = new TextBox();
            SignUptxt = new Label();
            Firstnametxt = new Label();
            Surnametxt = new Label();
            textBox3 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Usernametxt = new Label();
            usernameBox = new TextBox();
            Passwordtxt = new Label();
            Password = new TextBox();
            Roletxt = new Label();
            roleSelect = new ComboBox();
            Spacertxt = new Label();
            SignUpbtn = new Button();
            TblLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            TblLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Surname
            // 
            surnameBox.BackColor = Color.FromArgb(47, 54, 64);
            surnameBox.ForeColor = Color.FromArgb(220, 221, 225);
            surnameBox.Location = new Point(3, 79);
            surnameBox.Margin = new Padding(3, 4, 3, 4);
            surnameBox.Name = "Surname";
            surnameBox.Size = new Size(198, 27);
            surnameBox.TabIndex = 0;
            // 
            // Firstname
            // 
            firstnameBox.BackColor = Color.FromArgb(47, 54, 64);
            firstnameBox.ForeColor = Color.FromArgb(220, 221, 225);
            firstnameBox.Location = new Point(3, 24);
            firstnameBox.Margin = new Padding(3, 4, 3, 4);
            firstnameBox.Name = "Firstname";
            firstnameBox.Size = new Size(198, 27);
            firstnameBox.TabIndex = 1;
            // 
            // SignUptxt
            // 
            SignUptxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SignUptxt.AutoSize = true;
            SignUptxt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignUptxt.ForeColor = Color.FromArgb(220, 221, 225);
            SignUptxt.Location = new Point(14, 12);
            SignUptxt.Name = "SignUptxt";
            SignUptxt.Size = new Size(443, 28);
            SignUptxt.TabIndex = 2;
            SignUptxt.Text = "Welcome, please fill in the following details...";
            // 
            // Firstnametxt
            // 
            Firstnametxt.AutoSize = true;
            Firstnametxt.BackColor = Color.FromArgb(47, 54, 64);
            Firstnametxt.ForeColor = Color.FromArgb(220, 221, 225);
            Firstnametxt.Location = new Point(3, 0);
            Firstnametxt.Name = "Firstnametxt";
            Firstnametxt.Size = new Size(73, 20);
            Firstnametxt.TabIndex = 3;
            Firstnametxt.Text = "Firstname";
            // 
            // Surnametxt
            // 
            Surnametxt.AutoSize = true;
            Surnametxt.BackColor = Color.FromArgb(47, 54, 64);
            Surnametxt.ForeColor = Color.FromArgb(220, 221, 225);
            Surnametxt.Location = new Point(3, 55);
            Surnametxt.Name = "Surnametxt";
            Surnametxt.Size = new Size(67, 20);
            Surnametxt.TabIndex = 5;
            Surnametxt.Text = "Surname";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(51, 407);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(146, 27);
            textBox3.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(Firstnametxt);
            flowLayoutPanel1.Controls.Add(firstnameBox);
            flowLayoutPanel1.Controls.Add(Surnametxt);
            flowLayoutPanel1.Controls.Add(surnameBox);
            flowLayoutPanel1.Controls.Add(Usernametxt);
            flowLayoutPanel1.Controls.Add(usernameBox);
            flowLayoutPanel1.Controls.Add(Passwordtxt);
            flowLayoutPanel1.Controls.Add(Password);
            flowLayoutPanel1.Controls.Add(Roletxt);
            flowLayoutPanel1.Controls.Add(roleSelect);
            flowLayoutPanel1.Controls.Add(Spacertxt);
            flowLayoutPanel1.Controls.Add(SignUpbtn);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(126, 4);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.No;
            flowLayoutPanel1.Size = new Size(205, 359);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // Usernametxt
            // 
            Usernametxt.AutoSize = true;
            Usernametxt.BackColor = Color.FromArgb(47, 54, 64);
            Usernametxt.ForeColor = Color.FromArgb(220, 221, 225);
            Usernametxt.Location = new Point(3, 110);
            Usernametxt.Name = "Usernametxt";
            Usernametxt.Size = new Size(75, 20);
            Usernametxt.TabIndex = 7;
            Usernametxt.Text = "Username";
            // 
            // Username
            // 
            usernameBox.BackColor = Color.FromArgb(47, 54, 64);
            usernameBox.ForeColor = Color.FromArgb(220, 221, 225);
            usernameBox.Location = new Point(3, 134);
            usernameBox.Margin = new Padding(3, 4, 3, 4);
            usernameBox.Name = "Username";
            usernameBox.Size = new Size(198, 27);
            usernameBox.TabIndex = 6;
            // 
            // Passwordtxt
            // 
            Passwordtxt.AutoSize = true;
            Passwordtxt.BackColor = Color.FromArgb(47, 54, 64);
            Passwordtxt.ForeColor = Color.FromArgb(220, 221, 225);
            Passwordtxt.Location = new Point(3, 165);
            Passwordtxt.Name = "Passwordtxt";
            Passwordtxt.Size = new Size(70, 20);
            Passwordtxt.TabIndex = 9;
            Passwordtxt.Text = "Password";
            // 
            // Password
            // 
            Password.BackColor = Color.FromArgb(47, 54, 64);
            Password.ForeColor = Color.FromArgb(220, 221, 225);
            Password.Location = new Point(3, 189);
            Password.Margin = new Padding(3, 4, 3, 4);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(198, 27);
            Password.TabIndex = 8;
            // 
            // Roletxt
            // 
            Roletxt.AutoSize = true;
            Roletxt.BackColor = Color.FromArgb(47, 54, 64);
            Roletxt.ForeColor = Color.FromArgb(220, 221, 225);
            Roletxt.Location = new Point(3, 220);
            Roletxt.Name = "Roletxt";
            Roletxt.Size = new Size(39, 20);
            Roletxt.TabIndex = 11;
            Roletxt.Text = "Role";
            // 
            // RoleSelect
            // 
            roleSelect.BackColor = Color.FromArgb(47, 54, 64);
            roleSelect.ForeColor = Color.FromArgb(220, 221, 225);
            roleSelect.FormattingEnabled = true;
            roleSelect.Items.AddRange(new object[] { "Student", "Teacher" });
            roleSelect.Location = new Point(3, 244);
            roleSelect.Margin = new Padding(3, 4, 3, 4);
            roleSelect.Name = "RoleSelect";
            roleSelect.Size = new Size(198, 28);
            roleSelect.TabIndex = 10;
            // 
            // Spacertxt
            // 
            Spacertxt.AutoSize = true;
            Spacertxt.Location = new Point(3, 276);
            Spacertxt.Name = "Spacertxt";
            Spacertxt.Size = new Size(0, 20);
            Spacertxt.TabIndex = 13;
            // 
            // SignUpbtn
            // 
            SignUpbtn.BackColor = Color.FromArgb(47, 54, 64);
            SignUpbtn.ForeColor = Color.FromArgb(220, 221, 225);
            SignUpbtn.Location = new Point(3, 300);
            SignUpbtn.Margin = new Padding(3, 4, 3, 4);
            SignUpbtn.Name = "SignUpbtn";
            SignUpbtn.Size = new Size(199, 31);
            SignUpbtn.TabIndex = 12;
            SignUpbtn.Text = "Sign Up";
            SignUpbtn.UseVisualStyleBackColor = false;
            SignUpbtn.Click += SignUpButtonClick;
            // 
            // TblLayoutPanel
            // 
            TblLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TblLayoutPanel.ColumnCount = 1;
            TblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TblLayoutPanel.Controls.Add(flowLayoutPanel1, 0, 0);
            TblLayoutPanel.Location = new Point(0, 44);
            TblLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            TblLayoutPanel.Name = "TblLayoutPanel";
            TblLayoutPanel.RowCount = 1;
            TblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 517F));
            TblLayoutPanel.Size = new Size(457, 367);
            TblLayoutPanel.TabIndex = 7;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(461, 411);
            Controls.Add(TblLayoutPanel);
            Controls.Add(textBox3);
            Controls.Add(SignUptxt);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUpForm";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            TblLayoutPanel.ResumeLayout(false);
            TblLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox surnameBox;
        private TextBox firstnameBox;
        private Label SignUptxt;
        private Label Firstnametxt;
        private Label Surnametxt;
        private TextBox textBox3;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel TblLayoutPanel;
        private Label Usernametxt;
        private TextBox usernameBox;
        private Label Passwordtxt;
        private TextBox Password;
        private Label Roletxt;
        private ComboBox roleSelect;
        private Label Spacertxt;
        private Button SignUpbtn;
    }
}