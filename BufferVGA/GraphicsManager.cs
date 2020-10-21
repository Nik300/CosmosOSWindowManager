using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using SYS = Cosmos.System;
using Cosmos.Core.IOGroup.ExtPack;
using AerOS.System.Graphics.toolbox;
using System.Reflection.Metadata;

namespace AerOS.System.Graphics
{
    public struct Cursor
    {
        public int x;
        public int y;
        public int prevx;
        public int prevy;
        public bool changedMouse;
        public bool drag;
    }

    public class GraphicsManager
    {
        public static Cursor cursor;
        public static VGA canvas = new VGA(GraphicsModes._320x200x256());
        private bool changedBuffer = false;
        public static List<WindowContainer> WindowContainers = new List<WindowContainer>();
        public GraphicsManager()
        {
            SYS.MouseManager.ScreenHeight = (uint)canvas.Mode.Rows;
            SYS.MouseManager.ScreenWidth = (uint)canvas.Mode.Columns;

            cursor.x = (int)(canvas.Mode.Rows / 2);
            cursor.y = (int)(canvas.Mode.Columns / 2);
            cursor.drag = false;

            SYS.MouseManager.X = (uint)(canvas.Mode.Rows / 2);
            SYS.MouseManager.Y = (uint)(canvas.Mode.Columns / 2);

            //canvas.CleanScreen(Color.Blue);
            //canvas.PutPixel(cursor.x, cursor.y, Color.BrightGreen, true);

            changedBuffer = true;
        }

        public WindowContainer AddNewWindowContainer(int BaseX, int BaseY, int width, int height, string name, Color? color = null, bool TopBar = true)
        {
            Color color1 = color ?? Color.Red;
            WindowContainer windowContainer = new WindowContainer(BaseX, BaseY, width, height, name, color1, TopBar);
            WindowContainers.Add(windowContainer);
            return windowContainer;
        }
        public static void focus(WindowContainer container)
        {
            for (int i = 0; i < WindowContainers.ToArray().Length; i++)
            {
                if (WindowContainers[i].focus == true) WindowContainers[i].focus = false;
                if (WindowContainers[i] == container) WindowContainers[i].focus = true;
            }
        }
        public bool CheckMousePos()
        {
            cursor.prevx = cursor.x;
            cursor.prevy = cursor.y;
            if (SYS.MouseManager.MouseState == SYS.MouseState.Left && cursor.drag == false) cursor.drag = true;
            if (SYS.MouseManager.MouseState == SYS.MouseState.None && cursor.drag == true) {
                cursor.drag = false;
                for (int i = WindowContainers.ToArray().Length - 1; i >= 0; i--)
                {
                    WindowContainer container = WindowContainers[i];
                    if (container.name != "Desktop")
                    {
                        if (container.focus == true)
                        {
                            container.OnMouseMove(cursor.x, cursor.y, cursor.prevx, cursor.prevy);
                            break;
                        }
                        else continue;
                    }
                }
            }
            if ((int)SYS.MouseManager.X != cursor.x || (int)SYS.MouseManager.Y != cursor.y)
            {
                if (SYS.MouseManager.X >= (uint)canvas.Mode.Columns)
                    SYS.MouseManager.X = (uint)canvas.Mode.Columns;
                else if (SYS.MouseManager.Y >= (uint)canvas.Mode.Rows)
                    SYS.MouseManager.Y = (uint)canvas.Mode.Rows;
                cursor.x = (int)SYS.MouseManager.X;
                cursor.y = (int)SYS.MouseManager.Y;
                cursor.changedMouse = true;
            }
            else
                cursor.changedMouse = false;

            if (cursor.changedMouse == true)
                return true;
            //else
            return false;
        }

        private void renderMouse()
        {
            canvas.DrawCursor(cursor.x, cursor.y, Color.Gray);
            changedBuffer = true;
        }

        public void start()
        {
            bool clicked = false;
            bool moved = false;
            changedBuffer = true;
            for (; ; )  // Make infinite loop
            {
                if (!cursor.drag)
                    if (SYS.MouseManager.MouseState == SYS.MouseState.Left)
                    {
                        WindowContainer focussed = null;
                        for (int i = WindowContainers.ToArray().Length - 1; i >= 0; i--)
                        {
                            if (WindowContainers[i].focus == true) focussed = WindowContainers[i];
                        }
                        try
                        {
                            for (int i = WindowContainers.ToArray().Length - 1; i >= 0; i--)
                            {
                                WindowContainer container = WindowContainers[i];
                                if (container.IsHere(cursor.x, cursor.y) && (container.focus || container.alwaysOn))
                                {
                                    if (clicked) break;
                                    container.OnFocussedMouseClick(cursor.x, cursor.y, cursor.prevx, cursor.prevy);
                                    if (container.name != "TaskBar") clicked = true;
                                }
                                else if (container.IsHere(cursor.x, cursor.y) && !container.focus && !focussed.IsHere(cursor.x, cursor.y) && container.name != "Desktop")
                                {
                                    if (container.name != "TaskBar") container.OnMouseClick(cursor.x, cursor.y, cursor.prevx, cursor.prevy);
                                }
                            }
                        }
                        catch { }
                    }
                    else
                        clicked = false;

                bool mousechanged = CheckMousePos();

                if (mousechanged)
                {
                    if (SYS.MouseManager.MouseState == SYS.MouseState.Left)
                    {
                        for (int i = WindowContainers.ToArray().Length - 1; i >= 0; i--)
                        {
                            WindowContainer container = WindowContainers[i];
                            if (container.name != "Desktop")
                            {
                                if (container.focus == true)
                                {
                                    if (moved) break;
                                    container.OnMouseMove(cursor.x, cursor.y, cursor.prevx, cursor.prevy);
                                    foreach (VisualItem item in container.items)
                                    {
                                        if (item.IsHere(cursor.x, cursor.y))
                                        {
                                            moved = false;
                                            break;
                                        }
                                        moved = true;
                                    }
                                    break;
                                }
                                else continue;
                            }
                        }
                    }
                }
                if (!cursor.drag)
                    moved = false;

                foreach (WindowContainer container in WindowContainers)
                {
                    container.Refresh();
                    if (container.changed) 
                    { 
                        changedBuffer = true;
                        container.changed = false;
                    }
                }
                foreach (WindowContainer container in WindowContainers)
                {
                    if (container.focus) container.Refresh();
                }
                foreach (WindowContainer container in WindowContainers)
                {
                    if (container.alwaysOn) container.Refresh();
                }

                renderMouse();
                canvas.Render();

                SYS.KeyEvent key;
                SYS.KeyboardManager.TryReadKey(out key);
                if (SYS.KeyboardManager.AltPressed && key.Key == SYS.ConsoleKeyEx.Escape)
                {
                    canvas.Disable();
                    BufferVGA.console.BeforeRun();
                    for (; ; )
                        BufferVGA.console.Run();
                }
            }
        }

    }
}
