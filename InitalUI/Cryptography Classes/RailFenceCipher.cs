using CryptographyTeachingTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.Cryptography.Ciphers
{
    public class RailFenceCipher : CryptographicAlgorithm
    {
        /// <summary>
        /// The CryptographicAlgorithm will be a parent to this class. 
        /// Railfence is a transposition cipher that will need its own methods 
        /// therefore extra will be added into this class.
        /// </summary>

        public override string Encrypt(int key, string plainText)
        {
            // This static method overrides the original Encrypt method in CryptographicAlgorithm.
            // It is used to perform a railfence cipher on a string using a given key.
            // The result is returned as a single string.

            char[,] matrix = new char[key, plainText.Length]; // the matrix is created where the number of columns
                                                              // equals the length of the plain text and the number
                                                              // of rows equals the key

            int row = 0; // this is needed to keep track of the current row for each stage
            bool isDecreasing = true;
            for (int column = 0; column < plainText.Length; column++) // We interate through the columns (thus the plain text)
            {
                matrix[row, column] = plainText[column]; // the letter is placed in the appropriate cell

                if (row == key - 1) // if on the bottom row then begin going back up
                {
                    isDecreasing = false; 
                }
                else if (row == 0) // if on the top row then begin going back down
                {
                    isDecreasing = true;
                }

                // Alter the row based on the current direction
                if (isDecreasing)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            // Read the text from left to right and then top to bottom
            string cipherText = "";
            for (row = 0; row < key; row++)
            {
                for (int column = 0; column < plainText.Length; column++)
                {
                    if (matrix[row, column] != '\0')
                    {
                        cipherText += matrix[row, column];
                    }
                }
            }
            return cipherText;
        }

        public override string Decrypt(int key, string cipherText)
        {
            // This static method overrides the original Decrypt method in CryptographicAlgorithm.
            // It then decrypts a cipher text given the key and cipher text as a string.
            // The encryption process is different to the Encrypt process which is why a negative key 
            // cannot be used. The result is returned as a single string.
            
            char[,] matrix = new char[key, cipherText.Length];

            int row = 0;
            bool isDecreasing = true;
            for (int column = 0; column < cipherText.Length; column++)
            {
                // Begin by creating a matrix with the symbol '*' in place of where digits should be
                matrix[row, column] = '*';

                if (row == key - 1)
                {
                    isDecreasing = false;
                }
                else if (row == 0)
                {
                    isDecreasing = true;
                }

                if (isDecreasing)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            // Then replace each '*' with the appropriate letter
            int count = 0;
            for (row = 0; row < key; row++)
            {
                for (int column = 0; column < cipherText.Length; column++)
                {
                    if (matrix[row, column] == '*')
                    {
                        matrix[row, column] = cipherText[count];
                        count++;
                    }
                }
            }

            // Then read in the same zig zag pattern to get the plain text out
            row = 0;
            isDecreasing = true;
            string plainText = "";
            for (int column = 0; column < cipherText.Length; column++)
            {
                plainText += matrix[row, column];

                if (row == key - 1)
                {
                    isDecreasing = false;
                }
                else if (row == 0)
                {
                    isDecreasing = true;
                }

                if (isDecreasing)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            return plainText;
        }
    }

}
