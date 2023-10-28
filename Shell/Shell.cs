

namespace BiscuitOS.Shell
{
    public class Shell
    {
        public static void ParseUserCommand(string command)
        {
            // Parse the command words ready for reading
            string[] commandWord = CommandParser.ParseCommand(command);

            // Run the command words
            CommandInterpreter.Interpret(commandWord);
        }
    }
}
