using CryptographyTeachingTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CryptographyTeachingTool.Cryptography.CryptographicAlgorithm;

namespace CryptographyTeachingTool.Cryptography.Hash
{
    public class SHA256Hash : CryptographicAlgorithm, IHashingAlgorithm
    {
        /// <summary>
        /// This algorithm is highly compicated and therefore I will be decomposing
        /// the overall algorithms into many smaller tasks. I will use methods from
        /// the CryptographicAlgorithm class (its parent) to improve the ease of
        /// writing and debugging this algorithm. 
        /// </summary>

        // Constants
        private int N_BITS = 32; // This defines the word length of the algorithm
        // (the number of bits that each process occurs on)

        // The following array of strings contains the round constants used, which
        // are the fractional parts of the cube roots of the first 64 prime numbers.
        // Each value is stored in hexadecimal.
        private static readonly string[] K_CONSTANTS =
        {
            // H0-H7
            "0x428a2f98", "0x71374491", "0xb5c0fbcf", "0xe9b5dba5",
            "0x3956c25b", "0x59f111f1", "0x923f82a4", "0xab1c5ed5",

            // Later vals
            "0xd807aa98", "0x12835b01", "0x243185be", "0x550c7dc3",
            "0x72be5d74", "0x80deb1fe", "0x9bdc06a7", "0xc19bf174",
            "0xe49b69c1", "0xefbe4786", "0x0fc19dc6", "0x240ca1cc",
            "0x2de92c6f", "0x4a7484aa", "0x5cb0a9dc", "0x76f988da",
            "0x983e5152", "0xa831c66d", "0xb00327c8", "0xbf597fc7",
            "0xc6e00bf3", "0xd5a79147", "0x06ca6351", "0x14292967",
            "0x27b70a85", "0x2e1b2138", "0x4d2c6dfc", "0x53380d13",
            "0x650a7354", "0x766a0abb", "0x81c2c92e", "0x92722c85",
            "0xa2bfe8a1", "0xa81a664b", "0xc24b8b70", "0xc76c51a3",
            "0xd192e819", "0xd6990624", "0xf40e3585", "0x106aa070",
            "0x19a4c116", "0x1e376c08", "0x2748774c", "0x34b0bcb5",
            "0x391c0cb3", "0x4ed8aa4a", "0x5b9cca4f", "0x682e6ff3",
            "0x748f82ee", "0x78a5636f", "0x84c87814", "0x8cc70208",
            "0x90befffa", "0xa4506ceb", "0xbef9a3f7", "0xc67178f2"
        };

        // The following array of strings contains the initial hash values, which
        // are the fractional parts of the square roots of the first prime numbers.
        // Each value is stored in hexadecimal.
        private static readonly string[] INITIAL_HASH_VALUES =  // these are H0-7
        {
            "0x6a09e667", "0xbb67ae85", "0x3c6ef372", "0xa54ff53a",
            "0x510e527f", "0x9b05688c", "0x1f83d9ab", "0x5be0cd19"
        };

        // The following constants define various helper constants. They are stored as constants
        // to provide a placeholder or identifier for the value and a central place to store the value.
        private int N_H_VALUES = 8;
        private int N_K_VALUES = 64;
        private int BLOCK_SIZE = 512;
        private int PADDING = 448;
        private int LENGTH_BITS = 64;
        private int HEX_BASE = 16;
        private int TOTAL_ROUNDS = 16;

        // Hash methods
        private ulong[] ROTR(ulong[] a, ulong n)
        {
            // This method is used to rotate a string of bits to the right by a given
            // number of places.
            ulong length = Convert.ToUInt64(a.Length);
            ulong[] result = new ulong[length];

            // shift all bits to the right by n filling in the new spaces with the bits removed
            for (ulong i = 0; i < length; i++)
            {
                result[i] = a[(i + length - n) % length];
            }

            return result;
        }

        private ulong[] SHR(ulong[] a, ulong n)
        {
            // This method is used to shift all of the bits in a binary array to the
            // right by a given number of places the new space is filled with zeros.
            ulong length = Convert.ToUInt64(a.Length);
            ulong[] result = new ulong[length]; // this already allocated the array with zeros

            // shift all bits to the right by n filling in the new spaces with 0
            for (ulong i = 0; i < length - n; i++)
            {
                result[i + n] = a[i];
            }

            return result;
        }

