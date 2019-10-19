/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step03
    {
        /// <summary>
        /// Encrypt the String
        /// Reverse the order of the text
        /// For example: "abcd" becomes "dcba"
        /// </summary>
        /// <param name="text">String to be encrypted. Characters in text must be from 1 to 127, inclusive. </param>
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
