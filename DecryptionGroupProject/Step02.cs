/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Generic;

namespace CyberSecurityGroupProject
{
    class Step02
    {
        /// <summary>
        /// Add padding to both sides of each character in the string
        /// For example: "abc",'q', 2 becomes qqaqqqqbqqqqcqq
        /// </summary>
        /// <param name="text">The string to be encrypted. Characters in text must be from 1 to 127, inclusive. </param>
        /// <param name="padding">The single char to use as the padding</param>
        /// <param name="count">The number of padding characters on either side of the string</param>
        /// <returns>The encrypted string</returns>
        public static byte[] Encrypt(Byte[] text, char padding, int count) {
            Byte[] encryptedText = new byte[text.Length + text.Length * (count * 2)];
            int i = 0;
            foreach(Byte b in text) {
                for (int j = 0; j < count; j++) {
                    encryptedText[i] = (byte)padding;
                    i++;
                }
                encryptedText[i] = b;
                i++;
                for (int j = 0; j < count; j++) {
                    encryptedText[i] = (byte)padding;
                    i++;
                }
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// Remove padding from both sides of each character in the string
        /// For example: "qqaqqqqbqqqqcqq", 2 becomes abc
        /// </summary>
        /// <param name="text">The string to be decrypted</param>
        /// <param name="count">The number of padding characters on either side of the string</param>
        /// <returns>The encrypted string</returns>
        public static Byte[] Decrypt(Byte[] text, int count)
        {
            Byte[] decryptedText;
            List<Byte> tmpBytes = new List<Byte>();
            int idx = count;
            while (idx < text.Length) {
                tmpBytes.Add(text[idx]);
                idx += count * 2 + 1;
            }

            decryptedText = new Byte[tmpBytes.Count];
            for (idx = 0; idx < tmpBytes.Count; idx++)
            {
                decryptedText[idx] = tmpBytes[idx];
            }
            return decryptedText;
        }
    }
}
