using System;

namespace BiscuitOS
{
    public class BError
    {
        public BError(string msg)
        {
            ConsoleColor tmp = BConsole.ForegroundColor;
            BConsole.WriteLine(msg);
            BConsole.ForegroundColor = tmp;
            BConsole.ReadLine();
        }
    }
}
