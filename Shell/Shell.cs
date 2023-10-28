using System.Collections.Generic;
using BiscuitOS.Shell.Commands;

namespace BiscuitOS.Shell
{
    public class Shell
    {
        internal static List <ShellCommand> RC = new List <ShellCommand> ();

        public static void AddCommands()
        {
            RC.Add(Exit.New());
        }

        public static void ParseUserCommand(string command)
        {
            // Parse the command words ready for reading
            string[] commandWord = CommandParser.ParseCommand(command);
            foreach (string word in commandWord)
            {
                BConsole.WriteLine(word);
            }

            // Run the command words
            CommandInterpreter.Interpret(commandWord);
        }
    }
}
