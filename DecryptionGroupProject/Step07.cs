/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step07
    {
        private static int offset = 25;
            /// <summary>
            /// Encrypt the String
            /// Expand each byte to two bytes because the encryption will result in values > 255
            /// From the left, add 1, then 2, then 3 to each character up to 25 inclusive, then start from 1 again. 
            /// For example: "abcd" becomes "\0b\0d\0f\0h".   (8 bytes wide)
            /// </summary>
            /// <param name="text">Data to be encrypted.</param>
            /// <returns>Encrypted data</returns>
            public static Byte[] Encrypt(Byte[] text)
            {
                Byte[] encryptedText = new Byte[text.Length * 2];
                int increment = 1;
                int idx = 0;
                for (int i = 0; i < text.Length; i++) {
                    int tmp, highByte, lowByte;
                    tmp = text[i] + increment;    // This could overflow a byte so use ints
                    highByte = tmp / 256;
                    lowByte = tmp % 256;
                    encryptedText[idx] = (byte)(highByte);
                    encryptedText[idx + 1] = (byte)(lowByte);
                    idx += 2;
                    increment++;
                    if (increment == offset+1) { increment = 1; }
                }
            return encryptedText;
            }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">Data to be decrypted. From the left, subtract 1, then 2, then 3 to each character up to 25 inclusive,
        /// then start again from 1</param>
        /// <returns>Decrypted String</returns>
        public static Byte[] Decrypt(Byte[]  text) {
            Byte[] decryptedText = new Byte[text.Length/2];
            int increment = 1;
            int idx = 0;
            for (int i = 0; i < text.Length - 1; i += 2) {
                int tmp;
                tmp = text[i] * 256 + text[i + 1];
                tmp -= increment;      // This should always be less than one byte
                decryptedText[idx] = (byte)(tmp);
                idx++;
                increment++;
                if (increment == offset+1) { increment = 1; }
            }
            return decryptedText;
        }
    }
}

