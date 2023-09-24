using System;
using System.IO;
using BiscuitOS.FileExplorer;

namespace BiscuitOS.Commands
{
    public class CommandManager
    {
        public FileMan Command(string cmd, FileMan CurrentFileMan)
        {
            try
            {
                // To Lower
                var lw = cmd + " ";
                try
                {
                    lw = cmd.ToLower();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable To Call c# Function .ToLower()");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // Parse Command

                string[] commandWord = lw.Split(' ');

                /* 
                 * Note: The only parsing in this file should be commandWord[0] and then they 
                 * should go off to their own file.
                 */
                if (commandWord[0] == "exit")
                {
                    Cosmos.System.Power.Shutdown();
                }else if (commandWord[0] == "cls")
                {
                    Console.Clear();
                }else if (commandWord[0] == "ls")
                {
                    Console.WriteLine(CurrentFileMan.GetPath());

                    // List Current Dir Info
                    var files_list = Directory.GetFiles(CurrentFileMan.GetPath());
                    var directory_list = Directory.GetDirectories(CurrentFileMan.GetPath());

                    Console.WriteLine();
                    Console.WriteLine("    Files:");
                    Console.WriteLine();
                    foreach (var file in files_list)
                    {
                        Console.WriteLine("    " + file);
                    }
                    Console.WriteLine();
                    Console.WriteLine("    Directories:");
                    Console.WriteLine();
                    foreach (var directory in directory_list)
                    {
                        Console.WriteLine("    " + directory);
                    }
                    Console.WriteLine();
                }
                else if (commandWord[0] == "cd")
                {
                    CurrentFileMan.AddDir(commandWord[1]);
                }
                else if (commandWord[0] == "bkdir")
                {
                    CurrentFileMan.BackDir();
                }
                else if (commandWord[0] == "rd")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine(CurrentFileMan.ReadFile(commandWord[1]));
                    Console.WriteLine();
                    Console.WriteLine("Click Enter To Close File...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    if (commandWord[0] != "")
                    {
                        Console.WriteLine($"'{commandWord[0]}' is not recognized as an internal or external batch command.");
                    }
                }
            }
            catch
            {
                return CurrentFileMan;
                Console.WriteLine("Please specify a component after command word.");
            }
            return CurrentFileMan;
        }
    }
}
