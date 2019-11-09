/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step06
    {
        /// <summary>
        /// Encrypt the String
        /// Swap every other character. 
        /// If the number of bytes in text is odd, do not change the last character</param>
        /// For example "abcd" = "badc".
        /// </summary>
        /// <param name="text">Bytes to be encrypted. 
        /// <returns>Encrypted Bytes</returns>
        public static Byte[] Encrypt(Byte[] text)
        {
            return SwapMe(text);
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">Bytes to be decrypted. Swap every other byte to reverse the Encrypt method above</param>
        /// <returns>Decrypted Bytes</returns>
        public static Byte[] Decrypt(Byte[]  text)
        {
            return SwapMe(text);
        }
        private static Byte[] SwapMe(Byte[] text) {
            Byte[] decryptedText = new Byte[text.Length];
            try {
                for (int i = 0; i < text.Length; i += 2) {
                    decryptedText[i] = text[i + 1];
                    decryptedText[i + 1] = text[i];
                }
            }
            catch (Exception ex) {
                // If we end up here the string has an odd number of chars in it. 
                decryptedText[text.Length - 1] = text[text.Length - 1];
            }
            return decryptedText;
        }
    }
}
