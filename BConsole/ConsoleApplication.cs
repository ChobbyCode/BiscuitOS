
using System;

namespace BiscuitOS
{
    public class ConsoleApplication
    {
        private bool runApp = false;

        public EventHandler onStartUp;

        public void Start()
        {
            // Start Console App
            runApp = true;
            onStartUp.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            // Stop Console App
            runApp = false;
        }
    }
}
