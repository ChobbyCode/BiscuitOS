
namespace BiscuitOS.Graphics
{
    public class Window
    {
        public string WindowName { get; private set; }
        private Rectangle border;
        public Window(string Name, int width = 420, int height = 420)
        {
            // Init Border
            WindowName = Name;
            border = new Rectangle(0, 0, width, height);
        }

        public void Draw()
        {
            // First Render The Border
            border.Draw();
        }
    }
}
