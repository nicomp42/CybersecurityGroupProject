using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityGroupProject
{
    class Step14
    {
        /// <summary>
        /// Encrypt the String
        /// Starting with the first position, insert a random byte before each byte of the original text
        /// For example: "abcde" becomes "Qamb%c>dWe"
        /// </summary>
        /// <param name="text">Data to be encrypted.</param>
        /// <returns>Encrypted Data</returns>
        public static Byte[] Encrypt(Byte[] text)
        {
            Byte[] encryptedData = new byte[text.Length * 2];
            Random myRandom = new Random();
            int idx = 0;
            for (int i = 0; i < text.Length; i++) {
                encryptedData[idx] = (Byte)myRandom.Next();
                encryptedData[idx + 1] = text[i];
                idx+=2;
            }
            return encryptedData;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">Data to be decrypted</param>
        /// <returns>Decrypted Data</returns>
        public static Byte[] Decrypt(Byte[] text)
        {
            Byte[] decryptedData = new byte[text.Length / 2];
            int idx = 0;
            for (int i = 1; i < text.Length; i += 2) {
                decryptedData[idx] = text[i];
                idx++;
            }
            return decryptedData;
        }

    }
}
