using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Renderer
    {
        // List Of Render Items
        private static List<Window> windows = new List<Window>();

        public static void StartGUIMode()
        {
            // Create and clear canvas
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            Kernel.canvas.Clear();
            // Setup The Mouse Pointer
            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
        }

        public static void RenderScreen()
        {
            // Run All The Render Stuff
            Kernel.canvas.Clear(Color.DarkCyan);
            RenderMouse(MouseManager.X, MouseManager.Y);
            foreach(Window window in windows)
            {
                try
                {
                    window.Draw();
                }
                catch
                {
                    // Failed To Render Object
                }
            }

            // Update The Canvas
            Kernel.canvas.Display();

            // Reset all Lists
            windows = new List<Window>();
        }

        private static void RenderMouse(uint mouseX, uint mouseY)
        {
            Pen b = new Pen(Color.White);
            int x, y;
            try
            {
                x = Convert.ToInt32(mouseX);
                y = Convert.ToInt32(mouseY);

                Kernel.canvas.DrawFilledRectangle(b, x, y, 10, 10);
            }
            catch (Exception e)
            {
                Debugger.Log(0, "Biscuit", e.ToString());
            }
        }

        /// <summary>
        /// Adds a window to the render pipeline. Must be readded every render.
        /// </summary>
        public static void AddRenderWindow(Window Window)
        {
            windows.Add(Window);
        }
    }
}
