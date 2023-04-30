using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    internal class Menu
    {
        private Dictionary<string, dynamic> menu = new();
        private bool Quit { get; set; } = false;

        public void Start()
        {
            Calculator calc = new Calculator();


            menu["add"] = new Action<string, string>((a, b) => calc.Add(a, b));
            menu["store"] = new Action<string, string>((a, b) => calc.Store(a, b));

            while(true)
            {
                Console.WriteLine(calc.GetCurrentValue());
                string[] input = Console.ReadLine().Split(" ");

                if(input.Length == 3)
                {
                    menu[input[0]](input[1], input[2]);
                }
                else if(input.Length == 2)
                {
                    menu[input[0]](input[1], calc.GetCurrentValue().ToString());
                }
            }
        }
    }
}
