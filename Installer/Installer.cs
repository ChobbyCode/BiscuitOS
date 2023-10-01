using BiscuitOS.Apps.TextEditor;
using BiscuitOS.FileExplorer;
using System;
using System.IO;

namespace BiscuitOS.Installer
{
    public class Installer
    {
        public static void StartInstall()
        {
            BConsole.WriteLine("Please wait whilst we create some files..");
            CreateBaseFolders();
            CreateAccount();

            BConsole.Clear();
            BConsole.WriteLine("If you want to read the guide:");
            BConsole.WriteLine(@"1. Run the command 'cd Documents'");
            BConsole.WriteLine(@"2. Then do 'open BiscuitOS.txt'");
        }

        private static void CreateAccount()
        {
            var name = String.Empty;
            var pass = "a";
            var passConfirm = "b";

            BConsole.Clear();
            BConsole.WriteLine("Welcome to BiscuitOS, a light weight TUI based Operating System.");
            BConsole.WriteLine("We need to setup your account, so lets proceed.");
            BConsole.WriteLine("");
            BConsole.WriteLine("What should we call you?");
            name = BConsole.ReadLine("Username: ");
            BConsole.Clear();
            BConsole.WriteLine($"Hi {name}, we also need a password for your account.");
            BConsole.WriteLine($"Make sure only you remember your password, or you cannot access the OS");
            do
            {
                pass = BConsole.ReadRedacted("Password: ");
                passConfirm = BConsole.ReadRedacted("Confirm Password: ");
                if(pass != passConfirm)
                {
                    BConsole.WriteLine("You need to put the same password in twise");
                    BConsole.ReadKey();
                }
            } while (pass != passConfirm);

            BConsole.Clear();
            BConsole.WriteLine("We going to create a few more files quickly.");
            BConsole.WriteLine("Please wait, as this may take a while.");

            string[] userConfigFile =
            {
                "Type: SYSFILE",
                "",
                $"{name}",
                $"{pass}"
            };
            try
            {
                FileMan.MakeFile($@"0:\Biscuit\User\Data\userConfig.txt");
                File.WriteAllLines($@"0:\Biscuit\User\Data\userConfig.txt", userConfigFile);
                BConsole.Clear();
            }
            catch
            {
                new BError("Failed To Create userConfigFile.");
            }
        }

        private static void CreateBaseFolders()
        {
            FileMan.DeleteIn($@"0:\");
            FileMan.MakeDir($@"0:\Biscuit\User\Data\");
            FileMan.MakeDir($@"0:\Biscuit\Scripts\");

            FileMan.MakeDir($@"0:\Documents\");
            FileMan.MakeFile($@"0:\Documents\BiscuitOS.txt");

            string[] tutorialFile =
            {
                "Welcome to BiscuitOS, a light weight TUI based Operating System.",
                "Today we will show you how to use this operating system.",
                "",
                "You are currently in the TextEditor. On your keyboard you can use the",
                "up and down arrows to change the target write line.",
                "",
                "Below are a few examples of the basic controls.",
                "",
                "- ls               -- Gives a list of files and directories",
                "- cd [Directory]   -- Changes the open directory",
                "- open [File]      -- Opens a file in the text editor",
                "- fm run [File]    -- Runs a .fm macro file",
                "- fm del [File]    -- Deletes a file",
                "- fm new fl [Name] -- Creates a new file",
                "- rd [File]        -- Opens a file (read only)",
                "",
                "Those commands should allow you to start using the operating system to its",
                "fullest power. If you find a bug or issue with the OS, please make a issue at:",
                "https://github.com/ChobbyCode/BiscuitOS",
                "",
                "",
                "",
                "",
                "Copyright ChobbyCode 2023",
            };

            try
            {
                File.WriteAllLines($@"0:\Documents\BiscuitOS.txt", tutorialFile);
            }
            catch
            {

            }
        }
    }
}
