

namespace BiscuitOS.Shell.Commands
{
    /// <summary>
    /// Da System Command Bath Thingy
    /// </summary>
    internal class System
    {
        public static void Execute(string[] args)
        {
            switch (args[1])
            {
                default:
                    BConsole.WriteLine($"Invalid use of the 'System' command namespace, '{args[1]}' is not reconized as a internal or extenal Shell command.");
                    break;
            }
        }
    }
}
