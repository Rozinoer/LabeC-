using System;
using System.IO;
using System.Linq;
using System.Text;

namespace samsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            const string outputFileName = "ResultText.txt";
            string inputFileName = string.Empty;

            Console.Write("Введите название входного файла: ");
            inputFileName = Console.ReadLine();
            if (File.Exists(inputFileName)) { Console.Write("файл существует "); }
                Console.WriteLine();
            if (File.Exists(inputFileName))
            {
                File.WriteAllText(outputFileName, File.ReadAllText(inputFileName, Encoding.UTF8).ToUpper(), Encoding.UTF8);
                Console.WriteLine("Результат успешно записан в файл с именем \"{0}\"", outputFileName);
            }
            else
            {
                Console.WriteLine("Файл с именем \"{0}\" не найден!", inputFileName);
            }

            Console.ReadKey();
        }
    }
}




