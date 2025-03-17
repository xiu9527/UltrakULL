using System;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;


namespace UltrakULL
{
    public static class Encore
    {
        public static void PatchEncore(ref GameObject canvasObj)
        {
            string currentLevel = GetCurrentSceneName();
            string levelName = GetLevelName();
            PatchResultsScreen(levelName, "");
            if (currentLevel.Contains("0-E"))
            {
                try
                {
                    GameObject heatResistanceWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "HurtScreen"), "Heat Resistance");

                    TextMeshProUGUI heatResistanceWarn = GetTextMeshProUGUI(GetGameObjectChild(heatResistanceWindow, "Warning"));
                    heatResistanceWarn.text = LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceWarn;

                    TextMeshProUGUI heatResistanceText = GetTextMeshProUGUI(GetGameObjectChild(heatResistanceWindow, "Flavor Text"));
                    heatResistanceText.text = LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceText;

                    TextMeshProUGUI heatResistanceTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(heatResistanceWindow, "Meter"), "Label"));
                    heatResistanceTitle.text = LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceTitle;

                    GameObject heatResistanceFixedWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "HurtScreen"), "Heat Fixed");

                    TextMeshProUGUI heatResistanceFixedWarn = GetTextMeshProUGUI(GetGameObjectChild(heatResistanceFixedWindow, "Warning"));
                    heatResistanceFixedWarn.text = LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceRepaired;

                    TextMeshProUGUI heatResistanceFixedText = GetTextMeshProUGUI(GetGameObjectChild(heatResistanceFixedWindow, "Flavor Text"));
                    heatResistanceFixedText.text = LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceRepairedText;

                    TextMeshProUGUI heatResistanceFixedTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(heatResistanceFixedWindow, "Meter"), "Label"));
                    heatResistanceFixedTitle.text = LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceTitle;
                }
                catch (Exception e)
                {
                    Debug.LogError("Error patching Encore: " + e.Message);

                }
            }
        }
        private static string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level 0-E": { return "0-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encorePrelude; }
                case "Level 1-E": { return "1-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLimbo; }
                case "Level 2-E": { return "2-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLust; }
                case "Level 3-E": { return "3-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreGluttony; }
                case "Level 4-E": { return "4-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreGreed; }
                case "Level 5-E": { return "5-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreWrath; }
                case "Level 6-E": { return "6-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreHeresy; }
                case "Level 7-E": { return "7-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreViolence; }
                case "Level 8-E": { return "8-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreFraud; }
                case "Level 9-E": { return "9-E - " + LanguageManager.CurrentLanguage.levelNames.levelName_encoreTreachery; }

                default: { return "Unknown level name"; }
            }

        }
    }
}

