using BiscuitOS.Math;

namespace BiscuitOS.Graphics
{
    public class Window
    {
        public string WindowName { get; private set; }
        private Rectangle border;
        public Window(Dimension Size, string Name = "New Empty Window")
        {
            // Init Border
            WindowName = Name;
            border = new Rectangle(Size, 0, 0);
        }

        public void Draw()
        {
            // First Render The Border
            border.SetPos(10, 10);
            border.Draw();
        }
    }
}
