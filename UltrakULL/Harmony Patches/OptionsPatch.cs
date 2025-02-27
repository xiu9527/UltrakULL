using HarmonyLib;
using System.Collections.Generic;
using System;
using TMPro;
using UltrakULL.json;
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
    [HarmonyPatch(typeof(SettingsMenu.Components.SettingsMenu))]
    public static class OptionsPatch
    {
        [HarmonyPatch("SetActivePage"), HarmonyPostfix]
        public static void OptionsSetSelectedPostfix(GameObject targetPage) {
            try
            {
                switch (targetPage.name.ToUpper())
                {
                    case "GENERAL":
                        {
                            Logging.Info("General");
                            break;
                        }
                    case "CONTROLS":
                        {
                            Logging.Info("CONTROLS");
                            break;
                        }
                    case "GRAPHICS":
                        {
                            Logging.Info("GRAPHICS");
                            break;
                        }
                    case "AUDIO":
                        {
                            Logging.Info("AUDIO");
                            break;
                        }
                    case "ASSIST":
                        {
                            Logging.Info("ASSIST");
                            break;
                        }
                    case "HUD":
                        {
                            Logging.Info("HUD");
                            break;
                        }
                    case "COLORBLINDNESS OPTIONS":
                        {
                            Logging.Info("COLORBLIND");
                            break;
                        }
                    default:
                        {
                            Logging.Warn("Unknown Option page name: " +  targetPage.name);
                            break;
                        }

                }
                /*try { this.PatchGeneralOptions(generalOptions); } catch (Exception e) { Logging.Error("Failed to patch general options."); Logging.Error(e.ToString()); }
                try { this.PatchControlOptions(controlOptions); } catch (Exception e) { Logging.Error("Failed to patch control options."); Logging.Error(e.ToString()); }
                try { this.PatchGraphicsOptions(graphicsOptions); } catch (Exception e) { Logging.Error("Failed to patch graphics options."); Logging.Error(e.ToString()); }
                try { this.PatchAudioOptions(audioOptions); } catch (Exception e) { Logging.Error("Failed to patch audio options."); Logging.Error(e.ToString()); }
                try { this.PatchSettingsMenu(hudOptions); } catch (Exception e) { Logging.Error("Failed to patch HUD options."); Logging.Error(e.ToString()); }
                try { this.PatchAssistOptions(assistOptions); } catch (Exception e) { Logging.Error("Failed to patch assist options."); Logging.Error(e.ToString()); }
                try { this.PatchColorsOptions(colorsOptions); } catch (Exception e) { Logging.Error("Failed to patch colors options."); Logging.Error(e.ToString()); }
                try { this.PatchSavesOptions(savesOptions); } catch (Exception e) { Logging.Error("Failed to patch save options."); Logging.Error(e.ToString()); }
                try { this.PatchRumbleOptions(rumbleOptions); } catch (Exception e) { Logging.Error("Failed to patch rumble options."); Logging.Error(e.ToString()); }
                try { this.PatchAdvancedOptions(advancedOptions); } catch (Exception e) { Logging.Error("Failed to patch advanced options."); Logging.Error(e.ToString()); }
            */
            }
            catch (Exception e)
            {
                Logging.Error("Something went wrong while patching options.");
                Logging.Error(e.ToString());
            }

        }
    }
}
