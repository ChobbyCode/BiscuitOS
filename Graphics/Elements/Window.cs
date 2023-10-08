using BiscuitOS.Math;
using System.Collections.Generic;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Window
    {
        private static List<TextBox> textboxs = new List<TextBox>();

        public int x, y;

        public string WindowName { get; private set; }
        private Rectangle border;
        public Window(Dimension Size, int x = 0, int y = 0, string Name = "New Empty Window")
        {
            // Init Border
            this.x = x;
            this.y = y;
            WindowName = Name;
            border = new Rectangle(Size, Color.Black, Color.Beige, 5, this.x, this.y, true);
        }

        public void Draw()
        {
            // First Render The Border
            border.Draw();

            foreach(TextBox textBox in textboxs)
            {
                textBox.Draw();
            }
            

            // Clear arrays
            textboxs = new List<TextBox>();
        }

        public void AddTextBox(TextBox textBox)
        {
            textboxs.Add(textBox);
        }
    }
}
