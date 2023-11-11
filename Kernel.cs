using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using BiscuitOS.FileExplorer;
using S = BiscuitOS.Shell;
using BiscuitOS.FileExplorer.Application;
using System;
using System.IO;
using BiscuitOS.ExceptionHandling;


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
            Guts.System.OSStartUp();

            try
            {
                File.WriteAllText("Bob/bob/bob.txt", "Nope");
            }
            catch (Exception ex) 
            {
                BConsole.WriteLine("Error");
                OSException.CreateErrorLog(ErrorTypes.Unknown, ex, "This is a message");
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
