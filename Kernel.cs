using System;
using Sys = Cosmos.System;
using BiscuitOS.Commands;
using BiscuitOS.FileExplorer;
using BiscuitOS.Account;
using System.Threading;
using BiscuitOS;
using System.IO;
using Cosmos.Core.IOGroup.Network;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            BConsole.Refresh();

            /*var available_space = fs.GetAvailableFreeSpace(@"0:\");
            BConsole.WriteLine("Available Free Space: " + available_space);

            BConsole.WriteLine();
            BConsole.WriteLine("Copyright ChobbyCode 2023.");
            BConsole.WriteLine();*/

            Installer.Installer.StartInstall();
        }

        protected override void Run()
        {
            //Text Stuff
            var input = BConsole.ReadLine($"{FileMan.GetPath()}> ");
            BConsole.WriteLine($"{FileMan.GetPath()}> {input}");
            CommandManager.Command(input);
        }
    }
}
