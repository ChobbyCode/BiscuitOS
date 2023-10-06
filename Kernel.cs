﻿using Sys = Cosmos.System;
using BiscuitOS.Commands;
using BiscuitOS.FileExplorer;
using Cosmos.System.Graphics;
using System.Drawing;
using BiscuitOS.Graphics;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static Canvas canvas;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Renderer.StartGUIMode();
        }

        protected override void Run()
        {
            Renderer.AddRenderWindow(new Window("New Empty Window", 840, 420));

            Renderer.RenderScreen();
        }
    }
}
