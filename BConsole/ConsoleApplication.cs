using System;
using System.Collections.Generic;

namespace BiscuitOS
{
    /// <summary>
    /// Creates a Console Override application that appears on top of the console, instead of the default console.
    /// </summary>
    public class ConsoleApplication
    {
        private string currentText = String.Empty;
        private bool runApp = false;
        private List<String> lines = new List<String>();

        public EventHandler onWindowRender;
        public EventHandler onAppStartUp;
        public EventHandler onAppDispose;
        public EventHandler onEventTick;
        public EventHandler onFunctionKeyPress;

        public ConsoleApplication() { }

        public ConsoleApplication(bool autoStart)
        {
            if (autoStart) Start();
        }

        public void Start()
        {
            // Start App
            BConsole.IsAppMode = true;
            runApp = true;

            onAppStartUp.Invoke(this, EventArgs.Empty);
        }

        public void Dispose() 
        {
            // Stop App
            BConsole.IsAppMode = false;
            onAppDispose.Invoke(this, EventArgs.Empty);
        }

        public void Update()
        {
            RenderScreen(lines.ToArray(), "", false);
        }

        private void Run()
        {
            do
            {
                onEventTick.Invoke(this, EventArgs.Empty);
                DoInput();

            } while (runApp);
        }

        private void DoInput()
        {
            string line = String.Empty;

            ConsoleKeyInfo keyInfo = InputManager.GetKeyInfo();
            ConsoleKey key = keyInfo.Key;

            ProcessInput(key, keyInfo);
        }

        private void ProcessInput(ConsoleKey key, ConsoleKeyInfo keyInfo)
        {
            if (!key.isForbiddenKey())
            {
                currentText += keyInfo.KeyChar;
                return;
            }
            // Then it is a forbidden key / function key
            // Send to client to process
            FunctionKeyEventArgs functionKey = new();
            functionKey.keyInfo = keyInfo;
            functionKey.key = key;

            onFunctionKeyPress.Invoke(this, functionKey);
        }

        private void RenderScreen(string[] lines, string title, bool allowWrite)
        {
            // Create Screen Stuff And Buffers
            
            List<string> text = new List<string>();
            if(text.Count < 24) {
                while(text.Count < 24)
                {
                    text.Add(String.Empty);
                }
            }

            // Render The Screen
            foreach(string line in text) {
                Console.WriteLine(line);
            }

            if (allowWrite)
            {
                Console.WriteLine(currentText);
            }
        }
    }

    /// <summary>
    /// Can be passed into a ConsoleApp and does settings
    /// </summary>
    public class ConsoleSettings
    {

    }

    public class FunctionKeyEventArgs : EventArgs
    {
        public ConsoleKeyInfo keyInfo { get; set; }
        public ConsoleKey key { get; set; }
    }
}
