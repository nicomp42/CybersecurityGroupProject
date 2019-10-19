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
        /// </summary>
        /// <param name="text">String to be encrypted. Compute the checksum mod 25 of the text. 
        /// Append that number as ASCII text, 2 chars wide, xero padded from the left, at the beginning of the text.
        /// Then, append that number of random characters to the end of text. Characters in text must be from 1 to 127, inclusive.  </param>
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            String encryptedText = text;
            int checksum = 0;
            foreach (char c in text) {
                checksum += System.Convert.ToInt32(c);
            }
            checksum %= 25;    // Now checksum will be from 0 to 24, inclusive
            Random r = new Random();
            for (int i = 0; i < checksum; i++) {
                encryptedText += System.Convert.ToChar(r.Next(100) + 30);
            }
            encryptedText = System.Convert.ToString(checksum) + encryptedText;
            if (checksum < 10) { encryptedText = "0" + encryptedText; } // Add the zero padding if necessary
//          if (checksum == 0) { encryptedText = "0" + encryptedText; } // Add more zero padding if necessary
            return encryptedText;
        }
        /// <summary>
        /// Reverse the encryption applied in the Encrypt method in this class.
        /// </summary>
        /// <param name="text">String to be decrypted.</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text) {
            String decryptedText = text.Substring(2);
            int checkSum = System.Convert.ToInt32(text.Substring(0, 2));    // Extract the checksum and convert to int
            decryptedText = decryptedText.Substring(0, decryptedText.Length - checkSum);    // Lop off the random characters
            return decryptedText;
        }
    }
}
