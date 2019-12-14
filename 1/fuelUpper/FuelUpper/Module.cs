using System;
using System.Collections.Generic;
using System.Text;

namespace FuelUpper
{
    public class Module
    {
        private int Mass;
        private int RequiredFuel;

        public Module (int mass)
        {
            Mass = mass;
            RequiredFuel = CalculateRequiredFuel();
        }

        public int getRequiredFuel()
        {
            return RequiredFuel;
        }

        private int CalculateRequiredFuel()
        {
            if (this.Mass == 0)
            {
                throw new Exception("mass is null");
            }

            int fuelforMass = CalculateFuelbyMass(Mass);

            int fuelForFuel = CalculateFuelForFuel(fuelforMass);

            return fuelforMass + fuelForFuel;
        }

        private int CalculateFuelbyMass(int mass)
        {
            return Convert.ToInt32(Math.Floor(((double)mass / 3)) - 2);
        }
    
        private int CalculateFuelForFuel(int fuelForMass)
        {
            int additionalFuel = 0;
            int toAdd = 0;
   
            do {
      
                toAdd = CalculateFuelbyMass(fuelForMass);
                if (toAdd > 0)
                {
                    additionalFuel += toAdd;
                }
                 fuelForMass = toAdd;
            } while (fuelForMass > 0);

            return additionalFuel;

        }
    
        
    
    }
}
