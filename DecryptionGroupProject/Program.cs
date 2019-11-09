﻿/*
 * Text logic for Cyber Security Group Project
 * All the encryption steps are symmetric
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityGroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestStep12();
            //TestStep09();
            //TestStep10();
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
            Byte[] encryptedText;
            encryptedText = Step01.Encrypt(Encoding.ASCII.GetBytes(text));
            encryptedText = Step02.Encrypt(encryptedText, 'q', 2);
            encryptedText = Step03.Encrypt(encryptedText);
            encryptedText = Step04.Encrypt(encryptedText);
            encryptedText = Step05.Encrypt(encryptedText);
            encryptedText = Step06.Encrypt(encryptedText);
            encryptedText = Step07.Encrypt(encryptedText);
            encryptedText = Step08.Encrypt(encryptedText);
            encryptedText = Step09.Encrypt(encryptedText);
            byte[] mapping = BuildRandomMapping2();
            encryptedText = Step10.Encrypt(encryptedText, mapping);
            // Slip Step 11 because it's a one-way encryption
            encryptedText = Step12.Encrypt(encryptedText);

            Console.WriteLine("Decrypting " + encryptedText);

            Byte[] decryptedText;
            decryptedText = Step12.Decrypt(encryptedText);
            // Slip Step 11 because it's a one-way encryption
            decryptedText = Step10.Decrypt(decryptedText, mapping);
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
        public static Byte[] BuildRandomMapping() {
            Byte[] mapping = new Byte[256];
            Random r = new Random(42);
            for (int i = 0; i < mapping.Length; i++) {
                Byte tmpMap;
                while (true) {
                    Boolean found;
                    found = false;
                    tmpMap = (Byte)r.Next(256);
                    for (int j = 0; j < mapping.Length; j++) {  // Find a mapping we have not used yet.
                        if (mapping[j] == tmpMap) { found = true; /*Console.Write(i + " ");*/ break; }
                    }
                    if (!found) { mapping[i] = tmpMap; break; }
                }
            }
            return mapping;
        }

        public static Byte[] BuildRandomMapping2()
        {
            Byte[] mapping = new byte[256];
            Random r = new Random(42);
            Dictionary<byte, bool> dict = new Dictionary<byte, bool>();
            for (int i = 0; i < mapping.Length; i++)
            {
                bool foundByte = false;
                while (!foundByte)
                {
                    byte generatedByte = (Byte)r.Next(256);
                    if (!dict.ContainsKey(generatedByte))
                    {
                        mapping[i] = generatedByte;
                        dict.Add(generatedByte, true);
                        foundByte = true;
                    }
                }
            }
            return mapping;
        }

        private static Byte[] BuildRandomMapping3() {
            Byte[] mapping = new Byte[256];
            for (int i = 0; i < 256; i++) {mapping[i] = (byte)i;}
            Random r = new Random(42);
            for (int i = 0; i < 1000; i++) {
                int idx1, idx2;
                byte b1, b2;
                idx1 = r.Next(255);
                idx2 = r.Next(255);
                b1 = mapping[idx1];
                b2 = mapping[idx2];
                mapping[idx1] = b2;
                mapping[idx2] = b1;
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
            Byte[] encryptedTextStep01 = Step01.Encrypt(Encoding.ASCII.GetBytes(clearText));
            Console.WriteLine("Step 01: " + ToString(encryptedTextStep01));
            Byte[] decryptedTextStep01 = Step01.Decrypt(encryptedTextStep01);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep01));
            // Step 02
            Byte[] encryptedTextStep02 = Step02.Encrypt(encryptedTextStep01, 'q', 2);
            Console.WriteLine("Step 02: " + ToString(encryptedTextStep02));
            Byte[] decryptedTextStep02 = Step02.Decrypt(encryptedTextStep02, 2);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep02));
            //Step 03
            Byte[] encryptedTextStep03 = Step03.Encrypt(encryptedTextStep02);
            Console.WriteLine("Step 03: " + ToString(encryptedTextStep03));
            Byte[] decryptedTextStep03 = Step03.Decrypt(encryptedTextStep03);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep03));
            //Step 04
            Byte[] encryptedTextStep04 = Step04.Encrypt(encryptedTextStep03);
            Console.WriteLine("Step 04: " + ToString(encryptedTextStep04));
            Byte[] decryptedTextStep04 = Step04.Decrypt(encryptedTextStep04);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep04));
            //Step 05
            Byte[] encryptedTextStep05 = Step05.Encrypt(encryptedTextStep04);
            Console.WriteLine("Step 05: " + ToString(encryptedTextStep05));
            Byte[] decryptedTextStep05 = Step05.Decrypt(encryptedTextStep05);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep05));
            //Step 06
            Byte[] encryptedTextStep06 = Step06.Encrypt(encryptedTextStep05);
            Console.WriteLine("Step 06: " + ToString(encryptedTextStep06));
            Byte[] decryptedTextStep06 = Step06.Decrypt(encryptedTextStep06);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep06));
            //Step 07
            Byte[] encryptedTextStep07 = Step07.Encrypt(encryptedTextStep06);
            Console.WriteLine("Step 07: " + ToString(encryptedTextStep07));
            Byte[] decryptedTextStep07 = Step07.Decrypt(encryptedTextStep07);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep07));
            //Step 08
            Byte[] encryptedTextStep08 = Step08.Encrypt(encryptedTextStep07);
            Console.WriteLine("Step 08: " + ToString(encryptedTextStep08));
            Byte[] decryptedTextStep08 = Step08.Decrypt(encryptedTextStep08);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep08));
            //Step 09
            Byte[] encryptedTextStep09 = Step09.Encrypt(encryptedTextStep08);
            Console.WriteLine("Step 09: " + ToString(encryptedTextStep09));
            Byte[] decryptedTextStep09 = Step09.Decrypt(encryptedTextStep09);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep09));
            //Step 10
            Byte[] mapping = BuildRandomMapping3();
            Byte[] encryptedTextStep10 = Step10.Encrypt(encryptedTextStep09, mapping);
            Console.WriteLine("Step 10: " + ToString(encryptedTextStep10));
            Byte[] decryptedTextStep10 = Step10.Decrypt(encryptedTextStep10, mapping);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep10));
            // We skip Step 11 because it uses one-way encryption
            // Step 12
            Byte[] encryptedTextStep12 = Step12.Encrypt(encryptedTextStep10);
            Console.WriteLine("Step 12: " + ToString(encryptedTextStep12));
            Byte[] decryptedTextStep12 = Step12.Decrypt(encryptedTextStep12);
            Console.WriteLine("         Decrypts to " + ToString(decryptedTextStep12));
        }
        /// <summary>
        /// This step will encrypt but not decrypt so let's not use it 
        /// </summary>
        private static void TestStep11() {
            Byte[] test = Encoding.ASCII.GetBytes("Hello World");
            Byte[] encryptyed = Step11.Encrypt(test);
        }
        /// <summary>
        /// A stand-alone test for Step 12 'cause it's a little complicated relative to the others 
        /// </summary>
        private static void TestStep12()
        {
            Byte[] test = Encoding.ASCII.GetBytes("abcd");
            Byte[] encrypted = Step12.Encrypt(test);
            Byte[] decrypted = Step12.Decrypt(encrypted);
            Console.WriteLine("Step 12 test: " + ToString(test) + " encrypted to " + ToString(encrypted) + " and decrypted to >>>" + ToString(decrypted) + "<<<");
//                  01234567890
            test = Encoding.ASCII.GetBytes("          ");
            encrypted = Step12.Encrypt(test);
            decrypted = Step12.Decrypt(encrypted);
            Console.WriteLine("Step 12 test: " + ToString(test) + " encrypted to " + ToString(encrypted) + " and decrypted to >>>" + ToString(decrypted) + "<<<");
//                  01234567890
            test = Encoding.ASCII.GetBytes("!@#$%^&*()_+{}\":>?<");
            encrypted = Step12.Encrypt(test);
            decrypted = Step12.Decrypt(encrypted);
            Console.WriteLine("Step 12 test: " + ToString(test) + " encrypted to " + ToString(encrypted) + " and decrypted to >>>" + ToString(decrypted) + "<<<");
        }

        /// <summary>
        /// A stand-alone test for Step 2
        /// </summary>
        private static void TestStep2()
        {
            Byte[] result;
            result = Step02.Encrypt(Encoding.ASCII.GetBytes("abc"), 'q', 2);
            Console.WriteLine("Step 02 Encrypt: " + ToString(result));

            result = Step02.Decrypt(result, 2);
            Console.WriteLine("Step 02 Decrypt: " + ToString(result));
        }
        private static void TestStep09() {
            Byte[] result;
            result = Step09.Encrypt(Encoding.ASCII.GetBytes("abcdef"));
            Console.WriteLine("Step 09 Encrypt: >>>" + ToString(result) + "<<<");

            result = Step09.Decrypt(result);
            Console.WriteLine("Step 09 Decrypt: >>>" + ToString(result) + "<<<");
        }
        private static void TestStep10() {
            Byte[] result;
            Byte[] randomMapping = BuildRandomMapping3();
            result = Step10.Encrypt(Encoding.ASCII.GetBytes("abc"), randomMapping);
            Console.WriteLine("Step 10 Encrypt: >>>" + ToString(result) + "<<<");
     
            result = Step10.Decrypt(result, randomMapping);
            Console.WriteLine("Step 10 Decrypt: >>>" + ToString(result) + "<<<");
        }
        private static String ToString(Byte[] text) {
            return Encoding.Default.GetString(text);
        }
    }
}
    