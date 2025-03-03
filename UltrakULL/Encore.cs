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
    }
}

