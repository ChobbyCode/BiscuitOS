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

            Console.Clear();

            /*// Sign In
            Console.Write("Username: ");
            if(Console.ReadLine() != "admin")
            {
                commandManager.Command("exit", FileMan);
            }

            AccInputMan accInputMan = new AccInputMan();

            if(accInputMan.ObfuscateInput("Password: ") != "password") 
            {
                commandManager.Command("exit", FileMan);
            }

            Console.Clear();
            Console.WriteLine("Signing In..");
            Thread.Sleep(1000);
            Console.Clear();

            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Available Free Space: " + available_space);

            Console.WriteLine();
            Console.WriteLine("Copyright ChobbyCode 2023.");
            Console.WriteLine();*/
        }

        protected override void Run()
        {
            /*//Text Stuff
            Console.Write($"{FileMan.GetPath()}> ");
            var input = Console.ReadLine();

            FileMan = commandManager.Command(input, FileMan);*/

            BConsole.StartBConsole();
        }
    }
}
