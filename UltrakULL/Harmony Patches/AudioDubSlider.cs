using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using ULTRAKILL;
using System;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;
using UltrakULL;
using SettingsMenu.Components;
using UnityEngine.SceneManagement;

namespace UltrakULL.Harmony_Patches
{
    public static class MainMenuPatches
    {
        [HarmonyPatch(typeof(SettingsMenu.Components.SettingsPageBuilder))]
        public static class AudioPatch
        {
            [HarmonyPatch("BuildPage"), HarmonyPostfix]
            public static void OptionsSetSelectedPostfix(SettingsPageBuilder __instance)
            {
                if (__instance.name != "Audio" || __instance.transform.parent == null) return;

                Logging.Info("[AudioDubSlider] Processing Audio settings page");

                if (__instance.transform.GetChild(0).transform.name == "Container")
                {
                    try
                    {
                        GameObject AudioPage = __instance.gameObject;
                        AudioPage.SetActive(true);

                        GameObject AudioPageContainer = GetGameObjectChild(AudioPage, "Container");
                        GameObject originalSlider = GetGameObjectChild(AudioPageContainer, "Subtitles");


                        GameObject dubSlider = GameObject.Instantiate(originalSlider, AudioPageContainer.transform);
                        dubSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(300f, -225f);
                        dubSlider.name = "Dialogue Dub";


                        GameObject oldToggleObj = GetGameObjectChild(dubSlider, "Toggle(Clone)");
                        Toggle oldToggle = oldToggleObj.GetComponent<Toggle>();

                        GameObject newToggleObj = GameObject.Instantiate(oldToggleObj, oldToggleObj.transform.parent);
                        newToggleObj.name = "DubToggle";
                        newToggleObj.SetActive(true);

                        Toggle dubToggle = newToggleObj.GetComponent<Toggle>();

                        GameObject oldCheckmark = GetGameObjectChild(GetGameObjectChild(oldToggleObj, "Background"), "Checkmark");
                        GameObject oldFakeCheck = GetGameObjectChild(GetGameObjectChild(oldToggleObj, "Background"), "FakeCheck");
                        oldCheckmark.SetActive(false);
                        oldFakeCheck.SetActive(false);
                        GameObject background = GetGameObjectChild(newToggleObj, "Background");
                        GameObject checkmark = GetGameObjectChild(background, "Checkmark");

                        dubToggle.targetGraphic = background.GetComponent<Image>();
                        dubToggle.graphic = checkmark.GetComponent<Image>();

                        bool isDubbingActive = Convert.ToBoolean(LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value);
                        dubToggle.isOn = isDubbingActive;

                        dubToggle.transition = Selectable.Transition.ColorTint;

                        GameObject.Destroy(GetGameObjectChild(dubSlider, "Reset Button Variant(Clone)"));

                        dubToggle.onValueChanged.AddListener(delegate
                        {
                            bool newValue = dubToggle.isOn;
                            LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value = newValue.ToString();
                            Logging.Info("[AudioDubSlider] Dialogue Dub toggled: " + newValue);
                        });

                        try
                        {
                            GetTextMeshProUGUI(GetGameObjectChild(dubSlider, "Text")).text = LanguageManager.CurrentLanguage.options.audio_dubbing;
                        }
                        catch (Exception e)
                        {
                            Logging.Error("[AudioDubSlider] Failed to set localized text, using fallback. Error: " + e);
                            GetTextMeshProUGUI(GetGameObjectChild(dubSlider, "Text")).text = "DUBBED AUDIO";
                        }
                        Logging.Info("[AudioDubSlider] Successful creation of the AudioDubSlider");
                    }
                    catch (Exception e)
                    {
                        Logging.Error("[AudioDubSlider] Error in SetActive: " + e);
                    }
                }
            }
        }
    }
}