using System;

namespace Opcode
{
    class Program
    {
        static void Main(string[] args)
        {
            InputProcessor inputProcessor = new InputProcessor("1202 program alarm.txt");
            int[] state = inputProcessor.State;

            //Diagnostic diagTest = new Diagnostic(1);

            //ParameterSearcher searcher = new ParameterSearcher(state, computer);
            //int? output = searcher.Search(19690720);
            //Console.WriteLine((output == null) ? "something went wrong" : output.ToString());
            
            System.Environment.Exit(1);
        }
    }
}
