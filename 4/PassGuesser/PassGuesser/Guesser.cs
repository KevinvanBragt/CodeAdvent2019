using System;
using System.Collections.Generic;
using System.Text;

namespace PassGuesser
{
    public class Guesser
    {
        private Validator validator = new Validator();
        private List<int> Guesses = new List<int>();

        public Guesser(string input)
        {
            string[] inputs = input.Split("-");
            CreateGuesses(int.Parse(inputs[0]), int.Parse(inputs[1]));
        }

        private void CreateGuesses(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                if (validator.IsValid(i))
                {
                    Guesses.Add(i);
                } 
            }
        }

        public int GetAmountOfPossibilities()
        {
            return Guesses.Count;
        }
    }
}
