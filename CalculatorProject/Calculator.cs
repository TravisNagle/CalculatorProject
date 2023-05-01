using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    /// <summary>
    /// Implementation of the calculator class that handles several basic calculations
    /// </summary>
    internal class Calculator
    {
        public Dictionary<string, double> dispatchTable = new();
        
        /// <summary>
        /// Keeps track of whatever the previously calculated value is
        /// </summary>
        /// <returns>The last calculated value</returns>
        public double GetCurrentValue()
        {
            return dispatchTable.ContainsKey("currentValue") ? dispatchTable["currentValue"] : 0;
        }

        /// <summary>
        /// Clears the current value
        /// </summary>
        public void Clear()
        {
            dispatchTable["currentValue"] = 0;
        }

        /// <summary>
        /// Stores a variable to a value to a variable
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Store(string key, string value)
        {
            double x;
            double.TryParse(value, out x);
            dispatchTable[key] = x;
        }

        /// <summary>
        /// Converts values to fit underlying dispatch table
        /// </summary>
        /// <param name="value">key to store</param>
        /// <returns>value as a double</returns>
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

        /// <summary>
        /// Add method for adding a value to the current value
        /// </summary>
        /// <param name="input">value to add</param>
        public void Add(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() + x;
        }

        /// <summary>
        /// Adds two indpendent values together
        /// </summary>
        /// <param name="inputOne">first value</param>
        /// <param name="inputTwo">second value</param>
        public void Add(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x + y;
        }

        /// <summary>
        /// Subtracts value from the current value
        /// </summary>
        /// <param name="input">value to subtract</param>
        public void Subtract(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() - x;
        }

        /// <summary>
        /// Subtracts two independent values
        /// </summary>
        /// <param name="inputOne">first value</param>
        /// <param name="inputTwo">second value</param>
        public void Subtract(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x - y;
        }

        /// <summary>
        /// Multiplies the current value by an input value
        /// </summary>
        /// <param name="input">multiplier</param>
        public void Multiply(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() * x;
        }

        /// <summary>
        /// Multiplies two independent values
        /// </summary>
        /// <param name="inputOne">first value</param>
        /// <param name="inputTwo">second value</param>
        public void Multiply(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x * y;
        }

        /// <summary>
        /// Divides by a value from the current value
        /// </summary>
        /// <param name="input">divisor</param>
        public void Divide(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() / x;
        }

        /// <summary>
        /// Divides two independent values
        /// </summary>
        /// <param name="inputOne">Dividend</param>
        /// <param name="inputTwo">Divisor</param>
        public void Divide(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x / y;
        }

        /// <summary>
        /// Modulus function that takes the remainder from the current value
        /// </summary>
        /// <param name="input">Modulus value</param>
        public void Mod(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = this.GetCurrentValue() % x;
        }

        /// <summary>
        /// Modulus function for two independent values
        /// </summary>
        /// <param name="inputOne">first value</param>
        /// <param name="inputTwo">second value</param>
        public void Mod(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = x % y;
        }

        /// <summary>
        /// Squares the the given value
        /// </summary>
        /// <param name="input">value to square</param>
        public void Square(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = Math.Pow(x, 2);
        }

        /// <summary>
        /// Takes the root of the current value
        /// </summary>
        /// <param name="input">root index</param>
        public void Root(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = Math.Pow(this.GetCurrentValue(), 1 / x);
        }

        /// <summary>
        /// Takes the root of a value to another value as the root index
        /// </summary>
        /// <param name="inputOne">input value</param>
        /// <param name="inputTwo">root index</param>
        public void Root(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = Math.Pow(x, 1 / y);
        }

        /// <summary>
        /// Exponentiates the current value to the input value
        /// </summary>
        /// <param name="input">exponent</param>
        public void Exp(string input)
        {
            double x = Parse(input);
            dispatchTable["currentValue"] = Math.Pow(this.GetCurrentValue(), x);
        }

        /// <summary>
        /// Exponentiates an input value to a certain power
        /// </summary>
        /// <param name="inputOne">input value</param>
        /// <param name="inputTwo">exponent</param>
        public void Exp(string inputOne, string inputTwo)
        {
            double x = Parse(inputOne);
            double y = Parse(inputTwo);
            dispatchTable["currentValue"] = Math.Pow(x, y);
        }

        /// <summary>
        /// Factorial function that takes one input that calculates the factorial of that input
        /// </summary>
        /// <param name="input">input value</param>
        /// <exception cref="KeyNotFoundException">if value is negative, throw exception</exception>
        public void Factorial(string input)
        {
            double x = Parse(input);
            double total = 1;
            if (x == 0)
            {
                x = total;
            }
            else if(x < 0)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                for (int i = 1; i <= x; i++)
                {
                    total *= i;
                }
            }
            dispatchTable["currentValue"] = total;
        }
    }
}
