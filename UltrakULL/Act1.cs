using System;
using TMPro;
using UltrakULL.audio;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1
    {
        private static void PatchHellmap(ref GameObject canvasObj)
        {
            try
            {
                GameObject hellMapObject = GetGameObjectChild(GetGameObjectChild(canvasObj, "Hellmap"),"Hellmap Act 1");

                TextMeshProUGUI hellmapLimbo = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text"));
                hellmapLimbo.text = LanguageManager.CurrentLanguage.misc.hellmap_limbo;

                TextMeshProUGUI hellmapLust = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text (1)"));
                hellmapLust.text = LanguageManager.CurrentLanguage.misc.hellmap_lust;

                TextMeshProUGUI hellmapGluttony = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text (2)"));
                hellmapGluttony.text = LanguageManager.CurrentLanguage.misc.hellmap_gluttony;
            }
            catch(Exception e)
            {
                Logging.Warn("Failed to patch Act 1 hellmap.");
                Logging.Warn(e.ToString());
            }
        }
       
        public static void PatchAct1(ref GameObject canvasObj)
        {
            string currentLevel = GetCurrentSceneName();
            string levelName = Act1Strings.GetLevelName();
            string levelChallenge = Act1Strings.GetLevelChallenge(currentLevel);

            PatchHellmap(ref canvasObj);
            PatchResultsScreen(levelName, levelChallenge);

            //"Crane control" panel in 2-1
            if (currentLevel.Contains("2-1"))
            {
                GameObject outdoorsArenas = GetInactiveRootObject("3-4 - Outdoors Arenas");
                GameObject stuff = GetGameObjectChild(outdoorsArenas, "3-4 Stuff");
                Transform stuffTransform = stuff.transform;
                GameObject crane = stuffTransform.Find("Crane (Moveable)").gameObject;
                GameObject secretScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild( crane, "Cube (19)"), "Cube"), "UsableScreen New"), "InteractiveScreen"), "Canvas"), "Background");

                TextMeshProUGUI craneControl = GetTextMeshProUGUI(GetGameObjectChild(secretScreen, "Text (TMP) (1)"));
                craneControl.text = LanguageManager.CurrentLanguage.act1.act1_lustFirst_crane;
            }
        }
    }
}
