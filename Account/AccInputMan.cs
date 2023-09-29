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
            Console.Write(msg);

            List<char> input = new List<char>();
            int prevLength = 0;

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                key = consoleKey.Key;
                char readLet = consoleKey.KeyChar;

                if (key == ConsoleKey.Backspace)
                {
                    try
                    {
                        input.RemoveAt(input.Count() - 1);
                    }
                    catch
                    {
                        if (key != ConsoleKey.Enter) { }
                    }
                }
                else
                {
                    input.Add(readLet);
                }

                ClearCurrentConsoleLine();

                Console.Write(msg);

                foreach(char let in input)
                {
                    Console.Write("*");
                }


                prevLength = input.Count();

            } while (key != ConsoleKey.Enter);

            string output = String.Empty;
            foreach(char let in input)
            {
                output += let;
            }

            // End Line
            Console.WriteLine();

            return output;
        }

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

