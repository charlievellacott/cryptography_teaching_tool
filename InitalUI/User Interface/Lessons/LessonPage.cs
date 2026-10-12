using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Data.SqlClient;
using System.Speech.Synthesis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.Data.Repositories;

namespace CryptographyTeachingTool.UI.Basic
{
    public partial class LessonPage : NavigationalPagesTemplate
    {
        /// <summary>
        /// This class inherits from the GeneralForms class. There will be 
        /// many pages that will need a back button and a flow layout panel in the same space,
        /// for example a lesson on the Caesar Cipher. Similarly to the GeneralForms class this is a 
        /// parent to many different lesson screens (this could in include viewing the syllabus or a lesson).
        /// </summary>

        private Lesson lesson; // This lesson object stores the details to be displayed on the page
        private SpeechSynthesizer synth = new SpeechSynthesizer();  // The synth attribute is used to store and object of
                                                                    // type SpeechSynthesizer which is later used to read the 
                                                                    // text out loud.
        public LessonPage(User user, Lesson lesson, string level) : base(user, level, false)
        {
            // This is the only constructor for this page, it is used to add lesson information based on the lessonID given.
            this.lesson = lesson;
            this.lesson = LessonRepo.GetLessonByID(lesson.lessonID);
            AddComponents();
            DisplayLesson(lesson.text, lesson.workPrompt);
            if (!lesson.imageData.IsNullOrEmpty())
            {
                AddImage(lesson.imageData);
            }
        }

        private void AddImage(byte[] imageData)
        {
            // This method is used to load and add an image to the lesson page when given the image in a byte array. 
            // It does this in a manner that ensures the thread does not freeze.
            using (var ms = new MemoryStream(imageData))
            {
                PictureBox picture = new PictureBox();
                picture.Image = Image.FromStream(ms);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.Width = flowLayoutPanel.ClientSize.Width - 30;
                picture.Height = 300;
                picture.Margin = new Padding(10);
                picture.Dock = DockStyle.Top;

                flowLayoutPanel.Controls.Add(picture);
            }
        }

        private void AddComponents()
        {
            // This method is used to initalize a flowlayout pannel before initalizing the rest of the window.
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = lesson.title;
            flowLayoutPanel.Controls.Clear();
            InitializeComponent();
        }

        private void TextToSpeech(object sender, EventArgs e)
        {
            // This method is called when the text to speech button is pressed and reads the text on the page asynchronously.
            synth.SpeakAsyncCancelAll(); // prevents having multiple voices at once
            synth.SpeakAsync(lesson.text); // this async version prevents the thread from
                                    // freezing so the user can stop the synthesizer
        }

        private void StopSpeech(object sender, EventArgs e)
        {
            // This method is called when the stop button is pressed, and resultingly stops the voice from speaking.
            synth.SpeakAsyncCancelAll();
        }   
    }
}
