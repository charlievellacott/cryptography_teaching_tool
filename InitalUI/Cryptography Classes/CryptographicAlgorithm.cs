using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Web;
namespace CryptographyTeachingTool.Cryptography
{
    public class CryptographicAlgorithm
    {
        /// <summary>
        /// This is a parent class to all algorithms that I will have a demo on. 
        /// The class will contain methods for all generic and frequently used computations,
        /// for example XORs on binary arrays or converting denary to hexadecimal. 
        /// Therefore, all algorithms will inherit from it and be able to access or override certain
        /// methods to improve code reusability and maintainability.
        /// </summary>

        // The following constants are values used in general cryptographic algorithms. They are stored as constants
        // to provide a placeholder or identifier for the value and a central place to store the value.
        protected int BITS_PER_HEX_DIGIT = 4;
        protected int BITS_PER_BYTE = 8;
        protected ulong MAX_NUMERIC_VAL = 10; // this is the threashold for hexadecimal where numbers are no longer used (eg 10 = A)
        protected ulong NUMBER_TO_ALPHA_ASCII_SHIFT = 87; // eg 10 + 87 = the letter A (as above)
        protected int LOWERCASE_LOWER_BOUND = 97;   // These demonstrate the bounds for the ASCII 
        protected int LOWERCASE_UPPER_BOUND = 122;  // values of uppercase and lowercase symbols
        protected int UPPERCASE_LOWER_BOUND = 65;
        protected int UPPERCASE_UPPER_BOUND = 90;

        public CryptographicAlgorithm()
        {

        }

        public interface IHashingAlgorithm
        {
            // This interface creates a Hash method for hashing classes that inherit from this,
            // like the SHA-256 class.
            string Hash(string input);
        }

        public virtual string Encrypt(int key, string plainText)
        {
            // This method will be overridden by child classes to run their own version,
            // ultimately returning the text encrypted. 
            return "";
        }

        public virtual string Decrypt(int key, string cipherText)
        {
            // This method calls the Encrypt method with a negative key, because most decryption processes
            // are simply the same as encryption but with the key being used in a reverse manner.
            // This method can be overridden.
            return Encrypt(-key, cipherText);
        }


        // All numbers are represented using the type ulong to avoid conversion errors during bitwise
        // operations. This is memory inefficient however completely nessisary to ensure the correct 
        // result is achieved.

        protected ulong[] AND(ulong[] a, ulong[] b)
        {
            // This is a stock cryptography process and thus the method performs an AND operation between two ulong arrays.
            // Both arrays will only ever contain 1s and 0s in each index, but is of type ulong to prevent conversion errors
            // later in, for example, the hashing algorithm.
            ulong[] result = new ulong[a.Length];
            for (int i = 0; i < a.Length; i++)
            {

                result[i] = AND(a[i], b[i]);
            }
            return result;
        }

        protected ulong AND(ulong a, ulong b)
        {
            // This overload of AND takes two ulongs as opposed to a list of them.
            // It simply performs an AND operation between the two.
            if ((a == 1) && (b == 1)) { return 1; }
            else { return 0; }
        }

        protected int[] OR(int[] a, int[] b)
        {
            // This is a stock cryptography process and thus the method performs an OR operation between two ulong arrays.
            // Both arrays will only ever contain 1s and 0s in each index, but is of type ulong to prevent conversion errors
            // later in, for example, the hashing algorithm.
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {

                result[i] = OR(a[i], b[i]);
            }
            return result;
        }

        protected int OR(int a, int b)
        {
            // This overload of OR takes two ulongs as opposed to a list of them.
            // It simply performs an OR operation between the two.
            if ((a == 1) || (b == 1)) { return 1; }
            else { return 0; }
        }

        protected ulong[] XOR(ulong[] a, ulong[] b)
        {
            // This is a stock cryptography process and thus the method performs an XOR operation between two ulong arrays.
            // Both arrays will only ever contain 1s and 0s in each index, but is of type ulong to prevent conversion errors
            // later in, for example, the hashing algorithm.
            ulong[] result = new ulong[a.Length];
            for (int i = 0; i < a.Length; i++)
            {

                result[i] = XOR(a[i], b[i]);
            }
            return result;
        }

