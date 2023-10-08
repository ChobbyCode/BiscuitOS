using Cosmos.System.Graphics;
using System.Drawing;

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
            DrawLetter(Letter.a, new Pen(Color.White), 50, 50);
        }

        private void DrawLetter(int[] character, Pen pen, int x, int y) 
        {
            for(int pY = 0; pY < 20;  pY++)
            {
                for(int pX = 0; pX < (character.Length / 20); pX++)
                {
                    if (character[((character.Length) / 20) * pY + pX] == 1)
                    {
                        Renderer.DrawPixel(pen, x + pX * 2, y + pY * 2);
                    }
                }
            }
        }
    }
}
