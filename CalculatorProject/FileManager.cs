using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject
{
    internal class FileManager
    {
        private Dictionary<string, double> variables = new();

        public void AddVariable(string name, double value)
        {
            variables[name] = value;
        }

        public void SaveFile()
        {
            string fileName = "saveFile.csv";
            string filePath = $"../../../VariableData/{fileName}";
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(new FileStream(filePath, FileMode.Append));

                foreach (KeyValuePair<string, double> kvp in variables)
                {
                    writer.WriteLine("{0},{1}", kvp.Key, kvp.Value);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Invalid file path");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void LoadFile()
        {
            StreamReader reader = null;
            string fileName = "saveFile.csv";
            string filePath = $"../../../VariableData/{fileName}";
            string text = "";

            try
            {
                reader = new StreamReader(filePath);
                text = reader.ReadLine();
                if(text == null)
                {
                    Console.WriteLine("Your save file is empty");
                }
                else
                {
                    while(reader.Peek() != -1)
                    {
                        text = reader.ReadLine();
                        string[] fields = text.Split(",");
                        variables[fields[0]] = double.Parse(fields[1]);
                    }
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File not found");
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }
        }

    }
}
    