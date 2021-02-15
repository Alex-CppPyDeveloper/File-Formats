using System;

namespace KasperskyTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileProcessor fileProcessor = new FileProcessor();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите имя файла: ");
                var fileName = Console.ReadLine();

                fileProcessor.ProcessFile(fileName);
            }
        }
    }
}
