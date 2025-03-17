using HarmonyLib;
using TMPro;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;


namespace UltrakULL.Harmony_Patches
{
    public class CybergrindFogSettings
    {
        [HarmonyPatch(typeof(CustomFogController))]
        public class CustomFogPatch
        {

            [HarmonyPatch("Start"), HarmonyPostfix]
            public static void AwakePatch(TMP_Text ___dynamicDistanceButtonText, bool ___dynamicDistance)
            {
                ___dynamicDistanceButtonText.SetText(___dynamicDistance ? LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamicDisable : LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamicEnable, true);
            }
            [HarmonyPatch(nameof(CustomFogController.ToggleDynamicFogDistance)),HarmonyPostfix]
            public static void CustomFogPostPatch(TMP_Text ___dynamicDistanceButtonText, bool ___dynamicDistance)
            {
                ___dynamicDistanceButtonText.SetText(___dynamicDistance ? LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamicDisable : LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamicEnable, true);
            }
        }
    }
    public class CybergrindJukeboxCompleteLevelChallengeRequirement
    {
        [HarmonyPatch(typeof(UnlockCondition.HasCompletedLevelChallenge),"description",MethodType.Getter)]
        public class JukeboxPatch
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteLevelRequirementPatch(ref UnlockCondition.HasCompletedLevelChallenge __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicCompleteChallengeRequirement + " " + GetMissionName.GetMissionNumberOnly(__instance.levelIndex);
                }

   
                return false;
            }
        }
    }
    
    public class CybergrindJukeboxHasSeenEnemyRequirement
    {
        [HarmonyPatch(typeof(UnlockCondition.HasSeenEnemy),"description",MethodType.Getter)]
        public class JukeboxPatch
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteLevelRequirementPatch(ref UnlockCondition.HasSeenEnemy __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSeeEnemyRequirement;
                }

                return false;
            }
        }
    }
    
    public class CybergrindJukeboxUnlockLevelRequirement
    {
        [HarmonyPatch(typeof(UnlockCondition.HasReachedLevel),"description",MethodType.Getter)]
        public class JukeboxPatch
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxUnlockLevelRequirementPatch(ref UnlockCondition.HasReachedLevel __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                 __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlockLevelRequirement;
                }
                return false;
            }
        }
    }
    
    public class CybergrindJukeboxCompleteLevelRequirement
    {
        [HarmonyPatch(typeof(UnlockCondition.HasCompletedLevel),"description",MethodType.Getter)]
        public class JukeboxPatch
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteLevelRequirementPatch(ref UnlockCondition.HasCompletedLevel __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicCompleteLevelRequirement + " " +  GetMissionName.GetMissionNumberOnly(__instance.levelIndex);
                }
                return false;
            }
        }
    }
    
    public class CybergrindJukeboxCompleteSecretLevelRequirement
    {
        [HarmonyPatch(typeof(UnlockCondition.HasCompletedSecretLevel),"description",MethodType.Getter)]
        public class JukeboxPatch
        {
            [HarmonyPrefix]
            public static bool CybergrindJukeboxCompleteSecretLevelRequirementPatch(ref UnlockCondition.HasCompletedSecretLevel __instance, ref string __result)
            {
                if(!isUsingEnglish())
                {
                    __result = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicCompleteLevelRequirement + " " + __instance.secretLevelIndex + "-S";
                }
                return false;
            }
        }
    }
}