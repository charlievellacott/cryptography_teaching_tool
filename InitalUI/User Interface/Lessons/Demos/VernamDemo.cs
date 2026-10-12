using CryptographyTeachingTool.MainClasses;
using CryptographyTeachingTool;
using CryptographyTeachingTool.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptographyTeachingTool.Cryptography.Ciphers;

namespace CryptographyTeachingTool.UI.Demonstrations
{
    public partial class VernamDemo : DemosBasePage
    {
        private int MAX_ASCII_VAL = 127;
        private char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        public VernamDemo(User user) : base(user)
        {
            InitializeComponent();
        }

        private void EncryptClick(object sender, EventArgs e)
        {
            // This method first validates the users input (looking at the number of chars
            // in the key and the ascii codes for each char) then displays the result of
            // performing the vernam ciphers Encrypt method on the two

            string plainText = PlainTextBox.Text;
            string key = Keybox.Text;
            bool ValidChars = true;
            List<char> invalid = new List<char>();
            foreach (char c in plainText)
            {
                if (Convert.ToInt16(c) > MAX_ASCII_VAL)
                {
                    invalid.Add(c);
                    ValidChars = false;
                }
            }

            if (ValidChars)
            {
                if (plainText.Length != key.Length && key.Length != 0) // adds the case that the user wants the key automatically made
                {
                    MessageBox.Show($"The key's length and plaintext's length do not match");
                }
                else if (key.Length == 0)
                {
                    // Auto generate the key before performing the operation

                    VernamCipher vernam = new VernamCipher();
                    int[] arrayKey = vernam.GenerateKey(plainText);
                    string result = vernam.Encrypt(arrayKey, plainText);
                    key = string.Concat(arrayKey.Select(x => Convert.ToChar(x)));
                    Keybox.Text = key;
                    CipherTextBox.Text = result;
                }
                else
                {
                    // Convert the user entered key into the correct form before running
                    int[] ints = new int[key.Length];
                    for (int i = 0; i < ints.Length; i++)
                    {
                        ints[i] = (int)key[i];
                    }
                    VernamCipher vernam = new VernamCipher();
                    string result = vernam.Encrypt(ints, plainText); // currently returns string not binary
                    CipherTextBox.Text = result;
                }
            }
            else
            {
                MessageBox.Show("Only enter letters or numbers, no special characters.\n" +
                        "This is because they are stored using unicode which is 32bit, and this demo works on 8 bit numbers.\n" +
                        "The following character(s) are invalid:\n" +
                        $"{String.Join(',', invalid)}");
            }

        }

        private void DecryptClick(object sender, EventArgs e)
        {
            string cipherText = (CipherTextBox.Text).ToLower();
            string key = Keybox.Text;
            if (cipherText.Length != key.Length)
            {
                MessageBox.Show("The key's length and plaintext's length do not match.");
            }
            else if (cipherText.Length % 2 != 0)
            {
                MessageBox.Show("The cipher text must have an even number of characters."); // this is to ensure that the hexadecimal chars pair up to make a multiple of 8 bits thus ascii code
            }
            else
            {
                bool accept = true;
                List<char> invalid = new List<char>();
                foreach (char C in cipherText) // check each char is a hexadecimal symbol before accepting
                {
                    if (!hexDigits.Contains(C))
                    {
                        accept = false;
                        invalid.Add(C);
                    }
                }
                if (accept == false)
                {
                    MessageBox.Show("Only enter hexadecimal in the cipher text box.\n" +
                    "The following character(s) are invalid:\n" +
                    $"{String.Join(',', invalid)}");
                }
                else
                {
                    int[] ints = new int[key.Length];
                    for (int i = 0; i < ints.Length; i++)
                    {
                        ints[i] = (int)key[i];
                    }
                    VernamCipher vernam = new VernamCipher();
                    string result = vernam.Decrypt(ints, cipherText);
                    PlainTextBox.Text = result;
                }
            }
        }

    }
}
