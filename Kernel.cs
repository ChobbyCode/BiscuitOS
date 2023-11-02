using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using BiscuitOS.FileExplorer;
using S = BiscuitOS.Shell;
using BiscuitOS.FileExplorer.Application;
using System;


namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        public static Canvas canvas;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Console.Clear();
            Console.WriteLine("BiscuitOS First Message: ");
            Console.WriteLine("Leave Blank For Normal Start. Type 'FORCE' To Do A Force Start: ");
            var input = Console.ReadLine();
            if(input == "FORCE")
            {
                S.Shell.InitShell(Shell.ShellMode.Text);
            }
            else
            {
                Guts.System.OSStartUp();
            }

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
