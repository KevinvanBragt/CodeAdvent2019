using NUnit.Framework;
using Opcode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class Intcode3and4Test
    {

        [Test]
        public void IntCodeComputer3and4Test()
        {
            int[] state = new int[] { 3, 0, 4, 0, 99 };
            int output;

            IntCodeComputer computer = new IntCodeComputer();
            computer.State = state;
            output = computer.Compute(7);
            Assert.IsTrue(output == 7);
            
        }

        [Test]
        public void IntcodeParserTest()
        {
            IntCodeComputer computer = new IntCodeComputer();
            byte[] instructionset = computer.ParseOpCode(234);
            Assert.IsTrue(instructionset[0] == 0 && instructionset[1] == 0 && instructionset[2] == 2 && instructionset[3] == 34);  
         }


    }
}





