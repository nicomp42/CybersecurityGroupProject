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
    class Step12
    {
        /// <summary>
        /// Shift all the bytes to the left one bit. You will end up with one extra byte at the beginning
        /// </summary>
        /// <param name="text">Bytes to encrypt</param>
        /// <returns>Encrypted bytes</returns>
        public static Byte[] Encrypt(Byte[] text) {
Byte[] encryptedText = new Byte[text.Length];
            Byte[] bytes = new byte[text.Length + 1];
            Byte[] tmp = Encoding.ASCII.GetBytes(text);
            byte lastHighBit = 0x00, currentHighBit = 0x00; ;
            // Copy the original text, as bytes, into the target byte array, offset 1
            for (int i = 0; i < tmp.Length; i++) {
                bytes[i + 1] = tmp[i];
            }
            bytes[0] = 0;
            for (int i = bytes.Length - 1; i > 0; i--) {
                currentHighBit = (byte)(bytes[i] >> 7);
                bytes[i] = (byte)((byte)(bytes[i] << 1) | lastHighBit);  // get the high bit on the next byte
                lastHighBit = currentHighBit;
            }
            bytes[0] |= lastHighBit;
            for (int i = 0; i < bytes.Length; i++) {
                encryptedText += (char)bytes[i]; 
            }
            //Console.WriteLine(encryptedText);
            return encryptedText;
        }
        /// <summary>
        /// Shift all the bytes right one bit
        /// </summary>
        /// <param name="text">Bytes to decrypt</param>
        /// <returns>Decrypted bytes</returns>
        public static Byte[] Decrypt(Byte[]  text)
        {
            Byte[] decryptedText = "";
            byte lastHighBit = 0x00, currentHighBit = 0x00; ;
            Byte[] bytes = new byte[text.Length];
            for (int i = 0; i < text.Length; i++) {
                bytes[i] = (byte)((text.ToCharArray()[i])); // Inefficient!
            }
            Byte[] tmp = new byte[text.Length - 1];
            lastHighBit = bytes[0];
            for (int i = 1; i < bytes.Length; i++) {
                char c;
                currentHighBit = (byte)(bytes[i] & (byte)0x01);
                c = (char)((bytes[i] >> 1) | (lastHighBit << 7));
                decryptedText = decryptedText + c;
                lastHighBit = currentHighBit;
            }
            return decryptedText;
        }
    }
}
