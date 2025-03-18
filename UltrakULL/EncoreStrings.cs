using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    // The same code architecture, like as Act*Strings
    public static class EncoreStrings
    {
        public static string GetLevelChallenge(string currentLevel)
        {
            switch (currentLevel)
            {
                default: { return "There are no Challenges for this level."; }
            }
        }

        public static string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level 0-E": { return "0-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encorePrelude; }
                case "Level 1-E": { return "1-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLimbo; }

                default: 
                    {
                        Logging.Warn("Unknown level name: " + currentLevel);
                        return currentLevel; 
                    }
            }
        }
    }
}
