using System;
namespace CyberSecurityGroupProject
{
    public class Step13
    {
        /// <summary>
        /// Reverse the bits in each byte
        /// </summary>
        /// <param name="text">The data to process</param>
        /// <returns>The encrypted data</returns>
        public static Byte[] Encrypt(Byte[] text) {
            Byte[] encryptedText = new byte[text.Length];
            int idx = 0;
            foreach (Byte b in text) {
                encryptedText[idx] = ReverseBits(b);
                idx++;
            }
            return encryptedText;
        }
        public static Byte[] Decrypt(Byte[] text) {
            Byte[] decryptedText = new byte[text.Length];
            int idx = 0;
            foreach (Byte b in text) {
                decryptedText[idx] = ReverseBits(b);
                idx++;
            }
            return decryptedText;
        }
        private static Byte ReverseBits(Byte b)
        {
            byte reversedByte = 0;
            Byte mask; mask = 0x80;
            for (int i = 0; i < 8; i++) {
                reversedByte |= (byte)((mask & b) !=0 ? 0x01 : 0x00);
                reversedByte = (byte)(reversedByte << 1);
                mask = (byte)(mask >> 1);
            }
            return reversedByte;
        }
    }
}