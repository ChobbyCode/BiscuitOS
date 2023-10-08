using System.Collections.Generic;

namespace BiscuitOS.Apps
{
    public class AppManager
    {
        private static List<App> apps = new List<App>();

        public static int Add(App app)
        {
            apps.Add(app);
            return apps.Count;
        }

        public static void EndApp(int AppID)
        {
            
        }

        public static void TickApps()
        {
            try
            {
                foreach (App app in apps)
                {
                    app.Tick();
                }
            }
            catch
            {

            }
        }
    }
}
