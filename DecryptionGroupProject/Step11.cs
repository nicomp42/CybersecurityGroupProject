/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Security.Cryptography;

namespace CyberSecurityGroupProject
{
    class Step11 {
        /// <summary>
        /// Encrypt a string using SHA1
        /// Note that SHA1 is a one-way hash that can't be decrypted
        /// </summary>
        /// <param name="text">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public static byte[] Encrypt(String text)
        {
            /*            SHA1 sha1 = new SHA1();
                        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(text);
                        byte[] encrypted = sha1.ComputeHash(bytes);
                        return encrypted; */
            return (new Byte[5]);
        }
        /// <summary>
        /// Decrypt the data, but we can't
        /// </summary>
        /// <param name="text">the encrypted data</param>
        /// <returns>Throws an exception</returns>
        public static String Decrypt(byte[] text)
        {
            throw new Exception("SHA1 cannot be decrypted.");
        }
    }
}
