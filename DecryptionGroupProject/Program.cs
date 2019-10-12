using System;


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
            //Step 07
            String encryptedTextStep07 = Step07.Encrypt(encryptedTextStep06);
            Console.WriteLine("Step 07: " + encryptedTextStep07);
            String decryptedTextStep07 = Step07.Decrypt(encryptedTextStep07);
            Console.WriteLine("         Decrypts to " + decryptedTextStep07);
            //Step 08
            String encryptedTextStep08 = Step08.Encrypt(encryptedTextStep07);
            Console.WriteLine("Step 08: " + encryptedTextStep08);
            String decryptedTextStep08 = Step08.Decrypt(encryptedTextStep08);
            Console.WriteLine("         Decrypts to " + decryptedTextStep08);
            //Step 09
            String encryptedTextStep09 = Step09.Encrypt(encryptedTextStep08);
            Console.WriteLine("Step 09: " + encryptedTextStep09);
            String decryptedTextStep09 = Step09.Decrypt(encryptedTextStep09);
            Console.WriteLine("         Decrypts to " + decryptedTextStep09);
            // Test cases
            int passCount = 0, failCount = 0;
            if (Test("abc", "Test 01")) { passCount++; } else { failCount++; }
            if (Test("I Love La Rosas Pizza", "Test 02")) { passCount++; } else { failCount++; }
            if (Test("aaaaaaaaaaaaaaaaaaaaaa", "Test 03")) { passCount++; } else { failCount++; }
            if (Test("X", "Test 04")) { passCount++; } else { failCount++; }
            if (Test(" ", "Test 05")) { passCount++; } else { failCount++; }
            if (Test("          ", "Test 06")) { passCount++; } else { failCount++; }
            if (Test("12345", "Test 07")) { passCount++; } else { failCount++; }
            if (Test("!@#$%^&*()_+{}\":>?<", "Test 08")) { passCount++; } else { failCount++; }
            if (Test("~~~~~~~~~~~~~~~~~~~~          ", "Test 09")) { passCount++; } else { failCount++; }
            if (failCount == 0) {
                Console.WriteLine("ALL " + passCount + " tests passed");
            } else {
                Console.WriteLine(failCount + " tests FAILED");
            }
        }
        private static Boolean Test(String testString, String testTitle)
        {
            String text = testString;
            Console.WriteLine(testTitle + ": Starting with " + text);
            String encryptedText;
            encryptedText = Step01.Encrypt(text);
            encryptedText = Step02.Encrypt(encryptedText, 'q', 2);
            encryptedText = Step03.Encrypt(encryptedText);
            encryptedText = Step04.Encrypt(encryptedText);
            encryptedText = Step05.Encrypt(encryptedText);
            encryptedText = Step06.Encrypt(encryptedText);
            encryptedText = Step07.Encrypt(encryptedText);
            encryptedText = Step08.Encrypt(encryptedText);
            encryptedText = Step09.Encrypt(encryptedText);

            Console.WriteLine("Decrypting " + encryptedText);

            String decryptedText;
            decryptedText = Step09.Decrypt(encryptedText);
            decryptedText = Step08.Decrypt(decryptedText);
            decryptedText = Step07.Decrypt(decryptedText);
            decryptedText = Step06.Decrypt(decryptedText);
            decryptedText = Step05.Decrypt(decryptedText);
            decryptedText = Step04.Decrypt(decryptedText);
            decryptedText = Step03.Decrypt(decryptedText);
            decryptedText = Step02.Decrypt(decryptedText, 2);
            decryptedText = Step01.Decrypt(decryptedText);

            Console.WriteLine("Result = " + decryptedText);
            if (text.Equals(decryptedText)) {
                Console.WriteLine(testTitle + " Passed");
                return true;
            } else {
                Console.WriteLine(testTitle + " FAILED");
                return false;
            }
        }
    }
}
