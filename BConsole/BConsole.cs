using System;
using System.Collections.Generic;
using System.Linq;

namespace BiscuitOS
{
    public class BConsole
    {
        private static List<string> consoleText = new List<string>();
        private static bool RunBConsole = false;

        public static void StartBConsole()
        {
            Console.Clear();
            RunBConsole = true;
            Run();
        }

        public static void DisposeBConsole()
        { 
            RunBConsole = false;
        }

        public static void WriteLine(string text)
        {
            consoleText.Add(text);
        }

        private static void Run()
        {
            string currentText = String.Empty;
            do
            {
                ConsoleKeyInfo keyInfo = InputManager.GetKeyInfo();
                ConsoleKey key = keyInfo.Key;

                if (!key.isForbiddenKey())
                {
                    currentText += keyInfo.KeyChar;
                }
                else
                {
                    BConsole.WriteLine("Is forbidden key");
                    switch (key)
                    {
                        case ConsoleKey.Backspace:
                            // Remove Last Character
                            currentText.Remove(currentText.Length - 1, 1);
                            break;
                            
                        case ConsoleKey.Tab:
                            currentText += "    ";
                            break;

                        default:
                            break;
                    }
                }

                RenderBConsole(new string[0], currentText, false);

            } while (RunBConsole);
        }

        private static void RenderBConsole(string[] lines, string actionBar, bool ObfuscateInput)
        {
            Console.Clear();

            // Basic Setup Stuff
            List<string> output = new List<string>();
            output = lines.ToList();

            if(output.Count < 23) {
                while(output.Count < 23)
                {
                    output.Add(String.Empty);
                }
            }

            // Render Everything
            foreach (string line in output)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            if (ObfuscateInput)
            {
                foreach (char let in actionBar)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(actionBar);
            }

        }
    }
}
