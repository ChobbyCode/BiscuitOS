using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitOS
{
    internal static class InputManager
    {
        public static ConsoleKey GetKey()
        {
            return Console.ReadKey(true).Key;
        }
        public static char GetCharKey() 
        {
            return Console.ReadKey(true).KeyChar;
        }
        public static ConsoleKeyInfo GetKeyInfo()
        {
            return Console.ReadKey(true);
        }

        public static bool isForbiddenKey(this ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                return true;
            }
            else if (key == ConsoleKey.Delete)
            {
                return true;
            }
            else if (key == ConsoleKey.Backspace)
            {
                return true;
            }
            else if (key == ConsoleKey.Escape)
            {
                return true;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                return true;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                return true;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                return true;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                return true;
            }
            else if (key == ConsoleKey.Tab)
            {
                return true;
            }
            else if (key == ConsoleKey.F1)
            {
                return true;
            }
            else if (key == ConsoleKey.F2)
            {
                return true;
            }
            else if (key == ConsoleKey.F3)
            {
                return true;
            }
            else if (key == ConsoleKey.F4)
            {
                return true;
            }
            else if (key == ConsoleKey.F5)
            {
                return true;
            }
            else if (key == ConsoleKey.F6)
            {
                return true;
            }
            else if (key == ConsoleKey.F7)
            {
                return true;
            }
            else if (key == ConsoleKey.F8)
            {
                return true;
            }
            else if (key == ConsoleKey.F9)
            {
                return true;
            }
            else if (key == ConsoleKey.F10)
            {
                return true;
            }
            else if (key == ConsoleKey.F11)
            {
                return true;
            }
            else if (key == ConsoleKey.F12)
            {
                return true;
            }
            return false;
        }
    }
}
