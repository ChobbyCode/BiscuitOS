﻿using BiscuitOS.Apps.TextEditor;
using BiscuitOS.FileExecutable;
using BiscuitOS.FileManager;
using System.IO;



namespace BiscuitOS.FileExplorer
{
    internal class CommandParser
    {
        public static void ParseCommand(string[] commandWord)
        {
            if (commandWord[1] == "new")
            {
                // They want to create a new file
                if (commandWord[2] == "fl" || commandWord[2] == "file")
                {

                    if (commandWord[3] != "")
                    {
                        string[] defText =
                        {
                            "File auto generated by BiscuitOS",
                        };
                        if (FileMan.isRelative(commandWord[3]))
                        {
                            try
                            {
                                File.Create(FileMan.GetPath() + commandWord[3]);
                                File.WriteAllLines(FileMan.GetPath() + commandWord[3], defText);
                            }
                            catch
                            {
                                BError.SystemIOError();
                            }
                        }
                        else
                        {

                            try
                            {
                                File.Create(commandWord[3]);
                                File.WriteAllLines(commandWord[3], defText);
                            }
                            catch
                            {
                                BError.SystemIOError();
                            }
                        }
                    }
                    else
                    {
                        BConsole.WriteLine("Please specify a name for the file.");
                    }

                    if (commandWord[4] == "-r")
                    {
                        if (FileMan.isRelative(commandWord[3]))
                        {
                            string[] args = { FileMan.GetPath() + commandWord[3] };
                            TextEditor.StartTextEditor(args);
                        }
                        else
                        {
                            string[] args = { commandWord[3] };
                            TextEditor.StartTextEditor(args);
                        }
                    }
                }
                else if (commandWord[2] == "dir" || commandWord[2] == "directory")
                {
                    if (FileMan.isRelative(commandWord[3]))
                    {
                        try
                        {
                            Directory.CreateDirectory(FileMan.GetPath() + commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                    }
                    else
                    {
                        try
                        {
                            Directory.CreateDirectory(commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                    }

                    if (commandWord[4] == "-r")
                    {
                        // Open To Directory
                        if (FileMan.isRelative(commandWord[3]))
                        {
                            FileMan.SetDir(FileMan.GetPath() + commandWord[3]);
                        }
                        else
                        {
                            FileMan.SetDir(commandWord[3]);
                        }
                    }
                }
                else
                {
                    BConsole.WriteLine("Incorrect use of command word 'new'");
                }
            }
            else if (commandWord[1] == "st")
            {
                // Set text
                try
                {
                    File.WriteAllText(FileMan.GetPath() + commandWord[2], commandWord[3]);
                }
                catch
                {
                    BConsole.WriteLine("Failed to write to file");
                }
            }
            else if (commandWord[1] == "del")
            {
                if (commandWord[2] == "fl" || commandWord[2] == "file")
                {
                    if (FileMan.isRelative(commandWord[3]))
                    {
                        try
                        {
                            File.Delete(FileMan.GetPath() + commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                    }
                    else
                    {
                        try
                        {
                            File.Delete(commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                    }
                }
                else if (commandWord[2] == "dir" || commandWord[2] == "directory")
                {
                    if (FileMan.isRelative(commandWord[3]))
                    {
                        try
                        {
                            Directory.Delete(FileMan.GetPath() + commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                    }
                    else
                    {
                        try
                        {
                            Directory.Delete(commandWord[3]);
                        }
                        catch
                        {
                            BError.SystemIOError();
                        }
                    }
                }
            }
            else if (commandWord[1] == "run")
            {
                FMFile fmFile = new FMFile();
                fmFile.RunFile(FileMan.GetPath() + commandWord[2]);
            }
            else
            {
                BConsole.WriteLine("Incorrect use of command word 'fm'");
            }
        }
    }
}
