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
                        if (isRelative(commandWord[3]))
                        {
                            try
                            {
                                File.Create(GetPath() + commandWord[3]);
                            }
                            catch
                            {
                                BError.SystemIOError();
                            }

                            return;
                        }

                        try
                        {
                            File.Create(commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                        return;
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
