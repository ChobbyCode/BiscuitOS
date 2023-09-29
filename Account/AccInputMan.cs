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

                input = input + key.ToString();

                Console.Write("\r{0}%   ", input);

            } while (key != ConsoleKey.Enter);

            return input;
        }
    }
}

