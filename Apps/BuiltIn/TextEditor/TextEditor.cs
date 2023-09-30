using System.IO;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace BiscuitOS.Apps.TextEditor
{
    public class TextEditor
    {
        public static void StartTextEditor(/*string filePath*/)
        {
            // Start The Editor
            //string[] file = File.ReadAllLines(filePath);

            string[] file = { "Hello, World", "Hello, World" };

            TextEditorM(file);
        }

        private static void TextEditorM(string[] file)
        {
            List<string> lines = new List<string>();
            lines = file.ToList();

            int lineEdit = 0; // The Line We Are Editting
            

            ConsoleKey key;
            do
            {
                // Get key values
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                key = consoleKey.Key;
                char readLet = consoleKey.KeyChar;

                // Check If lineEdit Needs To Change
                if(key == ConsoleKey.UpArrow)
                {
                    if (lineEdit == 0) continue;
                    lineEdit--;
                }
                if(key == ConsoleKey.DownArrow)
                {
                    if (lineEdit == lines.Count()) continue;
                    lineEdit++;
                }

                if (key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow)
                {
                    if(key == ConsoleKey.Backspace)
                    {
                        // Delete Last Char
                        lines[lineEdit] = lines[lineEdit].Remove(lines[lineEdit].Length - 1, 1);
                    }
                    lines[lineEdit] = lines[lineEdit] + consoleKey.KeyChar;
                }

                // RenderScreen
                RenderScreen(lines.ToArray(), "Test", "Empty");
            } while(key != ConsoleKey.Escape);
        }

        private static void RenderScreen(string[] chars, string fileName, string info)
        {
            // Render The Screen
            Console.Clear();

            foreach(string line in chars)
            {
                Console.WriteLine(line);
            }
        }
    }
}
