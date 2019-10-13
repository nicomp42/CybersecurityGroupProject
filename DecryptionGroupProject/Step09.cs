/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step09
    {
        /// <summary>
        /// Encrypt the String
        /// </summary>
        /// <param name="text">String to be encrypted. Swap the first and last bytes. If the string is length 1, do nothing
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            String encryptedText = "";
            if (text.Length > 1)
            {
                String start = text.Substring(0, 1);
                String end = text.Substring(text.Length - 1, 1);
                encryptedText = end + text.Substring(1, text.Length - 2) + start;
            }
            return encryptedText;
        }
        /// <summary>
        /// Decrypt the String
        /// </summary>
        /// <param name="text">String to be decrypted. Swap the first and last bytes. If the string is length 1, do nothing</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text)
        {
            String decryptedText = "";
            if (text.Length > 1)
            {
                String start = text.Substring(0, 1);
                String end = text.Substring(text.Length - 1, 1);
                decryptedText = end + text.Substring(1, text.Length - 2) + start;
            }
            return decryptedText;
        }
    }
}
