using System;

namespace OrbitMap
{
    class Program
    {
        static void Main(string[] args)
        {
            OrbitMap orbitMap = new OrbitMap("TestOrbits");
            Console.WriteLine(orbitMap.CountTotalDistanceInMap());
        }
    }
}
