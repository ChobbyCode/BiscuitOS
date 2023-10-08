using BiscuitOS.Math;
using Cosmos.System.Graphics;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Rectangle
    {
        public int x, y;
        public int width, height;
        public bool isFill;

        /// <summary>
        /// A rectangle is a 2D shape
        /// </summary>
        /// <param name="x">Start X</param>
        /// <param name="y">Start Y</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Rectangle(Dimension Size, int x = 0, int y = 0, bool isFill = false)
        {
            this.x = x;
            this.y = y;
            this.width = Size.width;
            this.height = Size.height;
            this.isFill = isFill;
        }

        public void Draw()
        {
            Pen b = new Pen(Color.Black);
            if (!isFill)
            {
                Kernel.canvas.DrawRectangle(b, this.x, this.y, height, width);
            }
            else
            {
                Kernel.canvas.DrawFilledRectangle(b, this.x, this.y, height, width);
            }
        }

        public void SetPos(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }
}
