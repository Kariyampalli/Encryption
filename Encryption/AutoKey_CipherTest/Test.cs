using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Encryption;

namespace AutoKey_CipherTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestEncrypt()
        {
            Autokey_Cipher autokey_Cipher = new Autokey_Cipher();
            Assert.IsNull(autokey_Cipher.Encrypt("", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Encrypt("12A3", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Encrypt("AIFH!$§", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Encrypt("   ", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Encrypt(null, "QUEENLY"));

            Assert.IsNull(autokey_Cipher.Encrypt("ATTACK AT DAWN", ""));
            Assert.IsNull(autokey_Cipher.Encrypt("ATTACK AT DAWN", "12A3"));
            Assert.IsNull(autokey_Cipher.Encrypt("ATTACK AT DAWN", "AIFH!$§"));
            Assert.IsNull(autokey_Cipher.Encrypt("ATTACK AT DAWN", " "));
            Assert.IsNull(autokey_Cipher.Encrypt("ATTACK AT DAWN", null));

            Assert.AreEqual("QNXEPVYTWTWP",(autokey_Cipher.Encrypt("ATTACK AT DAWN", "QUEENLY")));
            Assert.AreEqual("QNXEPVYTWTWP", (autokey_Cipher.Encrypt("aTtACK aT DAWN", "QUEENLY")));
            Assert.AreEqual("QNXEPVYTWTWP", (autokey_Cipher.Encrypt("ATTACK AT DAWN", "quEENly")));
            Assert.AreEqual("QNXEPVYTWTWP", (autokey_Cipher.Encrypt("ATTACK AT DAWN", "QUEE NLY")));
        }

        [TestMethod]
        public void TestDencrypt()
        {
            Autokey_Cipher autokey_Cipher = new Autokey_Cipher();
            Assert.IsNull(autokey_Cipher.Decrypt("", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Decrypt("12A3", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Decrypt("AIFH!$§", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Decrypt("   ", "QUEENLY"));
            Assert.IsNull(autokey_Cipher.Decrypt(null, "QUEENLY"));

            Assert.IsNull(autokey_Cipher.Decrypt("ATTACK AT DAWN", ""));
            Assert.IsNull(autokey_Cipher.Decrypt("ATTACK AT DAWN", "12A3"));
            Assert.IsNull(autokey_Cipher.Decrypt("ATTACK AT DAWN", "AIFH!$§"));
            Assert.IsNull(autokey_Cipher.Decrypt("ATTACK AT DAWN", " "));
            Assert.IsNull(autokey_Cipher.Decrypt("ATTACK AT DAWN", null));

            Assert.AreEqual("ATTACKATDAWN", (autokey_Cipher.Decrypt("QNXEPVYTWTWP", "QUEENLY")));
            Assert.AreEqual("ATTACKATDAWN", (autokey_Cipher.Decrypt("QNXEPVyTWtWP", "QUEENLY")));
            Assert.AreEqual("ATTACKATDAWN", (autokey_Cipher.Decrypt("QNXEPVYTWTWP", "quEENly")));
            Assert.AreEqual("ATTACKATDAWN", (autokey_Cipher.Decrypt("QNXEPVYTWTWP", "quE ENly")));
            Assert.AreEqual("ATTACKATDAWN", (autokey_Cipher.Decrypt("QNXEPV YTWTWP", "quEENly")));
        }
    }
}
