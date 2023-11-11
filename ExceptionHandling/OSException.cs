
using System;

namespace BiscuitOS.ExceptionHandling
{
    public class OSException
    {
        public static void CreateErrorLog(ErrorTypes Error, Exception CSharpException, string message)
        {
            Logger.CreateLog(message, LogType.Error, CSharpException, Error);
        }
    }
}
