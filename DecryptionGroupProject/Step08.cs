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
        /// Then, for all the other characters, add the number to it. </param>
        /// <returns>Encrypted String</returns>
        public static String Encrypt(String text)
        {
            String encryptedText = "";
            int checksum = 0;
            foreach (char c in text) {
                checksum += System.Convert.ToInt32(c);
            }
            checksum %= 25;    // Now checksum will be from 0 to 24, inclusive
            foreach (char c in text) {
                int num;
                num = System.Convert.ToInt32(c);
                encryptedText += System.Convert.ToChar(num + checksum);
            }
            encryptedText = System.Convert.ToString(checksum) + encryptedText;
            if (checksum < 10) { encryptedText = "0" + encryptedText; } // Add the zero padding if necessary
//          if (checksum == 0) { encryptedText = "0" + encryptedText; } // Add more zero padding if necessary
            return encryptedText;
        }
        /// <summary>
        /// Decrypt the String
        /// </summary>
        /// <param name="text">String to be decrypted.</param>
        /// <returns>Decrypted String</returns>
        public static String Decrypt(String text)
        {
            String decryptedText = "";
            int checksum = System.Convert.ToInt32(text.Substring(0, 2));    // Extract the checksum and convert to int
            foreach (char c in text.Substring(2)) {
                int num;
                num = System.Convert.ToInt32(c);
                decryptedText += System.Convert.ToChar(num - checksum);
            }
            return decryptedText;
        }
    }
}
