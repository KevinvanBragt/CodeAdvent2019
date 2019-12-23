using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ManhattanDistance
{
    public class DistanceCalculator
    {
        private Wire Wire1;
        private Wire Wire2;
        private Dictionary<(int, int), long> Wire2Crosses = new Dictionary<(int, int), long>();
        private Dictionary<(int, int), long> Wire1Crosses = new Dictionary<(int, int), long>();

        public enum DistanceTypes { Manhattan, Iteration};

        public DistanceCalculator(Wire wire1, Wire wire2)
        {
            Wire1 = wire1;
            Wire2 = wire2;
            Wire2Crosses = Wire2.FindCrosses(Wire1);
            Wire1Crosses = Wire1.FindCrosses(Wire2);
        }
        
        private long CalculateManhattanDistance((int, int) coordinates)
        {
            int x = coordinates.Item1;
            int y = coordinates.Item2;

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

        private long CalculateIterationDistance((int, int) coordinates)
        {
            return Wire1Crosses.First(p => p.Key == coordinates).Value + Wire2Crosses.First(p => p.Key == coordinates).Value;
        }

        private long FindShortestManhattanDistance()
        {
            List<long> manhattanDistances = new List<long>();

            foreach (KeyValuePair<(int, int), long> point in Wire1Crosses)
            {
                manhattanDistances.Add(CalculateManhattanDistance(point.Key));
            }

            return manhattanDistances.Min();
        }
        private long FindShortestIterationDistance()
        {
            List<long> iterationDistances = new List<long>();

            foreach (KeyValuePair<(int, int), long> point in Wire1Crosses)
            {
                iterationDistances.Add(CalculateIterationDistance(point.Key));
            }

            return iterationDistances.Min();
        } 
        public long? GetNearestDistance(DistanceTypes type)
        {
            if (type == DistanceTypes.Manhattan)
            {
                return FindShortestManhattanDistance();
            }
            else if (type == DistanceTypes.Iteration)
            {               
                return FindShortestIterationDistance();
            }

            return null;
        } 

    }
}
