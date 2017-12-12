namespace Tests.BitManipulation
{
    using System;
    using System.Linq;
    using Matt.Random.BitManipulation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BitExtensionsClass
    {
        [TestClass]
        public class GetBitsMethod
        {
            [TestMethod]
            public void Converts0xF05CTo0b1111_0000_0101_1100()
            {
                var bytes = new byte[] { 0b1111_0000, 0b0101_1100 };
                var bits = bytes.ToBits().ToList();
                Assert.IsTrue(bits.SequenceEqual(new []
                {
                    true, true, true, true,
                    false, false, false, false,
                    false, true, false, true,
                    true, true, false, false
                }),
                string.Join(", ", bits.Select(x => x ? "1" : "0")));
            }
            
            [TestMethod]
            public void Converts0xFFTo0b1111_1111()
            {
                var bytes = new byte[] {0b1111_1111};
                var bits = bytes.ToBits().ToList();
                Assert.IsTrue(
                    bits.SequenceEqual(Enumerable.Repeat(true, 8)),
                    string.Join(", ", bits.Select(x => x ? "1" : "0"))
                );
            }
        }
        
        [TestClass]
        public class GetBytesMethod
        {
            [TestMethod]
            public void MakesFunnyValueFromIncompleteBytes()
            {
                var bits = Enumerable.Repeat(true, 12);
                var bytes = bits.ToBytes().ToList();
                Assert.IsTrue(
                    bytes.SequenceEqual(new byte[] { 0xFF, 0xF0 }),
                    BitConverter.ToString(bytes.ToArray()));
            }
            
            [TestMethod]
            public void MakesValueFromIncompleteByte()
            {
                var bits = new[]
                {
                    true
                };
                var bytes = bits.ToBytes().ToList();
                Assert.AreEqual(
                    bytes.Count,
                    1,
                    BitConverter.ToString(bytes.ToArray()));
            }
            
            [TestMethod]
            public void Converts0b1111_0000_0101_1100To0xF05C()
            {
                var bits = new []
                {
                    true, true, true, true,
                    false, false, false, false,
                    false, true, false, true,
                    true, true, false, false
                };
                var bytes = bits.ToBytes().ToList();
                Assert.IsTrue(
                    bytes.SequenceEqual(new byte[] { 0xF0, 0x5C }),
                    BitConverter.ToString(bytes.ToArray()));
            }
            
            [TestMethod]
            public void Converts0b1111_1111To0xFF()
            {
                var bits = new [] { true, true, true, true, true, true, true, true };
                var bytes = bits.ToBytes().ToList();
                Assert.IsTrue(
                    bytes.SequenceEqual(new byte[] { 0xFF }),
                    BitConverter.ToString(bytes.ToArray()));
            }
        }
    }
}