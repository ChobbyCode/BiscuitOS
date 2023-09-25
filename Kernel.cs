﻿using System;
using Sys = Cosmos.System;
using BiscuitOS.Commands;
using Cosmos.System.Graphics;
using System.Drawing;
using System.Threading;
using System.IO;
using BiscuitOS.FileExplorer;

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

            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Available Free Space: " + available_space);

            Console.WriteLine();
            Console.WriteLine("Copyright ChobbyCode 2023.");
            Console.WriteLine();
        }

        protected override void Run()
        {
            //Text Stuff
            Console.Write($"{FileMan.GetPath()}> ");
            var input = Console.ReadLine();

            FileMan = commandManager.Command(input, FileMan);
        }
    }
}