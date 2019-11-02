/*
 * Text logic for Cyber Security Group Project
 * All the encryption steps are symmetric
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

namespace CyberSecurityGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStep12();
            PerformStepByStepTest();
            PerformTestCases();
            Console.ReadLine();
        }
        /// <summary>
        /// Run a suite of test cases, evaluate the results, and print the evaulation to the console
        /// </summary>
        private static void PerformTestCases() {
            // Test cases
            int passCount = 0, failCount = 0;
            if (Test("abc",                            "Test 01")) { passCount++; } else { failCount++; }
            if (Test("I Love La Rosas Pizza",          "Test 02")) { passCount++; } else { failCount++; }
            if (Test("aaaaaaaaaaaaaaaaaaaaaa",         "Test 03")) { passCount++; } else { failCount++; }
            if (Test("X",                              "Test 04")) { passCount++; } else { failCount++; }
            if (Test(" ",                              "Test 05")) { passCount++; } else { failCount++; }
            if (Test("          ",                     "Test 06")) { passCount++; } else { failCount++; }
            if (Test("12345",                          "Test 07")) { passCount++; } else { failCount++; }
            if (Test("!@#$%^&*()_+{}\":>?<",           "Test 08")) { passCount++; } else { failCount++; }
            if (Test("~~~~~~~~~~~~~~~~~~~~          ", "Test 09")) { passCount++; } else { failCount++; }
            // Test 10: build a string wth all 127 ASCII characters (some are unprintable) and test that string
            String test10 = "";
            for (int i = 0; i < 127; i++) { test10 += (char)i; }
            if (Test(test10,                            "Test 10")) { passCount++; } else { failCount++; }

            // How did we do? Did all the test pass?
            if (failCount == 0) {
                Console.WriteLine("ALL " + passCount + " tests passed");
            } else {
                Console.WriteLine(failCount + " tests FAILED");
            }
        }
        /// <summary>
        /// Run a test case, evaluate the result, and print the evaulation to the console
        /// </summary>
        /// <param name="testString">The string to be encrypted</param>
        /// <param name="testTitle">The name of the test case</param>
        /// <returns>True if the testString encrypted then decrypted and ended up equal to testString, false otherwise </returns>
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
            int[] mapping = BuildRandomMapping();
            encryptedText = Step10.Encrypt(encryptedText, mapping);
            // Slip Step 11 because it's a one-way encryption
            //encryptedText = Step12.Encrypt(encryptedText);

            Console.WriteLine("Decrypting " + encryptedText);

            String decryptedText;
            //decryptedText = Step12.Decrypt(encryptedText);
            // Slip Step 11 because it's a one-way encryption
            decryptedText = Step10.Decrypt(encryptedText, mapping);
            decryptedText = Step09.Decrypt(decryptedText);
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
        /// <summary>
        /// Build a random map for all 255 characters.
        /// For example: mapping[0] is the value that should be mapped for character at location 0 in the ASCII chart
        /// For example: mapping[48] is the value that should be mapped for character at location 48 in the ASCII chart
        /// This a brute-force algorithm that may take a few milliseconds. 
        /// </summary>
        /// <param name="mapping">The random map</param>
        public static int[] BuildRandomMapping() {
            int[] mapping = new int[255];
            Random r = new Random(42);
            for (int i = 0; i < mapping.Length; i++) {
                int tmpMap;
                while (true) {
                    Boolean found;
                    found = false;
                    tmpMap = r.Next(256);
                    for (int j = 0; j < mapping.Length; j++) {  // Find a mapping we have not used yet.
                        if (mapping[j] == tmpMap) { found = true; /*Console.Write(i + " ");*/ break; }
                    }
                    if (!found) { mapping[i] = tmpMap; break; }
                }
            }
            return mapping;
        }
        /// <summary> Run a single test case and print every intermediate step for debugging.
        /// The results of each step are printed but not evaluated. </summary>
        private static void PerformStepByStepTest() {
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
            //Step 10
            int[] mapping = BuildRandomMapping();
            String encryptedTextStep10 = Step10.Encrypt(encryptedTextStep09, mapping);
            Console.WriteLine("Step 10: " + encryptedTextStep10);
            String decryptedTextStep10 = Step10.Decrypt(encryptedTextStep10, mapping);
            Console.WriteLine("         Decrypts to " + decryptedTextStep10);
            // We skip Step 11 because it uses one-way encryption
            // Step 12
            String encryptedTextStep12 = Step12.Encrypt(encryptedTextStep10);
            Console.WriteLine("Step 12: " + encryptedTextStep12);
            String decryptedTextStep12 = Step12.Decrypt(encryptedTextStep12);
            Console.WriteLine("         Decrypts to " + decryptedTextStep12);
        }
        /// <summary>
        /// This step will encrypt but not decrypt so let's not use it 
        /// </summary>
        private static void TestStep11() {
            String test = "Hello World";
            byte[] encryptyed = Step11.Encrypt(test);
        }
        /// <summary>
        /// A stand-alone test for Step 12 'cause it's a little complicated relative to the others 
        /// </summary>
        private static void TestStep12()
        {
            String test = "abc";
            String encrypted = Step12.Encrypt(test);
            String decrypted = Step12.Decrypt(encrypted);
            Console.WriteLine("Step 12 test: " + test + " encrypted to " + encrypted + " and decrypted to " + decrypted);
//                  01234567890
            test = "          ";
            encrypted = Step12.Encrypt(test);
            decrypted = Step12.Decrypt(encrypted);
            Console.WriteLine("Step 12 test: " + test + " encrypted to " + encrypted + " and decrypted to " + decrypted);
            //                  01234567890
            test = "!@#$%^&*()_+{}\":>?<";
            encrypted = Step12.Encrypt(test);
            decrypted = Step12.Decrypt(encrypted);
            Console.WriteLine("Step 12 test: " + test + " encrypted to " + encrypted + " and decrypted to " + decrypted);
        }
    }
}
