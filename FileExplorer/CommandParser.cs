using BiscuitOS.Apps.TextEditor;
using BiscuitOS.FileExecutable;
using BiscuitOS.FileManager;
using System.IO;

namespace BiscuitOS.FileExplorer
{
    internal class CommandParser
    {
        public static void ParseCommand(string[] commandWord)
        {
            // The First Chain
            switch(commandWord[1])
            {
                case "new":
                    New(commandWord);
                    break;
                case "del":
                    Delete(commandWord);
                    break;
                case "delete":
                    Delete(commandWord);
                    break;
                default:
                    BConsole.WriteLine("Invalid Use Of Command 'fm'.");
                    break;
            }
        }

        private static void New(string[] commandWord)
        {
            switch(commandWord[2])
            {
                case "fl":
                    NewFile(commandWord);
                    break;
                case "file":
                    NewFile(commandWord);
                    break;
                case "dir":
                    NewFolder(commandWord);
                    break;
                default:
                    BConsole.WriteLine("Invalid Use Of Command 'new'.");
                    break;
            }
        }

        private static void NewFile(string[] commandWord)
        {
            try
            {
                FileMan.CreateFile(commandWord[3]);
            }catch
            {
                BConsole.WriteLine("Failed To Create File");
            }
        }

        private static void NewFolder(string[] commandWord)
        {
            try
            {
                FileMan.CreateFolder(commandWord[3]);
            }
            catch
            {
                BConsole.WriteLine("Failed To Create Folder");
            }
        }

        private static void Delete(string[] commandWord)
        {
            switch (commandWord[2])
            {
                case "fl":
                    DeleteFile(commandWord);
                    break;
                case "file":
                    DeleteFile(commandWord);
                    break;
                case "dir":
                    DeleteFolder(commandWord);
                    break;
                default:
                    BConsole.WriteLine("Invalid Use Of Command 'delete'.");
                    break;
            }
        }

        private static void DeleteFile(string[] commandWord)
        {
            try
            {
                Directory.Delete(FileMan.GetPath() + commandWord[3]);
            }
            catch
            {
                BConsole.WriteLine("Failed To Delete Folder");
            }
        }

        private static void DeleteFolder(string[] commandWord)
        {
            try
            {
                Directory.Delete(FileMan.GetPath() + commandWord[3]);
            }
            catch
            {
                BConsole.WriteLine("Failed To Create Folder");
            }
        }
    }
}
