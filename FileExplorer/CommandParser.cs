using BiscuitOS.Apps.TextEditor;
using BiscuitOS.FileExecutable;
using BiscuitOS.FileManager;
using System.IO;

namespace BiscuitOS.FileExplorer
{
    internal class CommandParser
    {
        public static void ParseCommand(string[] commandWord, string[] unLow)
        {
            // The First Chain
            switch(commandWord[1])
            {
                case "new":
                    New(commandWord);
                    break;
                case "del":
                    Delete(commandWord, unLow);
                    break;
                case "delete":
                    Delete(commandWord, unLow);
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

        private static void Delete(string[] commandWord, string[] unLow)
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
                    DeleteFolder(commandWord, unLow);
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
                File.Delete(FileMan.GetPath() + commandWord[3]);
            }
            catch
            {
                BConsole.WriteLine("Failed To Delete File");
            }
        }

        private static void DeleteFolder(string[] commandWord, string[] unLow)
        {
            try
            {
                string FileName = string.Empty;
                for (int i = 3; i < commandWord.Length - 3; i++)
                {
                    FileName = FileName + " " + unLow[i];
                }

                Directory.Delete(FileMan.GetPath() + FileName + @"\", true);
            }
            catch
            {
                BConsole.WriteLine("Failed To Delete Folder");
            }
        }
    }
}
