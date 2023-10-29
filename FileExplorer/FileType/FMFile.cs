using System;
using System.Collections.Generic;
using System.IO;
using BiscuitOS.FileExplorer;
using BiscuitOS.Shell;

namespace BiscuitOS.FileExecutable
{
    public class FMFile
    {
        public void RunFile(string path)
        {

            // Convert To Array
            try
            {
                // Convert to array
                string[] readFile = File.ReadAllLines(path);

                List<string> program = new List<string>();

                foreach (string line in readFile)
                {
                    Shell.Shell.ParseUserCommand(line);
                    //.WriteLine($"Doing Command {line}");
                }
            }
            catch
            {
                BConsole.ForegroundColor = ConsoleColor.Red;
                BConsole.WriteLine("Failed To Read '.fm' File.");
                BConsole.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
