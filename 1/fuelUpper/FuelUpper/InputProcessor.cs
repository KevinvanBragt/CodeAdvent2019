using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FuelUpper
{
    public class InputProcessor
    {
        public List<string> Input = new List<string>();
    
        public InputProcessor()
        {
            using (StreamReader r = new StreamReader(@"D:\code advent\1\codeAdvent\Masses.txt"))
            {
                while (r.Peek() >= 0)
                {
                    Input.Add(r.ReadLine());
                }
            }
        }
   
    }
}
