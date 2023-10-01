using System;
using System.IO;
using System.Threading;
using Apps.MIV;
using BiscuitOS.Account;
using BiscuitOS.Apps.TextEditor;
using BiscuitOS.FileExplorer;

namespace BiscuitOS.Commands
{
    public class CommandManager
    {
        public static void Command(string cmd)
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
                    BConsole.ForegroundColor = ConsoleColor.Red;
                    BConsole.WriteLine("Unable To Call c# Function .ToLower()");
                    BConsole.ForegroundColor = ConsoleColor.White;
                }

                // Parse Command

                string[] commandWord = lw.Split(' ');

                /* 
                 * Note: The only parsing in this file should be commandWord[0] and then they 
                 * should go off to their own file.
                 */
                if (commandWord[0] == "exit")
                {
                    BConsole.Clear();
                    BConsole.WriteLine("Shutting Down! See you later.");
                    Thread.Sleep(1000);
                    Cosmos.System.Power.Shutdown();
                }
                else if (commandWord[0] == "cls")
                {
                    BConsole.Clear();
                }
                else if (commandWord[0] == "ls")
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
                else if (commandWord[0] == "cd")
                {
                    FileMan.AddDir(commandWord[1]);
                }
                else if (commandWord[0] == "bkdir")
                {
                    FileMan.BackDir();
                }
                else if (commandWord[0] == "fm")
                {
                    // Access file man
                    FileMan.ParseFileCommand(commandWord);
                }
                else if (commandWord[0] == "rd")
                {
                    string[] contents = File.ReadAllLines(FileMan.GetPath() + commandWord[1]);
                    foreach(string line in contents)
                    {
                        BConsole.WriteLine(line);
                    }
                    BConsole.ReadLine();
                    BConsole.Clear();
                }
                else if (commandWord[0] == "miv")
                {
                    string[] args = { FileMan.GetPath() + commandWord[1] };
                    MIV.StartMIV(args);
                }
                else if (commandWord[0] == "open")
                {
                    string[] args = { FileMan.GetPath() + commandWord[1] };
                    TextEditor.StartTextEditor(args);
                }
                else if (commandWord[0] == "print")
                {
                    BConsole.WriteLine(commandWord[1]);
                }
                else if (commandWord[0] == "if")
                {
                    
                }
                else
                {
                    if (commandWord[0] != "")
                    {
                        BConsole.WriteLine($"'{commandWord[0]}' is not recognized as an internal or external batch command.");
                    }
                }
            }
            catch
            {
                //BConsole.WriteLine("Please specify a component after command word.");
            }
        }

        public FileMan IfStatement(string[] commandWord, FileMan CurrentFileMan)
        {

            // Convert The IfStatement To A Straight String
            string commandString = ""; // Command Words To String
            foreach(string arg in commandWord)
            {
                commandString = commandString + arg;
            }

            BConsole.WriteLine(commandString);

            // Safe code to prevent infin loop
            if (!commandString.Contains('"') && !commandString.Contains("'"))
            {
                BConsole.WriteLine("Cannot Parse If Statement");
                return CurrentFileMan;
            }

            // Parse the if statement
            char letter = ' '; // Letter it is on
            string stLetter = "";
            int loop = -1;
            // Find what the question will be
            while(letter != '"' || stLetter != "'")
            {
                loop++;

                letter = commandString[loop];
                stLetter = commandString[loop].ToString();
            }

            int start = loop;
            // Now find the end

            // Reset Variables
            letter = ' '; // Letter it is on
            stLetter = "";
            loop++;
            while (letter != '"' || stLetter != "'")
            {
                loop++;

                letter = commandString[loop];
                stLetter = commandString[loop].ToString();
            }

            int end = loop;

            // We now know what the question is.

            // We can then remove stuff
            string question = commandString.Remove(start, end);

            BConsole.WriteLine(question);

            return CurrentFileMan;
        }
    }
}