        private ulong MAJ(ulong x, ulong y, ulong z)
        {
            // This method is used to perform a majority operation on three ulongs.
            // The operation can be broken down to:
            // (X AND Y) XOR (X AND Z) XOR (Y AND Z)
            ulong[] xBin = IntToBin(x, N_BITS);
            ulong[] yBin = IntToBin(y, N_BITS);
            ulong[] zBin = IntToBin(z, N_BITS);
            ulong[] a = AND(xBin, yBin);
            ulong[] b = AND(xBin, zBin);
            ulong[] c = AND(yBin, zBin);
            ulong[] result = XOR(XOR(a, b), c);
            return BinToInt(result);
        }

        private ulong CH(ulong x, ulong y, ulong z)
        {
            // This method is used to perfrom a choose operation on three ulongs.
            // The operation can be broken down to:
            // (X AND Y) XOR (NOT X AND Z)
            ulong[] xBin = IntToBin(x, N_BITS);
            ulong[] yBin = IntToBin(y, N_BITS);
            ulong[] zBin = IntToBin(z, N_BITS);
            ulong[] a = AND(xBin, yBin);
            ulong[] b = AND(NOT(xBin), zBin);
            ulong[] result = XOR(a, b);
            return BinToInt(result);
        }

        private ulong SigmaZero(ulong x)
        {
            // This method performs the lowercase sigma zero function unique to the SHA-256 hash
            // The operation can be broken down to:
            // ROTR(X, 7) XOR ROTR(X, 18) XOR SHR(X, 3)
            ulong[] xBin = IntToBin(x, N_BITS);
            ulong[] a = ROTR(xBin, 7);
            ulong[] b = ROTR(xBin, 18);
            ulong[] c = SHR(xBin, 3);
            ulong[] result = XOR(XOR(a, b), c);
            return BinToInt(result);
        }

        private ulong SigmaOne(ulong x)
        {
            // This method performs the lowercase sigma one function unique to the SHA-256 hash.
            // The operation can be broken down to:
            // ROTR(X, 17) XOR ROTR(X, 19) XOR SHR(X, 10)
            ulong[] xBin = IntToBin(x, N_BITS);
            ulong[] a = ROTR(xBin, 17);
            ulong[] b = ROTR(xBin, 19);
            ulong[] c = SHR(xBin, 10);
            ulong[] result = XOR(XOR(a, b), c);
            return BinToInt(result);
        }

        private ulong CapitalSigmaZero(ulong x)
        {
            // This method performs the uppercase sigma one function unique to the SHA-256 hash.
            // The operation can be broken down to:
            // ROTR(X, 2) XOR ROTR(X, 13) XOR SHR(X, 22)
            ulong[] xBin = IntToBin(x, N_BITS);
            ulong[] a = ROTR(xBin, 2);
            ulong[] b = ROTR(xBin, 13);
            ulong[] c = SHR(xBin, 22);
            ulong[] result = XOR(XOR(a, b), c);
            return BinToInt(result);
        }

        private ulong CapitalSigmaOne(ulong x)
        {
            // This method performs the uppercase sigma one function unique to the SHA-256 hash
            // The operation can be broken down to:
            // ROTR(X, 6) XOR ROTR(X, 11) XOR SHR(X, 25)
            ulong[] xBin = IntToBin(x, N_BITS);
            ulong[] a = ROTR(xBin, 6);
            ulong[] b = ROTR(xBin, 11);
            ulong[] c = SHR(xBin, 25);
            ulong[] result = XOR(XOR(a, b), c);
            return BinToInt(result);
        }

