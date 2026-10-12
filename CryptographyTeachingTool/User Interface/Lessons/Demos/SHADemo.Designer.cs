namespace CryptographyTeachingTool.UI.Demonstrations
{
    partial class SHADemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHADemo));
            label3 = new Label();
            HashTextBox = new TextBox();
            PlainTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            HashBtn = new Button();
            label5 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(446, 49);
            label3.Name = "label3";
            label3.Size = new Size(438, 20);
            label3.TabIndex = 4;
            label3.Text = "Here is the hashed text.";
            // 
            // HashTextBox
            // 
            HashTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HashTextBox.BackColor = Color.FromArgb(47, 54, 64);
            HashTextBox.Font = new Font("Segoe UI", 14.25F);
            HashTextBox.ForeColor = Color.FromArgb(220, 221, 225);
            HashTextBox.Location = new Point(446, 73);
            HashTextBox.Margin = new Padding(3, 4, 3, 4);
            HashTextBox.Multiline = true;
            HashTextBox.Name = "HashTextBox";
            HashTextBox.Size = new Size(438, 222);
            HashTextBox.TabIndex = 3;
            // 
            // PlainTextBox
            // 
            PlainTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlainTextBox.BackColor = Color.FromArgb(47, 54, 64);
            PlainTextBox.Font = new Font("Segoe UI", 14.25F);
            PlainTextBox.ForeColor = Color.FromArgb(220, 221, 225);
            PlainTextBox.Location = new Point(3, 73);
            PlainTextBox.Margin = new Padding(3, 4, 3, 4);
            PlainTextBox.Multiline = true;
            PlainTextBox.Name = "PlainTextBox";
            PlainTextBox.Size = new Size(437, 222);
            PlainTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Location = new Point(3, 49);
            label2.Name = "label2";
            label2.Size = new Size(437, 20);
            label2.TabIndex = 1;
            label2.Text = "Please use the text box below to enter your plaintext to hash.";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(437, 42);
            label1.TabIndex = 0;
            label1.Text = "Welcome to the SHA-256 Demo...";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(446, 4);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(438, 0);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(PlainTextBox, 0, 2);
            tableLayoutPanel1.Controls.Add(HashTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Location = new Point(14, 16);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.242424F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 268F));
            tableLayoutPanel1.Size = new Size(887, 568);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(HashBtn, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(446, 303);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 27.7777786F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 27.7777786F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 44.4444427F));
            tableLayoutPanel3.Size = new Size(438, 261);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // HashBtn
            // 
            HashBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HashBtn.BackColor = Color.FromArgb(47, 54, 64);
            HashBtn.Dock = DockStyle.Fill;
            HashBtn.ForeColor = Color.FromArgb(220, 221, 225);
            HashBtn.Location = new Point(3, 4);
            HashBtn.Margin = new Padding(3, 4, 3, 4);
            HashBtn.Name = "HashBtn";
            HashBtn.Size = new Size(432, 64);
            HashBtn.TabIndex = 5;
            HashBtn.Text = "Hash";
            HashBtn.UseVisualStyleBackColor = false;
            HashBtn.Click += HashButtonClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 299);
            label5.Name = "label5";
            label5.Size = new Size(437, 204);
            label5.TabIndex = 13;
            label5.Text = resources.GetString("label5.Text");
            // 
            // SHADemo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(914, 600);
            Controls.Add(tableLayoutPanel1);
            ForeColor = SystemColors.ButtonHighlight;
            Margin = new Padding(3, 4, 3, 4);
            Name = "SHADemo";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CipherDemo";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private NumericUpDown KeySelector;
        private Label label3;
        private TextBox HashTextBox;
        private TextBox PlainTextBox;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Button Decrypt;
        private Button HashBtn;
        private Label label5;
    }
}