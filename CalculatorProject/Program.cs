namespace CalculatorProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            FileManager mana = new FileManager();
            menu.MenuOptions();
        }
    }
}