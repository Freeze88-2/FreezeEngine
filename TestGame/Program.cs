using FreezeEngine;

namespace Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            LevelBuilder level = new LevelBuilder();

            _ = new Update(19, 19, level.AssembleLevelAssets());
        }
    }
}