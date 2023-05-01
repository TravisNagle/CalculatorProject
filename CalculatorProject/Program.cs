///////////////////////////////////////////////////////////////////////////////
//
// Author: Travis Nagle, Naglet@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 7 - CalculatorProject
// Description: Program class that runs program
//
///////////////////////////////////////////////////////////////////////////////
namespace CalculatorProject
{
    /// <summary>
    /// Program class that loads program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that runs the menu
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            FileManager mana = new FileManager();
            menu.MenuOptions();
        }
    }
}