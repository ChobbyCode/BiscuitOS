using BiscuitOS.Math;
using Cosmos.System;
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
            Draw(new BiscuitOS.Math.Point(0, 0), this.innerColour, this.drawColour);
        }

        public void Draw(BiscuitOS.Math.Point offset)
        {
            Draw(offset, this.innerColour, this.drawColour);
        }

        public void Draw(BiscuitOS.Math.Point offset, Color newInCol, Color newDrCol)
        {
            int xOff = offset.x;
            int yOff = offset.y;

            Pen b = new Pen(newDrCol);
            if (!isFill)
            {
                Kernel.canvas.DrawRectangle(b, this.x + xOff, this.y + yOff, width, height);
            }
            else
            {
                Kernel.canvas.DrawFilledRectangle(b, this.x + xOff, this.y + yOff, width, height);
                Kernel.canvas.DrawFilledRectangle(new Pen(newInCol), this.x + xOff + (borderWidth), this.y + yOff + (borderWidth), width - (borderWidth * 2), height - (borderWidth * 2));
            }
        }
        
        public void SetPos(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }
}
