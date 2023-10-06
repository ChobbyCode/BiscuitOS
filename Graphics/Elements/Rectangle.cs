using BiscuitOS.Math;
using Cosmos.System.Graphics;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Rectangle
    {
        public int x, y;
        public int width, height;

        /// <summary>
        /// A rectangle is a 2D shape
        /// </summary>
        /// <param name="x">Start X</param>
        /// <param name="y">Start Y</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Rectangle(int x, int y, int width = 10, int height = 10)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Pen b = new Pen(Color.Black);
            Kernel.canvas.DrawRectangle(b, x, y, width, height);
        }
    }
}
