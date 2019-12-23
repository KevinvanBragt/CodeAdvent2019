using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ManhattanDistance
{
    public class Wire
    {
        public Dictionary<(int, int), long> Points { get; private set; } = new Dictionary<(int, int), long>();
        private (int x, int y) CurrentCoordinate = (0, 0);
        private long CurrentIteration = 0;

        public Wire(String[] directions)
        {
            foreach (String direction in directions) 
            {
                string command = direction.Trim();
                GeneratePoints(command.Substring(0, 1), int.Parse(Regex.Replace(command, "[^.0-9]", "")));
            }
        }

        private void GeneratePoints(String direction, int recursion)
        {
            do
            {
                switch (direction)
                {
                    case "U" : CurrentCoordinate.y++; break;
                    case "D" : CurrentCoordinate.y--; break;
                    case "L" : CurrentCoordinate.x--; break;
                    case "R" : CurrentCoordinate.x++; break;
                    default: break;
                }
                CurrentIteration++;

                if (!Points.ContainsKey((CurrentCoordinate.x, CurrentCoordinate.y)))
                {
                    Points.Add((CurrentCoordinate.x, CurrentCoordinate.y), CurrentIteration);
                }

            } while (--recursion != 0);
        }

        public bool ContainsPoint((int x, int y) coordinate)
        {
            return Points.ContainsKey(coordinate);
        }
        public Dictionary<(int, int), long> FindCrosses(Wire wire)
        {
            Dictionary<(int, int), long> crosses = new Dictionary<(int, int), long>();

            foreach (KeyValuePair<(int x, int y), long> p in Points)
            {
                if (wire.ContainsPoint((p.Key)))
                {
                    crosses.Add(p.Key, p.Value);
                }
            }
            return crosses;
        }
       
    }
}
