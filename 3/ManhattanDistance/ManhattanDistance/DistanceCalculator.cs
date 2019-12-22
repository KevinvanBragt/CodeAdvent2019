using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ManhattanDistance
{
    public class DistanceCalculator
    {
        private List<(int, int)> Crosses = new List<(int, int)>();
        private Dictionary<(int, int), int> CrossDistances = new Dictionary<(int, int), int>();

        public DistanceCalculator(Wire wire1, Wire wire2)
        {
            FindCrosses(wire1, wire2);
            FindManhattanDistances();
        }

        private void FindCrosses(Wire wire1, Wire wire2)
        {
            foreach ((int, int) coordinate in wire1.Points)
            {
                if (wire2.Points.Contains(coordinate))
                {
                    Crosses.Add(coordinate);
                }
            }
        }

        private int CalculateManhattanDistance(int x, int y)
        {
            if (x < 0)
            {
                x *= -1;
            }
            if (y < 0)
            {
                y *= -1;
            }
            return x + y;
        }

        private void FindManhattanDistances()
        {
            foreach ((int, int) coordinate in Crosses)
            {
                CrossDistances.Add((coordinate.Item1, coordinate.Item2), CalculateManhattanDistance(coordinate.Item1, coordinate.Item2));
            }
        }

        public int GetNearestDistance()
        {
            return CrossDistances.OrderBy(pd => pd.Value).FirstOrDefault().Value;
        }

    }
}
