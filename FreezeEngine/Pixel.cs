using System;

namespace FreezeEngine
{
    public struct Pixel
    {
        public ConsoleColor BGcolor { get; }
        public ConsoleColor FGcolor { get; }
        public char Texture { get; set; }
        public int? ZDepth { get; }

        public Pixel(ConsoleColor color, ConsoleColor color2,
            char texture, int depth)
        {
            BGcolor = color;
            FGcolor = color2;
            Texture = texture;
            ZDepth = depth;
        }
    }
}