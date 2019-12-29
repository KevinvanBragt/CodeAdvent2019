using NUnit.Framework;
using Opcode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class Diagnostics
    {

        [Test]
        public void RunTests()
        {
            InputProcessor input = new InputProcessor("TEST.txt");

            IntCodeComputer computer = new IntCodeComputer();
            computer.State = input.State;

            int inputin = 1;
            int outputout = 0;

            do
            {
                outputout = computer.Compute(inputin);
                inputin = outputout;
                Console.WriteLine(outputout);
            } while (outputout == 0);

            Console.WriteLine(computer.State[0]);
            

        }
    }
}
