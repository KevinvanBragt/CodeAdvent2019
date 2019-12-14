using System;
using System.Collections.Generic;

namespace FuelUpper
{
    public class Program
    {
    
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Advent! \n\n");

            InputProcessor inputProcessor = new InputProcessor();
            List<Module> Modules = new List<Module>();
            inputProcessor.Input.ForEach((string s) => Modules.Add(new Module(Int32.Parse(s))));

            FuelUpper fuelUpper = new FuelUpper();
            Console.WriteLine(fuelUpper.getRequiredAmountOfFuel(Modules));

        }
    }
}
