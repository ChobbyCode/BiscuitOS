using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using BiscuitOS.Graphics;
using BiscuitOS.Math;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static Canvas canvas;
        Window testApp;
        Button button;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            testApp = new Window(new Dimension(840, 420), 150, 150, "New Empty Window");
            button = new Button(Dimension.Button, new Math.Point(10, 10));

            Renderer.StartGUIMode();
        }

        protected override void Run()
        {
            testApp.Add(button);
            Renderer.AddRenderWindow(testApp);
            Renderer.RenderScreen();
        }
    }
}
