using System;
using System.IO;
using System.Text.Json;

namespace KasperskyTask
{
    public class FileProcessor
    {
        public void ProcessFile(string fileName)
        {
            var address = File.ReadAllText("Settings/formats.json");
            ProcessedFormats formats = JsonSerializer.Deserialize<ProcessedFormats>(address);

            var indexPoint = fileName.IndexOf('.');
            if (indexPoint > 0)
            {
                while (indexPoint > 0)
                {
                    fileName = fileName.Remove(0, indexPoint + 1);
                    indexPoint = fileName.IndexOf('.');
                }

                if (formats.Formats.Find(x => x == fileName) == null)
                {
                   formats.Formats.Add(fileName);
                }
                else Console.WriteLine("Такой формат уже имеется!"); 
            }
            else Console.WriteLine("Имя файла неккоректно!");
            var jsonString = JsonSerializer.Serialize(formats);
            File.WriteAllText("Settings/formats.json", jsonString);
        }
    }
}
