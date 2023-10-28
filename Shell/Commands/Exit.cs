using System.Threading;

namespace BiscuitOS.Shell.Commands
{
    internal class Exit : ShellCommand
    {
        public new string TriggerWord = "exit";

        public override void DoCommandStuff(string[] c)
        {
            // Just Exit The System
            Thread.Sleep(1000);
            Cosmos.System.Power.Shutdown();
        }

        public static ShellCommand New()
        {
            return new Exit();
        }
    }
}
