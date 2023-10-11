using BiscuitOS.Math;
using BiscuitOS.Tasks;
using BiscuitOS.Application.BasicWindowApp;
using BiscuitOS.Apps;
using BiscuitOS.Graphics;
using System.Diagnostics;

namespace BiscuitOS.Apps
{
    public class Test : WindowApp
    {

        Button button;
        Button buttond;

        public override void Start()
        {
            base.Start();
            button = new Button(Dimension.Button, new Point(10, 10));
            buttond = new Button(Dimension.Button, new Point(110, 10));
            window.Add(button);
            window.Add(buttond);
        }

        public override void Invokement(int sender)
        {
            if(button.id == sender)
            {
                Cosmos.System.Power.Shutdown();
            }else if(buttond.id == sender)
            {
                Button b = new Button(Dimension.Button, new Point(10, 110));
                window.Add(button);
            }
        }
    }
}
