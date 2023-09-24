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

        public void MakeFile()
        {

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
