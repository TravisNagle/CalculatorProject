using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    internal class Calculator
    {
        public Dictionary<string, dynamic> dispatchTable = new();
        public void Run()
        {
            dispatchTable["add"] = new Func<int, int, int>((x, y) => (x + y));
            dispatchTable["sub"] = new Func<int, int, int>((x, y) => (x - y));
            dispatchTable["mul"] = new Func<int, int, int>((x, y) => (x * y));
            dispatchTable["div"] = new Func<int, int, int>((x, y) => (x / y));
        }
    }
}
