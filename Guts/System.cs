using BiscuitOS.Shell;
using System;
using System.IO;

namespace BiscuitOS.Guts
{
    public class System
    {
        /*
         * == SYSTEM NOTES ==
         * 
         * 
         * 
         */

        private static bool OSInstalled = false;
        private static bool OSStarted = false;

        // Keep this the same because if we change it then the OS can't start up and will try to do a fresh install
        // It's halfed baked into the OS atm so not good but eh..
        private static string SystemFile = @"0:\Biscuit\Boot\System.info";

        public static void OSStartUp(string[] args = null)
        {
            if (OSStarted) return;
            Console.Clear();
            Console.WriteLine("Start BiscuitOS Boot Process..");

            GetSysInfo();

            OSStarted = true;
        }

        private static void GetSysInfo()
        {
            /* 
             * == How GetSysInfo() Works ==
             * 
             * - Step 1: Try locate the system file which contains the boot info etc..
             * - Step 2: If it does not exist check to see if other system files exist so we
             *           can work out if it corrupted or needs a fresh Install. If we can't
             *           do a fresh install
             * - Step 3: Start the OS and set variables up and stuff.
             */

            if(DoesSysFileExist())
            {
                try
                {
                    // Get The Contents Of The Sys File
                    var SysContents = File.ReadAllLines(SystemFile);

                    foreach (var Sys in SysContents)
                    {
                        Console.WriteLine(Sys);
                    }
                }
                catch
                {
                    // Hard to do errors because Shell hasn't started up so no user communication
                    Console.WriteLine("System Error 'x0002': Failed To Read System File");
                }
            }
            else
            {
                // Then we need to locate it
                try
                {
                    if (!Directory.Exists(@"0:\Biscuit\")) Directory.CreateDirectory(@"0:\Biscuit\");
                    if (!Directory.Exists(@"0:\Biscuit\Boot\")) Directory.CreateDirectory(@"0:\Biscuit\Boot\");

                    File.Create(SystemFile);
                }
                catch (Exception e) 
                {
                    // Hard to do errors because Shell hasn't started up so no user communication
                    Console.WriteLine("System Error 'x0001': Failed To Create System File");
                    Console.WriteLine();
                    Console.WriteLine(e);
                }

                InstallOS();
            }
        }

        private static bool DoesSysFileExist()
        {
            try
            {
                if (File.Exists(SystemFile))
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch
            {
                // Starting Up Error || Shell hasn't started yet so it will be difficult to inform the user.
                return false;
            }
        }

        private static void InstallOS()
        {

        }

        private static void StartShell()
        {

        }

        public static bool isInstalled()
        {
            return OSInstalled;
        }
    }
}
