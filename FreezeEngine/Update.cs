using System;
using System.Collections.Generic;
using System.Threading;

namespace FreezeEngine
{
    public class Update
    {
        // Creates a variable to store all objects
        private readonly List<IGameObject> gameObjects;

        // Creates the thread for the InputSystem variable
        private readonly Thread keyReader;

        // Creates a variable for the renderer
        private readonly Renderer render;

        // Creates a variable for the physics module
        private readonly PhysicsUpdate physicsUpdate;

        /// <summary>
        /// Constructor of the class GameLoop initializing all the variables
        /// created above
        /// </summary>
        public Update(int x, int y, List<IGameObject> gameObjects)
        {
            physicsUpdate = new PhysicsUpdate(gameObjects);
            // Creates and passes the arguments to create the renderer
            render = new Renderer(x, y, gameObjects);
            // Creates a new Thread and gives it a method of InputSystem
            keyReader = new Thread(Input.ReadKeys);

            // hides the cursor
            Console.CursorVisible = false;
            this.gameObjects = gameObjects;
            Loop();
        }

        /// <summary>
        /// The main loop of the game
        /// </summary>
        private void Loop()
        {
            // Starts the input thread creates
            keyReader.Start();

            // Runs and executes the code while running is true
            while (true)
            {
                // creates a long with the value of the ticks at the moment
                long start = DateTime.Now.Ticks;
                // Processes the input
                Input.ProcessInput();
                // Runs the Update method
                UpdateObjects();
                // Runs the Render method
                render.Render();
                int idle = (int)(start / 100000 + 17 - DateTime.Now.Ticks / 100000);

                if (idle > 0)
                {
                    Thread.Sleep(idle);
                }

                Console.WriteLine((int)(DateTime.Now.Ticks / 100000 - start / 100000));
            }
        }

        private void UpdateObjects()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
                // Updates the physics
                physicsUpdate.UpdatePhysics();
            }
        }
    }
}