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

            var input = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if(key == ConsoleKey.Backspace)
                {
                    // Delete Last Key
                    try
                    {
                        input.Remove(input.Length - 1, 1);
                    }
                    catch
                    {
                        // Do Nothing
                    }
                }

                string write = String.Empty;

                // Create String Of *'s
                foreach(char letter in input)
                {
                    write = write + "*";
                }

                // Write Text
                Console.Write("\r{0}%   ", msg + ": " + write);

            } while (key != ConsoleKey.Enter);

            return input;
        }
    }
}

