using System;
using System.Collections.Generic;
using BiscuitOS.FileManager;
using BiscuitOS.Shell.Commands;

namespace BiscuitOS.Shell
{
    public class Shell
    {
        /*
         * == Shell Notes ==
         * 
         * - If the mode of the shell moves backwards, it requires a restart
         * 
         */

        private static readonly bool Yes = true;
        private static readonly bool No = false;

        private static ShellMode Mode;
        private static bool ShellInited = false;

        public static void InitShell(ShellMode StartMode, int[]? errors = null)
        {
            if(!ShellInited)
            {
                Mode = StartMode;

                // Arguments & Stuff
                if(errors != null)
                {
                    foreach(int error in errors)
                    {
                        switch(error) {
                            case 0:
                                BConsole.WriteLine("Bad Start: Shell failed to start correctly");
                                break;
                        }
                    }
                }

                ShellInited = true;
            }
            else
            {
                // Post Error Message

                // Cannot init shell if already inited
            }
        }

        public static int TickShell()
        {
            // We need to know if the Shell is usable
            if (!IsShellUsable())
            {
                int[] args = { 0 };
                InitShell(ShellMode.Text, args);
            }

            if (IsShellTextM()) TickTextShell();

            return 1;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="CorrectUser"></param>
        /// <param name="CorrectPass"></param>
        public static void Login(string CorrectUser, string CorrectPass)
        {
            // Login
            BConsole.WriteLine("Welcome To BiscuitOS");
            // Username
            string user = String.Empty;
            while (user != CorrectUser)
            {
                user = BConsole.ReadLine("Username: ");
            }
            //Password
            string pass = String.Empty;
            while (pass != CorrectUser)
            {
                pass = BConsole.ReadRedacted("Password: ");
            }
        }

        private static void TickTextShell()
        {
            // Old Code From Kernel
            var input = BConsole.ReadLine($"{FileMan.GetPath()}> ");
            BConsole.WriteLine($"{FileMan.GetPath()}> {input}");
            ParseUserCommand(input);
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

        /// <summary>
        /// Check to see if the Shell is in text mode
        /// </summary>
        /// <returns></returns>
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
            string[] unsplit = command.Split(' ');

            // Run the command words
            // Failed Or Succeeded
            int FS = CommandInterpreter.Interpret(commandWord , unsplit);
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
