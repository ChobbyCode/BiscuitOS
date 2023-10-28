

namespace BiscuitOS.Shell
{
    internal class CommandInterpreter
    {
        public static void Interpret(string[] commandWord)
        {
            /*
             * == ORDER OF OPERATION ==
             * 
             * - First check for built in commands
             * - Then check for Shell extensions
             * - Post error message
             */

            // Check for built in commands

            var trigWord = commandWord[0];

            foreach (ShellCommand obj in Shell.RC)
            {
                BConsole.WriteLine("Trigger Word: " + obj.TriggerWord);
                if(obj.TriggerWord == trigWord)
                {
                    obj.DoCommandStuff(commandWord);
                    return;
                }
            }
        }
    }
}
