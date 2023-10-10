using BiscuitOS.Math;
using BiscuitOS.Tasks;
using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Window
    {
        //private static List<TextBox> textboxs = new List<TextBox>(); // Unimplemente
        private static List<Button> _Buttons = new List<Button>();
        public Invokement buttonPress;

        public int x, y;

        public string WindowName { get; private set; }
        Rectangle border, topBar;
        BoundBox _topBarBoundingBox;
        public Window(Dimension Size, int x = 0, int y = 0, string Name = "New Empty Window")
        {
            // Init Border
            this.x = x;
            this.y = y;
            WindowName = Name;
            border = new Rectangle(Size, Color.Black, Color.FromArgb(255, 117, 121, 127), 2, this.x, this.y, true);
            topBar = new Rectangle(new Dimension(Size.width, 15), Color.Black, this.x, this.y, true);
            _topBarBoundingBox = new BoundBox(new Math.Point(this.x, this.y), new Dimension(Size.width, 15));
        }

        public void Draw()
        {
            // First Render The Border
            border.Draw();
            topBar.Draw();

            foreach (Button button in _Buttons)
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
            _Buttons.Add(button);
        }
         
        public Button[] GetButtons()
        {
            return _Buttons.ToArray();
        }

        public void Tick()
        {
            foreach(Button button in _Buttons)
            {
                button.Tick(new Math.Point(0, 0));
            }
        }
    }
}
