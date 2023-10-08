using BiscuitOS.Math;
using Cosmos.System;
using System;

namespace BiscuitOS.Graphics
{
    public class Mouse
    {
        public static Point GetMousePos()
        {
            try
            {
                uint mouseXu = MouseManager.X;
                uint mouseYu = MouseManager.Y;

                // Convert
                int mouseX = Convert.ToInt32(mouseXu);
                int mouseY = Convert.ToInt32(mouseYu);

                return new Point(mouseX, mouseY);
            }
            catch
            {
                return Point.Empty;
            }
        }

        public static MouseState GetMouseState()
        {
            return MouseManager.MouseState;
        }
    }
}
