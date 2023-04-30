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

        public void Store(string key, string value)
        {
            double x;
            double.TryParse(value, out x);
            dispatchTable[key] = x;
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

        public void Add(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() + x;
        }

        public void Add(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x + y;
        }

        public void Subtract(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() - x;
        }

        public void Subtract(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x - y;
        }

        public void Multiply(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() * x;
        }

        public void Multiply(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x * y;
        }

        public void Divide(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() / x;
        }

        public void Divide(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x / y;
        }
    }
}
