using System;
using static ManhattanDistance.DistanceCalculator.DistanceTypes;

namespace ManhattanDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();

            Wire wire1 = new Wire(input.wireDirections1);
            Wire wire2 = new Wire(input.wireDirections2);

            DistanceCalculator calculator = new DistanceCalculator(wire1, wire2);
            Console.WriteLine(calculator.GetNearestDistance(Manhattan));

        }
    }
}
