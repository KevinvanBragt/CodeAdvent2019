using System;
using System.Collections.Generic;
using System.IO;

namespace SpaceImageParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = _getInput("input");
            int width = 25;
            int tall = 6;
            int amountOfLayers = (input.Length / (width * tall));
            List<ImageLayer> layers = new List<ImageLayer>();

            for (int x = 1; x <= amountOfLayers; x++)
            {
                string layer = input.Substring((input.Length - (x * (width * tall))), (width * tall));
                layers.Add(new ImageLayer(layer));
            }

            ImageLayer leastCorrupted = layers.Find((ImageLayer l) => l.GetAmountOf(0) == _FindLowestAmountOfZeros(layers));

            Console.WriteLine(leastCorrupted.GetAmountOf(1) * leastCorrupted.GetAmountOf(2));
        }

        private static string _getInput(string name)
        {
            using (StreamReader r = new StreamReader(@"D:\CodeAdvent2019\CodeAdvent2019\7\SpaceImageFormat\" + name + ".txt"))
            {
                return r.ReadToEnd();
            }
        }

        private static int _FindLowestAmountOfZeros(List<ImageLayer> layers)
        {
            int lowestAmountOfZeros = 150;
            layers.ForEach((ImageLayer l) =>
            {
                if (l.GetAmountOf(0) < lowestAmountOfZeros)
                {
                    lowestAmountOfZeros = l.GetAmountOf(0);
                }
            });
            return lowestAmountOfZeros;
        }

    }

    public class ImageLayer
    {
        private string Data;
        public ImageLayer(string data)
        {
            Data = data;
        }

        public int GetAmountOf(int intToSearchFor)
        {
            int AmountOfX = 0;
            char x = Char.Parse(intToSearchFor.ToString());

            foreach (char c in Data)
            {
                if (c.Equals(x))
                {
                    AmountOfX++;
                }
            }
            return AmountOfX;
        }
    }
}
