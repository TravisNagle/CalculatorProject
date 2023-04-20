using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    internal class Menu
    {
        private Dictionary<int, string> menu = new();
        private bool Quit { get; set; } = false;

        public Menu()
        {
            Calculator calc = new Calculator();
            Console.WriteLine("----------------CALCULATOR----------------");
            Console.WriteLine("Please select an option");
            Console.WriteLine("Start\tQuit");
            string answer = Console.ReadLine();

            if (answer == "Start")
            {
                while(!Quit)
                {

                }
            }
        }
    }
}
