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
        /// Encrypt the string. Swap the first and last characters. If the string is length 1, do nothing.
        /// For example, "abcd" becomes "dbca"
        /// </summary>
        /// <param name="text">String to be encrypted.  Characters in text must be from 1 to 127, inclusive. </param>
        /// <returns>Encrypted String</returns>
        public static Byte[] Encrypt(Byte[] text)
        {
Byte[] encryptedText = new Byte[text.Length];
            if (text.Length > 1)
            {
                String start = text.Substring(0, 1);
                String end = text.Substring(text.Length - 1, 1);
                encryptedText = end + text.Substring(1, text.Length - 2) + start;
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted. Swap the first and last characters. If the string is length 1, do nothing</param>
        /// <returns>Decrypted String</returns>
        public static Byte[] Decrypt(Byte[]  text)
        {
            Byte[] decryptedText = "";
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
