using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BiscuitOS.Account
{
    public class AccInputMan
    {
        public string ObfuscatedInput(string msg)
        {
            Console.Write(msg);

            var pass = string.Empty;
            /*ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);*/

            for (int i = 0; i < 100; ++i)
            {
                Console.Write("\r{0}%   ", i);
                Thread.Sleep(100);
            }

            return pass;
        }
    }
}

