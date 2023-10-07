
namespace BiscuitOS.Math
{
    /// <summary>
    /// Point
    /// </summary>
    public class Point
    {
        public static Point Empty = new Point(0, 0);

        public int x, y;
        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
    }
}
