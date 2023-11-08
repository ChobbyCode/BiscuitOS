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
            try
            {
                // Start The Editor
                string[] file = File.ReadAllLines(filePath[0]);
                if(file == null) file = new string[1];

                RenderScreen(file.ToArray(), 0, 1);
                TextEditorM(file, filePath[0]);
            }catch (Exception ex)
            {
                BConsole.WriteLine(ex.Message);
            }
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

            /*for(int i = 0; i <  lines.Count; i++)
            {
                lines[i] += " ";
            }*/

            int lineEdit = 0; // The Line We Are Editting
            int letterEdit = 1; // The letter We Are Editting
            

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
                    if (lines[lineEdit].Length < letterEdit)
                    {
                        letterEdit = lines[lineEdit].Length;
                    }
                }
                if(key == ConsoleKey.DownArrow || key == ConsoleKey.Enter && lineEdit != lines.Count() - 1)
                {
                    lineEdit++;
                    if (lines[lineEdit].Length < letterEdit)
                    {
                        letterEdit = lines[lineEdit].Length;
                    }
                }
                if(key == ConsoleKey.LeftArrow && letterEdit !>= 1)
                {
                    letterEdit--;
                }
                if(key == ConsoleKey.RightArrow && letterEdit < lines[lineEdit].Length)
                {
                    letterEdit++;
                }

                if (key == ConsoleKey.Backspace)
                {
                    // Delete Last Char
                    try
                    {
                        lines[lineEdit] = lines[lineEdit].Remove(letterEdit - 2, 1);
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
                    try
                    {
                        lines[lineEdit] = lines[lineEdit].Insert(letterEdit - 1, consoleKey.KeyChar.ToString());
                        letterEdit++;
                    }
                    catch
                    {

                    }
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
