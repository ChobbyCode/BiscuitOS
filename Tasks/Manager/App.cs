using BiscuitOS.Graphics;
using System.Collections.Generic;

namespace BiscuitOS.Tasks
{
    public class App
    {
        public List<Window> _CurrentWindows = new List<Window>();

        public virtual void Start()
        {
            AppManager.Add(this);
            foreach (Window w in _CurrentWindows)
            {
                Renderer.AddRenderWindow(w);
            }
        }

        public virtual void Dispose() { }

        public Window[] GetWindows()
        {
            return _CurrentWindows.ToArray();
        }

        public void AddWindow(Window window)
        {
            _CurrentWindows.Add(window);
        }

        public virtual void Tick()
        {
            foreach(Window window in _CurrentWindows)
            {
                window.Tick();
                foreach(Button button in window.GetButtons())
                {
                    if(button.Pressed)
                    {
                        Invokement(button.id);
                    }
                }
                window.Draw();
            }
        }

        public virtual void Invokement(int id) {}
    }
}
