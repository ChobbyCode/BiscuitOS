using System.Threading;

namespace BiscuitOS.Shell.Commands
{
    internal class Exit
    {
        public static void Execute(string[] c)
        {
            // Just Exit The System
            Thread.Sleep(1000);
            Cosmos.System.Power.Shutdown();
        }
    }
}
