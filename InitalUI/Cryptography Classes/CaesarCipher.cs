using CryptographyTeachingTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.Cryptography.Ciphers
{
    public class CaesarCipher : CryptographicAlgorithm
    {
        /// <summary>
        /// I will be using polymorphism to override the CryptographicAlgorithm classes encrypt
        /// and decrypt methods with this shift cipher. The class will be used in the demos to
        /// for encrypting and decrypting strings when given a key.
        /// </summary>

        // Constants
        private int ALPHABET_LENGTH = 26;
        public override string Encrypt(int key, string plainText)
        {
            // This static method is used to process and string of text and key.
            // The original Encrypt method is overridden.
            // It performs a Caesar cipher on the string, shifting each char the given
            // number of places in the alphabet. The result is returned as a string.
            // Note: any symbols (such as punctuation) are not shifted but instead left in their place.
            // This is because the symbols do not have a native alphabet and would still be convient
            // to be represented by this cipher.
            key = ((key % ALPHABET_LENGTH) + ALPHABET_LENGTH) % ALPHABET_LENGTH; // a massive key is an issue (when going from a-z) therefore can be simplified
            bool isNegativeKey = false; // this var ensures that the code works for negative keys
            if (key < 0)
            {
                isNegativeKey = true;
            }
            int length = plainText.Length;
            char[] plainTextArray = plainText.ToArray(); // this is an array where each item is a char in the plain text
            int[] asciiArray = new int[length]; // this array will later contain the ascii values of certain characters
            int[] nonAlpha = new int[length]; // this array will contain all nonalpha characters which shouldn't be shifted
            string cipherText = "";

            for (int i = 0; i < length; i++) // creates the shifted ascii array and the non alpha array
            {
                int currentASCII = Convert.ToInt16(plainTextArray[i]);
                if ((currentASCII >= LOWERCASE_LOWER_BOUND && currentASCII <= LOWERCASE_UPPER_BOUND) || (currentASCII >= UPPERCASE_LOWER_BOUND && currentASCII <= UPPERCASE_UPPER_BOUND))
                {
                    int shiftedVal = currentASCII + key; // this stores the shifted values
                    if (currentASCII >= UPPERCASE_LOWER_BOUND && currentASCII <= UPPERCASE_UPPER_BOUND)
                    {
                        if (shiftedVal > UPPERCASE_UPPER_BOUND)
                            shiftedVal = shiftedVal - ALPHABET_LENGTH;
                    }
                    else if (currentASCII >= LOWERCASE_LOWER_BOUND && currentASCII <= LOWERCASE_UPPER_BOUND)
                    {
                        if (shiftedVal > LOWERCASE_UPPER_BOUND)
                            shiftedVal = shiftedVal - ALPHABET_LENGTH;
                    }

                    asciiArray[i] = shiftedVal;
                }
                else
                {
                    nonAlpha[i] = currentASCII;
                    asciiArray[i] = -1;
                }
            }

            for (int i = 0; i < length; i++) // places the two lists back together, converts back to a char
                                             // and then concatenates to a var called cipher text
            {
                if (asciiArray[i] == -1)
                {
                    asciiArray[i] = nonAlpha[i];
                }
                cipherText = cipherText + Convert.ToChar(asciiArray[i]);
            }

            return cipherText;
        }
    }

}
