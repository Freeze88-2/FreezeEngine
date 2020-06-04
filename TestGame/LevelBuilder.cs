using FreezeEngine;
using System.Collections.Generic;

namespace Game
{
    public class LevelBuilder
    {
        public int Y { get; private set; }
        public int X { get; private set; }
        private readonly List<IGameObject> gameObjects;
        private readonly LevelFileReader builder;

        public LevelBuilder()
        {
            X = 0;
            Y = 0;

            gameObjects = new List<IGameObject>();
            builder = new LevelFileReader();
        }

        public List<IGameObject> AssembleLevelAssets()
        {
            string next = builder.GenerateLevelFile();

            for (int i = 0; i < next?.Length; i++)
            {
                switch (next[i])
                {
                    case 'P':
                        gameObjects.Add(new Player(X, Y));
                        X++;
                        break;

                    case 'O':
                        gameObjects.Add(new Barrier(X, Y));
                        X++;
                        break;

                    case '.':
                        X++;
                        break;

                    case '|':
                        Y++;
                        X = 0;
                        break;
                }
            }
            Y++;
            return gameObjects;
        }
    }
}