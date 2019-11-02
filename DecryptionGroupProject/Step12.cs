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
        public static String Encrypt(String text) {
            String encryptedText = "";
            Byte[] bytes = new byte[text.Length + 1];
            Byte[] tmp = Encoding.ASCII.GetBytes(text);
            // Copy the original text, as bytes, into the target byte array, offset 1
            for (int i = 0; i < tmp.Length; i++) {
                bytes[i + 1] = tmp[i];
            }
            bytes[0] = 0;
            for (int i = 1; i < bytes.Length; i++) {
                bytes[i-1] = (byte)((byte)(bytes[i-1] << 1) | (byte)(bytes[i] >> 7));  // get the high bit on the next byte
            }
            bytes[bytes.Length-1] = (byte)(bytes[bytes.Length-1] << 1);
            for (int i = 0; i < bytes.Length; i++)
            {
                encryptedText += (char)bytes[i]; 
            }
            //Console.WriteLine(encryptedText);
            return encryptedText;
        }
        public static String Decrypt(String text)
        {
            String decryptedText = "";
            Byte[] bytes = new byte[text.Length];
            for (int i = 0; i < text.Length; i++) {
                bytes[i] = (byte)((text.ToCharArray()[i])); // Inefficient!
            }
            Byte[] tmp = new byte[text.Length - 1];
            for (int i = bytes.Length-1; i > 0; i--) {
                char c;
                c = (char)((bytes[i] >> 1) | ((bytes[i - 1] & (byte)0x01) << 7));
                decryptedText = c + decryptedText;
            }
            return decryptedText;
        }
    }
}
