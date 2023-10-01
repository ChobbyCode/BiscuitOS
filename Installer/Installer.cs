using BiscuitOS;
using BiscuitOS.Commands;
using BiscuitOS.FileExplorer;

namespace BiscuitOS.Installer
{
    public class Installer
    {
        public static void StartInstall()
        {
            new BError("Starting Install");
            FileMan.DeleteIn($@"0:\");
            FileMan.MakeDir($@"0:\Biscuit\User\Data\");
            FileMan.MakeDir($@"0:\Biscuit\Scripts\");
            
        }
    }
}
