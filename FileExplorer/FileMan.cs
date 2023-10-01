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
            try
            {
                File.Create(path);
            }
            catch
            {
                new BError($"Failed To Create File {path}");
            }
        }

        public static void MakeDir(string Path)
        {
            string[] directories = Path.Split(@"\");

            string fileConstructor = String.Empty;
            foreach(string dir in directories)
            {
                fileConstructor += @$"{dir}\";
                if(dir != "0:" && dir != "")
                {
                    if (!Directory.Exists(dir))
                    {
                        try
                        {
                            Directory.CreateDirectory(fileConstructor);
                        }
                        catch
                        {
                            new BError("Failed To Create Directory");
                        }
                    }
                }
            }
        }

        public static void DeleteDir(string BasePath)
        {
            if (BasePath != @"0:\")
            {
                try
                {
                    Directory.Delete(BasePath, true);
                }
                catch
                {
                    new BError($"Failed To Delete Directories {BasePath}");
                }
            }
        }

        public static void DeleteIn(string BasePath)
        {
            var dir_list = Directory.GetDirectories(BasePath);
            var file_list = Directory.GetFiles(BasePath);
            foreach(var dir in dir_list)
            {
                try
                {
                    Directory.Delete(BasePath + $@"\{dir}", true);
                }
                catch
                {
                    new BError($"Failed To Delete Directories {dir}");
                }
            }
            foreach(string file in file_list)
            {
                try
                {
                    File.Delete(BasePath + $@"\{file}");
                }
                catch
                {
                    new BError($"Failed To Delete File {file}");
                }
            }
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
    }
}
