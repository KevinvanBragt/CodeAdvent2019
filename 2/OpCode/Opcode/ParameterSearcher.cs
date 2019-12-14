using System;
using System.Collections.Generic;
using System.Text;

namespace Opcode
{
    public class ParameterSearcher
    {
        private IntCodeComputer Computer;

        private readonly int[] OriginalState;
        private int[] SearchState;
        private int Position;
        private int SearchConfiguration = -1;
        private int noun = 0;
        private int verb = 0;

        public ParameterSearcher(int[] originalState)
        {
            OriginalState = originalState;
            Computer = new IntCodeComputer();
        }
        
        public int[] Search(int output)
        {
            
            int[] result = null;
            do
            {
                SetSearchState();
                SetSearchConfiguration();
                result = Computer.Compute(SearchState, Position);
            } while (result[0] != output && Position < OriginalState.Length-3);

            return result;

        }

        private void SetSearchState()
        {
            SearchState = new int[OriginalState.Length];
            for (int i = 0; i < OriginalState.Length; i++)
            {
                SearchState[i] = OriginalState[i];
                SearchState[1] = noun;
                SearchState[2] = verb;
            }
        }
              
        private void SetSearchConfiguration()
        {

            if (noun == 99 || noun == 0)
            {
                SearchConfiguration *= -1;
                noun += SearchConfiguration;

                verb += 1;
            }
            else
            {
                noun += SearchConfiguration;
            }
        }



    }
}
