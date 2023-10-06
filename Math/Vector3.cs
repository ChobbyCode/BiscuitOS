
namespace BiscuitOS.Math
{
    public class Vector3
    {
        public static readonly Vector3 Empty = new Vector3(0f, 0f, 0f);
        public float x, y, z;

        /// <summary>
        /// X, Y on screen, Z in 3D
        /// </summary>
        public Vector3(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
