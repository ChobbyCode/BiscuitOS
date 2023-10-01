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
        string CurrentDir = @"0:\";


        public void ParseFileCommand(string[] commandWord)
        {
            if (commandWord[1] == "new")
            {
                // They want to create a new file
                if (commandWord[2] == "fl" || commandWord[2] == "file")
                {

                    if (commandWord[3] != "")
                    {
                        MakeFile(commandWord[3]);
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
                fmFile.RunFile(GetPath() + commandWord[2], this);
            }
            else
            {
                BConsole.WriteLine("Incorrect use of command word 'fm'");
            }
        }

        public void AddDir(string folder)
        {
            CurrentDir = CurrentDir + folder + @"\";
        }

        public void BackDir()
        {
            var newPath = "";

            string[] pathSplit = CurrentDir.Split(@"\");
            for (int i = 0; i < pathSplit.Length - 2; i++)
            {
                newPath = newPath + pathSplit[i] + @"\";
            }
            CurrentDir = newPath;
        }

        public void MakeFile(string name)
        {
            string fileName = name;

            if(File.Exists(CurrentDir + fileName))
            {
                BConsole.WriteLine();
                BConsole.WriteLine("Error cannot create duplicate files of same name!");
                BConsole.WriteLine();
                return;
            }

            try
            {
                var FileStream = File.Create(CurrentDir + fileName);
                BConsole.WriteLine($"Created File {CurrentDir + fileName}");
            }
            catch
            {
                BConsole.WriteLine("Failed To Create File");
            }
        }

        public string ReadFile(string fileName)
        {
            var fileContents = File.ReadAllText(GetPath() + fileName);

            return fileContents;
        }

        public string GetPath()
        {
            return CurrentDir;
        }
    }
}
