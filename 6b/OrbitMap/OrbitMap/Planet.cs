using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitMap
{
    public class Planet
    {
        public string Name { get; private set; }
        public Planet Orbits { get; private set; }
        public Planet(string name)
        {
            Name = name;
        }

        public void OrbitsPlanet(Planet planet)
        {
            Orbits = planet;
        }

        public int CountDistanceToCom(int total = 0)
        {
            return Orbits == null ? total : Orbits.CountDistanceToCom(total + 1);
        }

    }
}
