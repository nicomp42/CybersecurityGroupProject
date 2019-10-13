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
        /// </summary>
        /// <param name="text">The string to process</param>
        /// <returns>The encrypted string</returns>
        public static String Encrypt(String text)
        {
            String encryptedText = "";
            foreach (Char c in text) {
                encryptedText += (char)(c + 1);
            }
            return encryptedText;
        }
        /// <summary>
        /// Remove one unit to each character in the string
        /// 'b' becomes 'a', 'U' becomes 'T', etc. Use the ASCII chart to verify
        /// </summary>
        /// <param name="text">The string to process</param>
        /// <returns>The encrypted string</returns>
        public static String Decrypt(String text)
        {
            String decryptedText = "";
            foreach (Char c in text)
            {
                decryptedText += (char)(c - 1);
            }
            return decryptedText;
        }
    }
}
