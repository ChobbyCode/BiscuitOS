using BiscuitOS.Graphics;
using System.Collections.Generic;

namespace BiscuitOS.Apps
{
    public class App
    {
        private Window window = new Window(Math.Dimension.Window, 100, 100);

        List<Button> buttons = new List<Button>();

        public bool run = true;

        public App() { }
        public App(bool run)
        {
            this.run = run;
        }

        public virtual void Tick()
        {


            // Last
            Draw();
        }

        public virtual void Draw()
        {
            foreach (var button in buttons)
            {
                window.Add(button);
            }

            Renderer.AddRenderWindow(window);
        }

        public void Add(Button b)
        {
            buttons.Add(b);
        }
    }
}
