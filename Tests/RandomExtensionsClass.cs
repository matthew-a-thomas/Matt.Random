namespace Tests
{
    using System.Linq;
    using Matt.Random;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RandomExtensionsClass
    {
        [TestClass]
        public class ToEndlessBitSequenceMethod
        {
            [TestMethod]
            public void InvokesRandomPopulate()
            {
                var mocked = new Mock<IRandom>();
                mocked
                    .Object
                    .ToEndlessBitSequence()
                    .Take(10)
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    .ToList();
                mocked.Verify(x => x.Populate(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>()));
            }
        }
    }
}