using CryptographyTeachingTool.Help;
using CryptographyTeachingTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool.Cryptography;
using CryptographyTeachingTool.UI.Demonstrations;
using CryptographyTeachingTool.Cryptography.Ciphers;

namespace CryptographyTeachingTool.UI.Demos
{
    public partial class RailfenceDemo : DemosBasePage
    {

        public RailfenceDemo(User user) : base(user)
        {
            InitializeComponent();
        }

        private void EncryptButtonClick(object sender, EventArgs e)
        {
            // This method gets the key and plain text a user entered and displays the result of
            // running the Encrypt method for the railfense cipher object

            try
            {
                string plainText = PlainTextBox.Text;
                int key = Convert.ToInt32(numericUpDown.Value);
                if (key <= 1)
                {
                    MessageBox.Show("Enter a key that is greater than 1");
                }
                else
                {
                    RailFenceCipher rail = new RailFenceCipher();
                    string result = rail.Encrypt(key, plainText);
                    CipherTextBox.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }

        private void DecryptButtonClick(object sender, EventArgs e)
        {
            // This method gets the key and plain text a user entered and displays the result of
            // running the Decrypt method for the railfence cipher object

            try
            {
                string plainText = CipherTextBox.Text;
                int key = Convert.ToInt32(numericUpDown.Value);
                if (key <= 1)
                {
                    MessageBox.Show("Enter a key that is greater than 1");
                }
                else
                {
                    RailFenceCipher rail = new RailFenceCipher();
                    string result = rail.Decrypt(key, plainText);
                    PlainTextBox.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }
    }

}
