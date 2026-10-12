using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CryptographyTeachingTool.Help
{
    internal class ChatBot
    {
        /// <summary>
        /// This class will be used for making calls to OpenAI’s LLM API. When creating an instance 
        /// of the object a connection will be established using a securely stored API key, then the getResponse method
        /// may be called with the query as an input. 
        /// This class will be defined as an async class, which will mean that the thread will not freeze during the API call.
        /// </summary>

        private ChatClient chatClient; // This attribute stores OpenAI's ChatClient object (which serves as
                                       // a link between their LLM and my code)
        
        // The WELCOME_MESSAGE constant defines what is to be displayed on the user's screen as they first open the application.
        private string WELCOME_MESSAGE = "Hello, Welcome to the help page. I am an expert in all things cryptography related. " +
            "Please ask any questions you have here and I will answer them. " +
            "I can also suggest articles or YouTube videos to watch - just ask!";

        // This PATH directs the program to the location of the txt file with the API key inside.
        // It serves as a method of securely storing the key.
        private string PATH = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Help Page",
            "APIKey.txt"
        );

        public ChatBot()
        {
            // This constructor is used to initialize the chat bot and create a ChatClient object,
            // as per OpenAI's API.
            string apiKey = GetAPIKey();
            chatClient = new(model: "gpt-5-nano", apiKey: apiKey); // this creates a connection with the cheapest model (being gpt5nano)
        }

        public string GetWelcomeMessage()
        {
            return WELCOME_MESSAGE;
        }
        private string GetAPIKey() 
        {
            // This method is used to securely get the api key which is securely stored in
            // a given path. The key is not stored as plain text in a variable because this 
            // could allow others to get hold of and abuse the key.
            using (StreamReader sr = new StreamReader(PATH, false))
            {
                string line = sr.ReadLine();
                if (line == null) { return ""; }
                else { return line; }
            }
        }

        public async Task<string> GetResponse(string input)
        {
            // This method creates an api call to obtain the LLM's response, given a message as input.
            // It has been defined as async because it prevents the thread from being frozen during api calls.
            // This is cruital as API calls to this particual service can be slow and computationally intesive.

            if (input == "") { return "You did not say anything"; }
            var result = await chatClient.CompleteChatAsync(input); // this gets the response with await preventing the thread being frozen during the process

            var completion = result.Value;
            string reply = "(no reply)";
            if (completion.Content != null && completion.Content.Count > 0) // checks the reponse
            {
                reply = completion.Content[0].Text;
            }
            
            return reply;
        }
    }

}

