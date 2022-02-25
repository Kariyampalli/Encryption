using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Encryption;

namespace ChaocipherTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestEncrypt()
        {
            Chaocipher chaocipher = new Chaocipher(null, "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", null);
            Assert.IsNull(chaocipher.Encrypt("4TT4CK")); 
            chaocipher = new Chaocipher("BBCDEFGHIJKLMNOPQRSTUVWXYZ", "PTLNBQDEOYSFAVZKGJRIHWXUMC"); //changed A to B
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("BCDEFGHIJKLMNOPQRSTUVWXYZ", "PTLNBQDEOYSFAVZKGJRIHWXUMC"); //only removed A 
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("AABCDEFGHIJKLMNOPQRSTUVWXYZ", "PTLNBQDEOYSFAVZKGJRIHWXUMC"); //added another A length to big
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));

            chaocipher = new Chaocipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            Assert.IsNull(chaocipher.Encrypt(null));
            Assert.IsNull(chaocipher.Encrypt(""));
            Assert.IsNull(chaocipher.Encrypt(" "));
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            Assert.IsNull(chaocipher.Encrypt("192FUHUJ"));
            Assert.AreEqual("OAHQHCNYNXTSZJRRHJBYHQKSOUJY", chaocipher.Encrypt("WELLDONEISBETTERTHANWELLSAID"));
            Assert.AreEqual("OAHQHCNYNXTSZJRRHJBYHQKSOUJY", chaocipher.Encrypt("WEllDONEISbETTErTHaNWELLSAID"));
            Assert.AreEqual("OAHQ HCNY NX TSZJRR HJBY HQKS OUJY", chaocipher.Encrypt("WELL DONE IS BETTER THAN WELL SAID"));
        }

        [TestMethod]
        public void TestDencrypt()
        {
            Chaocipher chaocipher = new Chaocipher(null, "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", null);
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("PTLNBQDEOYSFAVZKGJRIHWXUMC", "BBCDEFGHIJKLMNOPQRSTUVWXYZ"); //changed A to B
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("PTLNBQDEOYSFAVZKGJRIHWXUMC", "BCDEFGHIJKLMNOPQRSTUVWXYZ"); //only removed A 
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));
            chaocipher = new Chaocipher("PTLNBQDEOYSFAVZKGJRIHWXUMC", "AABCDEFGHIJKLMNOPQRSTUVWXYZ"); //added another A length to big
            Assert.IsNull(chaocipher.Encrypt("4TT4CK"));

            chaocipher = new Chaocipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            Assert.IsNull(chaocipher.Decrypt(null));
            Assert.IsNull(chaocipher.Decrypt(""));
            Assert.IsNull(chaocipher.Decrypt(" "));
            Assert.IsNull(chaocipher.Decrypt("4TT4CK"));
            Assert.IsNull(chaocipher.Decrypt("192FUHUJ"));
            Assert.AreEqual("WELLDONEISBETTERTHANWELLSAID", chaocipher.Decrypt("OAHQHCNYNXTSZJRRHJBYHQKSOUJY"));
            Assert.AreEqual("WELLDONEISBETTERTHANWELLSAID", chaocipher.Decrypt("OahQHcNYnxtSZJrRHJByHQKsOUJY"));
            Assert.AreEqual("WELL DONE IS BETTER THAN WELL SAID", chaocipher.Decrypt("OAHQ HCNY NX TSZJRR HJBY HQKS OUJY"));
        }
    }
}
