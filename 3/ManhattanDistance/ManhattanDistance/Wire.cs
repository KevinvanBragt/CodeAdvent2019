using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ManhattanDistance
{
    public class Wire
    {
        public List<Point> Points { get; private set; } = new List<Point>();
        private (int x, int y) CurrentCoordinate = (0, 0);
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

                Points.Add(new Point(CurrentCoordinate.x, CurrentCoordinate.y));

            } while (--recursion != 0);
        }

    }
}
