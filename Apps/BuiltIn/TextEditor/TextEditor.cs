using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiscuitOS.Apps.TextEditor
{
    public class TextEditor
    {
        public static void StartTextEditor(string[] filePath)
        {
            // Start The Editor
            string[] file = File.ReadAllLines(filePath[0]);

            RenderScreen(file.ToArray(), 0, 0);
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
            int letterEdit = 0; // The letter We Are Editting
            

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
                if(key == ConsoleKey.LeftArrow && letterEdit != 1)
                {
                    letterEdit--;
                }
                if(key == ConsoleKey.RightArrow && letterEdit != lines[lineEdit].Length + 1)
                {
                    letterEdit++;
                }

                if (key == ConsoleKey.Backspace)
                {
                    // Delete Last Char
                    try
                    {
                        lines[lineEdit] = lines[lineEdit].Remove(letterEdit - 1, 1);
                        letterEdit--;
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
                else if (key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow && key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow)
                {
                    // Insert 
                    if(letterEdit >= lines[lineEdit].Length)
                    {
                        lines[lineEdit] = lines[lineEdit] + consoleKey.KeyChar;
                    }
                    else
                    {
                        lines[lineEdit] = lines[lineEdit].Insert(letterEdit, consoleKey.KeyChar.ToString());
                    }
                    letterEdit++;
                }

                // RenderScreen
                RenderScreen(lines.ToArray(), lineEdit, letterEdit);
            } while(key != ConsoleKey.Escape);
            Console.Clear();
        }

        private static void RenderScreen(string[] lines, int writeLine, int editLetter)
        {
            // Render The Screen
            Console.Clear();

            List<String> renderLines = lines.ToList();
            // Add Edit Line Notation
            renderLines[writeLine] = renderLines[writeLine].Insert(0, ">");
            renderLines[writeLine] = renderLines[writeLine].Insert(editLetter, "|<");

            int loop = 0;
            foreach(string line in renderLines)
            {
                Console.WriteLine(line);
                loop++;
            }
        }
    }
}
