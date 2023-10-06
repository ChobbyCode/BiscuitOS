using System;
using System.Collections.Generic;
using System.Linq;

namespace BiscuitOS
{
    public class BConsole
    {
        public static ConsoleColor ForegroundColor = ConsoleColor.Black;
        public static ConsoleColor BackgroundColor = ConsoleColor.DarkCyan;

        private static List<string> consoleText = new List<string>();
        private static string prevInput = String.Empty;

        public static void WriteLine(string text)
        {
            consoleText.Add(text);
            RenderBConsole(consoleText.ToArray(), String.Empty, "", false);
        }
        public static void WriteLine()
        {
            consoleText.Add(String.Empty);
            RenderBConsole(consoleText.ToArray(), String.Empty, "", false);
        }

        public static void Refresh()
        {
            RenderBConsole(consoleText.ToArray(), String.Empty, "", false);
        }
        public static void Clear()
        {
            consoleText.RemoveRange(0, consoleText.Count);
            RenderBConsole(consoleText.ToArray(), String.Empty, "", false);
        }

        public static string ReadRedacted()
        {
            return Read("", true);
        }
        public static string ReadRedacted(string msg)
        {
            return Read(msg, true);
        }

        public static ConsoleKey ReadKey()
        {
            return InputManager.GetKey();
        }
        public static string ReadLine()
        {
            return Read("", false);
        }
        public static string ReadLine(string msg)
        {
            RenderBConsole(consoleText.ToArray(), String.Empty, msg, false);
            return Read(msg, false);
        }

        private static string Read(string msg, bool redactInfo)
        {
            RenderBConsole(consoleText.ToArray(), msg, "", redactInfo);
            string line = String.Empty;

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = InputManager.GetKeyInfo();
                key = keyInfo.Key;

                if (!key.isForbiddenKey())
                {
                    line += keyInfo.KeyChar;
                }
                else
                {
                    if (key == ConsoleKey.Backspace)
                    {
                        try
                        {
                            line = line.Remove(line.Length - 1, 1);
                        }
                        catch
                        {
                            // Do nothing
                        }
                    }else if(key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                    {
                        // Set current line to previous line
                        var tmp = prevInput;
                        prevInput = line;
                        line = tmp;
                    }
                }
                RenderBConsole(consoleText.ToArray(), msg, line, redactInfo);
            } while (key != ConsoleKey.Enter);
            prevInput = line;
            return line;
        }

        private static void RenderBConsole(string[] lines, string msg, string actionBar, bool ObfuscateInput)
        {
            // Basic Setup Stuff
            List<string> output = new List<string>();
            output = lines.ToList();

            if(output.Count < 22) {
                while(output.Count < 22)
                {
                    output.Add(String.Empty);
                }
            }

            if (output.Count > 22)
            {
                while (output.Count > 22)
                {
                    output.RemoveAt(0);
                }
            }

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;

            Console.Clear();

            // Render Everything
            foreach (string line in output)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            if (ObfuscateInput)
            {
                Console.Write(msg);
                foreach (char let in actionBar)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(msg + actionBar);
            }

        }
    }
}
