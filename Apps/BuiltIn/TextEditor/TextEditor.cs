using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using BiscuitOS.FileManager;

namespace BiscuitOS.Apps.TextEditor
{
    public class TextEditor
    {
        public static void StartTextEditor(string[] filePath)
        {
            try
            {
                // Start The Editor
                if (FileMan.isRelative(filePath[0]))
                {
                    string[] file = File.ReadAllLines(FileMan.GetPath() + filePath[0]);

                    RenderScreen(file, 0, 1, FileMan.GetPath() + filePath[0]);
                    TextEditorM(file, FileMan.GetPath() + filePath[0]);

                }
                else
                {
                    string[] file = File.ReadAllLines(filePath[0]);

                    RenderScreen(file, 0, 1, filePath[0]);
                    TextEditorM(file, filePath[0]);
                }
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

            for(int i = 0; i <  lines.Count; i++)
            {
                lines[i] += " ";
            }

            int lineEdit = 0; // The Line We Are Editting
            int letterEdit = 1; // The letter We Are Editting
            bool debugMode = false;
            

            ConsoleKey key;
            do
            {
                // Get key values
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                key = consoleKey.Key;
                char readLet = consoleKey.KeyChar;

                // Check If lineEdit Needs To Change
                if (key == ConsoleKey.UpArrow && lineEdit != 0)
                {
                    lineEdit--;
                    if (lines[lineEdit].Length < letterEdit)
                    {
                        letterEdit = lines[lineEdit].Length;
                    }
                }
                if (key == ConsoleKey.DownArrow || key == ConsoleKey.Enter && lineEdit != lines.Count() - 1)
                {
                    lineEdit++;
                    if (lines[lineEdit].Length < letterEdit)
                    {
                        letterEdit = lines[lineEdit].Length;
                    }
                }
                if (key == ConsoleKey.LeftArrow && letterEdit! >= 1)
                {
                    letterEdit--;
                }
                if (key == ConsoleKey.RightArrow && letterEdit < lines[lineEdit].Length)
                {
                    letterEdit++;
                }
                // 77 is the letters on a line
                if(letterEdit >= 77)
                {
                    if(key != ConsoleKey.Spacebar) lines[lineEdit] = lines[lineEdit].Insert(letterEdit - 1, "-");
                    letterEdit = 1;
                    lineEdit++;
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
                else if (key == ConsoleKey.Delete)
                {
                    // Delete Last Char
                    try
                    {
                        lines[lineEdit] = lines[lineEdit].Remove(letterEdit - 1, 1);
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
                    }else if(input == "d")
                    {
                        if(debugMode) debugMode = false;
                        else debugMode = true;
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

                // Safe check so we not editing null value
                if (letterEdit == 0)
                {
                    // Must be 2 because it a buffer for the next one and they probaly spamming
                    letterEdit = 1;
                }

                // RenderScreen
                RenderScreen(lines.ToArray(), lineEdit, letterEdit, path, debugMode);
            } while(key != ConsoleKey.Escape);
            Console.Clear();
        }

        private static void RenderScreen(string[] lines, int writeLine, int editLetter, string path, bool debug = false)
        {
            // Render The Screen
            Console.Clear();

            List<String> renderLines = lines.ToList();
            // Add Edit Line Notation
            renderLines[writeLine] = renderLines[writeLine].Insert(0, ">");
            renderLines[writeLine] = renderLines[writeLine].Insert(editLetter, "|<");

            // Debug
            if (debug)
            {
                renderLines[14] = $"Letter: {editLetter} | Line: {writeLine}";
                renderLines[15] = $"Words: {renderLines[writeLine].Split(" ").Length - 1}";
                renderLines[16] = $"File Path: '{path}'";
                if (lines == null) renderLines[17] = $"Null? true";
                else renderLines[17] = $"Null? false";
            }

            int loop = 0;
            foreach(string line in renderLines)
            {
                Console.WriteLine(line);
                loop++;
            }
        }
    }
}
