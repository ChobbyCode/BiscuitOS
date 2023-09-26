using System;
using System.Collections.Generic;
using System.IO;
using BiscuitOS.FileExplorer;
using BiscuitOS.Commands;

namespace BiscuitOS.FileExecutable
{
    public class FMFile
    {
        public void RunFile(string path, FileMan CurrentFileMan)
        {
            // Create Command Manager
            CommandManager commandManager = new CommandManager();

            // Convert To Array
            try
            {
                // Convert to array
                string[] readFile = File.ReadAllLines(path);

                List<string> program = new List<string>();

                foreach (string line in readFile)
                {
                    commandManager.Command(line, CurrentFileMan);
                    //.WriteLine($"Doing Command {line}");
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed To Read '.fm' File.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
