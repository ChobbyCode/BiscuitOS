

namespace BiscuitOS.Shell
{
    public class ShellCommand
    {
        public string TriggerWord;

        /// <summary>
        /// Does the command stuff
        /// </summary>
        public virtual void DoCommandStuff(string[] commandWords) { }
    }
}
