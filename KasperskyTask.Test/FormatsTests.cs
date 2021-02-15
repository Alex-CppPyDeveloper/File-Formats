using System;
using Xunit;
using System.IO;
using System.Text.Json;
using KasperskyTask;

namespace KasperskyTask.Test
{

    public class FormatsTest
    {
        [Fact]
        public void FileTest()
        {
            var readFormats = File.ReadAllText("Settings/formats.json");

            Assert.NotNull(readFormats);
        }

        [Fact]
        public void JSONTest()
        {
            var readFormats = File.ReadAllText("Settings/formats.json");
            ProcessedFormats processedFormats = JsonSerializer.Deserialize<ProcessedFormats>(readFormats);

            Assert.NotNull(processedFormats);
        }

        [Fact]
        public void FormatTest()
        {
            var readFormats = File.ReadAllText("Settings/formats.json");
            ProcessedFormats processedFormats = JsonSerializer.Deserialize<ProcessedFormats>(readFormats);
            foreach (var item in processedFormats.Formats)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Assert.True(Convert.ToInt32(item[i]) > 96);
                }
            }
        }
    }
}
