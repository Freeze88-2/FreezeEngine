using System;
using System.Collections.Concurrent;

namespace FreezeEngine
{
    /// <summary>
    /// Responsible for handlind the user's input during the game's GameLoop.
    /// </summary>
    public static class Input
    {
        // Declare public property of Direction type with a private set, used
        // to indicate to the GameLoop what direction the player selected
        // through the input
        public static ConsoleKey Key { get; private set; }

        // Declare private readonly variable of type
        // BlockingCollection<ConsoleKey> used to save the player's input, used
        // to determine what direction the player chooses
        private static readonly BlockingCollection<ConsoleKey> inputCol
            = new BlockingCollection<ConsoleKey>();

        /// <summary>
        /// Sets Dir and LastDir to Direction.None values and takes everything
        /// saved in the inputCol BlockingCollection, effectively resetting any
        /// and all input given by the player up to that point.
        /// </summary>
        public static void ResetInput()
        {
            // Assign Direction.None value to Dir
            Key = ConsoleKey.NoName;
            // for cycle that takes all ConsoleKeys stored in inputCol
            for (int i = 0; i < inputCol.Count; i++)
            {
                inputCol.Take();
            }
        }

        /// <summary>
        /// Processes the ConsoleKeys given to the inputCol BlockingCollection
        /// and assigns a direction to Dir based on which key was pressed,
        /// assigning the LastDir to Dir if not ConsoleKey can be taken from
        /// inputCol.
        /// </summary>
        public static void ProcessInput()
        {
            // if statement that checks if it is possible to take an element
            // from inputCol
            if (inputCol.TryTake(out ConsoleKey key))
            {
                // Swithes the direction according to WASD or arrow keys
                Key = key;
            }
            // else statement that assigns LastDir's value to Dir if no
            // element can be taken from inputCol
            else
            {
                Key = ConsoleKey.NoName;
            }
        }

        /// <summary>
        /// Public method to be ran in it's own thread, constantly accepting
        /// input from the player and adding the ConsoleKey to the inputCol
        /// BlockingCollection, to be processed by the ProcessInput method.
        /// </summary>
        public static void ReadKeys()
        {
            // Declare key variable of ConsoleKey type
            ConsoleKey key;

            // while loop that runs as long as the IsRunning property is true
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    bool alreadyContains = false;
                    // Assigns a ConsoleKey value, returned from
                    // Console.Readkey().Key to variable key
                    key = Console.ReadKey(true).Key;

                    // Adds key read to the inputCol BlockingCollection
                    for (int i = 0; i < inputCol.Count; i++)
                    {
                        if (inputCol.ToArray()[i] == key)
                        {
                            alreadyContains = true;
                            break;
                        }
                    }
                    if (!alreadyContains)
                    {
                        inputCol.Add(key);
                    }
                }
            }
        }
    }
}