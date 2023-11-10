using BiscuitOS.ExceptionHandling;
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
            }catch (Exception e) 
            {
                OSException.CreateErrorLog(ErrorTypes.ParcingError, e, "Failed To Use C# Function ( .ToLower(); )");
            }

            // Parse command into lists
            string[] commandWord = commandLower.Split(' ');
        
            return commandWord;
        }
    }
}
