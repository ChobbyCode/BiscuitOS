
namespace BiscuitOS.Math
{
    /// <summary>
    /// Height and Width Definitions
    /// </summary>
    public class Dimension
    {
        public static Dimension Button = new Dimension(85, 35);
        public static Dimension Window = new Dimension(420, 420);
        public static Dimension Empty = new Dimension(0, 0);
        public static Dimension TenEightyP = new Dimension(1920, 1080);

        public int width, height;
        public Dimension(int width = 420, int height = 420)
        {
            this.width = width;
            this.height = height;
        }
    }
}
