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
                    BConsole.WriteLine(CurrentFileMan.GetPath());

                    // List Current Dir Info
                    var files_list = Directory.GetFiles(CurrentFileMan.GetPath());
                    var directory_list = Directory.GetDirectories(CurrentFileMan.GetPath());

                    BConsole.WriteLine();
                    BConsole.WriteLine("    Files:");
                    BConsole.WriteLine();
                    foreach (var file in files_list)
                    {
                        BConsole.WriteLine("    " + file);
                    }
                    BConsole.WriteLine();
                    BConsole.WriteLine("    Directories:");
                    BConsole.WriteLine();
                    foreach (var directory in directory_list)
                    {
                        BConsole.WriteLine("    " + directory);
                    }
                    BConsole.WriteLine();
                }
                else if (commandWord[0] == "cd")
                {
                    CurrentFileMan.AddDir(commandWord[1]);
                }
                else if (commandWord[0] == "bkdir")
                {
                    CurrentFileMan.BackDir();
                }
                else if (commandWord[0] == "fm")
                {
                    // Access file man
                    CurrentFileMan.ParseFileCommand(commandWord);
                }
                else if (commandWord[0] == "rd")
                {
                    BConsole.Clear();
                    BConsole.WriteLine();
                    BConsole.WriteLine(CurrentFileMan.ReadFile(commandWord[1]));
                    BConsole.WriteLine();
                    BConsole.ReadLine();
                    BConsole.Clear();
                }
                else if (commandWord[0] == "miv")
                {
                    string[] args = { CurrentFileMan.GetPath() + commandWord[1] };
                    MIV.StartMIV(args);
                }
                else if (commandWord[0] == "open")
                {
                    string[] args = { CurrentFileMan.GetPath() + commandWord[1] };
                    TextEditor.StartTextEditor(args);
                }
                else if (commandWord[0] == "print")
                {
                    BConsole.WriteLine(commandWord[1]);
                }
                else if (commandWord[0] == "if")
                {
                    // If statements
                    CurrentFileMan = IfStatement(commandWord, CurrentFileMan);
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
                return CurrentFileMan;
                //BConsole.WriteLine("Please specify a component after command word.");
            }
            return CurrentFileMan;
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
