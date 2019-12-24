using NUnit.Framework;
using PassGuesser;

namespace Test
{
    public class Tests
    {
        Validator validator = new Validator();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncreasingRuleTest()
        {
            Assert.IsTrue(validator.IsValid(123466));
            Assert.IsFalse(validator.IsValid(123324));
        }

        [Test]
        public void DoubleRuleTest()
        {
            Assert.IsTrue(validator.IsValid(112233));
            Assert.IsTrue(validator.IsValid(111122));
            Assert.IsFalse(validator.IsValid(123444));
        }
    }
}