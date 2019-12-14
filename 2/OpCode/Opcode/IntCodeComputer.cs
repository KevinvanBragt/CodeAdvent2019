using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Opcode
{
    public class IntCodeComputer
    {
        int[] State;
        int Position = 0;

        public int[] Compute(int[] state, int position = 0)
        {
            State = state;
            Position = position;
            int[] result = null;
            try
            {
                do
                {
                    result = Process();
                    Position += 4;
                } while (Position < State.Length-3);
            }
            catch (Exception e)
            {
                //
            }

            return result;

        }

        private int[] Process()
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
                return State;
            }

            return null;

        }

        
    }
}
