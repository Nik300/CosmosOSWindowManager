using AerOS.System.Graphics;
using Cosmos.Core.IOGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.Core.IOGroup.ExtPack;
namespace Cosmos.Core.IOGroup.ExtPack
{
    public static  class FontDrawer
    {
        #region textmaker

        private static void DrawTextChar(int x, int y, byte[] Data, Color color, int pos)
        {
            int c = 0;
            for (int p = y; p < y + 9; p++)
            {
                for (int i = x; i < x + 5; i++)
                {
                    if (Data[c] == 1)
                    {
                        GraphicsManager.WindowContainers[pos].DrawItemPixel(i, p, color);
                    }

                    c = c + 1;
                }
            }
        }
        private static void DrawTextChar(int x, int y, byte[] Data, Color color, WindowContainer windowContainer)
        {
            int c = 0;
            for (int p = y; p < y + 9; p++)
            {
                for (int i = x; i < x + 5; i++)
                {
                    if (Data[c] == 1)
                    {
                        windowContainer.DrawItemPixel(i, p, color);
                    }

                    c = c + 1;
                }
            }
        }
        private static void DrawTextChar(int x, int y, byte[] Data, Color color, VisualItem item)
        {
            int c = 0;
            for (int p = y; p < y + 9; p++)
            {
                for (int i = x; i < x + 5; i++)
                {
                    if (Data[c] == 1)
                    {
                        item.DrawPoint(i, p, color);
                    }

                    c = c + 1;
                }
            }
        }
        private static void DrawArray(int x, int y, byte[] Data, Color color, int w, int h)
        {
            int c = 0;
            for (int p = y; p < y + w; p++)
            {
                for (int i = x; i < x + h; i++)
                {
                    if (Data[c] == 1)
                    {
                        GraphicsManager.canvas.PutPixel(i, p, color);
                    }

                    c = c + 1;
                }
            }
        }
        public static void WriteText(String Text, int Textx, int Texty, Color Color, int pos)
        {
            foreach (char a in Text)
            {
                if (a == 'A')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapA, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'a')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlA, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'B')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapB, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'b')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlB, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'C')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapC, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'c')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlC, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'D')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapD, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'd')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlD, Color, pos);
                    Textx = Textx + 6;
                }

                else if (a == 'E')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapE, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'e')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlE, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'F')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapF, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'f')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlF, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'G')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapG, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'g')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlG, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'H')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapH, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'h')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlH, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'I')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapI, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'i')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlI, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'J')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapJ, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'j')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlJ, Color, pos);
                    Textx = Textx + 6;
                }

                else if (a == 'K')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapK, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'k')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlK, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'L')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapL, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'l')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlL, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'M')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapM, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'm')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlM, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'N')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapN, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'n')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlN, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'O')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapO, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'o')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlO, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'P')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapP, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'p')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlP, Color, pos);
                    Textx = Textx + 6;
                }

                else if (a == 'Q')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapQ, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'q')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlQ, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'R')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapR, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'r')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlR, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'S')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapS, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 's')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlS, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'T')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapT, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 't')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlT, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'U')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapU, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'u')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlU, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'V')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapV, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'v')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlV, Color, pos);
                    Textx = Textx + 6;
                }

                else if (a == 'W')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapW, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'w')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlW, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'X')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapX, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'x')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlX, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'Y')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapY, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'y')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlY, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'Z')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapZ, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == 'z')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlZ, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '.')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Dote, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '!')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Utro, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == ' ')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Null, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '0')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Zero, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '1')
                {
                    DrawTextChar(Textx, Texty, Font8x8.One, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '2')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Two, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '3')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Three, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '4')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Four, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '5')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Five, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '6')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Six, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '7')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Seven, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '8')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Eight, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == '9')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Nine, Color, pos);
                    Textx = Textx + 6;
                }
                else if (a == ':')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Colon, Color, pos);
                    Textx = Textx + 6;
                }
            }
        }
        public static void WriteText(String Text, int Textx, int Texty, Color Color, WindowContainer windowContainer)
        {
            foreach (char a in Text)
            {
                if (a == 'A')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapA, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'a')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlA, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'B')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapB, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'b')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlB, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'C')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapC, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'c')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlC, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'D')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapD, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'd')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlD, Color, windowContainer);
                    Textx = Textx + 6;
                }

                else if (a == 'E')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapE, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'e')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlE, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'F')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapF, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'f')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlF, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'G')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapG, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'g')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlG, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'H')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapH, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'h')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlH, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'I')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapI, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'i')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlI, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'J')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapJ, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'j')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlJ, Color, windowContainer);
                    Textx = Textx + 6;
                }

                else if (a == 'K')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapK, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'k')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlK, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'L')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapL, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'l')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlL, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'M')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapM, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'm')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlM, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'N')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapN, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'n')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlN, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'O')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapO, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'o')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlO, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'P')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapP, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'p')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlP, Color, windowContainer);
                    Textx = Textx + 6;
                }

                else if (a == 'Q')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapQ, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'q')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlQ, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'R')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapR, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'r')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlR, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'S')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapS, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 's')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlS, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'T')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapT, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 't')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlT, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'U')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapU, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'u')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlU, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'V')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapV, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'v')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlV, Color, windowContainer);
                    Textx = Textx + 6;
                }

                else if (a == 'W')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapW, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'w')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlW, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'X')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapX, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'x')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlX, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'Y')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapY, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'y')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlY, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'Z')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapZ, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == 'z')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlZ, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '.')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Dote, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '!')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Utro, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == ' ')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Null, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '0')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Zero, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '1')
                {
                    DrawTextChar(Textx, Texty, Font8x8.One, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '2')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Two, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '3')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Three, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '4')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Four, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '5')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Five, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '6')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Six, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '7')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Seven, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '8')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Eight, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == '9')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Nine, Color, windowContainer);
                    Textx = Textx + 6;
                }
                else if (a == ':')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Colon, Color, windowContainer);
                    Textx = Textx + 6;
                }
            }
        }
        public static void WriteText(String Text, int Textx, int Texty, Color Color, VisualItem item)
        {
            foreach (char a in Text)
            {
                if (a == 'A')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapA, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'a')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlA, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'B')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapB, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'b')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlB, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'C')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapC, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'c')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlC, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'D')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapD, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'd')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlD, Color, item);
                    Textx = Textx + 6;
                }

                else if (a == 'E')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapE, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'e')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlE, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'F')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapF, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'f')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlF, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'G')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapG, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'g')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlG, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'H')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapH, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'h')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlH, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'I')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapI, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'i')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlI, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'J')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapJ, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'j')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlJ, Color, item);
                    Textx = Textx + 6;
                }

                else if (a == 'K')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapK, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'k')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlK, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'L')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapL, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'l')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlL, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'M')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapM, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'm')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlM, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'N')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapN, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'n')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlN, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'O')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapO, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'o')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlO, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'P')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapP, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'p')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlP, Color, item);
                    Textx = Textx + 6;
                }

                else if (a == 'Q')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapQ, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'q')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlQ, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'R')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapR, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'r')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlR, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'S')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapS, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 's')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlS, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'T')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapT, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 't')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlT, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'U')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapU, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'u')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlU, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'V')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapV, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'v')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlV, Color, item);
                    Textx = Textx + 6;
                }

                else if (a == 'W')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapW, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'w')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlW, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'X')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapX, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'x')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlX, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'Y')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapY, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'y')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlY, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'Z')
                {
                    DrawTextChar(Textx, Texty, Font8x8.CapZ, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == 'z')
                {
                    DrawTextChar(Textx, Texty, Font8x8.SmlZ, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '.')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Dote, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '!')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Utro, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == ' ')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Null, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '0')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Zero, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '1')
                {
                    DrawTextChar(Textx, Texty, Font8x8.One, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '2')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Two, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '3')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Three, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '4')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Four, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '5')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Five, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '6')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Six, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '7')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Seven, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '8')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Eight, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == '9')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Nine, Color, item);
                    Textx = Textx + 6;
                }
                else if (a == ':')
                {
                    DrawTextChar(Textx, Texty, Font8x8.Colon, Color, item);
                    Textx = Textx + 6;
                }
            }
        }
        #endregion

    }
}
