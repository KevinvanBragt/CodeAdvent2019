using ManhattanDistance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static ManhattanDistance.DistanceCalculator.DistanceTypes;

namespace ManhattanTests
{
    public class Tests
    {
        public string[] wireDirections1 { get; private set; }
        public string[] wireDirections2 { get; private set; }
        public string[] wireDirections3 { get; private set; }
        public string[] wireDirections4 { get; private set; }
        public string[] wireDirections5 { get; private set; }
        public string[] wireDirections6 { get; private set; }


        [SetUp]
        public void Setup()
        {
            wireDirections1 = "R8,U5,L5,D3".Split(",");
            wireDirections2 = "U7,R6,D4,L4".Split(",");
            wireDirections3 = "R75, D30, R83, U83, L12, D49, R71, U7, L72".Split(",");
            wireDirections4 = "U62,R66,U55,R34,D71,R55,D58,R83".Split(",");
            wireDirections5 = "R98, U47, R26, D63, R33, U87, L62, D20, R33, U53, R51".Split(",");
            wireDirections6 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(",");
        }


        [Test]
        public void TestWires1and2()
        {
            Wire wire1 = new Wire(wireDirections1);
            Wire wire2 = new Wire(wireDirections2);

            DistanceCalculator calculator = new DistanceCalculator(wire1, wire2);
            long? output = calculator.GetNearestDistance(Manhattan);
            Assert.IsTrue(output == 6);

            output = calculator.GetNearestDistance(Iteration);
            Assert.IsTrue(output == 30);
        }

        [Test]
        public void TestWires3and4()
        {
            Wire wire3 = new Wire(wireDirections3);
            Wire wire4 = new Wire(wireDirections4);

            DistanceCalculator calculator = new DistanceCalculator(wire3, wire4);
            long? output = calculator.GetNearestDistance(Manhattan);
            Assert.IsTrue(output == 159);

            output = calculator.GetNearestDistance(Iteration);
            Assert.IsTrue(output == 610);
        }
        
        [Test]
        public void TestWires5and6()
        {
            Wire wire5 = new Wire(wireDirections5);
            Wire wire6 = new Wire(wireDirections6);

            DistanceCalculator calculator = new DistanceCalculator(wire5, wire6);
            long? output = calculator.GetNearestDistance(Manhattan);
            Assert.IsTrue(output == 135);

            output = calculator.GetNearestDistance(Iteration);
            Assert.IsTrue(output == 410);
        }
    }
}
