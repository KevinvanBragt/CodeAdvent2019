using System;

namespace PassGuesser
{
    class Program
    {
        private static string input = "235741-706948";

        static void Main(string[] args)
        {
            Guesser guesser = new Guesser(input);
            Console.WriteLine(guesser.GetAmountOfPossibilities());
        }
    }
}
