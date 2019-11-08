/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step01
    {
        /// <summary>
        /// Add one unit to each character in the string
        /// 'a' becomes 'b', 'T' becomes 'U', etc. Use the ASCII chart to verify
        /// Characters in text must be from 1 to 127, inclusive.
        /// </summary>
        /// <param name="text">The string to process</param>
        /// <returns>The encrypted string</returns>
        public static byte[] Encrypt(byte[] text)
        {
            byte[] encryptedText = new byte[text.Length];
            int i = 0;
            foreach (Byte b in text) {
                encryptedText[i] = (byte)(b + 1);
                i++;
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// Remove one unit to each character in the string
        /// 'b' becomes 'a', 'U' becomes 'T', etc. Use the ASCII chart to verify
        /// </summary>
        /// <param name="text">The string to process</param>
        /// <returns>The encrypted string</returns>
        public static byte[] Decrypt(byte[] text)
        {
            byte[] decryptedText = new byte[text.Length];
            int i = 0;
            foreach (Byte b in text) {
                decryptedText[i] = (byte)(b - 1);
                i++;
            }
            return decryptedText;
        }
    }
}
