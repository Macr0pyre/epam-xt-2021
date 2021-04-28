using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task_4_1.UI
{
    static class ConsoleUISupporting
    {
        public static bool TryInputDirectory(string message, out string path)
        {
            Console.Write(message);

            path = Console.ReadLine();

            return Directory.Exists(path);
        }
    }
}
