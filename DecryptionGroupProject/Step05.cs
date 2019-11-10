﻿/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step05
    {
        /// <summary>
        /// Encrypt the String
        /// XOR the low bit of each char in text with 1. This flips the state of the bit: 1 becomes 0, 0 becomes 1
        /// For example: "abcde" becomes  "`cbed"
        /// </summary>
        /// <param name="text">Data to be encrypted.</param>
        /// <returns>Encrypted Data</returns>
        public static Byte[] Encrypt(Byte[] text)
        {
            return XORMe(text);
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">Data to be decrypted</param>
        /// <returns>Decrypted Data</returns>
        public static Byte[] Decrypt(Byte[]  text)
        {
            return XORMe(text);
        }
        private static Byte[] XORMe(Byte[] text) {
            Byte[] encryptedText = new byte[text.Length];
            int idx = 0;
            foreach (Byte b in text) {
                encryptedText[idx] = (Byte)(b ^ 1);
                idx++;
            }
            return encryptedText;
        }
    }
}
