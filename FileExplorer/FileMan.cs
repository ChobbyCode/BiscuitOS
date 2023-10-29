using BiscuitOS.FileExplorer;
using System;
using System.IO;

namespace BiscuitOS.FileManager
{
    /// <summary>
    /// Basic File Manager
    /// </summary>
    public class FileMan
    {
        private static string CurrentDir = @"0:\";

        public static void ParseFileCommand(string[] commandWord)
        {
            // I hate how ugly this is
            CommandParser.ParseCommand(commandWord);
        }

        public static void AddDir(string folder)
        {
            CurrentDir = CurrentDir + folder + @"\";
        }

        public static void SetDir(string folder)
        {
            CurrentDir = folder + @"\";
        }

        public static void BackDir()
        {
            // Create a variable for the split
            var newPath = String.Empty;

            // Split into stuff
            string[] pathSplit = CurrentDir.Split(@"\");
            // Do some fancy stuff
            for (int i = 0; i < pathSplit.Length - 2; i++)
            {
                newPath = newPath + pathSplit[i] + @"\";
            }
            // Set the dir to the new path
            CurrentDir = newPath;
        }

        public static string ReadFile(string fileName)
        {
            var fileContents = File.ReadAllText(GetPath() + fileName);
            return fileContents;
        }

        public static string GetPath()
        {
            return CurrentDir;
        }

        public static bool isRelative(string path)
        {
            bool relative = true;
            path += @"\";
            try
            {
                string[] pathSplit = path.Split(@"\");
                if (pathSplit[0] == "0:")
                {
                    relative = false;
                }
            }
            catch
            {
                BError.ParsingError();
            }
            return relative;
        }
    }
}
