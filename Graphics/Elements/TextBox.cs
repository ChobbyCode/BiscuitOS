using Cosmos.System.Graphics;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class TextBox
    {
        public int x, y;
        public string text;

        public TextBox(int x = 0, int y = 0, string text = "Hello, World!")
        {
            this.x = x;
            this.y = y;
            this.text = text;
        }

        public void Draw()
        {
            int drawX = 0;

            Pen b = new Pen(Color.White);
            foreach(char let in text)
            {
                switch(let )
                {
                    case 'a':
                        DrawLetter(Letter.a, b, this.x + drawX, this.y);
                        break;
                    case 'b':
                        DrawLetter(Letter.b, b, this.x + drawX, this.y);
                        break;
                    case 'c':
                        DrawLetter(Letter.c, b, this.x + drawX, this.y);
                        break;
                        // To Add More Letters Create A New Array In The Letter Class
                        // Populate The Array & Add A New Case Here
                    default:
                        break;
                }
                drawX = drawX + 21;
            }
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
