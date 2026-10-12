using CryptographyTeachingTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyTeachingTool.Cryptography.Ciphers
{
    public class VernamCipher : CryptographicAlgorithm
    {
        /// <summary>
        /// This class inherits from the CryptographicAlgorithm class and will use methods
        /// from it relating to XORing strings, converting denary into binary or denary to
        /// hexadecimal. All binary results will be displayed as hexadecimal. 
        /// </summary>

        public int[] GenerateKey(string plainText)
        {
            // This static method is used to generate a random ASCII key of the correct
            // length. It is used when the user does not enter a key.
            Random random = new Random();
            int length = plainText.Length;
            int[] key = new int[length];
            for (int i = 0; i < plainText.Length; i++)
            {
                int k = random.Next(LOWERCASE_LOWER_BOUND, LOWERCASE_UPPER_BOUND);
                key[i] = k;
            }
            return key;
        }

        public string Encrypt(int[] key, string plainText)
        {
            // This static method overrides the original Encrypt method in CryptographicAlgorithm.
            // It is used to perfrom a Vernam cipher on a string. It returns the result in hexadecimal.
            string ConvertToBinary(int denary)
            {
                // This method is used to convert a denary number to binary and 
                // return the result as a string, unlike other conversion methods.
                if (denary == 0)
                {
                    return "00000000";
                }

                string result;
                if (denary == 1) // this ensures that if the denary value 0 is being converted it remains as "0" not ""
                {
                    return "1";
                }
                else
                {
                    result = ConvertToBinary(denary / 2) + Convert.ToString(denary % 2);
                }
                return result.PadLeft(BITS_PER_BYTE, '0'); // ensures the length is 8 bits 
            }

            if (key.Length != plainText.Length)
            {
                return "Key was not the same length as cipher text";
            }

            char[] plainTextArray = plainText.ToArray();
            List<ulong> binResult = new List<ulong>();
            for (int i = 0; i < plainTextArray.Length; i++)
            {
                // This loop goes through each character in the plain text converts it to ASCII,
                // performs an XOR operation on the two and concatenates the result onto the overall
                // plainTextArray for returning

                int PlainTextASCIIValue = Convert.ToInt16(plainTextArray[i]);
                string binaryASCIIValue = ConvertToBinary(PlainTextASCIIValue);
                string k = ConvertToBinary(key[i]);
                string result = XOR(binaryASCIIValue, k);

                foreach (char bit in result) // this concatenates the values onto the binary result list
                {
                    if (bit == '1')
                    {
                        binResult.Add(1);
                    }
                    else
                    {
                        binResult.Add(0);
                    }
                }
            }
            while (binResult.Count % BITS_PER_HEX_DIGIT != 0)
            {
                binResult.Add(0); // pads the array with zeros to ensure the length is a multiple of 4
            }
            ulong[] bitArray = binResult.ToArray();
            return BinToHex(bitArray); // the bit array is converted to hexadecimal and returned
        }

        public string Decrypt(int[] key, string cipherText)
        {
            // This static method overrides the original Decrypt method in CryptographicAlgorithm
            // A negative key cannot be created or used to decrypt the cipher text. Instead a
            // decryption can be done by performing the exact encryption process with the cipher
            // text and the same key.

            // Firstly the hexdecimal must be converted to a string
            ulong[] hexBits = HexToBin(cipherText);
            string cipherTextString = "";

            for (int i = 0; i < hexBits.Length; i += BITS_PER_BYTE) // gets every 8 bits
            {
                string stingOfBitsInByte = "";
                for (int j = 0; j < BITS_PER_BYTE; j++) // adds the 8 bits to the sting
                {
                    stingOfBitsInByte += hexBits[i + j];
                }
                cipherTextString += BinaryToChar(stingOfBitsInByte);
            }

            return Encrypt(key, cipherTextString); // The encryption process is now just the same process
        }
    }
}
