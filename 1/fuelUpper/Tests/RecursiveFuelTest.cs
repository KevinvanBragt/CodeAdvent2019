using FuelUpper;
using NUnit.Framework;

namespace Tests
{
    public class RecursiveFuelTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RecursiveFuelTest1()
        {
            Module module = new Module(1969);
            Assert.IsTrue(module.getRequiredFuel() == 966);
        }

        [Test]
        public void RecursiveFuelTest2()
        {
            Module module = new Module(100756);
            Assert.IsTrue(module.getRequiredFuel() == 50346, "actual calculation gave + " + module.getRequiredFuel());
        }

 
    }
}