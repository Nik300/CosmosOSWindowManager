using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AerOS.System.Graphics.toolbox;
using Cosmos.Core.IOGroup.ExtPack;
using Cosmos.System;
using Cosmos.System.Graphics;
using XSharp.Assembler.x86;

namespace AerOS.System.Graphics
{
    public struct Pixel
    {
        public Color color;
        public int x;
        public int y;
    }

    public struct coordinates
    {
        public int x;
        public int y;
        public int prevx;
        public int prevy;
    }

    public abstract class VisualItem
    {
        public int BaseX;
        public int BaseY;
        public int height;
        public int weight;
        public Color color;
        readonly public List<Pixel> pixels = new List<Pixel>();
        public readonly string type;
        public VisualItem(int x, int y, int weight, int height, string type, Color color = Color.Black)
        {
            BaseX = x;
            BaseY = y;
            this.weight = weight;
            this.height = height;
            this.color = color;
            this.type = type;
            clear();
        }
        public abstract void OnMouseClick();
        public void DrawPoint(int x, int y, Color color)
        {
            if (x < 0 || y < 0 || x > BaseX + weight || y > BaseY + height) return;
            GraphicsManager.canvas.PutPixel(x + BaseX, y + BaseY, color);
            Pixel px = new Pixel()
            {
                x = x,
                y = y,
                color = color
            };
            pixels.Add(px);
        }
        public void clear()
        {
            int endX = weight;
            int endY = height;

            for (int y = 0; y < endY; y++)
            {
                for (int x = 0; x < endX; x++)
                {
                    DrawPoint(x, y, color);
                }
            }
        }
        public void clear(Color color)
        {
            int endX = weight;
            int endY = height;

            for (int y = 0; y < endY; y++)
            {
                for (int x = 0; x < endX; x++)
                {
                    DrawPoint(x, y, color);
                }
            }
        }
        public void WriteText(string text, int x, int y, Color color)
        {
            FontDrawer.WriteText(text, x, y, color, this);
        }
        public void Refresh()
        {
            foreach (Pixel px in pixels)
            {
                GraphicsManager.canvas.PutPixel(px.x + BaseX, px.y + BaseY, px.color);
            }
        }
        public bool IsHere(int x, int y)
        {
            return ((x >= BaseX && y >= BaseY) && (x <= weight + BaseX && y <= height + BaseY));
        }
    }

    public class WindowContainer
    {
        public List<Pixel> pixels = new List<Pixel>();
        public List<Pixel> Items_Pixels = new List<Pixel>();
        public List<VisualItem> items = new List<VisualItem>();
        public bool focus = false;
        public bool alwaysOn = false;
        public int BaseX;
        public int BaseY;
        public int W;
        public string name;
        public int H;
        public Color color;
        public bool changed = false;
        bool hide = false;

        public WindowContainer(int X, int Y, int width, int height, string name, Color? color = null, bool TopBar = true)
        {
            this.color = color ?? Color.Red;
            BaseX = X;
            BaseY = Y;
            W = width;
            H = height;
            this.name = name;

            if(TopBar)
                LoadTopBar();

            Clear();
        }

        public void LoadTopBar()
        {
            TopBar topBar = new TopBar(name, this);
            AddItem(topBar);
        }

        public void OnMouseMove(int offsetX, int offsetY, int prevX, int prevY)
        {
            if (hide) return;
            foreach (VisualItem item in items)
            {
                if (item.type == "TopBar")
                {
                    if (((TopBar)item).bypass != GraphicsManager.cursor.drag)
                    {
                        if (((TopBar)item).bypass)
                        {
                            ((TopBar)item).bypass = false;
                            return;
                        }
                        if (!((TopBar)item).bypass)
                        {
                            if (item.IsHere(offsetX, offsetY))
                                ((TopBar)item).bypass = false;
                            else
                                return;
                        }
                    }
                    if (item.IsHere(offsetX, offsetY) || ((TopBar)item).bypass) item.OnMouseClick();
                }
            }
        }

        public void OnMouseClick(int x, int y, int prevx, int prevy)
        {
            if (hide) return;
            if (this.focus == false)
            {
                GraphicsManager.focus(this);
            }
        }

        public void OnFocussedMouseClick(int x, int y, int prevx, int prevy)
        {
            if (hide) return;
            foreach (VisualItem item in items)
            {
                if (item.IsHere(x, y)) item.OnMouseClick();
            }
        }

        /*private void MoveWindowPixels(int X, int Y, int endX, int endY)
        {
            
        }

        private void ClearPixels()
        {
            int endx = BaseX + W;
            int endy = BaseY + H;
            foreach (WindowContainer window in GraphicsManager.WindowContainers)
            {
                if (window == this)
                    break;
                else if(window.IsPixelInArray())

            }
        }*/

        public void Clear()
        {
            if (hide) return;
            int endX = W;
            int endY = H;

            for (int y = 0; y < endY; y++)
            {
                for (int x = 0; x < endX; x++)
                {
                    DrawPoint(x, y, color);
                }
            }

            changed = true;
        }

        public void Clear(Color _color)
        {
            if (hide) return;
            int endX = W;
            int endY = H;

            for (int y = 0; y < endY; y++)
            {
                for (int x = 0; x < endX; x++)
                {
                    DrawPoint(x, y, _color);
                }
            }

            changed = true;
        }

