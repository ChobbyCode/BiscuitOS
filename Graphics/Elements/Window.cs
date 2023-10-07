using BiscuitOS.Math;

namespace BiscuitOS.Graphics
{
    public class Window
    {
        public int x, y;

        public string WindowName { get; private set; }
        private Rectangle border;
        public Window(Dimension Size, int x = 0, int y = 0, string Name = "New Empty Window")
        {
            // Init Border
            this.x = x;
            this.y = y;
            WindowName = Name;
            border = new Rectangle(Size, 0, 0);
        }

        public void Draw()
        {
            // First Render The Border
            border.Draw();
        }
    }
}
