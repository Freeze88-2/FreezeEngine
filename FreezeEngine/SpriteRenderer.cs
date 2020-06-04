using System;

namespace FreezeEngine
{
    public class SpriteRenderer : IComponent
    {
        public readonly GameObject self;
        public Pixel Texture { get; set; }
        public Vector3 SpritePos => self.Position;

        public SpriteRenderer(ConsoleColor a, ConsoleColor b, char z, GameObject self)
        {
            Texture = new Pixel(a, b, z, 0);
            this.self = self;
        }

        public void UpdateComponent()
        {
            Texture = new Pixel(Texture.BGcolor, Texture.FGcolor,
                Texture.Texture, self.Position.Z);
        }
    }
}