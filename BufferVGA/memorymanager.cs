using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.System
{
    public static class memorymanager
    {
        public unsafe static void SwapByte(byte dest, byte b)
        {
            dest = b;
        }

        public unsafe static void MemSwap(byte* dest, byte* source, int nbytes)
        {
            for (int i = 0; i < nbytes; i++)
                if (*(dest + i) != *(source + i))
                    *(dest + i) = *(source + i);
        }

        public unsafe static void MemAlloc(byte* dest, byte val, uint len)
        {
            byte* temp = (byte*)dest;
            for (; len != 0; len--) *temp++ = val;
        }
    }
}
