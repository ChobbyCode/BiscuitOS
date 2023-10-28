

namespace BiscuitOS.Shell
{
    public class ShellCommand
    {
        /// <summary>
        /// Registers the command as a system shell command
        /// </summary>
        public virtual void Register() { }
        /// <summary>
        /// Does the command stuff
        /// </summary>
        public virtual void DoCommandStuff() { }
    }
}
