﻿using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using BiscuitOS.Graphics;
using BiscuitOS.Math;
using BiscuitOS.Apps;
using BiscuitOS.Tasks;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static Canvas canvas;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Test test = new Test();
            test.Start();

            Renderer.StartGUIMode();

        }

        protected override void Run()
        {
            //AppManager.TickHandlers();
            

            Renderer.RenderScreen();
        }
    }
}
