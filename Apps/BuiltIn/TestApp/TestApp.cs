using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitOS.Apps.TestApp
{
    public class TestApp
    {
        static ConsoleApplication consoleApplication;

        public static void Start()
        {
            consoleApplication = new ConsoleApplication(true);
            //BConsole.WriteLine("Simulated: 'Started Application'");
        }
    }
}
