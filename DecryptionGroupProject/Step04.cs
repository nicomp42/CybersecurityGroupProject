using System;


namespace CyberSecurityGroupProject
{
    class Step04
    {
        /// <summary>
        /// Encrypt the String
        /// </summary>
        /// <param name="text">String to be encrypted. XOR the low bit of each char in text with 1</param>
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            String encryptedText = "";
            foreach (char c in text)
            {
                encryptedText += (Char)(((int)c ^ 1));
            }
            return encryptedText;
        }
        /// <summary>
        /// Decrypt the String
        /// </summary>
        /// <param name="text">String to be decrypted</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text)
        {
            String decryptedText = "";
            foreach (char c in text)
            {
                decryptedText += (Char)(((int)c ^ 1));
            }
            return decryptedText;
        }
    }
}
