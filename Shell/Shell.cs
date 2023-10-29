using System.Collections.Generic;
using BiscuitOS.Shell.Commands;

namespace BiscuitOS.Shell
{
    public class Shell
    {
        public static void ParseUserCommand(string command)
        {
            // Parse the command words ready for reading
            string[] commandWord = CommandParser.ParseCommand(command);

            // Run the command words
            // Failed Or Succeeded
            int FS = CommandInterpreter.Interpret(commandWord);
            if(FS == 0)
            {
                // Print No Exist
                BConsole.WriteLine($"'{commandWord[0]}' is not recognized as an internal or external Shell command.");
            }
            if(FS == 2)
            {
                BConsole.WriteLine($"Unimplemented Shell Command '{commandWord[0]}'.");
            }
        }
    }
}
