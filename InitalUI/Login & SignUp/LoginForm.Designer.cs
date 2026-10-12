namespace CryptographyTeachingTool.Login
{
    partial class LoginForm
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
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            SignUpbtn = new LinkLabel();
            tblLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            Spacertxt = new Label();
            SignInbtn = new Button();
            label3 = new Label();
            Welcomelbl = new Label();
            tblLayoutPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // Username
            // 
            usernameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            usernameBox.BackColor = Color.FromArgb(47, 54, 64);
            usernameBox.ForeColor = Color.FromArgb(220, 221, 225);
            usernameBox.Location = new Point(2, 22);
            usernameBox.Margin = new Padding(2, 2, 2, 2);
            usernameBox.Name = "Username";
            usernameBox.Size = new Size(201, 27);
            usernameBox.TabIndex = 0;
            usernameBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Password
            // 
            passwordBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordBox.BackColor = Color.FromArgb(47, 54, 64);
            passwordBox.ForeColor = Color.FromArgb(220, 221, 225);
            passwordBox.Location = new Point(2, 73);
            passwordBox.Margin = new Padding(2, 2, 2, 2);
            passwordBox.Name = "Password";
            passwordBox.PasswordChar = '*';
            passwordBox.Size = new Size(201, 27);
            passwordBox.TabIndex = 1;
            passwordBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SignUpbtn
            // 
            SignUpbtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SignUpbtn.AutoSize = true;
            SignUpbtn.LinkColor = Color.FromArgb(0, 168, 255);
            SignUpbtn.Location = new Point(3, 160);
            SignUpbtn.Name = "SignUpbtn";
            SignUpbtn.Size = new Size(114, 20);
            SignUpbtn.TabIndex = 3;
            SignUpbtn.TabStop = true;
            SignUpbtn.Text = "Click to Sign Up";
            SignUpbtn.LinkClicked += SignUpLabelClick;
            // 
            // tblLayoutPanel
            // 
            tblLayoutPanel.ColumnCount = 1;
            tblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tblLayoutPanel.Controls.Add(flowLayoutPanel2, 0, 0);
            tblLayoutPanel.Dock = DockStyle.Bottom;
            tblLayoutPanel.Location = new Point(0, 52);
            tblLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tblLayoutPanel.Name = "tblLayoutPanel";
            tblLayoutPanel.RowCount = 1;
            tblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 218F));
            tblLayoutPanel.Size = new Size(294, 218);
            tblLayoutPanel.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(usernameBox);
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(passwordBox);
            flowLayoutPanel2.Controls.Add(Spacertxt);
            flowLayoutPanel2.Controls.Add(SignInbtn);
            flowLayoutPanel2.Controls.Add(SignUpbtn);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(44, 4);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.RightToLeft = RightToLeft.No;
            flowLayoutPanel2.Size = new Size(205, 210);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(220, 221, 225);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(220, 221, 225);
            label2.Location = new Point(3, 51);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 14;
            label2.Text = "Password";
            // 
            // Spacertxt
            // 
            Spacertxt.AutoSize = true;
            Spacertxt.Location = new Point(3, 102);
            Spacertxt.Name = "Spacertxt";
            Spacertxt.Size = new Size(0, 20);
            Spacertxt.TabIndex = 13;
            // 
            // SignInbtn
            // 
            SignInbtn.BackColor = Color.FromArgb(47, 54, 64);
            SignInbtn.ForeColor = Color.FromArgb(220, 221, 225);
            SignInbtn.Location = new Point(3, 126);
            SignInbtn.Margin = new Padding(3, 4, 3, 4);
            SignInbtn.Name = "SignInbtn";
            SignInbtn.Size = new Size(199, 30);
            SignInbtn.TabIndex = 12;
            SignInbtn.Text = "Sign In";
            SignInbtn.UseVisualStyleBackColor = false;
            SignInbtn.Click += SignInButtonClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 12);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 5;
            // 
            // Welcomelbl
            // 
            Welcomelbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Welcomelbl.AutoSize = true;
            Welcomelbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Welcomelbl.ForeColor = Color.FromArgb(220, 221, 225);
            Welcomelbl.Location = new Point(14, 12);
            Welcomelbl.Name = "Welcomelbl";
            Welcomelbl.Size = new Size(278, 32);
            Welcomelbl.TabIndex = 15;
            Welcomelbl.Text = "Welcome, please log in";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(294, 270);
            Controls.Add(Welcomelbl);
            Controls.Add(label3);
            Controls.Add(tblLayoutPanel);
            Margin = new Padding(2, 2, 2, 2);
            Name = "LoginForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            tblLayoutPanel.ResumeLayout(false);
            tblLayoutPanel.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameBox;
        private TextBox passwordBox;
        private LinkLabel SignUpbtn;
        private TableLayoutPanel tblLayoutPanel;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private Label Spacertxt;
        private Button SignInbtn;
        private Label label3;
        private Label Welcomelbl;
    }
}