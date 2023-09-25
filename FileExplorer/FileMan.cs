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
                        Console.WriteLine("Please specify a name for the file.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect use of command word 'new'");
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
                    Console.WriteLine("Failed to write to file");
                }
            }
            else
            {
                Console.WriteLine("Incorrect use of command word 'fm'");
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
                Console.WriteLine(pathSplit[i]);
                newPath = newPath + pathSplit[i] + @"\";
            }
            CurrentDir = newPath;
        }

        public void MakeFile(string name)
        {
            string fileName = name;

            if(File.Exists(CurrentDir + fileName))
            {
                Console.WriteLine();
                Console.WriteLine("Error cannot create duplicate files of same name!");
                Console.WriteLine();
                return;
            }

            try
            {
                var FileStream = File.Create(CurrentDir + fileName);
                Console.WriteLine($"Created File {CurrentDir + fileName}");
            }
            catch
            {
                Console.WriteLine("Failed To Create File");
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
