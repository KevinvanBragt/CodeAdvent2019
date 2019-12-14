using System;
using System.Collections.Generic;
using System.Text;

namespace FuelUpper
{
    public class FuelUpper
    {

        public long getRequiredAmountOfFuel(List<Module> modules)
        {
            long amountOfFuelRequired = 0;
            modules.ForEach((Module m) => amountOfFuelRequired += m.getRequiredFuel());
            return amountOfFuelRequired;
        }


    }
}
