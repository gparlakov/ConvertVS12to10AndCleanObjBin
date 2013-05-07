using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VS12ToVs10Converter
{
    class VS12ToVs10Converter
    {
        static void Main()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var files = Directory.EnumerateFiles(currentDirectory, "*.csproj", SearchOption.AllDirectories);
                       
            foreach (var file in files)
            {
                string fileContent = ReadFile(file);
                string chnagedContent = fileContent.Replace(
                    "<TargetFrameworkVersion>v4.5</TargetFrameworkVersion>", 
                    "<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");

                OverwriteFile(file, chnagedContent);
            }
        }

        private static void OverwriteFile(string file, string content)
        {
            StreamWriter writer = new StreamWriter(file);
            using (writer)
            {
                writer.Write(content);
            }
        }

        private static string ReadFile(string file)
        {
            string fileContent;
            StreamReader reader = new StreamReader(file);
            using (reader)
            {
                fileContent = reader.ReadToEnd();
            }

            return fileContent;
        }
    }
}
