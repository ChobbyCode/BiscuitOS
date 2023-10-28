

using System.Collections.Generic;

namespace BiscuitOS.Shell
{
    public static class ShellCommandManager
    {
        private static List <ShellCommand> RegisteredCommands = new List <ShellCommand>();

        public static void RegisterCommand(this ShellCommand register)
        {
            // Do stuff
            RegisteredCommands.Add(register);
        }
    }
}
