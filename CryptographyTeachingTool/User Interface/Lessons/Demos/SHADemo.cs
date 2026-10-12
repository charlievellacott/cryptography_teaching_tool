using CryptographyTeachingTool.MainClasses;
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
using CryptographyTeachingTool.Cryptography.Hash;

namespace CryptographyTeachingTool.UI.Demonstrations
{
    public partial class SHADemo : DemosBasePage
    {
        public SHADemo(User user) : base(user)
        {
            InitializeComponent();
        }

        private void HashButtonClick(object sender, EventArgs e)
        {
            // This method gets the key and plain text a user entered and displays the result of
            // running the Hash method for the SHA256Hash object

            try
            {
                string plainText = PlainTextBox.Text;
                SHA256Hash SHA = new SHA256Hash();
                string result = SHA.Hash(plainText);
                HashTextBox.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There has been an error:\n{ex.Message}");
            }
        }
    }

}
