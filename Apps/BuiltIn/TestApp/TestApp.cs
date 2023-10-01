
namespace BiscuitOS.Apps.TestApp
{
    public class TestApp
    {
        static ConsoleApplication consoleApp = new ConsoleApplication();

        public static void Start()
        {
            consoleApp.Start();

            consoleApp.onStartUp += (s, args) =>
            {
                BConsole.WriteLine("Started");
            };
        }
    }
}
