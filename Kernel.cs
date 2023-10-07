﻿using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using BiscuitOS.Graphics;
using BiscuitOS.Math;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static Canvas canvas;
        Window testWindow;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            testWindow = new Window(new Dimension(420, 840), "New Empty Window");
            //testWindow.MoveWindow(new Vector2(0, 0));

            Renderer.StartGUIMode();
        }

        protected override void Run()
        { 
            Renderer.AddRenderWindow(testWindow);
            Renderer.RenderScreen();
        }
    }
}
