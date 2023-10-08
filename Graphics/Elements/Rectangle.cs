using BiscuitOS.Math;
using Cosmos.System.Graphics;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Rectangle
    {
        public int x, y;
        public int width, height;
        public int borderWidth;
        public bool isFill;
        public Color drawColour, innerColour;

        /// <summary>
        /// A rectangle is a 2D shape
        /// </summary>
        /// <param name="x">Start X</param>
        /// <param name="y">Start Y</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Rectangle(Dimension Size, Color drawColour, int x = 0, int y = 0, bool isFill = false)
        {
            this.x = x;
            this.y = y;
            this.width = Size.width;
            this.height = Size.height;
            this.isFill = isFill;
            this.drawColour = drawColour;
            this.innerColour = drawColour;
            this.borderWidth = 1;
        }
        public Rectangle(Dimension Size, Color drawColour, Color innerColour, int borderWidth = 1, int x = 0, int y = 0, bool isFill = true)
        {
            this.x = x;
            this.y = y;
            this.width = Size.width;
            this.height = Size.height;
            this.isFill = isFill;
            this.drawColour = drawColour;
            this.innerColour = innerColour;
            this.borderWidth = borderWidth;
        }

        public void Draw()
        {
            Pen b = new Pen(this.drawColour);
            if (!isFill)
            {
                Kernel.canvas.DrawRectangle(b, this.x, this.y, height, width);
            }
            else
            {
                if(this.drawColour != this.innerColour)
                {
                    Kernel.canvas.DrawFilledRectangle(b, this.x, this.y, height, width);
                    Kernel.canvas.DrawFilledRectangle(new Pen(this.innerColour), this.x + (borderWidth), this.y + (borderWidth), height - (borderWidth * 2), width - (borderWidth * 2));
                }
                else
                {
                    Kernel.canvas.DrawFilledRectangle(b, this.x, this.y, height, width);
                }
            }
        }
        
        public void SetPos(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }
}
