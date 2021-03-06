﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassGuesser
{
    public class Validator
    {
        public bool IsValid(int guess)
        {
            byte[] guessArray = ParseGuess(guess);
            return (SatisfiesIncreasingRule(guessArray) && SatisfiesDoubleRule(guessArray));
        }

        private bool SatisfiesIncreasingRule(byte[] guessArray)
        {
            return guessArray[0] <= guessArray[1] &&
                   guessArray[1] <= guessArray[2] && 
                   guessArray[2] <= guessArray[3] && 
                   guessArray[3] <= guessArray[4] && 
                   guessArray[4] <= guessArray[5];
        }

        private bool SatisfiesDoubleRule(byte[] guessArray)
        {
            List<byte> numbers = guessArray.ToList<byte>();
            foreach (byte y in numbers.ToList<byte>())
            {
                if (numbers.FindAll(v => v == y).Count != 2)
                {              
                    numbers.RemoveAll((v => v == y));
                }
            }
            return (numbers.Count == 2 || numbers.Count == 4 || numbers.Count == 6);
        } 

        private byte[] ParseGuess(int guess)
        {
            int x = 0;
            Byte[] guessArray = new Byte[6];
            foreach (Char c in guess.ToString().ToCharArray())
            {
                guessArray[x] = Byte.Parse(c.ToString());
                x++;
            }
            return guessArray;
        }

    }
}
