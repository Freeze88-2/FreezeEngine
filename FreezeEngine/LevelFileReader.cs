using System.IO;

namespace FreezeEngine
{
    public class LevelFileReader
    {
        public string GenerateLevelFile()
        {
            if (!File.Exists("LevelBuilder"))
            {
                // Creates the file for the user, using "FileStream"
                using FileStream fs = File.Create("LevelBuilder");
            }
            else
            {
                using StreamReader sr = new StreamReader("LevelBuilder");

                string next = sr.ReadToEnd();

                return next;
            }
            return null;
        }
    }
}