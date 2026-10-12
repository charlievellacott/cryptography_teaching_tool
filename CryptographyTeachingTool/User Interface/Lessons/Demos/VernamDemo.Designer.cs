namespace CryptographyTeachingTool.UI.Demonstrations
{
    partial class VernamDemo
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
            tableLayoutPanel3 = new TableLayoutPanel();
            Decrypt = new Button();
            button2 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label4 = new Label();
            Keybox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            PlainTextBox = new TextBox();
            CipherTextBox = new TextBox();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(PlainTextBox, 0, 2);
            tableLayoutPanel1.Controls.Add(CipherTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 1, 1);
            tableLayoutPanel1.Location = new Point(17, 20);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.02834F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3603239F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 67.6113358F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 297F));
            tableLayoutPanel1.Size = new Size(1109, 710);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(Decrypt, 0, 1);
            tableLayoutPanel3.Controls.Add(button2, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(558, 417);
            tableLayoutPanel3.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 27.7777786F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 27.7777786F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 44.4444427F));
            tableLayoutPanel3.Size = new Size(547, 288);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // Decrypt
            // 
            Decrypt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Decrypt.BackColor = Color.FromArgb(47, 54, 64);
            Decrypt.Dock = DockStyle.Fill;
            Decrypt.ForeColor = Color.FromArgb(220, 221, 225);
            Decrypt.Location = new Point(4, 85);
            Decrypt.Margin = new Padding(4, 5, 4, 5);
            Decrypt.Name = "Decrypt";
            Decrypt.Size = new Size(539, 70);
            Decrypt.TabIndex = 6;
            Decrypt.Text = "Decrypt";
            Decrypt.UseVisualStyleBackColor = false;
            Decrypt.Click += DecryptClick;
            // 
            // button2
            // 
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackColor = Color.FromArgb(47, 54, 64);
            button2.Dock = DockStyle.Fill;
            button2.ForeColor = Color.FromArgb(220, 221, 225);
            button2.Location = new Point(4, 5);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(539, 70);
            button2.TabIndex = 5;
            button2.Text = "Encrypt";
            button2.UseVisualStyleBackColor = false;
            button2.Click += EncryptClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.4712029F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.5287971F));
            tableLayoutPanel2.Controls.Add(label4, 1, 0);
            tableLayoutPanel2.Controls.Add(Keybox, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(4, 417);
            tableLayoutPanel2.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 222F));
            tableLayoutPanel2.Size = new Size(546, 222);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(334, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(208, 222);
            label4.TabIndex = 1;
            label4.Text = "Please enter your key here. If it is left empty the algorithm will make one for you. The key can me any character on your keyboard but must be the same length as the text.";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Keybox
            // 
            Keybox.Dock = DockStyle.Fill;
            Keybox.Location = new Point(4, 5);
            Keybox.Margin = new Padding(4, 5, 4, 5);
            Keybox.Multiline = true;
            Keybox.Name = "Keybox";
            Keybox.Size = new Size(322, 212);
            Keybox.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(546, 78);
            label1.TabIndex = 0;
            label1.Text = "Welcome to the Vernam Demo...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Location = new Point(4, 108);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(546, 25);
            label2.TabIndex = 1;
            label2.Text = "Please use the text box below to enter your plaintext to cipher.";
            // 
            // PlainTextBox
            // 
            PlainTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlainTextBox.BackColor = Color.FromArgb(47, 54, 64);
            PlainTextBox.Font = new Font("Segoe UI", 14.25F);
            PlainTextBox.ForeColor = Color.FromArgb(220, 221, 225);
            PlainTextBox.Location = new Point(4, 138);
            PlainTextBox.Margin = new Padding(4, 5, 4, 5);
            PlainTextBox.Multiline = true;
            PlainTextBox.Name = "PlainTextBox";
            PlainTextBox.Size = new Size(546, 269);
            PlainTextBox.TabIndex = 2;
            // 
            // CipherTextBox
            // 
            CipherTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CipherTextBox.BackColor = Color.FromArgb(47, 54, 64);
            CipherTextBox.Font = new Font("Segoe UI", 14.25F);
            CipherTextBox.ForeColor = Color.FromArgb(220, 221, 225);
            CipherTextBox.Location = new Point(558, 138);
            CipherTextBox.Margin = new Padding(4, 5, 4, 5);
            CipherTextBox.Multiline = true;
            CipherTextBox.Name = "CipherTextBox";
            CipherTextBox.ReadOnly = false;
            CipherTextBox.Size = new Size(547, 269);
            CipherTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(558, 108);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(547, 25);
            label3.TabIndex = 4;
            label3.Text = "Here is the cipher text.";
            // 
            // VernamDemo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(1143, 750);
            Controls.Add(tableLayoutPanel1);
            ForeColor = SystemColors.ButtonHighlight;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VernamDemo";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CipherDemo";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TextBox PlainTextBox;
        private TextBox CipherTextBox;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel3;
        private Button Decrypt;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private TextBox Keybox;
    }
}