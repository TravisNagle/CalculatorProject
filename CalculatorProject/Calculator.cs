using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    internal class Calculator
    {
        public Dictionary<string, double> dispatchTable = new();
        
        public double GetCurrentValue()
        {
            return dispatchTable.ContainsKey("currentValue") ? dispatchTable["currentValue"] : 0;
        }

        public double Parse(string value)
        {
            double x;
            if(dispatchTable.ContainsKey(value))
            {
                x = dispatchTable[value];
            }
            else
            {
                double.TryParse(value, out x);
            }
            return x;
        }


    }
}
