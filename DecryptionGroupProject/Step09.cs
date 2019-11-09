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
            return(SwapFirstAndLast(text));
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted. Swap the first and last characters. If the string is length 1, do nothing</param>
        /// <returns>Decrypted String</returns>
        public static Byte[] Decrypt(Byte[]  text)
        {
            return(SwapFirstAndLast(text));
        }
        public static Byte[] SwapFirstAndLast(Byte[] text) {
            Byte[] encryptedText= null;
            if (text.Length > 1) {
                Byte start = text[0];
                Byte end = text[text.Length-1];
                encryptedText = text.Clone();
                encryptedText[0] = end;
                encryptedText[encryptedText.Length-1] = start;
            }
            return encryptedText;
        }

    }
}
