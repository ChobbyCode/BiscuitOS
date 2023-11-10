using System.IO;
using BiscuitOS.Shell;
using BiscuitOS.FileManager;
using System;

namespace BiscuitOS.ExceptionHandling
{
    public class Logger
    {
        public static void CreateLog(string Message, LogType Type, Exception CSharpException = null, ErrorTypes Error = ErrorTypes.Unknown)
        {
            if (Type == LogType.Error) CreateErrorLog(Message, Error, CSharpException);
        }

        public static void StartLogger()
        {
            try
            {
                string[] CrashInfoBasic =
                {
                    "0",
                };

                FileMan.CreateFolder(@$"0:\Biscuit\CrashManager\");
                FileMan.CreateFolder(@$"0:\Biscuit\CrashManager\CrashFiles\");

                if (!File.Exists(@$"0:\Biscuit\CrashManager\CrashFiles\CrashInfo.info"))
                {
                    FileMan.CreateFile(@$"0:\Biscuit\CrashManager\CrashFiles\CrashInfo.info");

                    File.WriteAllLines(@$"0:\Biscuit\CrashManager\CrashFiles\CrashInfo.info", CrashInfoBasic);
                }

                FileMan.CreateFolder(@$"0:\Biscuit\");
                FileMan.CreateFolder(@$"0:\Biscuit\CrashLogs\");
            }
            catch
            {
                Console.WriteLine("A Crash Occured Whilst Attempting To Start The Crash Handler. The System May Not Work Correctly.");
            }
        }

        private static void CreateErrorLog(string Message, ErrorTypes Error, Exception CSharpException)
        {
            try
            {
                string[] CrashLog = GetLogFile(Message, Error, CSharpException);

                string[] CrashInfo = File.ReadAllLines(@$"0:\Biscuit\CrashManager\CrashFiles\CrashInfo.info");
                int CrashAmount = Convert.ToInt32(CrashInfo[0]) + 1;
                CrashInfo[0] = CrashAmount.ToString();

                File.Create(@$"0:\Biscuit\CrashLogs\{CrashAmount}ErrorCrash{Error}.log");

                File.WriteAllLines(@$"0:\Biscuit\CrashLogs\{CrashAmount}ErrorCrash{Error}.log", CrashLog);
            }
            catch
            {
                Console.WriteLine("A Crash Occured Whilst Attempting To Create A Crash Report.");
            }
        }

        private static string[] GetLogFile(string Message, ErrorTypes Error, Exception CSharpException)
        {
            if (Error == ErrorTypes.Unknown)
            {
                return new string[]
                {
                    "An unexpected error occured. This is not set as a recorded error.",
                    "",
                    "=== Operating System Error Message ===",
                    "",
                    $"{Message}",
                    "",
                    "=== C# Error Message ===",
                    "",
                    $"{CSharpException.Message}",
                    "",
                };
            }

            return new string[]
            {
                "You're gonna have to tell me what happened.",
                "",
                "=== Operating System Error Message ===",
                "",
                $"{Message}",
                "",
                "=== C# Error Message ===",
                "",
                $"{CSharpException.Message}",
                "",
            };
        }
    }
}
