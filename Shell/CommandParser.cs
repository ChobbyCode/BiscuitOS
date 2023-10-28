using System;



namespace BiscuitOS.Shell
{
    internal class CommandParser
    {
        public static string[] ParseCommand(string command)
        {
            // Parse the command

            // We want a to lower and normal version of the command
            string commandLower = command + " ";
            try
            {
                commandLower = commandLower.ToLower();
            }catch
            {
                BConsole.ForegroundColor = ConsoleColor.Red;
                BConsole.WriteLine("Unable To Call c# Function .ToLower()");
                BConsole.ForegroundColor = ConsoleColor.White;
            }

            // Parse command into lists
            string[] commandWord = commandLower.Split(' ');
        
            return commandWord;
        }
    }
}
