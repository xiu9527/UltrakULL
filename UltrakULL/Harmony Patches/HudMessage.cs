﻿using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(CutsceneSkipText),"Show")]
    public static class CutsceneSkipTextPatch
    {
        [HarmonyPostfix]
        public static void CutsceneSkipText_Patch(CutsceneSkipText __instance, ref TMP_Text ___txt)
        {
            Console.WriteLine(___txt.text);
            //Need to disable the TextOverride component. Slightly hacky but we can't access TextOverride directly.
            Component[] test = __instance.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[3];
            bhvr.enabled = false;
            ___txt.text = LanguageManager.CurrentLanguage.misc.pressToSkip;
        }
    }

    [HarmonyPatch(typeof(HudMessageReceiver),"SendHudMessage")]
    public static class SendHudMessagePatch
    {
        [HarmonyPrefix]
        public static bool SendHudMessage_Prefix(ref string newmessage,ref string newinput,ref string newmessage2, int delay = 0, bool silent = false)
        {
            if (!isUsingEnglish())
            {
                if ((newmessage != null) && (newmessage2 != null) && (newinput != null))
                {
                    newmessage = StringsParent.GetMessage(newmessage, newmessage2, newinput);
                    newmessage2 = "";
                    newinput = "";
                }
                else
                {
                    newmessage = HUDMessages.GetHUDToolTip(newmessage);
                }
            }
            return true;
        }
    }
}
