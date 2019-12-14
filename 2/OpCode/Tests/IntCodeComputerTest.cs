using NUnit.Framework;
using Opcode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class IntCodeComputerTest
    {

        [Test]
        public void IntCodeComputerTestDay2()
        {
            InputProcessor inputProcessor = new InputProcessor();
            int[] state = inputProcessor.State;

            IntCodeComputer computer = new IntCodeComputer();
            int[] output = computer.Compute(state);

            Assert.IsTrue(output[0] == 5534943);
        }

    }
}
