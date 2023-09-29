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
        public string ObfuscateInput(string msg)
        {
            List<char> input = new List<char>();

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                key = consoleKey.Key;
                char readLet = consoleKey.KeyChar;

                input.Add(readLet);

                foreach(char let in input)
                {
                    Console.Write("\r {0}%", let);
                }
            } while (key != ConsoleKey.Enter);

            return String.Empty;
        }
    }
}

