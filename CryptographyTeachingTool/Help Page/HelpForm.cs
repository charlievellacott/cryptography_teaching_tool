using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyTeachingTool.Help
{
    public partial class HelpForm : Form
    {
        private ChatBot bot;
        public HelpForm()
        {
            InitializeComponent();
            bot = new ChatBot(); // creates the help bot object
            flowLayoutPanel.Controls.Add(CreateBubble(bot.GetWelcomeMessage(), false)); // add the welcome message to the screen
        }

        private async void SendButtonClick(object sender, EventArgs e) // async because it prevents the thread from being frozen during api calls
        {
            // This async method calls the GetResponse method of the ChatBot class
            // it also displays the users input and the reply from the LLM
            string input = userInput.Text;
            userInput.Text = ""; // clears the text box

            flowLayoutPanel.Controls.Add(CreateBubble(input, true)); // add the message to the screen
            string response = await bot.GetResponse(input); // get the reponse
            flowLayoutPanel.Controls.Add(CreateBubble(response, false)); // add the response to the screen
        }
        
        private Panel CreateBubble(string message, bool isUserMessage)
        {
            // This method is used to create display any text message.
            // It uses blue for the user's messages and grey for the bot's

            Label label = new Label();
            label.Text = message;
            label.AutoSize = true;
            label.MaximumSize = new Size(400, 0);
            if (isUserMessage) { label.BackColor = Color.LightBlue; }
            else { label.BackColor = Color.LightGray; }
            label.Padding = new Padding(10);
            label.Margin = new Padding(5);
            label.Font = new Font("Segoe UI", 10);

            Panel bubble = new Panel();
            bubble.AutoSize = true;
            bubble.Controls.Add(label);
            bubble.Dock = DockStyle.Top;

            return bubble;
        }
    }
}
