using BiscuitOS.FileManager;
using System.IO;

namespace BiscuitOS.FileExplorer.Application
{
    public class FileViewer
    {
        public static void Start()
        {
            bool run = true;

            do
            {
                BConsole.Clear();

                var Files = FileMan.getFiles();
                var Folders = FileMan.getFolders();

                foreach(string Folder in Folders)
                {
                    DirectoryInfo dl = new DirectoryInfo(Folder);
                    BConsole.WriteLine(dl.Name.ToUpper());
                }
                foreach(string File in Files)
                {
                    FileInfo fl = new FileInfo(File);
                    BConsole.WriteLine(fl.Name.ToLower());
                }

                BConsole.ReadLine();
            } while (run);
        }
    }
}
