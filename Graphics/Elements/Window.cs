using BiscuitOS.Math;
using System.Collections.Generic;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Window
    {
        //private static List<TextBox> textboxs = new List<TextBox>(); // Unimplemente
        private static List<Button> buttons = new List<Button>();

        public int x, y;

        public string WindowName { get; private set; }
        private Rectangle border;
        public Window(Dimension Size, int x = 0, int y = 0, string Name = "New Empty Window")
        {
            // Init Border
            this.x = x;
            this.y = y;
            WindowName = Name;
            border = new Rectangle(Size, Color.Black, Color.FromArgb(255, 117, 121, 127), 2, this.x, this.y, true);
        }

        public void Draw()
        {
            // First Render The Border
            border.Draw();

            //foreach(TextBox textBox in textboxs)
            //{
                //textBox.Draw();
            //}
            foreach (Button button in buttons)
            {
                button.Draw(new Math.Point(this.x, this.y));
            }
        }

        public void Add(TextBox textBox)
        {
            //textboxs.Add(textBox);
        }
        public void Add(Button button)
        {
            buttons.Add(button);
        }
    }
}
