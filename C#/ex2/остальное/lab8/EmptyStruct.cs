using System;
using System.IO;
using System.Linq;
using System.Text;
namespace lab8
{
  

    public class Program1
{
    public static void Main()
    {
        const string outputFileName = "ResultText.out";
        string inputFileName = string.Empty;

        Console.Write("Введите название входного файла: ");
        inputFileName = Console.ReadLine();

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