        public void AddItem(VisualItem item)
        {
            if (hide) return;
            item.BaseX += BaseX;
            item.BaseY += BaseY;
            items.Add(item);
            item.Refresh();
        }

        public void DrawPoint(int x, int y, Color color)
        {
            if (hide) return;
            if (x < 0 || y < 0 || x > BaseX + W || y > BaseY + H) return;
            GraphicsManager.canvas.PutPixel(x + BaseX, y + BaseY, color);
            Pixel px = new Pixel();
            px.x = x;
            px.y = y;
            px.color = color;
            pixels.Add(px);
        }
        public void WriteText(string text, int x, int y, Color color)
        {
            if (hide) return;
            if (x < 0 || y < 0 || x > BaseX + W || y > BaseY + H) return;
            FontDrawer.WriteText(text, x + BaseX, y + BaseY, color, this);
        }
        public void DrawItemPixel(int x, int y, Color color)
        {
            if (hide) return;
            if (x < 0 || y < 0) return;
            GraphicsManager.canvas.PutPixel(x + BaseX, y + BaseY, color);
            Pixel px = new Pixel();
            px.x = x;
            px.y = y;
            px.color = color;
            Items_Pixels.Add(px);
        }
        private void RefreshPixels()
        {
            if (hide) return;
            foreach (Pixel pixel in pixels)
            {
                GraphicsManager.canvas.PutPixel(pixel.x + BaseX, pixel.y + BaseY, pixel.color);
            }
            foreach (Pixel pixel in Items_Pixels)
            {
                GraphicsManager.canvas.PutPixel(pixel.x + BaseX, pixel.y + BaseY, pixel.color);
            }
        }

        public bool IsHere(int x, int y)
        {
            if (hide) return false;
            return ((x >= BaseX && y >= BaseY) && (x <= W + BaseX && y <= H + BaseY));
        }

        public bool IsPixelInArray(int x, int y)
        {
            if (hide) return false;
            foreach (Pixel pixel in pixels)
            {
                if (pixel.x == x - BaseX && pixel.y == y - BaseY)
                    return true;
            }

            return false;
        }

        public Color GetPixelColor(int x, int y)
        {
            if (hide) return Color.Black;
            foreach (Pixel px in pixels)
                if (px.x == x - BaseX && px.y == y - BaseY) return px.color;
            return color;
        }

        public void Refresh()
        {
            if (hide) return;
            RefreshPixels();
            foreach (VisualItem item in items)
            {
                item.Refresh();
            }
            changed = true;
        }
        public void Close()
        {
            List<WindowContainer> newlist = new List<WindowContainer>();
            foreach (WindowContainer container in GraphicsManager.WindowContainers)
            {
                if (container != this)
                    newlist.Add(container);
            }
            GraphicsManager.WindowContainers = newlist;
        }
    }
    namespace toolbox
    {
        public delegate void OnMouseClick();
        public class Button: VisualItem
        {
            private readonly OnMouseClick click_handler;
            public Button(int x, int y, int weight, int height, string text, OnMouseClick click_handler, Color color = Color.Black)
            : base(x, y, weight, height, "Button", color)
            {
                this.click_handler = click_handler;
                WriteText(text, 1, 1, Color.Black);
            }
            public override void OnMouseClick()
            {
                click_handler();
            }
        }
        public class TopBar: VisualItem
        {
            private readonly WindowContainer parent;
            public bool bypass = false;
            public override void OnMouseClick()
            {
                OnMouseClick(GraphicsManager.cursor.x, GraphicsManager.cursor.y, GraphicsManager.cursor.prevx, GraphicsManager.cursor.prevy);
            }
            public void OnMouseClick(int offsetX, int offsetY, int prevX, int prevY)
            {
                bypass = GraphicsManager.cursor.drag;
                int pointx_old = prevX - BaseX;
                int pointy_old = prevY - BaseY;
                int pointx = offsetX - BaseX;
                int pointy = offsetY - BaseY;

                parent.BaseX += (pointx - pointx_old);
                parent.BaseY += (pointy - pointy_old);
                foreach (VisualItem item in parent.items)
                {
                    item.BaseX += (pointx - pointx_old);
                    item.BaseY += (pointy - pointy_old);
                }
            }
            public TopBar(string title, WindowContainer parent, Color color = Color.Orange)
            : base(0, 0, parent.W, 6, "TopBar", color)
            {
                this.parent = parent;
                WriteText(title, 0, 0, Color.Black);
            }
        }
        public class TaskBar: VisualItem
        {
            readonly protected private WindowContainer parent;
            public List<VisualItem> inners = new List<VisualItem>();
            public TaskBar(int h, WindowContainer parent, Color color = Color.DarkGray)
            : base(0, 0, parent.W, h, "TaskBar", color)
            {
                this.parent = parent;
            }
            public override void OnMouseClick()
            {
                foreach (VisualItem item in inners)
                {
                    if (item.IsHere(GraphicsManager.cursor.x, GraphicsManager.cursor.y)) item.OnMouseClick();
                }
            }
            public void AddItem(VisualItem item)
            {
                foreach(Pixel pixel in item.pixels)
                {
                    DrawPoint(pixel.x, pixel.y, pixel.color);
                }
                item.BaseX += parent.BaseX;
                item.BaseY += parent.BaseY;
                inners.Add(item);
                item.Refresh();
            }
        }
    }
}
