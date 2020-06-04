using FreezeEngine;
using System;

namespace Game
{
    public class Barrier : GameObject
    {
        private bool what = false;
        private readonly SpriteRenderer sprite;

        public Barrier(int x, int y)
        {
            AddComponent<SpriteRenderer>(ConsoleColor.Black, ConsoleColor.White, '+', gameObject);
            AddComponent<PhysicsObject>(1, 1, gameObject);

            sprite = GetComponent<SpriteRenderer>();
            Position = new Vector3(x, y, 0);
        }

        public override void Update()
        {
            what = !what;
            sprite.Texture = new Pixel(ConsoleColor.Black, ConsoleColor.White, what ? 'x' : '+', Position.Z);
        }
    }
}