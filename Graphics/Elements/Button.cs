using BiscuitOS.Math;
using Cosmos.System;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Button
    {
        public Dimension Size = Dimension.Button;
        public BiscuitOS.Math.Point Position = BiscuitOS.Math.Point.Empty;
        //public TextBox Text;

        private ButtonState state = ButtonState.none;
        private ButtonState prevState = ButtonState.none;

        Rectangle inner, outer, lowerBorder;

        public Button(Dimension Size, int x = 0, int y = 0, string text = "")
        {
            this.Size = Size;
            //this.Text = new TextBox(0, 0, text);
            this.Position = new BiscuitOS.Math.Point(x, y);
            CreateDrawingComponents();
        }
        public Button(Dimension Size, BiscuitOS.Math.Point Position, string text = "")
        {
            this.Size = Size;
            //this.Text = new TextBox(0, 0, text);
            this.Position = Position;
            CreateDrawingComponents();
        }

        private void CreateDrawingComponents()
        {
            inner = new(this.Size, Color.Gray, this.Position.x, this.Position.y, true);
            outer = new(new Dimension(this.Size.width - 2, this.Size.height - 2), Color.Black, this.Position.x + 1, this.Position.y + 1, false);
            lowerBorder = new(new Dimension(this.Size.width, 2), Color.DarkGray, this.Position.x, this.Position.y + this.Size.height, true);
        }

        public void Move(BiscuitOS.Math.Point Distance)
        {
            this.Position.x += Distance.x;
            this.Position.y += Distance.y;
        }

        public void Draw()
        {
            Draw(new Math.Point(0, 0));
        }

        public void Draw(Math.Point offset)
        {
            // Check if mouse is in button bounds
            BiscuitOS.Math.Point mousePos = Mouse.GetMousePos();
            if(mousePos.x > this.Position.x + offset.x && mousePos.x < this.Position.x + offset.x + this.Size.width && mousePos.y > this.Position.y + offset.y && mousePos.y < this.Position.y + offset.y + this.Size.height)
            {
                state = ButtonState.hover;
                if (Mouse.GetMouseState() == MouseState.Left)
                {
                    state = ButtonState.clicked;
                }
            }
            else
            {
                state = ButtonState.none;
            }

            if (state == ButtonState.none)
            {
                inner.Draw(offset);
                outer.Draw(offset);
                lowerBorder.Draw(offset);
            }
            else
            {
                if(state == ButtonState.hover)
                {
                    // render hover
                    inner.Draw(offset, Color.DarkGray, Color.DarkGray);
                    outer.Draw(offset);
                    lowerBorder.Draw(offset);
                }
                else if(state == ButtonState.clicked)
                {
                    // render clicked
                    inner.Draw(new Math.Point(0, 2).Combine(offset));
                    outer.Draw(new Math.Point(0, 2).Combine(offset));

                    if(prevState != state)
                    {
                        // Basically We Pressed The Button
                    }
                }
            }

            // Set prev variables
            prevState = state;
        }
    }
}
