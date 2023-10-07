
using Cosmos.System.Graphics;

namespace BiscuitOS.Graphics
{
    public class TextBox
    {
        public int x, y;

        public TextBox(int x = 0, int y = 0, string text = "Hello, World!")
        {
            this.x = x;
            this.y = y;
        }

        public void Draw()
        {
            DrawLetter(Letter.a, new Pen(Color.White), 0, 0);
        }

        private void DrawLetter(int[] _char, Pen pen, int x, int y) 
        { 
            for(int pY = 0; pY < 20; pY++)
            {
                for(int pX = 0; pX < (_char.Length) / 20; pX++)
                {
                    if (_char[((_char.Length) / 20) * pY + pX] == 1)
                    {
                        Kernel.canvas.DrawPoint(pen, x, y);
                    }
                }
            }
        }
    }
}
