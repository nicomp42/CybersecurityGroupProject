﻿/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step08
    {
        private static int modValue = 25;
        /// <summary>
        /// Encrypt the data
        /// Compute the checksum mod 25 of all the bytes in the text. 
        /// Append that number as ASCII text, 2 bytes wide, zero padded from the left, at the beginning of the text.
        /// Then, append that number of random characters to the end of the text.
        /// For example: "abcd" encrypts to  "19abcdRjRs'mzy?_MmZx93-a"
        /// </summary>
        /// <param name="text">data to be encrypted.  </param>
        /// <returns>Encrypted data</returns>
        public static Byte[] Encrypt(Byte[] text)
        {
            Byte[] encryptedText = null;
            Random r = new Random();
            int checksum = 0;
            foreach (Byte b in text) {checksum += b;}
            checksum %= modValue;    // Now checksum will be from 0 to modValue, inclusive
            encryptedText = new byte[text.Length + 2 + checksum];
            encryptedText[0] = Convert.ToByte((checksum / 10) + '0');
            encryptedText[1] = Convert.ToByte((checksum % 10) + '0');
            for (int i = 0; i < text.Length; i++) { encryptedText[i + 2] = text[i]; }
            for (int i = 2 + text.Length; i < checksum; i++) {
                encryptedText[i] = Convert.ToByte(r.Next(100) + 30);
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">data to be decrypted.</param>
        /// <returns>Decrypted data</returns>
        public static Byte[] Decrypt(Byte[]  text) {
            int checkSum = ((text[0] - '0') * 10) + (text[1] - '0');
            Byte[] decryptedText = new Byte[text.Length - 2 - checkSum];
            int idx = 0;
            for (int i = 2; i < text.Length - checkSum; i++) {
                decryptedText[idx] = text[i];
                idx++;
            }
            return decryptedText;
        }
    }
}
