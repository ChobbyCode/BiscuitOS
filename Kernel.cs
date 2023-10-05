using Sys = Cosmos.System;
using BiscuitOS.Commands;
using BiscuitOS.FileExplorer;
using Cosmos.System.Graphics;
using System.Drawing;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            BConsole.WriteLine("Available Free Space: " + available_space);

            
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
