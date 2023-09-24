using System;
using Sys = Cosmos.System;
using BiscuitOS.Commands;
using Cosmos.System.Graphics;
using System.Drawing;
using System.Threading;

namespace BiscuitOS
{
    public class Kernel : Sys.Kernel
    {
        CommandManager commandManager = new CommandManager();
        Canvas canvas;

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Copyright ChobbyCode 2023.");
            Console.WriteLine();

            StartGUI();
        }

        protected override void Run()
        {
            //Text Stuff
            //Console.Write("Biscuit> ");
            //var input = Console.ReadLine();

            //commandManager.Command(input);

            DrawBox();

            canvas.Display();
        }

        public void StartGUI()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Called GUI Start Function");

            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.Blue);

            Console.WriteLine("Loading Canvas Mode");

            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(500);

            canvas.Display();
        }

        public void DrawBox()
        {
            Pen pen = new Pen(Color.Black);

            FillRect(pen, 10, 10, 600, 450);
        }

        public void FillRect(Pen pen, int startX, int startY, int width, int height)
        {
            canvas.DrawFilledRectangle(pen, startY, startY, width, height);
        }
    }
}
