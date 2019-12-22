using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Opcode
{
    public class IntCodeComputer
    {
        private int[] State;
        private int Position = 0;

        public int[] Compute(int[] state, int position = 0)
        {
            State = state;
            Position = position;
            Boolean found;
            do
            {
                found = Process();
                Position += 4;
            } while (Position < State.Length-3 && !found);
 
            return State;

        }

        private Boolean Process()
        {
            if (State[Position] == 1)
            {
                State[State[Position + 3]] = State[State[Position + 1]] + State[State[Position + 2]];
            }
            else if (State[Position] == 2)
            {
                State[State[Position + 3]] = State[State[Position + 1]] * State[State[Position + 2]];
            }
            else if (State[Position] == 99)
            {
                return true;
            }

            return false;


        }

        
    }
}
