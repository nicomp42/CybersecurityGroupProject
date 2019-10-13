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
        /// </summary>
        /// <param name="text">String to be encrypted</param>
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// Decrypt the String
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
