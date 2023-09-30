using System.IO;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Core;

namespace BiscuitOS.Apps.TextEditor
{
    public class TextEditor
    {
        public static void StartTextEditor(string[] filePath)
        {
            // Start The Editor
            string[] file = File.ReadAllLines(filePath[0]);

            RenderScreen(file.ToArray(), "Test", "Empty", 0);
            TextEditorM(file, filePath[0]);
        }

        private static void TextEditorM(string[] file, string path)
        {
            List<string> lines = new List<string>();
            lines = file.ToList();

            if(lines.Count < 24) { 
                while(lines.Count < 24)
                {
                    lines.Add("");
                }
            }

            int lineEdit = 0; // The Line We Are Editting
            

            ConsoleKey key;
            do
            {
                // Get key values
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                key = consoleKey.Key;
                char readLet = consoleKey.KeyChar;

                // Check If lineEdit Needs To Change
                if(key == ConsoleKey.UpArrow && lineEdit != 0)
                {
                    lineEdit--;
                }
                if(key == ConsoleKey.DownArrow && lineEdit != lines.Count() - 1)
                {
                    lineEdit++;
                }

                if (key == ConsoleKey.Backspace)
                {
                    // Delete Last Char
                    try
                    {
                        lines[lineEdit] = lines[lineEdit].Remove(lines[lineEdit].Length - 1, 1);
                    }
                    catch
                    {
                        // Do Nothing
                    }
                }
                else if (readLet == ':')
                {
                    Console.Write(": ");
                    var input = Console.ReadLine();
                    if(input == "s")
                    {
                        File.WriteAllLines(path, lines.ToArray());
                    }else if(input == "e")
                    {
                        key = ConsoleKey.Escape;
                    }
                }
                else if (key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow)
                {
                    lines[lineEdit] = lines[lineEdit] + consoleKey.KeyChar;
                }

                // RenderScreen
                RenderScreen(lines.ToArray(), "Test", "Empty", lineEdit);
            } while(key != ConsoleKey.Escape);
            Console.Clear();
        }

        private static void RenderScreen(string[] chars, string fileName, string info, int writeLine)
        {
            // Render The Screen
            Console.Clear();

            int loop = 0;
            foreach(string line in chars)
            {
                if(loop == writeLine)
                {
                    Console.WriteLine("> " + line);
                }
                else
                {
                    Console.WriteLine(line);
                }
                loop++;
            }
        }
    }
}
