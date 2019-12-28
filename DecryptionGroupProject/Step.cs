using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityGroupProject {
    abstract class Step {
        /// <summary>
        /// Encrypt a message
        /// </summary>
        /// <param name="bytes">The message to be encrypted</param>
        /// <returns>The encrypted message</returns>
        public abstract byte[] Encrypt(byte[] bytes);
        /// <summary>
        /// Decrypt a message
        /// </summary>
        /// <param name="bytes">The message to be decrypted</param>
        /// <returns>The decrypted message</returns>
        public abstract byte[] Decrypt(byte[] bytes);
    }
}
