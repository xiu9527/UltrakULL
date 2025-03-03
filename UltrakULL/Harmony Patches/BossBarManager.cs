using HarmonyLib;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the CreateBossBar method from the BossBarManager class. This is needed to swap in the translated boss names on their health bars.
    [HarmonyPatch(typeof(BossBarManager), "CreateBossBar")]
    public static class LocalizeBossBar
    {
        [HarmonyPrefix]
        public static bool CreateBossBar_MyPatch(ref BossHealthBar bossBar)
        {
            if(!isUsingEnglish())
            {

                // Change "BossStrings.GetBossName(bossBar.source.FullName)" to "BossStrings.GetBossName(bossBar.bossName)" because RADIANT enemies have default source names (like RADIANT SWORDMACHINE = SWORDMACHINE) // Maybe this not work
                string translatedName = BossStrings.GetBossName(bossBar.bossName);
                if(translatedName != null)
                {
                    bossBar.bossName = BossStrings.GetBossName(bossBar.bossName);
                }
                else
                {
                    bossBar.bossName = "MISSING BOSS STRING: " + bossBar.bossName;
                }
            }
            return true;
        }
    }
}
