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
            String clearText = "abcde";
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
            //Step 05
            String encryptedTextStep05 = Step05.Encrypt(encryptedTextStep04);
            Console.WriteLine("Step 05: " + encryptedTextStep05);
            String decryptedTextStep05 = Step05.Decrypt(encryptedTextStep05);
            Console.WriteLine("         Decrypts to " + decryptedTextStep05);
            //Step 06
            String encryptedTextStep06 = Step06.Encrypt(encryptedTextStep05);
            Console.WriteLine("Step 06: " + encryptedTextStep06);
            String decryptedTextStep06 = Step06.Decrypt(encryptedTextStep06);
            Console.WriteLine("         Decrypts to " + decryptedTextStep06);

            Test01();
        }
        private static void Test01()
        {
            String text = "abc";            // "I Love La Rosas Pizza";
            Console.WriteLine("Test 01: Starting with " + text);
            String encryptedText;
            encryptedText = Step01.Encrypt(text);
            encryptedText = Step02.Encrypt(encryptedText, 'q', 2);
            encryptedText = Step03.Encrypt(encryptedText);
            encryptedText = Step04.Encrypt(encryptedText);
            encryptedText = Step05.Encrypt(encryptedText);
            encryptedText = Step06.Encrypt(encryptedText);

            Console.WriteLine("Decrypting " + encryptedText);

            String decryptedText;
            decryptedText = Step06.Decrypt(encryptedText);
            decryptedText = Step05.Decrypt(decryptedText);
            decryptedText = Step04.Decrypt(decryptedText);
            decryptedText = Step03.Decrypt(decryptedText);
            decryptedText = Step02.Decrypt(decryptedText, 2);
            decryptedText = Step01.Decrypt(decryptedText);

            Console.WriteLine("Result = " + decryptedText);
        }
    }
}
