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
        private Dictionary<string, dynamic> underlyingCommands = new();
        private Dictionary<uint, string> menu = new();
        private bool Quit { get; set; } = false;

        public void Start()
        {
            Calculator calc = new Calculator();
            menu[1] = "add";
            menu[2] = "subtract";
            Console.WriteLine("////////////////////Calculator////////////////////");
            for(uint i = 1; i <= menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }


            underlyingCommands["="] = new Action<string, string>((a, b) => calc.Store(a, b));
            underlyingCommands["+"] = new Action<string, string>((a, b) => calc.Add(a, b));
            underlyingCommands["-"] = new Action<string, string>((a, b) => calc.Subtract(a, b));
            underlyingCommands["*"] = new Action<string, string>((a, b) => calc.Multiply(a, b));
            underlyingCommands["/"] = new Action<string, string>((a, b) => calc.Divide(a, b));

            //TODO: Fix error where divide and subtract don't work properly when working with the current value
            while (!Quit)
            {
                Console.WriteLine("Current Value: " + calc.GetCurrentValue());
                string[] input = Console.ReadLine().Split(" ");

                try
                {
                    if (input.Length == 3)
                    {
                        underlyingCommands[input[1]](input[0], input[2]);
                    }
                    else if (input.Length == 2)
                    {
                        underlyingCommands[input[0]](calc.GetCurrentValue().ToString(), input[1]);
                    }
                }
                catch(KeyNotFoundException e)
                {
                    Console.WriteLine("I'm sorry, I didn't understand that. Please try again.");
                }
            }
        }
    }
}
