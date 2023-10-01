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
        CommandManager commandManager = new CommandManager();
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        FileMan FileMan = new();
        public string currentDir = @"0:\";

        protected override void BeforeRun()
        {

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            BConsole.Refresh();

            if (!File.Exists($@"0:\System\Account\uData"))
            {
                BConsole.WriteLine("Welcome To Biscuit OS");
                BConsole.WriteLine("Lets go through the setup guide...");
                BConsole.WriteLine();
                BConsole.WriteLine("Click enter on your keyboard to continue..");
                BConsole.ReadLine();
                BConsole.WriteLine();
                BConsole.WriteLine("What Should We Call You?");
                var name = BConsole.ReadLine("Your Name: ");
                BConsole.WriteLine($"Hello {name}, we need to choose a password for your account to");
                BConsole.WriteLine("Make sure you remeber your password or you cant't log into your account again");
                var password = BConsole.ReadRedacted("Password: ");
                BConsole.WriteLine();
                BConsole.WriteLine("Please Wait. This May Take Some Time");

                try
                {
                    if (!Directory.Exists($@"0:\System\"))
                    {
                        Directory.CreateDirectory($@"0:\System\");
                    }
                    if (!Directory.Exists($@"0:\System\Account\"))
                    {
                        Directory.CreateDirectory($@"0:\System\Account\");
                    }

                    if (!File.Exists($@"0:\System\Account\uData"))
                    {
                        File.Create($@"0:\System\Account\uData");
                    }

                    string[] uData =
                    {
                        "Type: SYSTEM_FILE",
                        "",
                        $"{name}",
                        $"{password}"
                    };

                    File.WriteAllLines($@"0:\System\Account\uData", uData);
                    
                }
                catch
                {
                    Console.WriteLine("An Error Occured In The Installation Process!");
                }

                BConsole.WriteLine();
                BConsole.WriteLine("All Done. We Just Need To Restart - your system - Quickly");
                BConsole.ReadLine();

                Cosmos.System.Power.Reboot();

            }

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