        // hashing
        public string Hash(string input)
        {
            // This static method overrides the interface and Hash method of the CryptographicAlgorithm class.
            // It is used to perform the overall hashing process for SHA-256. The result is returned
            // as a hexadecimal value.

            // initalise the hash vals H0-7
            ulong[] H = new ulong[N_H_VALUES];
            for (int i = 0; i < N_H_VALUES; i++)
            {
                H[i] = Convert.ToUInt64(INITIAL_HASH_VALUES[i], HEX_BASE); // uses built in function rather than converting to binary then denary
            }
            // initalise the k constants
            ulong[] K = new ulong[N_K_VALUES];
            for (int i = 0; i < N_K_VALUES; i++)
            {
                K[i] = Convert.ToUInt64(K_CONSTANTS[i], HEX_BASE);
            }

            // convert the input to one ulong binary string
            string binInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                ulong[] binArray = IntToBin(input[i], BITS_PER_BYTE); // 8 bits per char
                foreach (int digit in binArray)
                {
                    binInput += digit;
                }
            }

            // alter length
            int l = binInput.Length;
            int k = (PADDING - ((l + 1) % BLOCK_SIZE) + BLOCK_SIZE) % BLOCK_SIZE;
            binInput += '1';
            for (int i = 0; i < k; i++) // adds padding
            {
                binInput += '0';
            }
            ulong[] lengthInBits = IntToBin(Convert.ToUInt64(l), LENGTH_BITS); // stores the length in the final 64 bits
            foreach (int digit in lengthInBits)
            {
                binInput += digit;
            }

            // split into blocks and words
            int N = binInput.Length / BLOCK_SIZE;
            string[] blocks = new string[N];
            for (int i = 0; i < N; i++)
            {
                blocks[i] = binInput.Substring(i * BLOCK_SIZE, BLOCK_SIZE); // creates the nessisary number of blocks
            }
            ulong[][][] words = new ulong[N][][]; // N blocks, 16 words, 32 bits

            for (int i = 0; i < N; i++) // fills the words array
            {
                words[i] = new ulong[TOTAL_ROUNDS][];
                for (int j = 0; j < TOTAL_ROUNDS; j++)
                {
                    string wordString = blocks[i].Substring(j * N_BITS, N_BITS);
                    words[i][j] = new ulong[N_BITS];

                    for (int bit = 0; bit < N_BITS; bit++)
                    {
                        words[i][j][bit] = Convert.ToUInt64(char.GetNumericValue(wordString[bit])); // convert characters to integers
                    }
                }
            }

            // loop through each block
            for (int i = 0; i < N; i++)
            {
                ulong[] W = new ulong[TOTAL_ROUNDS];
                for (int t = 0; t < TOTAL_ROUNDS; t++) // initalise vals for W
                {
                    if (t >= 0 && t <= 15) // first 15
                    {
                        W[t] = Convert.ToUInt64(BinToInt(words[i][t]));
                    }
                    else if (t >= 16 && t <= 63) // above 15
                    {
                        W[t] = Convert.ToUInt64(SigmaOne(W[t - 2]) + W[t - 7] + SigmaZero(W[t - 15]) + W[t - 16]);
                    }
                }

                // initalise a-h
                ulong a = H[0];
                ulong b = H[1];
                ulong c = H[2];
                ulong d = H[3];
                ulong e = H[4];
                ulong f = H[5];
                ulong g = H[6];
                ulong h = H[7];

                // calculate a to h
                for (int t = 0; t < TOTAL_ROUNDS; t++)
                {
                    ulong TOne = Convert.ToUInt64(h + CapitalSigmaOne(e) + CH(e, f, g)) + K[t] + W[t];
                    ulong TTwo = Convert.ToUInt64(CapitalSigmaZero(a) + MAJ(a, b, c));
                    h = g;
                    g = f;
                    f = e;
                    e = d + TOne;
                    d = c;
                    c = b;
                    b = a;
                    a = TOne + TTwo;
                }

                // add corrosponding a-h onto H0-7
                H[0] += a;
                H[1] += b;
                H[2] += c;
                H[3] += d;
                H[4] += e;
                H[5] += f;
                H[6] += g;
                H[7] += h;
            }

            string result = "";
            for (int i = 0; i < BITS_PER_BYTE; i++)
            {
                result += H[i].ToString("x8"); // using built in prevents needing to do binToHex(intToBin(result, nBits));
            }

            return result.Substring(0, 64);
        }
    }

}
