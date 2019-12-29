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
                Planet p = null;
                Planet o = null;
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

                    //p.AddOrbiter(o);
                    o.setOrbits(p);

                }

            }
        }

        public int CountTotalDistanceInMap()
        {
            int totalDistance = 0;
            Planets.ForEach((Planet p) => totalDistance += p.CountDistanceToCom());
            return totalDistance;
        }


    }
}
