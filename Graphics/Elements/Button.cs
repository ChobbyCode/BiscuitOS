using BiscuitOS.Math;
using BiscuitOS.Tasks;
using Cosmos.System;
using System.Drawing;

namespace BiscuitOS.Graphics
{
    public class Button
    {
        public Dimension Size = Dimension.Button;
        public BiscuitOS.Math.Point Position = BiscuitOS.Math.Point.Empty;

        public ButtonState state { get; private set; } = ButtonState.none;
        private ButtonState prevState = ButtonState.none;

        private Rectangle inner, outer, lowerBorder;

        public int id { get; private set; }

        public bool Pressed { get; private set; } = false;

        //private Math.Point offset;

        public Button(Dimension Size, int x = 0, int y = 0, string text = "")
        {
            this.Size = Size;
            //this.Text = new TextBox(0, 0, text);
            this.Position = new BiscuitOS.Math.Point(x, y);
            this.id = AppManager.GetButtonId();
            CreateDrawingComponents();
        }
        public Button(Dimension Size, BiscuitOS.Math.Point Position, string text = "")
        {
            this.Size = Size;
            //this.Text = new TextBox(0, 0, text);
            this.Position = Position;
            this.id = AppManager.GetButtonId();
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

        public void Tick(Math.Point offset)
        {
            this.Pressed = false;

            // Check if mouse is in button bounds
            BiscuitOS.Math.Point mousePos = Mouse.GetMousePos();
            if (mousePos.x > this.Position.x + offset.x && mousePos.x < this.Position.x + offset.x + this.Size.width && mousePos.y > this.Position.y + offset.y && mousePos.y < this.Position.y + offset.y + this.Size.height)
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

            if (prevState != state && state == ButtonState.clicked)
            {
                this.Pressed = true;

            }

            // Set prev variables
            prevState = state;
        }

        public void Draw(Math.Point offset)
        {

            // Render the button

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

                }
            }
        }
    }
}
