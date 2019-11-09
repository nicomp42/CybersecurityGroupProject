/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
 using System;

namespace CyberSecurityGroupProject
{
    class Step07
    {
            /// <summary>
            /// Encrypt the String
            /// From the left, add 1, then 2, then 3 to each character up to 25 inclusive,
            /// then start from 1 again. 
            /// For example: "abcd" becomes "bdfh".
            /// </summary>
            /// <param name="text">String to be encrypted. Bytes in text must be from 1 to 127, inclusive. </param>
            /// <returns>Encrypted String</returns>
            public static Byte[] Encrypt(Byte[] text)
            {
                Byte[] encryptedText = new Byte[text.Length];
                int increment = 1;
                int idx = 0;
                for (int i = 0; i < text.Length; i++) {
                    encryptedText[idx] = (byte)(text[idx] + increment);
                    increment++;
                    idx++;
                    if (increment == 26) { increment = 1; }
                }
            return encryptedText;
            }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted. From the left, subtract 1, then 2, then 3 to each character up to 100 inclusive,
        /// then start again from 1</param>
        /// <returns>Decrypted String</returns>
        public static Byte[] Decrypt(Byte[]  text) {
            Byte[] decryptedText = new Byte[text.Length];
            int increment = 1;
            int idx = 0;
            for (int i = 0; i < text.Length; i++) {
                decryptedText[idx] = (byte)(text[idx] - increment);
                increment++;
                idx++;
                if (increment == 26) { increment = 1; }
            }
            return decryptedText;
        }
    }
}

