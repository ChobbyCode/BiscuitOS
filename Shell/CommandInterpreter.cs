using BiscuitOS.Apps.TextEditor;
using BiscuitOS.FileManager;
using BiscuitOS.Shell.Commands;

namespace BiscuitOS.Shell
{
    internal class CommandInterpreter
    {
        public static int Interpret(string[] cW, string[] unSplit)
        {
            /*
             * == ORDER OF OPERATION ==
             * 
             * - First check for built in commands
             * - Then check for Shell extensions
             * - Post error message
             */

            // Check for built in commands

            if (cW[0] == "open")
            {
                BConsole.WriteLine("This is working, but not working too");
            }

            try
            {
                int SC = CheckSysCmd(cW[0], cW , unSplit);
                if (SC == 1) return 1;
            }catch { }

            // Do Shell Extensions and stuff next...

            // !Not implemented!

            // Return 0 if no commands were found. The thing that is using the Shell can handle this
            return 0;
        }

        public static int CheckSysCmd(string trigWord, string[] args, string[] unLow)
        {
            /*
             * == ORDER OF OPERATION ==
             * 
             * - First check for high level commands, & return 1
             * - Then check low level commands, & return 1
             * - If none are found return 0
             */

            // High Level
            int HL = CheckHighLevel(trigWord, args, unLow);
            if (HL == 1 || HL == 2) return HL;

            // Low Level
            int LL = CheckLowLevel(trigWord, args, unLow);
            if (LL == 1 || LL == 2) return LL;

            // No Command Was Found
            return 0;
        }

        public static int CheckHighLevel(string trigWord, string[] args, string[] unLow)
        {
            /*
             * == Notes ==
             * 
             * - Have the code in a sep file to avoid mess & spaghetti code
             * - All things MUST return 1
             * 
             * - This method can only be high level System commands
             * 
             */

            switch (trigWord)
            {
                case "exit":
                    Exit.Execute(args);
                    return 1;
                case "system":
                    BiscuitOS.Shell.Commands.System.Execute(args);
                    return 1;
                default:
                    return 0;
            }
        }

        public static int CheckLowLevel(string trigWord, string[] args, string[] unLow)
        {
            /*
             * == Notes ==
             * 
             * - Have the code in a sep file to avoid mess & spaghetti code
             * - All things MUST return 1, can return 2 if not implemented
             * 
             * - This method can be anything except high level sys commands
             * 
             */

            BConsole.WriteLine("Word: " + trigWord);

            switch (trigWord)
            {
                case "cls":
                    BConsole.Clear();
                    return 1;
                case "ls":
                    List.Execute(args);
                    return 1;
                case "cd":
                    FileMan.AddDir(args[1]);
                    return 1;
                case "bkdir":
                    FileMan.BackDir();
                    return 1;
                case "fm":
                    FileMan.ParseFileCommand(args, unLow);
                    return 1;
                case "open":
                    string[] open = { FileMan.GetPath() + args[1] };
                    BConsole.WriteLine("Path: " + open[0]);
                    TextEditor.StartTextEditor(open);
                    return 1;
                case "print":
                    BConsole.WriteLine(args[1]);
                    return 1;
                case "if":
                    // Not Implemented Error
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
