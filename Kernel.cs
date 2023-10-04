using System;
using Sys = Cosmos.System;
using BiscuitOS.Commands;
using BiscuitOS.FileExplorer;
using BiscuitOS.Account;
using System.Threading;
using BiscuitOS;
using System.IO;
using Cosmos.Core.IOGroup.Network;
using BiscuitOS.Apps.TextEditor;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            BConsole.Refresh();

            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            BConsole.WriteLine("Available Free Space: " + available_space);

            BConsole.WriteLine();
            BConsole.WriteLine("Copyright ChobbyCode 2023.");
            BConsole.WriteLine();

            try
            {
                File.Create(@"0:\bob.txt");
            }
            catch
            {
                BError.SystemDeleteError();
            }
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
