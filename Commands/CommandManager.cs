using System;

namespace BiscuitOS.Commands
{
    public class CommandManager
    {
        public void Command(string cmd)
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
                Console.WriteLine("Please specify a component after command word.");
            }
        }

    }
}
