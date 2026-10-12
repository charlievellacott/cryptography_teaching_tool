using CryptographyTeachingTool.Cryptography;
using CryptographyTeachingTool.Cryptography.Ciphers;
using CryptographyTeachingTool.Help;
using CryptographyTeachingTool.MainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyTeachingTool.UI.Demonstrations
{
    public partial class CaesarDemo : DemosBasePage
    {
        public CaesarDemo(User user) : base(user)
        {
            InitializeComponent();
        }

        private void EncryptButtonClick(object sender, EventArgs e)
        {
            // This method gets the key and plain text a user entered and displays the result of
            // running the Encrypt method for the caesar cipher object
            try
            {
                string plainText = PlainTextBox.Text;
                int key = Convert.ToInt32(KeySelector.Value);
                CaesarCipher caesar = new CaesarCipher();
                string result = caesar.Encrypt(key, plainText);
                CipherTextBox.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }

        private void DecryptButtonClick(object sender, EventArgs e)
        {
            // This method gets the key and cipher text a user entered and displays the result of
            // running the Decrypot method for the caesar cipher object
            try
            {
                string plainText = CipherTextBox.Text;
                int key = Convert.ToInt32(KeySelector.Value);
                CaesarCipher caesar = new CaesarCipher();
                string result = caesar.Decrypt(key, plainText);
                PlainTextBox.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }
    }
}
