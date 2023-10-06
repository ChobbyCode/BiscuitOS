
namespace BiscuitOS.Math
{
    public class Vector2
    {
        public static readonly Vector2 Empty = new Vector2(0f, 0f);
        public float x, y;

        /// <summary>
        /// X and Y on the screen
        /// </summary>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
