

using System.Threading;

namespace BiscuitOS.Shell.Commands
{
    internal class Exit : ShellCommand
    {
        public override void Register()
        {
            
        }

        public override void DoCommandStuff()
        {
            // Just Exit The System
            Thread.Sleep(1000);
            Cosmos.System.Power.Shutdown();
        }
    }
}
