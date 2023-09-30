﻿using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BiscuitOS
{
    public class BConsole
    {
        public static ConsoleColor ForegroundColor = ConsoleColor.Black;
        public static ConsoleColor BackgroundColor = ConsoleColor.DarkCyan;

        private static List<string> consoleText = new List<string>();

        public static void WriteLine(string text)
        {
            consoleText.Add(text);
            RenderBConsole(consoleText.ToArray(), "", false);
        }
        public static void WriteLine()
        {
            consoleText.Add(String.Empty);
            RenderBConsole(consoleText.ToArray(), "", false);
        }

        public static void Clear()
        {
            consoleText.RemoveRange(0, consoleText.Count);
            RenderBConsole(consoleText.ToArray(), "", false);
        }

        public static string ReadLine()
        {
            return Read("");
        }

        public static string ReadLine(string msg)
        {
            return Read(msg);
        }

        private static string Read(string msg)
        {
            string line = String.Empty;

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = InputManager.GetKeyInfo();
                key = keyInfo.Key;

                RenderBConsole(consoleText.ToArray(), msg + line, false);

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
                    }
                }
            } while (key != ConsoleKey.Enter);
            return line;
        }

        private static void RenderBConsole(string[] lines, string actionBar, bool ObfuscateInput)
        {
            // Basic Setup Stuff
            List<string> output = new List<string>();
            output = lines.ToList();

            if(output.Count < 23) {
                while(output.Count < 23)
                {
                    output.Add(String.Empty);
                }
            }

            if (output.Count > 23)
            {
                while (output.Count > 23)
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
