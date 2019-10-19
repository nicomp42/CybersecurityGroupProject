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
            /// From the left, add 1, then 2, then 3 to each character up to 100 inclusive,
            /// then start from 1 again. 
            /// For example: "abcd" becomes "bdfh".
            /// </summary>
            /// <param name="text">String to be encrypted. Characters in text must be from 1 to 127, inclusive. </param>
            /// <returns>Encrypted String</returns>
            public static String Encrypt(String text)
            {
                String encryptedText = "";
                int increment = 1;
                for (int i = 0; i < text.Length; i++) {
                    encryptedText += (char)(((int)text.ToCharArray()[i]) + increment);
                    increment++;
                    if (increment == 101) { increment = 1; }
                }
            return encryptedText;
            }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted. From the left, subtract 1, then 2, then 3 to each character up to 100 inclusive,
        /// then start again from 1</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text) {
            String decryptedText = "";
            int increment = 1;
            for (int i = 0; i < text.Length; i++)
            {
                decryptedText += (Char)(((int)text.ToCharArray()[i]) - increment);
                increment++;
                if (increment == 101) { increment = 1; }
            }
            return decryptedText;
        }
    }
}

