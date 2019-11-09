/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Step08
    {
        /// <summary>
        /// Encrypt the String
        /// Compute the checksum mod 25 of the text. 
        /// Append that number as ASCII text, 2 chars wide, zero padded from the left, at the beginning of the text.
        /// Then, append that number of random characters to the end of the text.
        /// For example: "abcd" encrypts to  "19abcdRjRs'mzy?_MmZx93-a"
        /// </summary>
        /// <param name="text">String to be encrypted. Characters in text must be from 1 to 127, inclusive.  </param>
        /// <returns>Encrypted String</returns>
        public static Byte[] Encrypt(Byte[] text)
        {
            Byte[] encryptedText = null;
            Random r = new Random();
            int checksum = 0;
            foreach (Byte b in text) {
                checksum += b;
            }
            checksum %= 25;    // Now checksum will be from 0 to 24, inclusive
            String checksumString = Convert.ToString(checksum);
            encryptedText = new byte[text.Length + 2 + checksum];
            encryptedText[0] = Convert.ToByte(checksumString.Substring(0, 1));
            encryptedText[1] = Convert.ToByte(checksumString.Substring(1, 1));
            int idx = 2;
            encryptedText = new byte[text.Length + 2 + checksum];
            for (int i = 0; i < checksum; i++) {
                int myRandom = r.Next(100) + 30;
                encryptedText[idx] = Convert.ToByte(r.Next(100) + 30);
                idx++;
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted.</param>
        /// <returns>Decrypted String</returns>
        public static Byte[] Decrypt(Byte[]  text) {
            String tmp = Convert.ToString(text[0]) + Convert.ToString(text[1]);
            int checkSum = Convert.ToInt32(tmp);
            Byte[] decryptedText = new Byte[text.Length - 2 - checkSum];
            int idx = 0;
            for (int i = 2; i < text.Length - 2 - checkSum; i++) {
                decryptedText[idx] = text[i];
            }
            return decryptedText;
        }
    }
}
