namespace CryptographyTeachingTool.Help
{
    partial class HelpForm
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
            components = new System.ComponentModel.Container();
            bindingSource1 = new BindingSource(components);
            flowLayoutPanel = new FlowLayoutPanel();
            userInput = new TextBox();
            Sendbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(14, 16);
            flowLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel.Name = "flowLayoutPanel1";
            flowLayoutPanel.Size = new Size(417, 411);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;
            // 
            // userInput
            // 
            userInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userInput.Location = new Point(14, 435);
            userInput.Margin = new Padding(3, 4, 3, 4);
            userInput.Name = "userInput";
            userInput.Size = new Size(347, 27);
            userInput.TabIndex = 1;
            // 
            // Sendbtn
            // 
            Sendbtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Sendbtn.Location = new Point(368, 435);
            Sendbtn.Margin = new Padding(3, 4, 3, 4);
            Sendbtn.Name = "Sendbtn";
            Sendbtn.Size = new Size(63, 31);
            Sendbtn.TabIndex = 2;
            Sendbtn.Text = "Send";
            Sendbtn.UseVisualStyleBackColor = true;
            Sendbtn.Click += SendButtonClick;
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 481);
            Controls.Add(Sendbtn);
            Controls.Add(userInput);
            Controls.Add(flowLayoutPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HelpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HelpForm";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource bindingSource1;
        private FlowLayoutPanel flowLayoutPanel;
        private TextBox userInput;
        private Button Sendbtn;
    }
}