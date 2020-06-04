using FreezeEngine;
using System;

namespace Game
{
    public class Player : GameObject
    {
        public Player(int x, int y)
        {
            Tag = "player";

            AddComponent<SpriteRenderer>(ConsoleColor.Red, ConsoleColor.White, '"', gameObject);
            AddComponent<PhysicsObject>(1, 1, gameObject);
            Position = new Vector3(x, y, 10);
        }

        public override void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Input.Key == ConsoleKey.W)
            {
                Position = new Vector3(Position.X, Position.Y - 1, Position.Z);
            }
            else if (Input.Key == ConsoleKey.S)
            {
                Position = new Vector3(Position.X, Position.Y + 1, Position.Z);
            }
            if (Input.Key == ConsoleKey.A)
            {
                Position = new Vector3(Position.X - 1, Position.Y, Position.Z);
            }
            else if (Input.Key == ConsoleKey.D)
            {
                Position = new Vector3(Position.X + 1, Position.Y, Position.Z);
            }
        }
    }
}