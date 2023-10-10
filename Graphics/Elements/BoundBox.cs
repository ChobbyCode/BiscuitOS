using BiscuitOS.Math;

namespace BiscuitOS.Graphics
{
    /// <summary>
    /// A way to detect if a point is in a square bound box.
    /// </summary>
    public class BoundBox
    {
        public Dimension Size;
        public Point Position;

        public BoundBox(Point Position, Dimension Size)
        {
            this.Position = Position;
            this.Size = Size;
        }

        /// <summary>
        /// Sees if a point is in bounds
        /// </summary>
        /// <param name="p">The point that is wanted to be checked</param>
        /// <returns>Returns true if in bounds, and false if it is not.</returns>
        public bool inBounds(Point p)
        {
            if (p.x > Position.x && p.x < Position.x + Size.width &&
                p.y > Position.y && p.y < Position.y + Size.height)
            {
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the mouse is in the bound box.
        /// </summary>
        /// <returns>Returns true if the mouse is in bounds, and false if it is not.</returns>
        public bool MouseInBounds()
        {
            return inBounds(Mouse.GetMousePos());
        }
    }
}
