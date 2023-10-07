using BiscuitOS.Math;
using Cosmos.System;
using System;

namespace BiscuitOS.Graphics
{
    public class Mouse
    {
        public static Vector2 GetMousePos()
        {
            try
            {
                uint mouseXu = MouseManager.X;
                uint mouseYu = MouseManager.Y;

                // Convert
                int mouseX = Convert.ToInt32(mouseXu);
                int mouseY = Convert.ToInt32(mouseYu);

                return new Vector2(mouseX, mouseY);
            }
            catch
            {
                return Vector2.Empty;
            }
        }
    }
}
