
using System;

namespace BiscuitOS.ExceptionHandling
{
    public class OSException
    {
        public static void CreateErrorLog(ErrorTypes Error, Exception CSharpException, string message = null)
        {
            if(message != null) Logger.CreateLog(message, LogType.Error, CSharpException, Error);
            else Logger.CreateLog("", LogType.Error, CSharpException, Error);
        }
    }
}
