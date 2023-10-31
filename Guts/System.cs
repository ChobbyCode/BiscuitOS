﻿using BiscuitOS.Shell;
using System;
using System.IO;

namespace BiscuitOS.Guts
{
    /// <summary>
    /// Raw System Of The OS. Mainly Boot Files Etc..
    /// </summary>
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

            //File.Delete(SystemFile);

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

                    // Do Stuff
                    var CorrectUser = SysContents[0];
                    var CorrectPass = SysContents[1];

                    // Start Da Shell
                    Shell.Shell.InitShell(ShellMode.Text);

                    // Login
                    BConsole.WriteLine("Welcome To BiscuitOS");
                    // Username
                    string user = String.Empty;
                    while(user != CorrectUser)
                    {
                        user = BConsole.ReadLine("Username: ");
                    }
                    //Password
                    string pass = String.Empty;
                    while (pass != CorrectUser)
                    {
                        pass = BConsole.ReadRedacted("Password: ");
                    }

                    // We Are Done.

                    // Do any extra things in the furture

                }
                catch
                {
                    // Hard to do errors because Shell hasn't started up so no user communication
                    Console.WriteLine("System Error 'x0002': Failed To Read System File");
                }
            }
            else
            {
                bool SuccessInstall = false;

                // Then we need to locate it
                try
                {
                    if (!Directory.Exists(@"0:\Biscuit\")) Directory.CreateDirectory(@"0:\Biscuit\");
                    if (!Directory.Exists(@"0:\Biscuit\Boot\")) Directory.CreateDirectory(@"0:\Biscuit\Boot\");

                    File.Create(SystemFile);

                    InstallOS();

                    SuccessInstall = true;
                }
                catch (Exception e)
                {
                    // Hard to do errors because Shell hasn't started up so no user communication
                    Console.WriteLine("System Error 'x0001': Failed To Create System File");
                    Console.WriteLine();
                    Console.WriteLine(e);

                    SuccessInstall = false;
                }
                finally
                {
                    if(!SuccessInstall)
                    {
                        // Roll Back Changes
                    }
                }
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
                Console.WriteLine("System Error 'x0003': Failed To Find System File");
                return false;
            }
        }

        /// <summary>
        /// Installation
        /// </summary>
        private static void InstallOS()
        {
            StartShell();

            if (Shell.Shell.IsShellUsable() == false) Console.WriteLine("System Error 'x0004': Shell Is Not Usable For An Unknown Reason");

            BConsole.Clear();

            BConsole.WriteLine("Welcome to BiscuitOS. A light-weight Operating System.");
            BConsole.WriteLine("To start using the OS, we need to know your name.");
            BConsole.WriteLine("What should we call you?");

            var name = BConsole.ReadLine("Your Name: ");

            BConsole.WriteLine("Furthermore, we also need a password for your account.");
            BConsole.WriteLine("What should we set your password as?");

            var password = BConsole.ReadRedacted("Your Password: ");

            BConsole.WriteLine("We are going to do some stuff to install eveything.");
            BConsole.WriteLine("This may take some time..");

            GenerateSysFile(name, password);

            BConsole.WriteLine("Installation Complete. Please Restart The System.");
        }

        private static void GenerateSysFile(string username, string password)
        {
            try
            {
                string[] sysFileContents =
                {
                    username, password,
                };
                File.WriteAllLines(SystemFile, sysFileContents);
            }
            catch
            {
                Console.WriteLine("System Error 'x0001': Failed To Create System File");
            }
        }

        private static void StartShell()
        {
            /*
             *  == NOTES ==
             *  
             *  - There needs to be a sep Shell mode for install / sys high levels
             */

            Shell.Shell.InitShell(ShellMode.Text);
        }

        public static bool isInstalled()
        {
            return OSInstalled;
        }
    }
}
