///////////////////////////////////////////////////////////////////////////////
//
// Author: Travis Nagle, Naglet@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 7 - CalculatorProject
// Description: Menu class that handles user interaction with calculator
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    /// <summary>
    /// Menu class that takes care of user interaction
    /// </summary>
    internal class Menu
    {
        private Dictionary<string, dynamic> underlyingCommands = new();
        private Dictionary<string, string> menu = new();
        private Dictionary<string, dynamic> options = new();
        private FileManager manager = new FileManager();
        private bool QuitCalc { get; set; } = false;
        
        /// <summary>
        /// MenuOptions method that serves as the basic menu when the program starts
        /// </summary>
        public void MenuOptions()
        {
            Console.Clear();
            bool valid = false;

            options["start"] = new Action(() => Start());
            options["load"] = new Action(() => manager.LoadFile());
            options["quit"] = new Action(() => QuitApp());
            
            while(!valid)
            {
                try
                {
                    Console.WriteLine("////////////////////Calculator////////////////////");
                    Console.WriteLine("Start\nLoad\nQuit");
                    string userInput = Console.ReadLine();

                    options[userInput]();
                    valid = true;
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Please enter a valid menu option");
                }
            }
        }

        /// <summary>
        /// Start method that handles the entirety of the Calculator user commands
        /// </summary>
        public void Start()
        {
            Console.Clear();
            Calculator calc = new Calculator();

            menu["add"] = "+";
            menu["subtract"] = "-";
            menu["multiply"] = "*";
            menu["divide"] = "/";
            menu["modulus"] = "%";
            menu["square"] = "square";
            menu["root"] = "root";
            menu["exponentiate"] = "exp";
            menu["factorial"] = "factorial";
            menu["store"] = "=";
            menu["clear"] = "clear";
            Console.WriteLine("////////////////////Calculator////////////////////");
            Console.WriteLine("Operator\t Command");

            foreach (KeyValuePair<string, string> kvp in menu)
            {
                if(kvp.Key == "root" || kvp.Key == "add" || kvp.Key == "store")
                {
                    Console.WriteLine("[{0}]\t\t [{1}]", kvp.Key, kvp.Value);
                }
                else
                {
                    Console.WriteLine("[{0}]\t [{1}]", kvp.Key, kvp.Value);
                }
            }

            underlyingCommands["="] = new Action<string, string>((a, b) => calc.Store(a, b));
            underlyingCommands["+"] = new Action<string, string>((a, b) => calc.Add(a, b));
            underlyingCommands["-"] = new Action<string, string>((a, b) => calc.Subtract(a, b));
            underlyingCommands["*"] = new Action<string, string>((a, b) => calc.Multiply(a, b));
            underlyingCommands["/"] = new Action<string, string>((a, b) => calc.Divide(a, b));
            underlyingCommands["%"] = new Action<string, string>((a, b) => calc.Mod(a, b));
            underlyingCommands["square"] = new Action<string>((a) => calc.Square(a));
            underlyingCommands["exp"] = new Action<string, string>((a, b) => calc.Exp(a, b));
            underlyingCommands["root"] = new Action<string, string>((a, b) => calc.Root(a, b));
            underlyingCommands["factorial"] = new Action<string>((a) => calc.Factorial(a));
            underlyingCommands["clear"] = new Action(() => calc.Clear());

            while (!QuitCalc)
            {
                Console.WriteLine("Current Value: " + calc.GetCurrentValue());
                string[] input = Console.ReadLine().Split(" ");

                try
                {
                    if (input[0] == "clear")
                    {
                        underlyingCommands["clear"]();
                    }
                    else if(input.Length == 3 && input[1] == "=")
                    {
                        Console.WriteLine("Save variable? (Y/N)");
                        string userInput = Console.ReadLine();
                        userInput = userInput.ToUpper();
                        if(userInput == "Y")
                        {
                            manager.AddVariable(input[0], double.Parse(input[2]));
                            manager.SaveFile();
                            Console.WriteLine($"Variable {input[0]} saved");
                        }
                    }
                    else if (input.Length == 3)
                    {
                        underlyingCommands[input[1]](input[0], input[2]);
                    }
                    else if (input.Length == 2 && (input[0] == "factorial" || input[0] == "square"))
                    {
                        underlyingCommands[input[0]](input[1]);
                    }
                    else if (input.Length == 2)
                    {
                        underlyingCommands[input[0]](calc.GetCurrentValue().ToString(), input[1]);
                    }
                    else if (input[0] == "quit")
                    {
                        break;
                    }
                }
                catch(KeyNotFoundException e)
                {
                    Console.WriteLine("I'm sorry, I didn't understand that. Please try again.");
                }
            }
            MenuOptions();
        }

        /// <summary>
        /// QuitApp method that exits the application
        /// </summary>
        public void QuitApp()
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
        }
    }
}
