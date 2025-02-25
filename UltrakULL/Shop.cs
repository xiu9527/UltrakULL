using System;
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
                if (tipDescriptionText.Contains("V-Rank")) { }
                else { tipDescription.text = StringsParent.GetLevelTip(); }

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

                TextMeshProUGUI revolverWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "Revolver Window"), "Variation Screen"),"Title"));
                revolverWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;
                
                //Piercer
                GameObject piercer = GetGameObjectChild(revolverVariations, "Variation Panel (Blue)");
                TextMeshProUGUI piercerName = GetTextMeshProUGUI(GetGameObjectChild(piercer, "Variation Name"));
                piercerName.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercer;

                GameObject piercerWindow = GetGameObjectChild(revolverWindow, "Variation Info (Blue)");
                TextMeshProUGUI piercerWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(piercerWindow, "Title"));
                piercerWindowTitle.text = piercerName.text;

                GameObject piercerPanel = GetGameObjectChild(piercerWindow, "Panel");

                TextMeshProUGUI piercerWindowName = GetTextMeshProUGUI(GetGameObjectChild(piercerPanel, "Name"));
                piercerWindowName.text = piercerName.text;
                TextMeshProUGUI piercerWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(piercerPanel, "Description"));
                piercerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2;

                TextMeshProUGUI piercerWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(piercerPanel, "Back Button"),"Text"));
                piercerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Marksman
                GameObject marksman = GetGameObjectChild(revolverVariations, "Variation Panel (Green)");
                TextMeshProUGUI marksmanName = GetTextMeshProUGUI(GetGameObjectChild(marksman, "Variation Name"));
                marksmanName.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksman;
                marksmanName.fontSize = 14;
                
                GameObject marksmanWindow = GetGameObjectChild(revolverWindow, "Variation Info (Green)");
                TextMeshProUGUI marksmanWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(marksmanWindow, "Title"));
                marksmanWindowTitle.text = marksmanName.text;

                GameObject marksmanPanel = GetGameObjectChild(marksmanWindow, "Panel");

                TextMeshProUGUI marksmanWindowName = GetTextMeshProUGUI(GetGameObjectChild(marksmanPanel, "Name"));
                marksmanWindowName.text = marksmanName.text;
                TextMeshProUGUI marksmanWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(marksmanPanel, "Description"));
                marksmanWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3;
                marksmanWindowDescription.fontSize = 14;

                TextMeshProUGUI marksmanWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(marksmanPanel, "Back Button"), "Text"));
                marksmanWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Sharpshooter
                GameObject sharpshooter = GetGameObjectChild(revolverVariations, "Variation Panel (Red)");
                TextMeshProUGUI sharpshooterName = GetTextMeshProUGUI(GetGameObjectChild(sharpshooter, "Variation Name"));
                sharpshooterName.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter;
                sharpshooterName.fontSize = 20;
                
                GameObject sharpshooterWindow = GetGameObjectChild(revolverWindow, "Variation Info (Red)");
                TextMeshProUGUI sharpshooterWindowName = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterWindow, "Title"));
                sharpshooterWindowName.text = sharpshooterName.text;

                GameObject sharpshooterPanel = GetGameObjectChild(sharpshooterWindow, "Panel");

                TextMeshProUGUI sharpshooterWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterPanel, "Description"));
                sharpshooterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription2 + "\n\n";
                sharpshooterWindowDescription.fontSize = 20;

                //just in case.
                TextMeshProUGUI redrevolverBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sharpshooterPanel, "Back Button"), "Text"));
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
                GameObject revolverColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "Color Screen"),"Main Window");

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
                GameObject shotgunWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Variation Screen");

                //Core Eject
                GameObject coreEject = GetGameObjectChild(shotgunWindow, "Variation Panel (Blue)");
                TextMeshProUGUI coreEjectName = GetTextMeshProUGUI(GetGameObjectChild(coreEject, "Variation Name"));
                coreEjectName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                GameObject coreEjectWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Blue)");
                TextMeshProUGUI coreEjectWindowName = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow, "Title"));
                coreEjectWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                TextMeshProUGUI coreEjectWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow, "Description"));
                coreEjectWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3;

                TextMeshProUGUI coreEjectWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(coreEjectWindow, "Button"), "Text"));
                coreEjectWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Pump Charge
                GameObject pumpCharge = GetGameObjectChild(shotgunWindow, "Variation Panel (Green)");
                TextMeshProUGUI pumpChargeName = GetTextMeshProUGUI(GetGameObjectChild(pumpCharge, "Variation Name"));
                pumpChargeName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
                pumpChargeName.fontSize = 16;

                GameObject pumpChargeWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Green)");
                TextMeshProUGUI pumpChargeWindowName = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow, "Title"));
                pumpChargeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;

                TextMeshProUGUI pumpChargeWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow, "Description"));
                pumpChargeWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2;
                pumpChargeWindowDescription.fontSize = 14;

                TextMeshProUGUI pumpChargeWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pumpChargeWindow, "Button"), "Text"));
                pumpChargeWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Sawed-On
                GameObject sawedOn = GetGameObjectChild(shotgunWindow, "Variation Panel (Red)");
                TextMeshProUGUI sawedOnName = GetTextMeshProUGUI(GetGameObjectChild(sawedOn, "Variation Name"));
                sawedOnName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn;

                GameObject sawedOnWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Red)");
                TextMeshProUGUI sawedOnWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(sawedOnWindow, "Title"));
                sawedOnWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn;

                TextMeshProUGUI sawedOnWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(sawedOnWindow, "Description"));
                sawedOnWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription3;

                TextMeshProUGUI sawedOnWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sawedOnWindow, "Button"), "Text"));
                sawedOnWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun info & color tabs
                GameObject shotgunExtra = GetGameObjectChild(shotgunWindow, "Info and Color Panel");
                GameObject shotgunExtraInfo = GetGameObjectChild(shotgunExtra, "InfoButton");
                GameObject shotgunExtraColor = GetGameObjectChild(shotgunExtra, "ColorButton");

                TextMeshProUGUI shotgunExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(shotgunExtraInfo, "Text"));
                shotgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI shotgunExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(shotgunExtraColor, "Text"));
                shotgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Shotgun lore
                GameObject shotgunLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Info Screen");
                TextMeshProUGUI shotgunLoreName = GetTextMeshProUGUI(GetGameObjectChild(shotgunLore, "Name"));
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

                TextMeshProUGUI shotgunLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Button"), "Text"));
                shotgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun preset colors
                GameObject shotgunColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Color Screen");


                TextMeshProUGUI shotgunColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(shotgunColorWindow, "Title"));
                shotgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun + "--";

                GameObject shotgunStandardTemplates = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "Template");
                TextMeshProUGUI shotgunStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                shotgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
                shotgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
                shotgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
                shotgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
                shotgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

                TextMeshProUGUI shotgunColorSwitchToAlternative = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "AlternateButton"), "Text"));
                shotgunColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                TextMeshProUGUI shotgunColorSwitchToStandard = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Alternate"), "AlternateButton"), "Text"));
                shotgunColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                GameObject shotgunAlternateTemplates = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Alternate"), "Template");
                TextMeshProUGUI shotgunAlternateTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunAlternateTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunAlternateTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunAlternateTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunAlternateTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                shotgunAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
                shotgunAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
                shotgunAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
                shotgunAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
                shotgunAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

                TextMeshProUGUI shotgunColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "TemplateButton"), "Text"));
                shotgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI shotgunColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "CustomButton"), "Text"));
                shotgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI shotgunColorAlternatePreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "TemplateButton"), "Text"));
                shotgunColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI shotgunColorAlternateCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunAlternateTemplates, "CustomButton"), "Text"));
                shotgunColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI shotgunColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Done"), "Text"));
                shotgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Shotgun custom colors
                GameObject shotgunStandardCustom = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "Custom");
                TextMeshProUGUI shotgunStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardCustom, "TemplateButton"), "Text"));
                shotgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI shotgunStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardCustom, "CustomButton"), "Text"));
                shotgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                GameObject shotgunAlternateCustom = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Alternate"), "Custom");
                TextMeshProUGUI shotgunAlternateCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunAlternateCustom, "TemplateButton"), "Text"));
                shotgunAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI shotgunAlternateCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunAlternateCustom, "CustomButton"), "Text"));
                shotgunAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Shotgun custom color unlock prompt
                TextMeshProUGUI shotgunCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                shotgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                // Nailgun
                // Attractor(Blue)
                // Overheat(Green)
                // Jumpstart(Red)

                //Nailgun window and descriptions
                GameObject nailgunWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Variation Screen");

                //Attractor
                GameObject attractor = GetGameObjectChild(nailgunWindow, "Variation Panel (Blue)");
                TextMeshProUGUI attractorName = GetTextMeshProUGUI(GetGameObjectChild(attractor, "Variation Name"));
                attractorName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                GameObject attractorWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Blue)");
                TextMeshProUGUI attractorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow, "Title"));
                attractorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                TextMeshProUGUI attractorWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow, "Description"));
                attractorWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2;
                attractorWindowDescription.fontSize = 16;

                TextMeshProUGUI attractorWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(attractorWindow, "Button"), "Text"));
                attractorWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Overheat
                GameObject overheat = GetGameObjectChild(nailgunWindow, "Variation Panel (Green)");
                TextMeshProUGUI overheatName = GetTextMeshProUGUI(GetGameObjectChild(overheat, "Variation Name"));
                overheatName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
                overheatName.fontSize = 16;

                GameObject overheatWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Green)");
                TextMeshProUGUI overheatWindowName = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow, "Name"));
                overheatWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;

                TextMeshProUGUI overheatWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow, "Description"));
                overheatWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2;
                overheatWindowDescription.fontSize = 14;

                TextMeshProUGUI overheatWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(overheatWindow, "Button"), "Text"));
                overheatWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Jumpstarter
                GameObject jumpStart = GetGameObjectChild(nailgunWindow, "Variation Panel (Red)");
                TextMeshProUGUI jumpStartName = GetTextMeshProUGUI(GetGameObjectChild(jumpStart, "Variation Name"));
                jumpStartName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;
                jumpStartName.fontSize = 16;

                GameObject jumpStartWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Red)");
                TextMeshProUGUI jumpStartWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(jumpStartWindow, "Title"));
                jumpStartWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;

                TextMeshProUGUI jumpStartWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(jumpStartWindow, "Description"));
                jumpStartWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription2;

                TextMeshProUGUI jumpStartWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(jumpStartWindow, "Button"), "Text"));
                jumpStartWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Nailgun info & color tabs
                GameObject nailgunExtra = GetGameObjectChild(nailgunWindow, "Info and Color Panel");
                GameObject nailgunExtraInfo = GetGameObjectChild(nailgunExtra, "InfoButton");
                GameObject nailgunExtraColor = GetGameObjectChild(nailgunExtra, "ColorButton");

                TextMeshProUGUI nailgunExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(nailgunExtraInfo, "Text"));
                nailgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI nailgunExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(nailgunExtraColor, "Text"));
                nailgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Nailgun lore
                GameObject nailgunLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Info Screen");
                TextMeshProUGUI nailgunLoreName = GetTextMeshProUGUI(GetGameObjectChild(nailgunLore, "Name"));
                nailgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                TextMeshProUGUI nailgunLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Scroll View"), "Viewport"), "Text"));
                nailgunLoreInfo.text =
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

                TextMeshProUGUI nailgunLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Button"), "Text"));
                nailgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Nailgun preset colors
                GameObject nailgunColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Color Screen");

                TextMeshProUGUI nailgunColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(nailgunColorWindow, "Title"));
                nailgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun + "--";

                GameObject nailgunStandardTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "Template");
                TextMeshProUGUI nailgunStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                nailgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                TextMeshProUGUI nailgunColorSwitchToAlternative = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "AlternateButton"), "Text"));
                nailgunColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                TextMeshProUGUI nailgunColorSwitchToStandard = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "AlternateButton"), "Text"));
                nailgunColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                GameObject nailgunAlternateTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "Template");
                TextMeshProUGUI nailgunAlternateTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                nailgunAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                TextMeshProUGUI nailgunColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "TemplateButton"), "Text"));
                nailgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI nailgunColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "CustomButton"), "Text"));
                nailgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI nailgunColorAlternatePreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "TemplateButton"), "Text"));
                nailgunColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI nailgunColorAlternateCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "CustomButton"), "Text"));
                nailgunColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI nailgunColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Done"), "Text"));
                nailgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Nailgun custom colors
                GameObject nailgunStandardCustom = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "Custom");
                TextMeshProUGUI nailgunStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardCustom, "TemplateButton"), "Text"));
                nailgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI nailgunStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardCustom, "CustomButton"), "Text"));
                nailgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                GameObject nailgunAlternateCustom = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "Custom");
                TextMeshProUGUI nailgunAlternateCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateCustom, "TemplateButton"), "Text"));
                nailgunAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI nailgunAlternateCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateCustom, "CustomButton"), "Text"));
                nailgunAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Nailgun custom color unlock prompt
                TextMeshProUGUI nailgunCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                nailgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                // Railcannon
                // Electric(Blue)
                // Screwdriver(Green)
                // Malicious(Red)

                //Railcannon window and descriptions
                GameObject railcannonWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Variation Screen");

                //Electric
                GameObject electric = GetGameObjectChild(railcannonWindow, "Variation Panel (Blue)");
                TextMeshProUGUI electricName = GetTextMeshProUGUI(GetGameObjectChild(electric, "Variation Name"));
                electricName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                GameObject electricWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Blue)");
                TextMeshProUGUI electricWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(electricWindow, "Title"));
                electricWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                TextMeshProUGUI electricWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(electricWindow, "Description"));
                electricWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3;
                electricWindowDescription.fontSize = 16;

                TextMeshProUGUI electricWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(electricWindow, "Button"), "Text"));
                electricWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Screwdriver
                GameObject screwdriver = GetGameObjectChild(railcannonWindow, "Variation Panel (Green)");
                TextMeshProUGUI screwdriverName = GetTextMeshProUGUI(GetGameObjectChild(screwdriver, "Variation Name"));
                screwdriverName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                GameObject screwdriverWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Green)");
                TextMeshProUGUI screwdriverWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow, "NTitleame"));
                screwdriverWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                TextMeshProUGUI screwdriverWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow, "Description"));
                screwdriverWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2;
                screwdriverWindowDescription.fontSize = 16;

                TextMeshProUGUI screwdriverWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(screwdriverWindow, "Button"), "Text"));
                screwdriverWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Malicious
                GameObject malicious = GetGameObjectChild(railcannonWindow, "Variation Panel (Red)");
                TextMeshProUGUI maliciousName = GetTextMeshProUGUI(GetGameObjectChild(malicious, "Variation Name"));
                maliciousName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                GameObject maliciousWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Red)");
                TextMeshProUGUI maliciousWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow, "Title"));
                maliciousWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                TextMeshProUGUI maliciousWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow, "Description"));
                maliciousWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2;
                maliciousWindowDescription.fontSize = 16;

                TextMeshProUGUI maliciousWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(maliciousWindow, "Button"), "Text"));
                maliciousWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon info & color tabs
                GameObject railcannonExtra = GetGameObjectChild(railcannonWindow, "Info and Color Panel");
                GameObject railcannonExtraInfo = GetGameObjectChild(railcannonExtra, "InfoButton");
                GameObject railcannonExtraColor = GetGameObjectChild(railcannonExtra, "ColorButton");

                TextMeshProUGUI railcannonExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(railcannonExtraInfo, "Text"));
                railcannonExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI railcannonExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(railcannonExtraColor, "Text"));
                railcannonExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Railcannon lore
                GameObject railcannonLore =  GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Info Screen");
                TextMeshProUGUI railcannonLoreName = GetTextMeshProUGUI(GetGameObjectChild(railcannonLore, "Name"));
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

                TextMeshProUGUI railcannonLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Button"), "Text"));
                railcannonLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon preset colors
                GameObject railcannonColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Color Screen");

                TextMeshProUGUI railcannonColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(railcannonColorWindow, "Title"));
                railcannonColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon + "--";

                GameObject railcannonStandardTemplates = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Standard"), "Template");
                TextMeshProUGUI railcannonStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                railcannonStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1;
                railcannonStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2;
                railcannonStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3;
                railcannonStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4;
                railcannonStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5;

                TextMeshProUGUI railcannonColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "TemplateButton"), "Text"));
                railcannonColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI railcannonColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "CustomButton"), "Text"));
                railcannonColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI railcannonColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Done"), "Text"));
                railcannonColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Railcannon custom colors
                GameObject railcannonStandardCustom = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Standard"), "Custom");
                TextMeshProUGUI railcannonStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardCustom, "TemplateButton"), "Text"));
                railcannonStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI railcannonStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardCustom, "CustomButton"), "Text"));
                railcannonStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Railcannon custom color unlock prompt
                TextMeshProUGUI railcannonCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));
                railcannonCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                // Rocket Launcher
                // Freezeframe(Blue)
                // S.R.S Cannon(Green)
                // Firestarter(Red)

                //Rocket launcher window & descriptions
                GameObject rocketlauncherWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Variation Screen");

                //Freezeframe
                GameObject freezeframe = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Blue)");
                TextMeshProUGUI freezeframeName = GetTextMeshProUGUI(GetGameObjectChild(freezeframe, "Variation Name"));
                freezeframeName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;

                GameObject freezeframeInfo = GetGameObjectChild(rocketlauncherWindow, "Variation Info (Blue)");
                TextMeshProUGUI freezeframeInfoTitle = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo, "Title"));
                freezeframeInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
                TextMeshProUGUI freezeframeDescription = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo, "Description"));
                freezeframeDescription.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2;
                freezeframeDescription.fontSize = 16;

                TextMeshProUGUI freezeframeDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(freezeframeInfo, "Button"), "Text"));
                freezeframeDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket Launcher green variation
                GameObject srsCannon = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Green)");
                TextMeshProUGUI srsCannonName = GetTextMeshProUGUI(GetGameObjectChild(srsCannon, "Variation Name"));
                srsCannonName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                
                GameObject srsCannonInfo = GetGameObjectChild(rocketlauncherWindow, "Variation Info (Green)");
                TextMeshProUGUI srsCannonInfoTitle = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo, "Title"));
                srsCannonInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                TextMeshProUGUI srsCannonInfoDescription = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo, "Description"));
                srsCannonInfoDescription.text =
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription1 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription2 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription3;
                srsCannonInfoDescription.fontSize = 16;

                TextMeshProUGUI srsCannonBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(srsCannonInfo, "Button"), "Text"));
                srsCannonBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Firestarter a.k.a Gasoline
                GameObject fireStarter = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Red)");
                TextMeshProUGUI fireStarterName = GetTextMeshProUGUI(GetGameObjectChild(fireStarter, "Variation Name"));
                fireStarterName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;

                GameObject fireStarterInfo = GetGameObjectChild(rocketlauncherWindow, "Variation Info (Red)");
                TextMeshProUGUI fireStarterInfoName = GetTextMeshProUGUI(GetGameObjectChild(fireStarterInfo, "Name"));
                fireStarterInfoName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;
                TextMeshProUGUI fireStarterInfoDescription = GetTextMeshProUGUI(GetGameObjectChild(fireStarterInfo, "Description"));
                fireStarterInfoDescription.text =
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription1 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription2;
                fireStarterInfoDescription.fontSize = 16;
                TextMeshProUGUI fireStarterBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fireStarterInfo, "Button"), "Text"));
                fireStarterBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Rocket launcher info & color tabs
                GameObject rocketlauncherExtra = GetGameObjectChild(rocketlauncherWindow, "Info and Color Panel");
                GameObject rocketlauncherExtraInfo = GetGameObjectChild(rocketlauncherExtra, "InfoButton");
                GameObject rocketlauncherExtraColor = GetGameObjectChild(rocketlauncherExtra, "ColorButton");

                TextMeshProUGUI rocketlauncherExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherExtraInfo, "Text"));
                rocketlauncherExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI rocketlauncherExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherExtraColor, "Text"));
                rocketlauncherExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Rocket launcher lore
                GameObject rocketlauncherLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Info Screen");
                TextMeshProUGUI rocketlauncherLoreName = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherLore, "Name"));
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
                
                TextMeshProUGUI rocketlauncherLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Button"), "Text"));
                rocketlauncherLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket launcher preset colors
                GameObject RLColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Color Screen");

                TextMeshProUGUI RLColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(RLColorWindow, "Title"));
                RLColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher + "--";

                GameObject RLStandardTemplates = GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Standard"), "Template");
                TextMeshProUGUI RLStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                RLStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1;
                RLStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2;
                RLStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3;
                RLStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4;
                RLStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5;

                TextMeshProUGUI RLColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "TemplateButton"), "Text"));
                RLColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI RLColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "CustomButton"), "Text"));
                RLColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI RLColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Done"), "Text"));
                RLColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Rocket launcher custom colors
                GameObject RLStandardCustom = GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Standard"), "Custom");
                TextMeshProUGUI RLStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardCustom, "TemplateButton"), "Text"));
                RLStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI RLStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardCustom, "CustomButton"), "Text"));
                RLStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Rocket launcher custom color unlock prompt
                TextMeshProUGUI RLCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                RLCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                // Arm
                // Feedbacker(Blue)
                // Knuckleblaster(Red)
                // Whiplash(Green)
                // ???(Yellow)

                //Arm window and descriptions
                GameObject armWindow = GetGameObjectChild(shopWeaponsObject, "ArmWindow");

                //Feedbacker
                GameObject feedbacker = GetGameObjectChild(armWindow, "Variation Panel 1 (New)");
                TextMeshProUGUI feedbackerName = GetTextMeshProUGUI(GetGameObjectChild(feedbacker, "Text"));
                feedbackerName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                GameObject feedbackerWindow = GetGameObjectChild(armWindow, "Variation 1 Info (New)");
                TextMeshProUGUI feedbackerWindowName = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow, "Name"));
                feedbackerWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                TextMeshProUGUI feedbackerWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow, "Description"));
                feedbackerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2;

                TextMeshProUGUI feedbackerWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(feedbackerWindow, "Button"), "Text"));
                feedbackerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Knuckleblaster
                GameObject knuckleblaster = GetGameObjectChild(armWindow, "Variation Panel 2 (New)");
                TextMeshProUGUI knuckleblasterName = GetTextMeshProUGUI(GetGameObjectChild(knuckleblaster, "Text"));
                knuckleblasterName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                GameObject knuckleblasterWindow = GetGameObjectChild(armWindow, "Variation 2 Info (New)");
                TextMeshProUGUI knuckleblasterWindowName = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow, "Name"));
                knuckleblasterWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                TextMeshProUGUI knuckleblasterWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow, "Description"));
                knuckleblasterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2;

                TextMeshProUGUI knuckleblasterWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(knuckleblasterWindow, "Button"), "Text"));
                knuckleblasterWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Whiplash
                GameObject whiplash = GetGameObjectChild(armWindow, "Variation Panel 3 (New)");
                TextMeshProUGUI whiplashName = GetTextMeshProUGUI(GetGameObjectChild(whiplash, "Text"));
                whiplashName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                GameObject whiplashWindow = GetGameObjectChild(armWindow, "Variation 3 Info (New)");
                TextMeshProUGUI whiplashWindowName = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow, "Name"));
                whiplashWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                TextMeshProUGUI whiplashWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow, "Description"));
                whiplashWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2;
                whiplashWindowDescription.fontSize = 16;
                
                TextMeshProUGUI whiplashWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(whiplashWindow, "Button"), "Text"));
                whiplashWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Gold arm (under construction)
                GameObject goldArm = GetGameObjectChild(armWindow, "Variation Panel 1 (3)");
                TextMeshProUGUI goldArmUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(goldArm, "Text (1)"));
                goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;
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
