using BiscuitOS.FileExecutable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitOS.FileExplorer
{
    public class FileMan
    {
        static string CurrentDir = @"0:\";


        public static void ParseFileCommand(string[] commandWord)
        {
            if (commandWord[1] == "new")
            {
                // They want to create a new file
                if (commandWord[2] == "fl" || commandWord[2] == "file")
                {

                    if (commandWord[3] != "")
                    {
                        MakeFile(FileMan.GetPath() + commandWord[3]);
                    }
                    else
                    {
                        BConsole.WriteLine("Please specify a name for the file.");
                    }
                }
                else
                {
                    BConsole.WriteLine("Incorrect use of command word 'new'");
                }
            }else if (commandWord[1] == "st")
            {
                // Set text
                try
                {
                    File.WriteAllText(CurrentDir + commandWord[2], commandWord[3]);
                }
                catch
                {
                    BConsole.WriteLine("Failed to write to file");
                }
            }else if (commandWord[1] == "del")
            {
                try
                {
                    File.Delete(GetPath() + commandWord[2]);
                    BConsole.WriteLine("Deleted File.");
                }
                catch
                {
                    BConsole.WriteLine("Failed to delete file.");
                }
            }else if (commandWord[1] == "run")
            {
                FMFile fmFile = new FMFile();
                fmFile.RunFile(GetPath() + commandWord[2]);
            }
            else
            {
                BConsole.WriteLine("Incorrect use of command word 'fm'");
            }
        }

        public static void AddDir(string folder)
        {
            CurrentDir = CurrentDir + folder + @"\";
        }

        public static void BackDir()
        {
            var newPath = "";

            string[] pathSplit = CurrentDir.Split(@"\");
            for (int i = 0; i < pathSplit.Length - 2; i++)
            {
                newPath = newPath + pathSplit[i] + @"\";
            }
            CurrentDir = newPath;
        }

        public static void MakeFile(string path)
        {
            if (isRelative(path))
            {
                // Basically construct it with the current open path
                path = GetPath() + path;
                try
                {
                    File.Create(path);
                }
                catch
                {
                    BError.SystemIOError();
                }

                return;
            }
            //else

            try
            {
                File.Create(path);
            }
            catch
            {
                BError.SystemIOError();
            }
        }

        public static void MakeDir(string path)
        {
            path += @"\";
            if (isRelative(path))
            {
                // Basically construct it with the current open path
                path = GetPath() + path;
                try
                {
                    BConsole.WriteLine(path);
                }
                catch
                {
                    BError.SystemIOError();
                }

                return;
            }
            //else

            try
            {
                //Directory.CreateDirectory(path);
                BConsole.WriteLine(path);
            }
            catch
            {
                BError.SystemIOError();
            }
        }

        public static void DeleteDir(string BasePath)
        {
            
        }

        public static void DeleteIn(string BasePath)
        {
            
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

        private static bool isRelative(string path)
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
