/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityGroupProject
{
    class Step10
    {
        /// <summary>
        /// Map every character to a different character using a mapping array. 
        /// "Caesar Substitution" https://studio.code.org/s/hoc-encryption/stage/1/puzzle/1
        /// For example (assuming a 5 letter alphabet!) text = "abcd", mapping array = 'n', 'p', 'k', 'z', 'q' then the encrypted string = "npkz"
        /// </summary>
        /// <param name="text">The text to be mapped.</param>
        /// <param name="mapping">The mapping array. Must be 256 unique values!</param>
        /// <returns>The encoded string</returns>
        public static Byte[] Encrypt(Byte[] text, Byte[] mapping)
        {
            Byte[] encryptedText = new Byte[text.Length];
            int idx = 0;
            foreach (Byte b in text) {
                encryptedText[idx] = mapping[text[idx]];
                idx++;
            }
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">The text to be decrypted</param>
        /// <param name="mapping">The mapping array used to encrypt the text</param>
        /// <returns>The decrypted string</returns>
        public static Byte[] Decrypt(Byte[] text, Byte[] mapping)
        {
            Byte[] decryptedText = new Byte[text.Length];

            int idx = 0;
            foreach (Byte b in text) {
                for (int i = 0; i < 256; i++) {
                    if (text[idx] == mapping[i]) { decryptedText[idx] = (byte)i; break; }
                }
                idx++;
            }
            return decryptedText;
        }
    }
}
