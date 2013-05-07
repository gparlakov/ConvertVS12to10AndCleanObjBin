using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BinObjCleaner
{
    class BinObjCleaner
    {
        static void Main()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var binDirectories = Directory.GetDirectories(currentDirectory, "bin", SearchOption.AllDirectories);
                foreach (var subDirectory in binDirectories)
                {
                    Directory.Delete(subDirectory, true);
                }

                var objDirectories = Directory.GetDirectories(currentDirectory, "obj", SearchOption.AllDirectories);
                foreach (var dir in objDirectories)
                {
                    Directory.Delete(dir, true);
                }
            }
            catch (Exception ex)
            {
                foreach (var key in ex.Data.Keys)
                {
                    Console.WriteLine(ex.Data[key]);
                }
            }
        }
    }
}
