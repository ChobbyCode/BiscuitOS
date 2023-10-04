
namespace BiscuitOS
{
    public class BError
    {
        private static void PrintError(string msg)
        {
            BConsole.WriteLine();
            BConsole.WriteLine(msg);
            BConsole.WriteLine();
        }

        public static void Error(string msg)
        {
            PrintError(msg);
        }
        public static void Error()
        {
            PrintError("An Error Occured.");
        }

        public static void SystemWriteError()
        {
            PrintError("A System Write Error Occured.");
        }

        public static void SystemDeleteError()
        {
            PrintError("A System Delete Error Occured");
        }

        public static void SystemIOError()
        {
            PrintError("A System IO Errro Occured");
        }

        public static void CPUHaltError()
        {
            PrintError("CPU Halt Error Occured. The Computer May Shutdown.");
        }

        public static void NullableValueError()
        {
            PrintError("A Nullable Value Occured");
        }

        public static void ParsingError()
        {
            PrintError("A Parsing Error Occured");
        }
    }
}
