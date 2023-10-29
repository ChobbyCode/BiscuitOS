using System.Collections.Generic;
using BiscuitOS.Shell.Commands;

namespace BiscuitOS.Shell
{
    public class Shell
    {
        /*
         * == Shell Notes ==
         * 
         * - Changing the shell mode requires a restart
         * 
         */

        private static readonly bool Yes = true;
        private static readonly bool No = false;

        private static ShellMode Mode;
        private static bool ShellInited = false;

        public static void InitShell(ShellMode StartMode)
        {
            if(!ShellInited)
            {
                Mode = StartMode;
                ShellInited = true;
            }
            else
            {
                // Post Error Message

                // Cannot init shell if already inited
            }
        }

        /// <summary>
        /// Check to see if the shell is usable
        /// </summary>
        /// <returns>True if yes, False if no</returns>
        public static bool IsShellUsable()
        {
            if(ShellInited) return Yes;
            else return No;
        }

        public static bool IsShellTextM()
        {
            if(Mode == ShellMode.Text) return Yes;
            else return No;
        }

        public static void ParseUserCommand(string command)
        {
            // Just makes sure we aren't causing any errors
            if(!IsShellUsable()) return;

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
