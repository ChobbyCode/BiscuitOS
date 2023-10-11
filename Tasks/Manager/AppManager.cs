using BiscuitOS.Graphics;
using System.Collections.Generic;

namespace BiscuitOS.Tasks
{
    public class AppManager
    {
        /*
         * Event Handlers are way for cross communication. Traditional EventHandlers do not
         * work for an odd reason, so I made my own.
         */
        private static List<App> _CurrentEvents = new List<App>();

        private static int _buttonsIdentityManager = 0;

        public static void Add(App app)
        {
            _CurrentEvents.Add(app);
        }

        public static void TickHandlers()
        {
            // Note: Probally should change this loop to be more efficient and less ugly
            foreach (App app in _CurrentEvents)
            {
                app.Tick();
            }
        }

        public static int GetButtonId()
        {
            _buttonsIdentityManager++;
            return _buttonsIdentityManager;
        }
    }
}