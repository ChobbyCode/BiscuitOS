using System.IO;
using System;
using BiscuitOS.FileManager;


namespace BiscuitOS.Shell.Commands
{
    internal class List
    {
        public static void Execute(string[] c)
        {
            // List Current Dir Info
            var files_list = Directory.GetFiles(FileMan.GetPath());
            var directory_list = Directory.GetDirectories(FileMan.GetPath());

            BConsole.ForegroundColor = ConsoleColor.Black;
            BConsole.WriteLine();
            BConsole.WriteLine("    Files:");
            BConsole.WriteLine();
            BConsole.ForegroundColor = ConsoleColor.White;
            foreach (var file in files_list)
            {
                BConsole.WriteLine("    " + file);
            }
            BConsole.ForegroundColor = ConsoleColor.Black;
            BConsole.WriteLine();
            BConsole.WriteLine("    Directories:");
            BConsole.WriteLine();
            BConsole.ForegroundColor = ConsoleColor.White;
            foreach (var directory in directory_list)
            {
                BConsole.WriteLine("    " + directory);
            }
            BConsole.ForegroundColor = ConsoleColor.Black;
            BConsole.WriteLine();
        }
    }
}
