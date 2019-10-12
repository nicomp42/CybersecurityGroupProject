using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            String clearText = "abc";
            Console.WriteLine("Starting with "+ clearText);
            Console.WriteLine("Encrypting...");
            // Step 01
            String encryptedTextStep01 = Step01.Encrypt(clearText);
            Console.WriteLine("Step 01: " + encryptedTextStep01);
            String decryptedTextStep01 = Step01.Decrypt(encryptedTextStep01);
            Console.WriteLine("         Decrypts to " + decryptedTextStep01);
            // Step 02
            String encryptedTextStep02 = Step02.Encrypt(encryptedTextStep01, 'q', 2);
            Console.WriteLine("Step 02: " + encryptedTextStep02);
            String decryptedTextStep02 = Step02.Decrypt(encryptedTextStep02, 2);
            Console.WriteLine("         Decrypts to " + decryptedTextStep02);
            //Step 03
            String encryptedTextStep03 = Step03.Encrypt(encryptedTextStep02);
            Console.WriteLine("Step 03: " + encryptedTextStep03);
            String decryptedTextStep03 = Step03.Decrypt(encryptedTextStep03);
            Console.WriteLine("         Decrypts to " + decryptedTextStep03);
            //Step 04
            String encryptedTextStep04 = Step04.Encrypt(encryptedTextStep03);
            Console.WriteLine("Step 04: " + encryptedTextStep04);
            String decryptedTextStep04 = Step04.Decrypt(encryptedTextStep04);
            Console.WriteLine("         Decrypts to " + decryptedTextStep04);

        }
    }
}
