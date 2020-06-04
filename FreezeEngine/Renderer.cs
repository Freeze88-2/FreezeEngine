using System;
using System.Collections.Generic;
using System.Text;

namespace FreezeEngine
{
    public class Renderer
    {
        private readonly DoubleBuffer<Pixel> Db;
        private readonly List<SpriteRenderer> components;

        public Renderer(int x, int y, List<IGameObject> gameObjects)
        {
            components = new List<SpriteRenderer>();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int b = 0; b < gameObjects[i].Components.Count; b++)
                {
                    if (gameObjects[i].Components[b] is SpriteRenderer)
                    {
                        components.Add(gameObjects[i].Components[b] as SpriteRenderer);
                    }
                }
            }
            // Creates a variable of DoubleBuffer for when rendering
            Db = new DoubleBuffer<Pixel>(x, y);
        }

        private readonly StringBuilder s = new StringBuilder();

        public void Render()
        {
            FillBuffer();
            // Swap the current frame for the next frame of the DoubleBuffer
            Db.Swap();
            // Update objects displayed
            // Loop throught the doublebuffers YDim, starting at 0
            for (int y = 0; y < Db.YDim; y++)
            {
                // Loop throught the doublebuffers XDim, starting at 0
                for (int x = 0; x < Db.XDim; x++)
                {
                    if (Console.BackgroundColor != Db[x, y].BGcolor)
                    {
                        Console.BackgroundColor = Db[x, y].BGcolor;
                    }

                    if (Console.BackgroundColor != Db[x, y].FGcolor)
                    {
                        Console.ForegroundColor = Db[x, y].FGcolor;
                    }

                    Console.Write(Db[x, y].Texture);
                }
                Console.Write('\n');
            }

            // Sets CursorPosition to 0 in x and 0 in y
            Console.SetCursorPosition(0, 0);
            // Clears the doublebuffer
            Db.Clear();
        }

        private void FillBuffer()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].UpdateComponent();
            }

            components.Sort(delegate (SpriteRenderer rd,
                SpriteRenderer rn)
            {
                if (rd.Texture.ZDepth > rn.Texture.ZDepth)
                {
                    return 1;
                }
                else if (rd.Texture.ZDepth < rn.Texture.ZDepth)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });

            for (int i = 0; i < components.Count; i++)
            {
                Pixel current = components[i].Texture;

                Db[components[i].SpritePos.X, components[i].SpritePos.Y] = current;
            }
        }
    }
}