using System;

namespace Opcode
{
    class Program
    {
        static void Main(string[] args)
        {
            InputProcessor inputProcessor = new InputProcessor();
            int[] state = inputProcessor.State;

            ParameterSearcher searcher = new ParameterSearcher(state);
            int[] output = searcher.Search(19690720);

            Console.WriteLine((output == null) ? "something went wrong" : (100 * output[1] + output[2]).ToString());
            System.Environment.Exit(1);
        }
    }
}
