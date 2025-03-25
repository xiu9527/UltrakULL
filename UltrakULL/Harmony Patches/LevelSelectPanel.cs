using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

using static UltrakULL.CommonFunctions;
using System.Diagnostics.Eventing.Reader;

namespace UltrakULL.Harmony_Patches
{
	//@Override
	//Overrides checkScore function from the vanilla game. This translates level names, as well as if challenges have been completed or not. POSTFIX.
	[HarmonyPatch(typeof(LevelSelectPanel), "CheckScore")]
	public static class LocalizeGameProgressChallenges
	{
		[HarmonyPostfix]
		public static void CheckScore_MyPatchPostFix(LevelSelectPanel __instance)
		{
			if(isUsingEnglish())
			{
				return;
			}
			int num = __instance.levelNumber;
			RankData rank = GameProgressSaver.GetRank(num, false);
			try
			{
                //Prime Sanctums and Encore levels actually have it's own id but for some reason these levels use same id as first one. 
                //Bandaid fix for P-2 and P-3 for now since they share the same level id as P-1 for some reason. Shall need to change/remove when they release.
                TextMeshProUGUI nameText = __instance.transform.Find("Name").GetComponent<TextMeshProUGUI>();
				if (num == 666)
				{
					//Don't worry about P-1, it's taken care of LevelNames.cs
					if (__instance.name.Contains("P-2") || nameText.text.Contains("P-2"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ }
						else
						{ nameText.text = "P-2:" + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond; }
					}
					else if (__instance.name.Contains("P-3") || nameText.text.Contains("P-3"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ }
						else
						{ nameText.text = "P-3: ???"; }
					}
				}
				//All of the Encore levels share the same level id in this menu. 
				if (num == 100)
				{
					if (__instance.name.Contains("0-E") || nameText.text.Contains("0-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٠-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encorePrelude; }
						else
						{ nameText.text = "0-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encorePrelude; }
					}
					else if (__instance.name.Contains("1-E") || nameText.text.Contains("1-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "١-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLimbo; }
						else
						{ nameText.text = "1-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLimbo; }
					}
					else if (__instance.name.Contains("2-E") || nameText.text.Contains("2-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٢-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLust; }
						else
						{ nameText.text = "2-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreLust; }
					}
					else if (__instance.name.Contains("3-E") || nameText.text.Contains("3-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٣-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreGluttony; }
						else
						{ nameText.text = "3-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreGluttony; }
					}
					else if (__instance.name.Contains("4-E") || nameText.text.Contains("4-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٤-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreGreed; }
						else
						{ nameText.text = "4-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreGreed; }
					}
					else if (__instance.name.Contains("5-E") || nameText.text.Contains("5-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٥-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreWrath; }
						else
						{ nameText.text = "5-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreWrath; }
					}
					else if (__instance.name.Contains("6-E") || nameText.text.Contains("6-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٦-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreHeresy; }
						else
						{ nameText.text = "6-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreHeresy; }
					}
					else if (__instance.name.Contains("7-E") || nameText.text.Contains("7-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٧-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreViolence; }
						else
						{ nameText.text = "7-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreViolence; }
					}
					else if (__instance.name.Contains("8-E") || nameText.text.Contains("8-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٨-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreFraud; }
						else
						{ nameText.text = "8-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreFraud; }
					}
					else if (__instance.name.Contains("9-E") || nameText.text.Contains("9-E"))
					{
						if (LanguageManager.UsingHinduNumbers)
						{ nameText.text = "٩-E" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreTreachery; }
						else
						{ nameText.text = "9-E:" + LanguageManager.CurrentLanguage.levelNames.levelName_encoreTreachery; }
					}
				}
                //RTL support
                string levelName = LevelNames.GetLevelName(num, __instance.name);
				if (LanguageManager.IsRightToLeft)
				{
					string lvlNumber = "";
					char[] lnum = levelName.Substring(0, 3).ToCharArray();

					lvlNumber += lnum[2];
					lvlNumber += lnum[1];
					lvlNumber += lnum[0];

					string lvlTitle = levelName.Substring(5);

					levelName = $"{lvlTitle} :{lvlNumber}";
				}
				nameText.text = levelName; //Level Name
				if (rank.levelNumber == __instance.levelNumber || ((__instance.levelNumber == 666 || __instance.levelNumber == 100) && rank.levelNumber == __instance.levelNumber + __instance.levelNumberInLayer - 1))
				{
					if (__instance.challengeIcon)
					{
						if (LanguageManager.CurrentLanguage.frontend.level_challengeCompleted == null)
							return;
						if (rank.challenge)
						{
							__instance.challengeIcon.fillCenter = true;
							TextMeshProUGUI componentInChildren2 = __instance.challengeIcon.GetComponentInChildren<TextMeshProUGUI>();
							componentInChildren2.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challengeCompleted.ToList()); //Challenge completed
						}
						else
						{
							__instance.challengeIcon.fillCenter = false;
							TextMeshProUGUI componentInChildren3 = __instance.challengeIcon.GetComponentInChildren<TextMeshProUGUI>();
							componentInChildren3.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challenge.ToList()); //Challenge not completed
							componentInChildren3.color = Color.white;
						}
					}
				}
				else
				{

					TextMeshProUGUI componentInChildren3 = __instance.challengeIcon.GetComponentInChildren<TextMeshProUGUI>();
					componentInChildren3.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challenge.ToList()); //Challenge not completed
					componentInChildren3.color = Color.white;
				}
			}
			catch (Exception e)
			{
				Logging.Error("Exception occured :  " + num);
                Logging.Error(e.ToString());
			}
		}
	}
}
