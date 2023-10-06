using Cosmos.System.Graphics;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Renderer
    {
        // List Of Render Items
        public static Window testWindow;

        public static void StartGUIMode()
        {
            // Create and clear canvas
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            Kernel.canvas.Clear();

            testWindow = new Window("Test App", 420, 420);

        }

        public static void RenderScreen()
        {
            // Run All The Render Stuff
            Kernel.canvas.Clear(Color.DarkCyan);
            testWindow.Draw();


            // Update The Canvas
            Kernel.canvas.Display();

        }
    }
}
