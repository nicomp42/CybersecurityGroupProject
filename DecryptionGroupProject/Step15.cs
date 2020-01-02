using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityGroupProject {
    class Step15 : Step {

        /// <summary>
        /// Convert each byte to a set of 8 bytes, one bit per byte based on the ASCII chart 
        /// For example, {'a','b','c'} converts to {'0','1','0','0','0','0','0','1','0','1','0','0','0','0','1','0','0','1','0','0','0','0','1','1'}
        /// </summary>
        /// <param name="bytes">The message to be encrypted</param>
        /// <returns>The encrypted message</returns>
        public override byte[] Encrypt(byte[] bytes) {
            byte[] encrypt = new byte[bytes.Length * 8];
            int offset = 0;
            foreach (Byte b in bytes) {
                byte[] tmp;
                tmp = ConvertByteToByteArrayOfBits(b);
                for (int i = 0; i < tmp.Length; i++) {
                    encrypt[offset + i] = tmp[i];
                }
                offset += 8;
            }
            return encrypt;
        }
        /// <summary>
        /// Decrypt the bytes after they were encrypted in the Encrypt method in this class
        /// </summary>
        /// <param name="bytes">Bytes to be decrypted. All bytes will be '1' or '0'</param>
        /// <returns>The decrypted bytes.</returns>
        public override byte[] Decrypt(byte[] bytes) {
            Byte[] decrypt = new byte[bytes.Length / 8];        // Each set of 8 bytes will collapse into one byte of the decrypted message
            for (int i = 0; i < bytes.Length/8; i++) {
                Byte[] tmpBytes;
                tmpBytes = new byte[8];
                tmpBytes[0] = bytes[(i * 8) + 0]; tmpBytes[1] = bytes[(i * 8) + 1];
                tmpBytes[2] = bytes[(i * 8) + 2]; tmpBytes[3] = bytes[(i * 8) + 3];
                tmpBytes[4] = bytes[(i * 8) + 4]; tmpBytes[5] = bytes[(i * 8) + 5];
                tmpBytes[6] = bytes[(i * 8) + 6]; tmpBytes[7] = bytes[(i * 8) + 7];
                decrypt[i] = ConvertByteArrayOfBitsToByte(tmpBytes);
            }
            return decrypt;
        }
        /// <summary>
        /// Convert an 8-byte array into one byte, each element in the array is ASCII one or ASCII zero
        /// </summary>
        /// <param name="b">The byte array to be converted. Must be 8 bytes</param>
        /// <returns>The single byte</returns>
        private static Byte ConvertByteArrayOfBitsToByte(Byte[] bytes) {
            byte result = 0;
            foreach (Byte b in bytes) {
                result = (byte)(result << 1);
                if (b == (byte)'1') {
                    result = (byte)(result | 0x01);
                }
            }
            return result;
        } 

        /// <summary>
        /// Convert one byte to an 8-byte array, each element in the array is ASCII one or ASCII zero
        /// </summary>
        /// <param name="b">The byte to be converted</param>
        /// <returns>The 8-byte array</returns>
        private static Byte[] ConvertByteToByteArrayOfBits(Byte b) {
            byte[] bytes = new byte[8];
            byte tmp = b;
            for (int i = 7; i >= 0; i--) {
                bytes[i] = ((tmp & (byte)0x01) == 1) ? (byte)'1': (byte)'0';
                tmp = (byte)(tmp >> 1);
            }
            return bytes;
        }
    }
}
