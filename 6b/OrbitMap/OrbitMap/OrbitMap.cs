using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrbitMap
{
    public class OrbitMap
    {
        private List<Planet> Planets = new List<Planet>();

        public OrbitMap(string orbitListName)
        {

            using (StreamReader r = new StreamReader(@"D:\CodeAdvent2019\CodeAdvent2019\6b\OrbitMap\"+orbitListName+".txt"))
            {
                string line;
                Planet p, o = null;
                while ((line = r.ReadLine()) != null)
                {
                    if (!Planets.Exists((Planet p) => p.Name.Equals(line.Split(")")[0])))
                    {
                        p = new Planet(line.Split(")")[0]);
                        Planets.Add(p);   
                    }
                    else
                    {
                        p = Planets.Find((Planet p) => p.Name.Equals(line.Split(")")[0]));
                    }
                    
                    if (!Planets.Exists((Planet o) => o.Name.Equals(line.Split(")")[1])))
                    {
                        o = new Planet(line.Split(")")[1]);
                        Planets.Add(o);
                    }
                    else
                    {
                        o = Planets.Find((Planet o) => o.Name.Equals(line.Split(")")[1]));
                    }

                    o.OrbitsPlanet(p);
                }
            }
        }

        public int CountTotalDistanceInMap()
        {
            int totalDistance = 0;
            Planets.ForEach((Planet p) => totalDistance += p.CountDistanceToCom());
            return totalDistance;
        }

        private int FindPathBetween(Planet x, Planet y)
        {
            List<Planet> pathX = new List<Planet>();
            List<Planet> pathY = new List<Planet>();
            List<Planet> path = new List<Planet>();

            while (x.Orbits != null)
            {
                pathX.Add(x.Orbits);
                x = x.Orbits;
            }

            while (y.Orbits != null)
            {
                pathY.Add(y.Orbits);
                y = y.Orbits;
            }

            pathX.ForEach((Planet p) => { if (!pathY.Contains(p)) path.Add(p); });
            pathY.ForEach((Planet p) => { if (!pathX.Contains(p)) path.Add(p); });

            //path now contains the list to traverse, minus the intersectionpoint
            //however, I don't add this because the example also counts the step to the planet you currently orbit..

            return path.Count;
        }

        public int FindPathBetween(string nameX, string nameY)
        {
            Planet x = Planets.Find((Planet p) => p.Name.Equals(nameX));
            Planet y = Planets.Find((Planet p) => p.Name.Equals(nameY));

            return FindPathBetween(x, y);
        }
    }
}
