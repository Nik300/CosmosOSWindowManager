using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.Core.IOGroup.ExtPack;
using AerOS.System.Graphics;
using System.Runtime.InteropServices;
using Cosmos.Core_Asm;
using XSharp;
using IL2CPU.API.Attribs;
using Cosmos.Core_Asm.MemoryOperations;
using AerOS.System.Graphics.toolbox;

namespace AerOS.Software
{
}

namespace BufferVGA
{
    public class Kernel : Sys.Kernel
    {

        static public GraphicsManager GM;

        protected override void BeforeRun()
        {
            try
            {
                GM = new GraphicsManager();
                WindowContainer desktop = GM.AddNewWindowContainer(0, 0, GraphicsManager.canvas.Mode.Columns, GraphicsManager.canvas.Mode.Rows, "Desktop", Color.Purple, false);
                WindowContainer window1 = GM.AddNewWindowContainer(10, 15, 90, 35, "Test window #1", Color.Blue);
                WindowContainer window2 = GM.AddNewWindowContainer(7, 9, 100, 35, "Test window #2", Color.Green);
                WindowContainer TaskBar = GM.AddNewWindowContainer(0, GraphicsManager.canvas.Mode.Rows - 20, GraphicsManager.canvas.Mode.Columns, 20, "TaskBar", Color.Blue, false);
                TaskBar.alwaysOn = true;
                Button button1 = new Button(window1.W - 9, 0, 9, 10, "X", new OnMouseClick(() => { window1.Close(); }), Color.Red);
                TaskBar taskbar = new TaskBar(20, TaskBar);
                taskbar.AddItem(new Button(0, 0, 32, taskbar.height, "start", new OnMouseClick(() => {
                    foreach (WindowContainer container in GraphicsManager.WindowContainers)
                    {
                        if (container.name == "list_menu")
                        {
                            container.Close();
                            return;
                        }
                    }
                    WindowContainer list_menu = GM.AddNewWindowContainer(0, TaskBar.BaseY - ((desktop.H / 2) + desktop.BaseY), 200, (desktop.H / 2) + desktop.BaseY, "list_menu", Color.LightBlue, false);
                    list_menu.alwaysOn = true;
                }), Color.Orange));
                TaskBar.AddItem(taskbar);
                window1.AddItem(button1);
                window1.WriteText("Test", 0, 0, Color.DarkGray);
                window2.WriteText("Window", 0, 3, Color.Orange);
                GraphicsManager.focus(window2);
            }
            catch { }
        }

        protected override void Run()
        {
            GM.start();
        }
    }

    public static class console
    {
        public static void BeforeRun()
        {
            Console.Clear();
        }
        public static void Run()
        {
            Console.Write($"sh@AerOS: '{System.IO.Directory.GetCurrentDirectory()}'> ");
            var com = Console.ReadLine();
            if (com == "xstart")
            {
                GraphicsManager gm = new GraphicsManager();
                Kernel.GM.start();
            }

            Console.WriteLine("No commands installed in '0:\\Sys32\\Softwares\\$CONSOLE.bundle\\commands.\nUse pkg -l for a list of LIVE-READY programs.'");
        }
    }
}
