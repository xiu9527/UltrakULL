using HarmonyLib;
using System;
using static UltrakULL.CommonFunctions;
using SettingsMenu.Components;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{

    [HarmonyPatch(typeof(SettingsMenu.Components.SettingsMenu))]
    public static class HUDOptionsPatch
    {
        /*[HarmonyPatch("Start"), HarmonyPostfix]
        public static void HUDOptionsStartPostfix(TMP_Dropdown ___iconPackDropdown)
        {
            List<TMP_Dropdown.OptionData> iconsDropdownListText = ___iconPackDropdown.options;
            try
            {
                iconsDropdownListText[0].text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default;
                iconsDropdownListText[1].text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr;
            }
            catch (Exception e)
            { Logging.Warn("Failed to patch icons text in HUD options.");
                Logging.Warn(e.ToString());
            }
        }*/
    }
    [HarmonyPatch(typeof(SettingsMenu.Components.SettingsPageBuilder))]
    public static class OptionsPatch
    {
        [HarmonyPatch("BuildPage"), HarmonyPostfix]
        public static void OptionsSetSelectedPostfix(SettingsPageBuilder __instance) {
            try
            {
                Logging.Debug("Patching Option menu...");
                GameObject optionsObject = __instance.gameObject;
                switch (__instance.name.ToUpper())
                {
                    case "GENERAL":
                        {
                            Logging.Debug("GENERAL");
                            Options.PatchGeneralOptions(optionsObject);
                            break;
                        }
                    case "CONTROLS":
                        {
                            Logging.Debug("CONTROLS");
                            Options.PatchControlOptions(optionsObject);
                            break;
                        }
                    case "GRAPHICS":
                        {
                            Logging.Debug("GRAPHICS");
                            Options.PatchGraphicsOptions(optionsObject);
                            break;
                        }
                    case "AUDIO":
                        {
                            Logging.Debug("AUDIO");
                            Options.PatchAudioOptions(optionsObject);
                            break;
                        }
                    case "ASSIST":
                        {
                            Logging.Debug("ASSIST");
                            Options.PatchAssistOptions(optionsObject);
                            break;
                        }
                    case "HUD":
                        {
                            Logging.Debug("HUD");
                            Options.PatchHUDOptions(optionsObject);
                            break;
                        }
                    default:
                        {
                            Logging.Warn("Unknown Option page name: " + __instance.name);
                            break;
                        }

                }
            }
            catch (Exception e)
            {
                Logging.Error("Something went wrong while patching options.");
                Logging.Error(e.ToString());
            }

        }
    }
}
