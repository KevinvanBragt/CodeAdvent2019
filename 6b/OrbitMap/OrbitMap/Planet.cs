using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitMap
{
    public class Planet
    {
        public string Name { get; private set; }

        private List<Planet> OrbitingPlanets = new List<Planet>();
        private Planet Orbits;
        public Planet(string name)
        {
            Name = name;
        }

        public void AddOrbiter(Planet planet)
        {
            OrbitingPlanets.Add(planet);
        }

        public void setOrbits(Planet planet)
        {
            Orbits = planet;
        }

        public int CountDistanceToCom(int total = 0)
        {
            return Orbits == null ? total : Orbits.CountDistanceToCom(total + 1);
        }

    }
}
