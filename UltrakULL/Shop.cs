﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Shop
    {
        private static void PatchShopFrontEnd(ref GameObject shopObject)
        {
            try
            {
                GameObject shopPanel = GetGameObjectChild(GetGameObjectChild(shopObject, "Background"), "Main Panel");

                //Tip panel
                GameObject tipPanel = GetGameObjectChild(shopPanel, "Tip of the Day");
                TextMeshProUGUI tipTitle = GetTextMeshProUGUI(GetGameObjectChild(tipPanel, "Title"));
                tipTitle.text = LanguageManager.CurrentLanguage.shop.shop_tipofthedayTitle;

                TextMeshProUGUI tipDescription = GetTextMeshProUGUI((GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(tipPanel, "Panel"), "Text Inset"), "TipText")));
                string tipDescriptionText = tipDescription.text;
                //V-Rank Check, do nothing if "V-Rank" is in them, otherwise replace by the correct text
                if (tipDescriptionText.Contains("V-Rank")) { tipDescription.text = tipDescriptionText; }
                else { tipDescription.text = StringsParent.GetLevelTip(tipDescriptionText); }

                //--MENU--
                // removed and replaced with SmileOS 2.0 in patch 16
                //TextMeshProUGUI menuText = GetTextMeshProUGUI(GetGameObjectChild(shopObject, "Menu Title"));
                //menuText.text = "--" + LanguageManager.CurrentLanguage.shop.shop_menu + "--";

                //Weapons button
                GameObject mainButtons = GetGameObjectChild(GetGameObjectChild(shopPanel, "Main Menu"), "Buttons");

                TextMeshProUGUI weaponsButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "WeaponsButton"), "Text"));
                weaponsButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_weapons;

                //Enemies button
                TextMeshProUGUI enemiesButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "EnemiesButton"), "Text"));
                enemiesButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

                //CG buttons
                TextMeshProUGUI cgButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "CyberGrindButton"), "Text"));
                cgButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrind;

                TextMeshProUGUI cgReturnButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "ReturnButton"), "Text"));
                cgReturnButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_returnToMission;

                //Sandbox button
                TextMeshProUGUI sandboxButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "SandboxButton"), "Text"));
                sandboxButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;
                
                //Enemies title
                TextMeshProUGUI enemiesTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Enemies"), "Enemies Panel"),"Title"));
                enemiesTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;
                

                //Sandbox enter description
                GameObject sandboxEnter = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Sandbox"), "Sandbox Panel"),"Panel");

                TextMeshProUGUI sandboxTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Sandbox"), "Sandbox Panel"),"Title"));
                sandboxTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

                TextMeshProUGUI sandboxEnterDescription = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxEnter,"Text Inset"), "Text"));

                sandboxEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_sandboxDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_sandboxDescription2;

                TextMeshProUGUI sandboxEnterButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxEnter, "Enter Button"), "Text"));
                sandboxEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_sandboxEnter;

                //CG enter description
                GameObject cgEnter = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "The Cyber Grind"), "Cyber Grind Panel"), "Panel");

                TextMeshProUGUI cgEnterTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "The Cyber Grind"), "Cyber Grind Panel"), "Title"));
                cgEnterTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnterTitle;

                TextMeshProUGUI cgEnterDescription = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgEnter, "Text Inset"), "Text"));

                cgEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription3;

                TextMeshProUGUI cgEnterButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgEnter, "Enter Button"), "Text"));
                cgEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnter;

                //CG exit description
                GameObject cgExit = GetGameObjectChild(GetGameObjectChild(shopPanel, "Return from Cyber Grind"), "Return from Cyber Grind Panel");

                TextMeshProUGUI cgExitTitle = GetTextMeshProUGUI(GetGameObjectChild(cgExit, "Title"));
                cgExitTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExitTitle;

                TextMeshProUGUI cgExitButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgExit, "Panel"), "Exit Button"), "Text"));
                if (GetCurrentSceneName() == "uk_construct")
                {
                    cgExitButton.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;
                }
                else
                {
                    cgExitButton.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExit;
                }

                //Enemies back button 
                TextMeshProUGUI enemiesBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Enemies"), "Back Button"), "Text"));
                enemiesBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //EnemyInfo back button
                TextMeshProUGUI enemyInfoBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Enemies"), "Info Screen"), "Main Window"), "Back Button"), "Text"));
                enemyInfoBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Sandbox back button
                TextMeshProUGUI sandboxBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Sandbox"), "Back Button"), "Text"));
                sandboxBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Enter CG back text
                TextMeshProUGUI cgEnterBackButtonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "The Cyber Grind"), "Back Button"), "Text"));
                cgEnterBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Exit CG back text
                TextMeshProUGUI cgExitBackButtonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopPanel, "Return from Cyber Grind"), "Back Button"), "Text"));
                cgExitBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;
            }
            catch (Exception e)
            {
                Logging.Error("An error occured while translating shop texts.");
                Logging.Error(e.ToString());
            }

        }
        

        private static void PatchWeapons(ref GameObject shopObject)
        {
            try
            {
                GameObject shopPanel = GetGameObjectChild(GetGameObjectChild(shopObject, "Background"), "Main Panel");

                //weapons
                GameObject shopWeaponsObject  = GetGameObjectChild(shopPanel, "Weapons");
                
                GameObject shopWeaponsButtonsObject = GetGameObjectChild(GetGameObjectChild(shopPanel, "Weapons"), "Weapons Panel").transform.GetChild(4).gameObject;
                
                TextMeshProUGUI weaponTitleText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "Weapons Panel"), "Menu Title"));
                weaponTitleText.text = LanguageManager.CurrentLanguage.shop.shop_weapons;
                
                TextMeshProUGUI weaponBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "BackButton"), "Text"));
                weaponBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;
                
                TextMeshProUGUI weaponRevolverText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "RevolverButton"), "Text"));
                weaponRevolverText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;
                
                TextMeshProUGUI weaponShotgunText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "ShotgunButton"), "Text"));
                weaponShotgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;
                
                TextMeshProUGUI weaponNailgunText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "NailgunButton"), "Text"));
                weaponNailgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                //Slight problem - not all the text fits in the box.
                //The longer text is, the more we'll need to reduce the font size to compensate.
                TextMeshProUGUI weaponRailcannonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "RailcannonButton"), "Text"));
                weaponRailcannonText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;
                weaponRailcannonText.fontSize = 16;

                TextMeshProUGUI rocketLauncherText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "RocketLauncherButton"), "Text"));
                rocketLauncherText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;
                rocketLauncherText.fontSize = 16;

                TextMeshProUGUI weaponArmText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsButtonsObject, "ArmButton"), "Text"));
                weaponArmText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

                // Revolver
                // Piercer(Blue)
                // Marksman(Green)
                // Sharpshooter(Red)

                //Revolver window and descriptions
                GameObject revolverWindow = GetGameObjectChild(shopWeaponsObject, "Revolver Window");
                GameObject revolverVariations = GetGameObjectChild(GetGameObjectChild(revolverWindow, "Variation Screen"), "Variations");

                TextMeshProUGUI revolverWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(revolverVariations.transform.parent.gameObject, "Title"));
                revolverWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;
                
                //Piercer
                GameObject piercer = GetGameObjectChild(revolverVariations, "Variation Panel (Blue)");
                TextMeshProUGUI piercerName = GetTextMeshProUGUI(GetGameObjectChild(piercer, "Variation Name"));
                piercerName.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercer;

                GameObject piercerWindow = GetGameObjectChild(GetGameObjectChild(revolverWindow, "Variation Info (Blue)"), "Panel");
                TextMeshProUGUI piercerWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(piercerWindow.transform.parent.gameObject, "Title"));
                piercerWindowTitle.text = piercerName.text;
                TextMeshProUGUI piercerWindowName = GetTextMeshProUGUI(GetGameObjectChild(piercerWindow, "Name"));
                piercerWindowName.text = piercerName.text;

                TextMeshProUGUI piercerWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(piercerWindow, "Description"));
                piercerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2;

                TextMeshProUGUI piercerWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(piercerWindow, "Back Button"),"Text"));
                piercerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Marksman
                GameObject marksman = GetGameObjectChild(revolverVariations, "Variation Panel (Green)");
                TextMeshProUGUI marksmanName = GetTextMeshProUGUI(GetGameObjectChild(marksman, "Variation Name"));
                marksmanName.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksman;
                marksmanName.fontSize = 14;
                
                GameObject marksmanWindow = GetGameObjectChild(GetGameObjectChild(revolverWindow, "Variation Info (Green)"), "Panel");
                TextMeshProUGUI marksmanWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(marksmanWindow.transform.parent.gameObject, "Title"));
                marksmanWindowTitle.text = marksmanName.text;
                TextMeshProUGUI marksmanWindowName = GetTextMeshProUGUI(GetGameObjectChild(marksmanWindow, "Name"));
                marksmanWindowName.text = marksmanName.text;

                TextMeshProUGUI marksmanWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(marksmanWindow, "Description"));
                marksmanWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3;
                marksmanWindowDescription.fontSize = 14;

                TextMeshProUGUI marksmanWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(marksmanWindow, "Back Button"), "Text"));
                marksmanWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Sharpshooter
                GameObject sharpshooter = GetGameObjectChild(revolverVariations, "Variation Panel (Red)");
                TextMeshProUGUI sharpshooterName = GetTextMeshProUGUI(GetGameObjectChild(sharpshooter, "Variation Name"));
                sharpshooterName.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter;
                sharpshooterName.fontSize = 20;
                
                GameObject sharpshooterWindow = GetGameObjectChild(GetGameObjectChild(revolverWindow, "Variation Info (Red)"), "Panel");
                TextMeshProUGUI sharpshooterWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterWindow.transform.parent.gameObject, "Title"));
                sharpshooterWindowTitle.text = sharpshooterName.text;
                TextMeshProUGUI sharpshooterWindowName = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterWindow, "Name"));
                sharpshooterWindowName.text = sharpshooterName.text;

                TextMeshProUGUI sharpshooterWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterWindow, "Description"));
                sharpshooterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription2 + "\n\n";
                sharpshooterWindowDescription.fontSize = 20;

                //just in case.
                TextMeshProUGUI redrevolverBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sharpshooterWindow, "Back Button"), "Text"));
                redrevolverBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Revolver info & color tabs
                GameObject revolverExtra = GetGameObjectChild(revolverVariations, "Info and Color Panel");
                GameObject revolverExtraInfo = GetGameObjectChild(revolverExtra, "InfoButton");
                GameObject revolverExtraColor = GetGameObjectChild(revolverExtra, "ColorButton");

                TextMeshProUGUI revolverExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(revolverExtraInfo, "Text"));
                revolverExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI revolverExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(revolverExtraColor, "Text"));
                revolverExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Revolver lore
                GameObject revolverLore = GetGameObjectChild(revolverWindow, "Info Screen");
                TextMeshProUGUI revolverLoreName = GetTextMeshProUGUI(GetGameObjectChild(revolverLore, "Title"));
                revolverLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;// + info

                TextMeshProUGUI revolverLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverLore, "Main Window"), "Scroll View"),"Viewport"),"Text"));

                revolverLoreInfo.text =
                    "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver4 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver5 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver9 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver10;

                TextMeshProUGUI revolverLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverLore, "Main Window"), "Back Button"), "Text"));
                revolverLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Revolver preset colors
                GameObject revolverColorWindow = GetGameObjectChild(GetGameObjectChild(revolverWindow, "Color Screen"),"Main Window");

                TextMeshProUGUI revolverColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(revolverColorWindow.transform.parent.gameObject,"Title"));
                revolverColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver + "--"; //+ color

                GameObject revolverTemplates = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Window"), "Presets");
                TextMeshProUGUI revolverTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTemplates, "Template 1"), "Text"));
                TextMeshProUGUI revolverTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTemplates, "Template 2"), "Text"));
                TextMeshProUGUI revolverTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTemplates, "Template 3"), "Text"));
                TextMeshProUGUI revolverTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTemplates, "Template 4"), "Text"));
                TextMeshProUGUI revolverTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTemplates, "Template 5"), "Text"));

                revolverTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
                revolverTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
                revolverTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
                revolverTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
                revolverTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

                /*  Patch GunColorTypeGetter.ToggleAlternate() instead
                TextMeshProUGUI revolverColorSwitchToAlternative = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"AlternateButton"),"Text"));
                revolverColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                TextMeshProUGUI revolverColorSwitchToStandard = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "AlternateButton"), "Text"));
                revolverColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;
                */

                GameObject revolverTypeButtons = GetGameObjectChild(revolverTemplates.transform.parent.gameObject, "Type Selection");
                TextMeshProUGUI revolverColorPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTypeButtons, "Preset Button"),"Text"));
                revolverColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI revolverColorCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTypeButtons, "Custom Button"),"Text"));
                revolverColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI revolverColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverTemplates.transform.parent.gameObject, "Done"),"Text"));
                revolverColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Revolver custom color unlock prompt
                TextMeshProUGUI revolverCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverTemplates.transform.parent.gameObject, "Custom"),"Locked"),"Text"));
                revolverCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                // SHOTGUN
                // Core Eject(Blue)
                // Pump Charge(Green)
                // Sawed-On(Red)

                //Shotgun window and descriptions
                GameObject shotgunWindow = GetGameObjectChild(shopWeaponsObject, "Shotgun Window");
                GameObject shotgunVariations = GetGameObjectChild(GetGameObjectChild(shotgunWindow, "Variation Screen"), "Variations");

                TextMeshProUGUI shotgunWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(shotgunVariations.transform.parent.gameObject, "Title"));
                shotgunWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                //Core Eject
                GameObject coreEject = GetGameObjectChild(shotgunVariations, "Variation Panel (Blue)");
                TextMeshProUGUI coreEjectName = GetTextMeshProUGUI(GetGameObjectChild(coreEject, "Variation Name"));
                coreEjectName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                GameObject coreEjectWindow = GetGameObjectChild(GetGameObjectChild(shotgunWindow, "Variation Info (Blue)"), "Panel");
                TextMeshProUGUI coreEjectWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow.transform.parent.gameObject, "Title"));
                coreEjectWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;
                TextMeshProUGUI coreEjectWindowName = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow, "Name"));
                coreEjectWindowName.text = coreEjectName.text;

                TextMeshProUGUI coreEjectWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow, "Description"));
                coreEjectWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3;

                TextMeshProUGUI coreEjectWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(coreEjectWindow, "Back Button"), "Text"));
                coreEjectWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Pump Charge
                GameObject pumpCharge = GetGameObjectChild(shotgunVariations, "Variation Panel (Green)");
                TextMeshProUGUI pumpChargeName = GetTextMeshProUGUI(GetGameObjectChild(pumpCharge, "Variation Name"));
                pumpChargeName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
                pumpChargeName.fontSize = 16;

                GameObject pumpChargeWindow = GetGameObjectChild(GetGameObjectChild(shotgunWindow, "Variation Info (Green)"), "Panel");
                TextMeshProUGUI pumpChargeWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow.transform.parent.gameObject, "Title"));
                pumpChargeWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
                TextMeshProUGUI pumpChargeWindowName = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow, "Name"));
                pumpChargeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;

                TextMeshProUGUI pumpChargeWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow, "Description"));
                pumpChargeWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2;
                pumpChargeWindowDescription.fontSize = 14;

                TextMeshProUGUI pumpChargeWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pumpChargeWindow, "Back Button"), "Text"));
                pumpChargeWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Sawed-On
                GameObject sawedOn = GetGameObjectChild(shotgunVariations, "Variation Panel (Red)");
                TextMeshProUGUI sawedOnName = GetTextMeshProUGUI(GetGameObjectChild(sawedOn, "Variation Name"));
                sawedOnName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn;

                GameObject sawedOnWindow = GetGameObjectChild(GetGameObjectChild(shotgunWindow, "Variation Info (Red)"), "Panel");
                TextMeshProUGUI sawedOnWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(sawedOnWindow.transform.parent.gameObject, "Title"));
                sawedOnWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn;
                TextMeshProUGUI sawedOnWindowName = GetTextMeshProUGUI(GetGameObjectChild(sawedOnWindow, "Name"));
                sawedOnWindowName.text = sawedOnName.text;

                TextMeshProUGUI sawedOnWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(sawedOnWindow, "Description"));
                sawedOnWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription3;

                TextMeshProUGUI sawedOnWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sawedOnWindow, "Back Button"), "Text"));
                sawedOnWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun info & color tabs
                GameObject shotgunExtra = GetGameObjectChild(shotgunVariations, "Info and Color Panel");
                GameObject shotgunExtraInfo = GetGameObjectChild(shotgunExtra, "InfoButton");
                GameObject shotgunExtraColor = GetGameObjectChild(shotgunExtra, "ColorButton");

                TextMeshProUGUI shotgunExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(shotgunExtraInfo, "Text"));
                shotgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI shotgunExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(shotgunExtraColor, "Text"));
                shotgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Shotgun lore
                GameObject shotgunLore = GetGameObjectChild(GetGameObjectChild(shotgunWindow,"Info Screen"), "Main Window");
                TextMeshProUGUI shotgunLoreName = GetTextMeshProUGUI(GetGameObjectChild(shotgunLore.transform.parent.gameObject, "Title"));
                shotgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                TextMeshProUGUI shotgunLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Scroll View"), "Viewport"), "Text"));

                shotgunLoreInfo.text =
                    "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun4 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun5 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun9;

                TextMeshProUGUI shotgunLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Back Button"), "Text"));
                shotgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun preset colors
                GameObject shotgunColorWindow = GetGameObjectChild(GetGameObjectChild(shotgunWindow, "Color Screen"), "Main Window");

                TextMeshProUGUI shotgunColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(shotgunColorWindow.transform.parent.gameObject, "Title"));
                shotgunColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun; //+ color

                GameObject shotgunTemplates = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Window"), "Presets");
                TextMeshProUGUI shotgunTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTemplates, "Template 1"), "Text"));
                TextMeshProUGUI shotgunTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTemplates, "Template 2"), "Text"));
                TextMeshProUGUI shotgunTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTemplates, "Template 3"), "Text"));
                TextMeshProUGUI shotgunTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTemplates, "Template 4"), "Text"));
                TextMeshProUGUI shotgunTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTemplates, "Template 5"), "Text"));

                shotgunTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
                shotgunTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
                shotgunTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
                shotgunTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
                shotgunTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

                GameObject shotgunTypeButtons = GetGameObjectChild(shotgunTemplates.transform.parent.gameObject, "Type Selection");
                TextMeshProUGUI shotgunColorPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTypeButtons, "Preset Button"), "Text"));
                shotgunColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI shotgunColorCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTypeButtons, "Custom Button"), "Text"));
                shotgunColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI shotgunColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunTemplates.transform.parent.gameObject, "Done"), "Text"));
                shotgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //shotgun custom color unlock prompt
                TextMeshProUGUI shotgunCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunTemplates.transform.parent.gameObject, "Custom"), "Locked"), "Text"));
                shotgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                // Nailgun
                // Attractor(Blue)
                // Overheat(Green)
                // Jumpstart(Red)

                //Nailgun window and descriptions
                GameObject nailgunWindow = GetGameObjectChild(shopWeaponsObject, "Nailgun Window");
                GameObject nailgunVariations = GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Variation Screen"), "Variations");

                TextMeshProUGUI nailgunWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(nailgunVariations.transform.parent.gameObject, "Title"));
                nailgunWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                //Attractor
                GameObject attractor = GetGameObjectChild(nailgunVariations, "Variation Panel (Blue)");
                TextMeshProUGUI attractorName = GetTextMeshProUGUI(GetGameObjectChild(attractor, "Variation Name"));
                attractorName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                GameObject attractorWindow = GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Variation Info (Blue)"), "Panel");
                TextMeshProUGUI attractorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow.transform.parent.gameObject, "Title"));
                attractorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;
                TextMeshProUGUI attractorWindowName = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow, "Name"));
                attractorWindowName.text = attractorName.text;

                TextMeshProUGUI attractorWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow, "Description"));
                attractorWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2;
                attractorWindowDescription.fontSize = 16;

                TextMeshProUGUI attractorWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(attractorWindow, "Back Button"), "Text"));
                attractorWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Overheat
                GameObject overheat = GetGameObjectChild(nailgunVariations, "Variation Panel (Green)");
                TextMeshProUGUI overheatName = GetTextMeshProUGUI(GetGameObjectChild(overheat, "Variation Name"));
                overheatName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
                overheatName.fontSize = 16;

                GameObject overheatWindow = GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Variation Info (Green)"), "Panel");
                TextMeshProUGUI overheatWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow.transform.parent.gameObject, "Title"));
                overheatWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
                TextMeshProUGUI overheatWindowName = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow, "Name"));
                overheatWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;

                TextMeshProUGUI overheatWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow, "Description"));
                overheatWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2;
                overheatWindowDescription.fontSize = 14;

                TextMeshProUGUI overheatWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(overheatWindow, "Back Button"), "Text"));
                overheatWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Jumpstarter
                GameObject jumpStart = GetGameObjectChild(nailgunVariations, "Variation Panel (Red)");
                TextMeshProUGUI jumpStartName = GetTextMeshProUGUI(GetGameObjectChild(jumpStart, "Variation Name"));
                jumpStartName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;
                jumpStartName.fontSize = 16;

                GameObject jumpStartWindow = GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Variation Info (Red)"), "Panel");
                TextMeshProUGUI jumpStartWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(jumpStartWindow.transform.parent.gameObject, "Title"));
                jumpStartWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;
                TextMeshProUGUI jumpStartWindowName = GetTextMeshProUGUI(GetGameObjectChild(jumpStartWindow, "Name"));
                jumpStartWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;

                TextMeshProUGUI jumpStartWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(jumpStartWindow, "Description"));
                jumpStartWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription2;

                TextMeshProUGUI jumpStartWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(jumpStartWindow, "Back Button"), "Text"));
                jumpStartWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Nailgun info & color tabs
                GameObject nailgunExtra = GetGameObjectChild(nailgunVariations, "Info and Color Panel");
                GameObject nailgunExtraInfo = GetGameObjectChild(nailgunExtra, "InfoButton");
                GameObject nailgunExtraColor = GetGameObjectChild(nailgunExtra, "ColorButton");

                TextMeshProUGUI nailgunExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(nailgunExtraInfo, "Text"));
                nailgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI nailgunExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(nailgunExtraColor, "Text"));
                nailgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Nailgun lore
                GameObject nailgunLore = GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Info Screen"), "Main Window");
                TextMeshProUGUI nailgunLoreName = GetTextMeshProUGUI(GetGameObjectChild(nailgunLore.transform.parent.gameObject, "Title"));
                nailgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                TextMeshProUGUI NailgunLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Scroll View"), "Viewport"), "Text"));

                NailgunLoreInfo.text =
                    "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun4 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun5 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun9;

                TextMeshProUGUI NailgunLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Back Button"), "Text"));
                NailgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //nailgun preset colors
                GameObject nailgunColorWindow = GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Color Screen"), "Main Window");

                TextMeshProUGUI nailgunColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(nailgunColorWindow.transform.parent.gameObject, "Title"));
                nailgunColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun; //+ color

                GameObject nailgunTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Window"), "Presets");
                TextMeshProUGUI nailgunTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTemplates, "Template 1"), "Text"));
                TextMeshProUGUI nailgunTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTemplates, "Template 2"), "Text"));
                TextMeshProUGUI nailgunTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTemplates, "Template 3"), "Text"));
                TextMeshProUGUI nailgunTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTemplates, "Template 4"), "Text"));
                TextMeshProUGUI nailgunTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTemplates, "Template 5"), "Text"));

                nailgunTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                GameObject nailgunTypeButtons = GetGameObjectChild(nailgunTemplates.transform.parent.gameObject, "Type Selection");
                TextMeshProUGUI nailgunColorPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTypeButtons, "Preset Button"), "Text"));
                nailgunColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI nailgunColorCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTypeButtons, "Custom Button"), "Text"));
                nailgunColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI nailgunColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunTemplates.transform.parent.gameObject, "Done"), "Text"));
                nailgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //nailgun custom color unlock prompt
                TextMeshProUGUI nailgunCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunTemplates.transform.parent.gameObject, "Custom"), "Locked"), "Text"));
                nailgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                // Railcannon
                // Electric(Blue)
                // Screwdriver(Green)
                // Malicious(Red)

                //Railcannon window and descriptions
                GameObject railcannonWindow = GetGameObjectChild(shopWeaponsObject, "Railcannon Window");
                GameObject railcannonVariations = GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Variation Screen"), "Variations");

                TextMeshProUGUI railcannonWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(railcannonVariations.transform.parent.gameObject, "Title"));
                railcannonWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                //Electric
                GameObject electric = GetGameObjectChild(railcannonVariations, "Variation Panel (Blue)");
                TextMeshProUGUI electricName = GetTextMeshProUGUI(GetGameObjectChild(electric, "Variation Name"));
                electricName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                GameObject electricWindow = GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Variation Info (Blue)"), "Panel");
                TextMeshProUGUI electricWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(electricWindow.transform.parent.gameObject, "Title"));
                electricWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;
                TextMeshProUGUI electricWindowName = GetTextMeshProUGUI(GetGameObjectChild(electricWindow, "Name"));
                electricWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                TextMeshProUGUI electricWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(electricWindow, "Description"));
                electricWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3;
                electricWindowDescription.fontSize = 16;

                TextMeshProUGUI electricWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(electricWindow, "Back Button"), "Text"));
                electricWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Screwdriver
                GameObject screwdriver = GetGameObjectChild(railcannonVariations, "Variation Panel (Green)");
                TextMeshProUGUI screwdriverName = GetTextMeshProUGUI(GetGameObjectChild(screwdriver, "Variation Name"));
                screwdriverName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                GameObject screwdriverWindow = GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Variation Info (Green)"), "Panel");
                TextMeshProUGUI screwdriverWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow.transform.parent.gameObject, "Title"));
                screwdriverWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;
                TextMeshProUGUI screwdriverWindowName = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow, "Name"));
                screwdriverWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                TextMeshProUGUI screwdriverWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow, "Description"));
                screwdriverWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2;
                screwdriverWindowDescription.fontSize = 16;

                TextMeshProUGUI screwdriverWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(screwdriverWindow, "Back Button"), "Text"));
                screwdriverWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Malicious
                GameObject malicious = GetGameObjectChild(railcannonVariations, "Variation Panel (Red)");
                TextMeshProUGUI maliciousName = GetTextMeshProUGUI(GetGameObjectChild(malicious, "Variation Name"));
                maliciousName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                GameObject maliciousWindow = GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Variation Info (Red)"), "Panel");
                TextMeshProUGUI maliciousWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow.transform.parent.gameObject, "Title"));
                maliciousWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;
                TextMeshProUGUI maliciousWindowName = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow, "Name"));
                maliciousWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                TextMeshProUGUI maliciousWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow, "Description"));
                maliciousWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2;
                maliciousWindowDescription.fontSize = 16;

                TextMeshProUGUI maliciousWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(maliciousWindow, "Back Button"), "Text"));
                maliciousWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon info & color tabs
                GameObject railcannonExtra = GetGameObjectChild(railcannonVariations, "Info and Color Panel");
                GameObject railcannonExtraInfo = GetGameObjectChild(railcannonExtra, "InfoButton");
                GameObject railcannonExtraColor = GetGameObjectChild(railcannonExtra, "ColorButton");

                TextMeshProUGUI railcannonExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(railcannonExtraInfo, "Text"));
                railcannonExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI railcannonExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(railcannonExtraColor, "Text"));
                railcannonExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Railcannon lore
                GameObject railcannonLore = GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Info Screen"), "Main Window");
                TextMeshProUGUI railcannonLoreName = GetTextMeshProUGUI(GetGameObjectChild(railcannonLore.transform.parent.gameObject, "Title"));
                railcannonLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                TextMeshProUGUI railcannonLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Scroll View"), "Viewport"), "Text"));

                railcannonLoreInfo.text =
                     "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon4 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon5 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon8 + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon9;

                TextMeshProUGUI railcannonLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Back Button"), "Text"));
                railcannonLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon preset colors
                GameObject railcannonColorWindow = GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Color Screen"), "Main Window");

                TextMeshProUGUI railcannonColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(railcannonColorWindow.transform.parent.gameObject, "Title"));
                railcannonColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon; //+ color

                GameObject railcannonTemplates = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Window"), "Presets");
                TextMeshProUGUI railcannonTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTemplates, "Template 1"), "Text"));
                TextMeshProUGUI railcannonTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTemplates, "Template 2"), "Text"));
                TextMeshProUGUI railcannonTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTemplates, "Template 3"), "Text"));
                TextMeshProUGUI railcannonTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTemplates, "Template 4"), "Text"));
                TextMeshProUGUI railcannonTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTemplates, "Template 5"), "Text"));

                railcannonTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1;
                railcannonTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2;
                railcannonTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3;
                railcannonTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4;
                railcannonTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5;

                GameObject railcannonTypeButtons = GetGameObjectChild(railcannonTemplates.transform.parent.gameObject, "Type Selection");
                TextMeshProUGUI railcannonColorPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTypeButtons, "Preset Button"), "Text"));
                railcannonColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI railcannonColorCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTypeButtons, "Custom Button"), "Text"));
                railcannonColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI railcannonColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonTemplates.transform.parent.gameObject, "Done"), "Text"));
                railcannonColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //railcannon custom color unlock prompt
                TextMeshProUGUI railcannonCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonTemplates.transform.parent.gameObject, "Custom"), "Locked"), "Text"));
                railcannonCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                // Rocket Launcher
                // Freezeframe(Blue)
                // S.R.S Cannon(Green)
                // Firestarter(Red)

                //Rocket launcher window & descriptions
                GameObject rocketlauncherWindow = GetGameObjectChild(shopWeaponsObject, "Rocket Launcher Window");
                GameObject rocketlauncherVariations = GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Variation Screen"), "Variations");

                TextMeshProUGUI rocketlauncherWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherVariations.transform.parent.gameObject, "Title"));
                rocketlauncherWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                //Freezeframe
                GameObject freezeframe = GetGameObjectChild(rocketlauncherVariations, "Variation Panel (Blue)");
                TextMeshProUGUI freezeframeName = GetTextMeshProUGUI(GetGameObjectChild(freezeframe, "Variation Name"));
                freezeframeName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;

                GameObject freezeframeInfo = GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Variation Info (Blue)"), "Panel");
                TextMeshProUGUI freezeframeInfoTitle = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo.transform.parent.gameObject, "Title"));
                freezeframeInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
                TextMeshProUGUI freezeframeWindowName = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo, "Name"));
                freezeframeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
                TextMeshProUGUI freezeframeDescription = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo, "Description"));
                freezeframeDescription.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2;
                freezeframeDescription.fontSize = 16;

                TextMeshProUGUI freezeframeDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(freezeframeInfo, "Back Button"), "Text"));
                freezeframeDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket Launcher green variation
                GameObject srsCannon = GetGameObjectChild(rocketlauncherVariations, "Variation Panel (Green)");
                TextMeshProUGUI srsCannonName = GetTextMeshProUGUI(GetGameObjectChild(srsCannon, "Variation Name"));
                srsCannonName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                
                GameObject srsCannonInfo = GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Variation Info (Green)"), "Panel");
                TextMeshProUGUI srsCannonInfoTitle = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo.transform.parent.gameObject, "Title"));
                srsCannonInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                TextMeshProUGUI srsCannonWindowName = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo, "Name"));
                srsCannonWindowName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                TextMeshProUGUI srsCannonInfoDescription = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo, "Description"));
                srsCannonInfoDescription.text =
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription1 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription2 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription3;
                srsCannonInfoDescription.fontSize = 16;

                TextMeshProUGUI srsCannonBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(srsCannonInfo, "Back Button"), "Text"));
                srsCannonBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Firestarter a.k.a Gasoline
                GameObject fireStarter = GetGameObjectChild(rocketlauncherVariations, "Variation Panel (Red)");
                TextMeshProUGUI fireStarterName = GetTextMeshProUGUI(GetGameObjectChild(fireStarter, "Variation Name"));
                fireStarterName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;

                GameObject fireStarterInfo = GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Variation Info (Red)"), "Panel");
                TextMeshProUGUI fireStarterInfoTitle = GetTextMeshProUGUI(GetGameObjectChild(fireStarterInfo.transform.parent.gameObject, "Title"));
                fireStarterInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;
                TextMeshProUGUI fireStarterInfoName = GetTextMeshProUGUI(GetGameObjectChild(fireStarterInfo, "Name"));
                fireStarterInfoName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;
                TextMeshProUGUI fireStarterInfoDescription = GetTextMeshProUGUI(GetGameObjectChild(fireStarterInfo, "Description"));
                fireStarterInfoDescription.text =
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription1 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription2;
                fireStarterInfoDescription.fontSize = 16;
                TextMeshProUGUI fireStarterBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fireStarterInfo, "Back Button"), "Text"));
                fireStarterBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Rocket launcher info & color tabs
                GameObject rocketlauncherExtra = GetGameObjectChild(rocketlauncherVariations, "Info and Color Panel");
                GameObject rocketlauncherExtraInfo = GetGameObjectChild(rocketlauncherExtra, "InfoButton");
                GameObject rocketlauncherExtraColor = GetGameObjectChild(rocketlauncherExtra, "ColorButton");

                TextMeshProUGUI rocketlauncherExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherExtraInfo, "Text"));
                rocketlauncherExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI rocketlauncherExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherExtraColor, "Text"));
                rocketlauncherExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //RocketLauncher lore
                GameObject rocketlauncherLore = GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Info Screen"), "Main Window");
                TextMeshProUGUI rocketlauncherLoreName = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherLore.transform.parent.gameObject, "Title"));
                rocketlauncherLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                TextMeshProUGUI rocketlauncherLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Scroll View"), "Viewport"), "Text"));

                rocketlauncherLoreInfo.text =
                      "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher4 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher5 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher9 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher10 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher11 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher12 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher13 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher14 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher15;

                TextMeshProUGUI rocketlauncherLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Back Button"), "Text"));
                rocketlauncherLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //RocketLauncher preset colors
                GameObject rocketlauncherColorWindow = GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Color Screen"), "Main Window");

                TextMeshProUGUI rocketlauncherColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherColorWindow.transform.parent.gameObject, "Title"));
                rocketlauncherColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher; //+ color

                GameObject rocketlauncherTemplates = GetGameObjectChild(GetGameObjectChild(rocketlauncherColorWindow, "Window"), "Presets");
                TextMeshProUGUI rocketlauncherTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates, "Template 1"), "Text"));
                TextMeshProUGUI rocketlauncherTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates, "Template 2"), "Text"));
                TextMeshProUGUI rocketlauncherTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates, "Template 3"), "Text"));
                TextMeshProUGUI rocketlauncherTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates, "Template 4"), "Text"));
                TextMeshProUGUI rocketlauncherTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates, "Template 5"), "Text"));

                rocketlauncherTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1;
                rocketlauncherTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2;
                rocketlauncherTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3;
                rocketlauncherTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4;
                rocketlauncherTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5;

                GameObject rocketlauncherTypeButtons = GetGameObjectChild(rocketlauncherTemplates.transform.parent.gameObject, "Type Selection");
                TextMeshProUGUI rocketlauncherColorPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTypeButtons, "Preset Button"), "Text"));
                rocketlauncherColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI rocketlauncherColorCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTypeButtons, "Custom Button"), "Text"));
                rocketlauncherColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI rocketlauncherColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates.transform.parent.gameObject, "Done"), "Text"));
                rocketlauncherColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //rocketlauncher custom color unlock prompt
                TextMeshProUGUI rocketlauncherCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(rocketlauncherTemplates.transform.parent.gameObject, "Custom"), "Locked"), "Text"));
                rocketlauncherCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                // Arm
                // Feedbacker(Blue)
                // Knuckleblaster(Red)
                // Whiplash(Green)
                // ???(Yellow)

                //Arm window and descriptions
                GameObject armWindow = GetGameObjectChild(shopWeaponsObject, "Arm Window");
                GameObject armVariations = GetGameObjectChild(GetGameObjectChild(armWindow, "Variation Screen"), "Variations");

                TextMeshProUGUI armWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(armVariations.transform.parent.gameObject, "Title"));
                armWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

                //Feedbacker
                GameObject feedbacker = GetGameObjectChild(armVariations, "Arm Panel (Blue)");
                TextMeshProUGUI feedbackerName = GetTextMeshProUGUI(GetGameObjectChild(feedbacker, "Variation Name"));
                feedbackerName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                GameObject feedbackerWindow = GetGameObjectChild(GetGameObjectChild(armWindow, "Arm Info (Blue)"), "Panel");
                TextMeshProUGUI feedbackerWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow.transform.parent.gameObject, "Title"));
                feedbackerWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;
                TextMeshProUGUI feedbackerWindowName = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow, "Name"));
                feedbackerWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                TextMeshProUGUI feedbackerWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow, "Description"));
                feedbackerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2;

                TextMeshProUGUI feedbackerWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(feedbackerWindow, "Back Button"), "Text"));
                feedbackerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Knuckleblaster
                GameObject knuckleblaster = GetGameObjectChild(armVariations, "Arm Panel (Red)");
                TextMeshProUGUI knuckleblasterName = GetTextMeshProUGUI(GetGameObjectChild(knuckleblaster, "Variation Name"));
                knuckleblasterName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                GameObject knuckleblasterWindow = GetGameObjectChild(GetGameObjectChild(armWindow, "Arm Info (Red)"), "Panel");
                TextMeshProUGUI knuckleblasterWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow.transform.parent.gameObject, "Title"));
                knuckleblasterWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;
                TextMeshProUGUI knuckleblasterWindowName = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow, "Name"));
                knuckleblasterWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                TextMeshProUGUI knuckleblasterWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow, "Description"));
                knuckleblasterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2;

                TextMeshProUGUI knuckleblasterWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(knuckleblasterWindow, "Back Button"), "Text"));
                knuckleblasterWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Whiplash
                GameObject whiplash = GetGameObjectChild(armVariations, "Arm Panel (Green)");
                TextMeshProUGUI whiplashName = GetTextMeshProUGUI(GetGameObjectChild(whiplash, "Variation Name"));
                whiplashName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                GameObject whiplashWindow = GetGameObjectChild(GetGameObjectChild(armWindow, "Arm Info (Green)"), "Panel");
                TextMeshProUGUI whiplashWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow.transform.parent.gameObject, "Title"));
                whiplashWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;
                TextMeshProUGUI whiplashWindowName = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow, "Name"));
                whiplashWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                TextMeshProUGUI whiplashWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow, "Description"));
                whiplashWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2;
                whiplashWindowDescription.fontSize = 16;
                
                TextMeshProUGUI whiplashWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(whiplashWindow, "Back Button"), "Text"));
                whiplashWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //it's "???" and placeholders so comment it for future
                /*//Gold arm (under construction)
                GameObject goldArm = GetGameObjectChild(armVariations, "Arm Panel (Gold)");
                TextMeshProUGUI goldArmUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(goldArm, "Variation Name"));
                goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.shop.shop_armGold;

                GameObject goldArmWindow = GetGameObjectChild(GetGameObjectChild(armWindow, "Arm Info (Green)"), "Panel");
                TextMeshProUGUI goldArmWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(goldArmWindow.transform.parent.gameObject, "Title"));
                goldArmWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armGold;
                TextMeshProUGUI goldArmWindowName = GetTextMeshProUGUI(GetGameObjectChild(goldArmWindow, "Name"));
                goldArmWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armGold;

                TextMeshProUGUI goldArmWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(goldArmWindow, "Description"));
                goldArmWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armGoldDescription;
                */

                //Usually it's VariationInfo's job but it disabled in gold arm so
                try
                {
                    GameObject goldArm = GetGameObjectChild(armVariations, "Arm Panel (Gold)");
                    TextMeshProUGUI goldArmUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(goldArm, "Purchase Status"));
                    goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                }
                catch (Exception e)
                {
                    Logging.Warn("An error occured while patching gold arm's under construction text.");
                    Logging.Warn(e.ToString());
                }

            }
            catch (Exception e)
            {
                Logging.Error("An error occured while translating shop weapons texts.");
                Logging.Error(e.ToString());
            }
                
        }

        public static void PatchShopRefactor(ref GameObject shopObject)
        {
            PatchShopFrontEnd(ref shopObject);
            PatchWeapons(ref shopObject);
        }
        
    }
}
