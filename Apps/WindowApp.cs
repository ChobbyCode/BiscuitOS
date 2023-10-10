using BiscuitOS.Tasks;
using BiscuitOS.Math;
using BiscuitOS.Graphics;

namespace BiscuitOS.Application.BasicWindowApp
{
    /// <summary>
    /// Basic Template for a BiscuitOS Window Application
    /// </summary>
    public class WindowApp : App
    {
        public Window window;

        /// <summary>
        /// Start App
        /// </summary>
        public override void Start()
        {
            window = new Window(Dimension.Window);
            this.AddWindow(window);

            base.Start();
        }
    }
}
