using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using BiscuitOS.FileExplorer;
using S = BiscuitOS.Shell;


namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static Canvas canvas;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            //Test test = new Test();
            //test.Start();

            // Start Shell
            S.Shell.InitShell(Shell.ShellMode.Text);

            //Renderer.StartGUIMode();
        }

        protected override void Run()
        {
            //AppManager.TickHandlers();

            S.Shell.TickShell();

            //Renderer.RenderScreen();
        }
    }
}
