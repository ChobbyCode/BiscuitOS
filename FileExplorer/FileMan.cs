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

        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                if(isRelative(path))
                {
                    try
                    {
                        Directory.CreateDirectory(GetPath() + path);
                    }
                    catch
                    {

                    }
                }else
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {

                    }
                }
            }
            return;
        }

        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                if (isRelative(path))
                {
                    try
                    {
                        File.Create(GetPath() + path);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        File.Create(path);
                    }
                    catch
                    {

                    }
                }
            }
            return;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                if (isRelative(path))
                {
                    try
                    {
                        File.Delete(GetPath() + path);
                    }catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch
                    {

                    }
                }
            }
        }

        public static void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                if (isRelative(path))
                {
                    try
                    {
                        Directory.Delete(GetPath() + path + @"\", true);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        Directory.Delete(path + @"\", true);
                    }
                    catch
                    {

                    }
                }
            }
        }

        public static void ParseFileCommand(string[] commandWord, string[] unLow)
        {
            // I hate how ugly this is
            CommandParser.ParseCommand(commandWord, unLow);
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

        public static string[] getFiles()
        {
            try
            {
                var Files = Directory.GetFiles(CurrentDir);

                return Files;
            }catch
            {
                return new string[0]; 
            }
        }

        public static string[] getFolders()
        {
            try
            {
                var Directories = Directory.GetDirectories(CurrentDir);

                return Directories;
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
