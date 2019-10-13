/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;


namespace CyberSecurityGroupProject
{
    class Step02
    {
        /// <summary>
        /// Add padding to both sides of each character in the string
        /// For example: "abc",'q', 2 becomes qqaqqqqbqqqqcqq
        /// </summary>
        /// <param name="text">The string to be encrypted</param>
        /// <param name="padding">The single char to use as the padding</param>
        /// <param name="count">The number of padding characters on either side of the string</param>
        /// <returns>The encrypted string</returns>
        public static String Encrypt(String text, char padding, int count) {
            String encryptedText = "";
            String paddingString = new string(padding, count);
            foreach(char c in text)
            {
                encryptedText += paddingString + c + paddingString;
            }
            return encryptedText;
        }
        /// <summary>
        /// Remove padding from both sides of each character in the string
        /// For example: "qqaqqqqbqqqqcqq", 2 becomes abc
        /// </summary>
        /// <param name="text">The string to be encrypted</param>
        /// <param name="padding">The single char to use as the padding</param>
        /// <param name="count">The number of padding characters on either side of the string</param>
        /// <returns>The encrypted string</returns>
        public static String Decrypt(String text, int count)
        {
            String decryptedText = "";
            String decryptedTextTmp = text.Substring(2);       // Chop off the first two padding characters
            decryptedTextTmp = decryptedTextTmp.Substring(0, decryptedTextTmp.Length-2);       // Chop off the last two padding characters
            int idx = 0;
            while (idx < decryptedTextTmp.Length) {
                decryptedText += decryptedTextTmp.Substring(idx,1);
                idx += count * 2 + 1;
            }
            return decryptedText;
        }
    }
}
