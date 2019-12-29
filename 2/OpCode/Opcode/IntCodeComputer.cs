using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Opcode
{
    public class IntCodeComputer
    {
        public int[] State { get; set; }
        private int Position;
        public enum ParameterModes { Position = 0, Immediate =1 };

        //expose state through method instead of this. then use it in searcher and normal. 

        public int Compute(in int input=0)
        {
            Position = 0;
            bool exit;
            int result = 0;

            do
            {
                
                exit = Process(ref result, input);
                Console.WriteLine("input: " + input + "result: " + result);
                Position += 4;
            } while (Position < State.Length && !exit);

            return result;
        }

        private Boolean Process(ref int output, int input)
        {
            byte[] instructionSet = ParseOpCode(State[Position]);

            if (instructionSet[3] == 1)
            {
                State[State[Position + 3]] = GetValue(GetParameterMode(instructionSet[0]), Position+1) + GetValue(GetParameterMode(instructionSet[1]), Position + 2);
            }
            else if (instructionSet[3] == 2)
            {
                State[State[Position + 3]] = GetValue(GetParameterMode(instructionSet[0]), Position + 1) * GetValue(GetParameterMode(instructionSet[1]), Position + 2);
            }
            else if (instructionSet[3] == 3)
            {
                State[State[Position + 1]] = input;
                Position -= 2; //nog refactoren zodat dit in de compute functie gebeurd.
            }
            else if (instructionSet[3] == 4)
            {
                output = GetValue(GetParameterMode(instructionSet[0]), Position + 1);
                Position -= 2; //nog refactoren zodat dit in de compute functie gebeurd.
                return true;
            }
            else if (instructionSet[3] == 99)
            {
                return true;
            }

            return false;
        }

        public byte[] ParseOpCode(int opCode)
        {
            byte[] instructionSet = new byte[4] { 0, 0, 0, 0 };
            
            //add leading zero's
            StringBuilder code = new StringBuilder(opCode.ToString());
            while (code.Length != 5)
            {
                code = code.Insert(0, "0");
            }

            for (int x = 0; x < 3; x++)
            {
                instructionSet[x] = byte.Parse(code.ToString().Substring(x, 1));
            }
            instructionSet[3] = byte.Parse(code.ToString().Substring(3, 2));

            return instructionSet;
        }

        private ParameterModes GetParameterMode (byte instruction)
        {
            return (ParameterModes)instruction;
        }

        private int GetValue(ParameterModes mode, int parameter)
        {
            if (mode == ParameterModes.Immediate)
            {
                return parameter;
            }
            else if (mode == ParameterModes.Position)
            {
                return State[State[parameter]];
            }
            else return 0;
            
        }
    }
}
