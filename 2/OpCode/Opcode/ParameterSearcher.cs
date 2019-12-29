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
        private int SearchConfiguration = -1;
        private int noun = 0;
        private int verb = 0;

        public ParameterSearcher(int[] originalState, IntCodeComputer computer)
        {
            OriginalState = originalState;
            Computer = computer;
        }
        
        public int Search(int outputToSearchFor, int indexToSearchAt=0)
        {
            int position = 0;
            int result;
            do
            {
                SetSearchState();
                SetSearchConfiguration();
                Computer.State = SearchState;
                result = Computer.Compute();
            } while (Computer.State[indexToSearchAt] != outputToSearchFor && position < OriginalState.Length-3);

            return Computer.State[1] * 100 + Computer.State[2];

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