        protected ulong XOR(ulong a, ulong b)
        {
            // This overload of XOR takes two ulongs as opposed to a list of them.
            // It simply performs an XOR operation between the two.
            if ((a == 1) && (b == 1)) { return 0; }
            else if ((a == 0) && (b == 0)) { return 0; }
            else { return 1; }
        }

        protected string XOR(string ascii, string key)
        {
            // This overload of XOR takes two strings where each character is only a 1 or 0. 
            // This method has been created specifically for cryptography processes such as the Vernam Cipher,
            // where ascii values are XORed with a key.
            string result = "";
            for (int i = 0; i < ascii.Length; i++)
            {
                if (ascii[i] != key[i])
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        protected ulong[] NOT(ulong[] a)
        {
            // This is a stock cryptography process and thus the method performs a NOT operation on every bit in a ulong array.
            // The array will only ever contain 1s and 0s in each index, but is of type ulong to prevent conversion errors
            // later in, for example, the hashing algorithm.
            ulong[] result = new ulong[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = NOT(a[i]);
            }
            return result;
        }

        protected ulong NOT(ulong a)
        {
            // This overload of NOT takes asingle ulong as opposed to a list of them.
            // It simply performs an OR operation on it.
            if (a == 1) { return 0; }
            else { return 1; }
        }

        protected ulong[] IntToBin(ulong x, int length)
        {
            // This method is used to convert a positive integer to a binary value.
            // It takes a value to convert and then a number of bits to express it with.
            // The method does not use a sign convention - only positive values are represented.
            ulong[] bin = new ulong[length];

            for (int i = length - 1; i >= 0; i--)
            {
                bin[i] = x % 2;
                x = x / 2;
            }

            return bin;
        }

        protected ulong BinToInt(ulong[] bin)
        {
            // This method converts an binary array of any given length to a single ulong (positive)
            // value. The value can only ever be positive.
            ulong x = 0;
            int length = bin.Length;

            for (int i = 0; i < length; i++)
            {
                x += bin[i] * Convert.ToUInt64(Math.Pow(2, length - 1 - i));
            }

            return x;
        }

        protected ulong[] HexToBin(string hex)
        {
            // This method is used to convert a string of any number of hexadecimal digits to an unsigned binary array.
            ulong[] bits = new ulong[hex.Length * BITS_PER_HEX_DIGIT]; // one hex val is 4 bits
            for (int i = 0; i < hex.Length; i++)
            {
                ulong val = Convert.ToUInt64(hex[i].ToString(), 16);
                ulong[] binVal = IntToBin(val, BITS_PER_HEX_DIGIT);

                for (int j = 0; j < BITS_PER_HEX_DIGIT; j++)
                {
                    bits[i * BITS_PER_HEX_DIGIT + j] = binVal[j];
                }
            }
            return bits;
        }

        protected string BinToHex(ulong[] bin)
        {
            // This method is used to convert an unsigned binary array of any given length
            // into a string of hexadecimal digits which represent the value of the binary array.
            string hex = "";
            for (int i = 0; i < bin.Length; i += BITS_PER_HEX_DIGIT) // asumes its a mult of 4
            {
                ulong[] bits = new ulong[BITS_PER_HEX_DIGIT];
                for (int j = 0; j < BITS_PER_HEX_DIGIT; j++)
                {
                    bits[j] = bin[i + j];
                }

                ulong val = BinToInt(bits);

                if (val >= MAX_NUMERIC_VAL)
                {
                    ulong asciiVal = val + NUMBER_TO_ALPHA_ASCII_SHIFT;
                    hex += Convert.ToChar(asciiVal);
                }

                else { hex += val.ToString(); }
            }

            return hex;
        }

        protected char BinaryToChar(string binary)
        {
            // This method is used to convert an unsigned binary array of 8 chars 
            // into a single character, based on its ASCII code.
            int result = 0;
            int columnValue = 1;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                result += (columnValue * Convert.ToInt16(binary[i]));
                columnValue = columnValue * 2;
            }
            return Convert.ToChar(result);
        }

    }
}