using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ManhattanDistance
{
    public class DistanceCalculator
    {
        private List<Point> Crosses = new List<Point>();
        private Dictionary<Point, int> CrossDistances = new Dictionary<Point, int>();

        public DistanceCalculator(Wire wire1, Wire wire2)
        {
            FindCrosses(wire1, wire2);
            FindManhattanDistances();
        }

        private void FindCrosses(Wire wire1, Wire wire2)
        {
            Crosses = wire1.Points.Where(p => wire2.Points.Any(p2 => p.X == p2.X && p.Y == p2.Y)).ToList();
        }

        private int CalculateManhattanDistance(Point point)
        {
            int x = point.X;
            int y = point.Y;

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
            foreach (Point p in Crosses)
            {
                CrossDistances.Add(p, CalculateManhattanDistance(p));
            }

        }

        public int GetNearestDistance()
        {
            return CrossDistances.OrderBy(pd => pd.Value).FirstOrDefault().Value;
        }

    }
}
