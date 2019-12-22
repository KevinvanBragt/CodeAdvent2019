using System;
using System.Collections.Generic;
using System.IO;

namespace Opcode
{
    public class InputProcessor
    {

        public int[] State { get; private set; }

        public InputProcessor()
        {
            ParseFile();
            RecoverState();
        }

        private void ParseFile()
        {
            string[] input; 

            using (StreamReader r = new StreamReader(@"D:\CodeAdvent2019\CodeAdvent2019\2\OpCode\1202 program alarm.txt"))
            {
                input = r.ReadToEnd().Split(",");
            }

            State = Array.ConvertAll(input, s => Convert.ToInt32(s));
        }

        private void RecoverState()
        {
            State[1] = 12;
            State[2] = 2;
        }

    }
}
