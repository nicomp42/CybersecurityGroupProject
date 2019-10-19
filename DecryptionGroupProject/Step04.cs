/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step04
    {
        /// <summary>
        /// Encrypt the String
        /// XOR the low bit of each char in text with 1. This flips the state of the bit: 1 becomes 0, 0 becomes 1
        /// For example: "abcde" becomes  "`cbed"
        /// </summary>
        /// <param name="text">String to be encrypted. Characters in text must be from 1 to 127, inclusive. </param>
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            String encryptedText = "";
            foreach (char c in text) {
                encryptedText += (Char)(((int)c ^ 1));
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text)
        {
            String decryptedText = "";
            foreach (char c in text) {
                decryptedText += (Char)(((int)c ^ 1));
            }
            return decryptedText;
        }
    }
}
