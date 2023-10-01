using System;
using Sys = Cosmos.System;
using BiscuitOS.Commands;
using BiscuitOS.FileExplorer;
using BiscuitOS.Account;
using System.Threading;
using BiscuitOS;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        CommandManager commandManager = new CommandManager();
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        FileMan FileMan = new();
        public string currentDir = @"0:\";

        protected override void BeforeRun()
        {

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            BConsole.Refresh();

            BConsole.WriteLine(BConsole.ReadRedacted("Password: "));

            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            BConsole.WriteLine("Available Free Space: " + available_space);

            BConsole.WriteLine();
            BConsole.WriteLine("Copyright ChobbyCode 2023.");
            BConsole.WriteLine();
        }

        protected override void Run()
        {
            //Text Stuff
            var input = BConsole.ReadLine($"{FileMan.GetPath()}> ");
            BConsole.WriteLine($"{FileMan.GetPath()}> {input}");
            FileMan = commandManager.Command(input, FileMan);
        }
    }
}
