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
            InputProcessor inputProcessor = new InputProcessor("1202 program alarm.txt");

            IntCodeComputer computer = new IntCodeComputer();
            computer.State = inputProcessor.State;
            int output = computer.Compute();

            Assert.IsTrue(output == 5534943);
        }

    }
}
