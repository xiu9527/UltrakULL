using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;
using System.Linq;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public static class InjectLanguageButton
    {
        public static TextMeshProUGUI languageButtonText;
        public static TextMeshProUGUI languageButtonTitleText;
        private static readonly HttpClient Client = new HttpClient();
        
        private static bool hasAlreadyFetchedLanguages = false;
        private static List<GameObject> languageButtons = new List<GameObject>();
        
        private static GameObject langBrowserPage;
        private static GameObject langLocalPage;
        private static GameObject redownloadConfirmPanel;
        
        public static bool langFileLocallyExists(string languageTag)
        {
            string expectedFileLocation = Path.Combine(BepInEx.Paths.ConfigPath, "ultrakull", languageTag + ".json");
            return File.Exists(expectedFileLocation);
        }

        public static void updateLanguageButtonText()
        {
            languageButtonText.text = LanguageManager.CurrentLanguage.options.language_languages;
            languageButtonTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_title + "--";
        }
        
        public static void warnBeforeDownload(LanguageInfo lInfo)
        {
            GameObject difficultySelectMenu = GetGameObjectChild(GetInactiveRootObject("Canvas"),"Difficulty Select (1)");

            GameObject panelToUse = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Canvas"),"OptionsMenu"),"Assist Options"),"Panel");
            
            if(redownloadConfirmPanel == null)
            {
                redownloadConfirmPanel = GameObject.Instantiate(panelToUse,difficultySelectMenu.transform.parent);
            }

            redownloadConfirmPanel.name = "ConfirmDownloadPanel";
            
            Text confirmDownloadText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"Text (2)"));
            
            confirmDownloadText.fontSize = 22;
            confirmDownloadText.text =
            "This language has already been downloaded. <color=#34e1eb>Redownload?</color>\n\n" 
                +"<color=orange>The current file's contents will be overwritten.</color>";

            Text confirmDownloadTextConfirm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"Text (1)"));
            confirmDownloadTextConfirm.text = "";
            
            //Destroy the original buttons and replace them with new ones (at least until I can figure out how to change the listeners of the original buttons)
            GameObject origYes = GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"Yes");
            GameObject origNo = GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"No");
            origYes.SetActive(false);
            origNo.SetActive(false);
            
            //Make new buttons here
            GameObject DownloadYes = CreateButton("YES","DownloadYes");
            DownloadYes.name = "DownloadYes";
            DownloadYes.transform.position = new Vector3(1150, 300, 0);
            DownloadYes.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(300f, 50f);
            DownloadYes.GetComponentInChildren<Text>().text = "YES";
            DownloadYes.GetComponentInChildren<Text>().font = Core.GlobalFont;
            DownloadYes.transform.SetParent(redownloadConfirmPanel.transform);
            
            GameObject DownloadNo = CreateButton("NO","DownloadNo");
            DownloadNo.name = "DownloadNo";
            DownloadNo.transform.position = new Vector3(750, 300, 0);
            DownloadNo.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(300f, 50f);
            DownloadNo.GetComponentInChildren<Text>().text = "NO";
            DownloadNo.GetComponentInChildren<Text>().font = Core.GlobalFont;
            DownloadNo.transform.SetParent(redownloadConfirmPanel.transform);
            
            DownloadYes.GetComponentInChildren<Button>().onClick.AddListener(delegate { redownloadConfirmPanel.SetActive(false); downloadLanguageFile(lInfo.languageTag,lInfo.languageFullName); });
            DownloadNo.GetComponentInChildren<Button>().onClick.AddListener(delegate { redownloadConfirmPanel.SetActive(false); });
            
            redownloadConfirmPanel.SetActive(true);
        }

        public async static Task getOnlineLanguages(Transform parent, GameObject languagePage)
        {
            string masterLanguageUrl = "https://clearwateruk.github.io/mods/ultrakULL/languagesMaster.json";
            Transform navigationRail = GameObject.Find("Navigation Rail").transform;
            Button referenceButton = navigationRail.GetComponentsInChildren<Button>().FirstOrDefault();
            Transform pagesParent = GameObject.Find("Pages").transform;
            Transform referencePage = pagesParent.transform.Find("General");
            Scrollbar referenceScrollbar = referencePage.GetComponentsInChildren<Scrollbar>().FirstOrDefault();

            if (langBrowserPage.transform.Find("Title") == null)
            {
                langBrowserPage = new GameObject("LanguageBrowserPage", typeof(RectTransform), typeof(CanvasRenderer));
                langBrowserPage.transform.SetParent(parent, false);
                RectTransform pageRect = langBrowserPage.GetComponent<RectTransform>();
                pageRect.sizeDelta = new Vector2(600, 800);        

                // Title
                GameObject titleObject = new GameObject("Title", typeof(TextMeshProUGUI));
                titleObject.transform.SetParent(langBrowserPage.transform, false);
                TextMeshProUGUI langBrowserTitle = titleObject.GetComponent<TextMeshProUGUI>();
                langBrowserTitle.text = "--LANGUAGE BROWSER--";
                langBrowserTitle.alignment = TextAlignmentOptions.Center;
                langBrowserTitle.fontSize = 24;
                langBrowserTitle.font = Core.GlobalFontTMP;

                RectTransform titleRect = langBrowserTitle.rectTransform;
                titleRect.anchorMin = new Vector2(0.5f, 1);
                titleRect.anchorMax = new Vector2(0.5f, 1);
                titleRect.pivot = new Vector2(0.5f, 1);
                titleRect.anchoredPosition = new Vector2(0, -50);
                titleRect.sizeDelta = new Vector2(400, 50);

                // ScrollView
                GameObject scrollView = new GameObject("ScrollView", typeof(RectTransform), typeof(ScrollRect), typeof(Image), typeof(Mask));
                scrollView.transform.SetParent(langBrowserPage.transform, false);
                RectTransform scrollRect = scrollView.GetComponent<RectTransform>();
                scrollRect.anchorMin = new Vector2(0.5f, 0.5f);
                scrollRect.anchorMax = new Vector2(0.5f, 0.5f);
                scrollRect.pivot = new Vector2(0.5f, 0.5f);
                scrollRect.anchoredPosition = new Vector2(0, 0);
                scrollRect.sizeDelta = new Vector2(550, 600);
                scrollView.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
                scrollView.GetComponent<Mask>().showMaskGraphic = false;

                // ScrollRect settings to limit side-to-side scrolling
                ScrollRect scrollRectComponent = scrollView.GetComponent<ScrollRect>();
                scrollRectComponent.horizontal = false;
                scrollRectComponent.vertical = true;
                scrollRectComponent.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;

                // Adding a scrollbar
                GameObject scrollbar = GameObject.Instantiate(referenceScrollbar.gameObject, langBrowserPage.transform);
                scrollbar.transform.SetParent(langBrowserPage.transform, false);
                RectTransform scrollbarRect = scrollbar.GetComponent<RectTransform>();

                Scrollbar scrollbarComponent = scrollbar.GetComponent<Scrollbar>();
                scrollbarComponent.direction = Scrollbar.Direction.BottomToTop;
                scrollRectComponent.verticalScrollbar = scrollbarComponent;

                // Content Container
                GameObject content = new GameObject("Content", typeof(RectTransform), typeof(VerticalLayoutGroup), typeof(ContentSizeFitter));
                content.transform.SetParent(scrollView.transform, false);
                RectTransform contentRect = content.GetComponent<RectTransform>();
                contentRect.anchorMin = new Vector2(0, 1);
                contentRect.anchorMax = new Vector2(1, 1);
                contentRect.pivot = new Vector2(0.5f, 1);
                contentRect.anchoredPosition = Vector2.zero;
                contentRect.sizeDelta = new Vector2(0, 0);

                VerticalLayoutGroup vGroup = content.GetComponent<VerticalLayoutGroup>();
                vGroup.spacing = 10;
                vGroup.childAlignment = TextAnchor.UpperCenter;
                vGroup.childForceExpandWidth = true;
                vGroup.childForceExpandHeight = false;
                vGroup.childControlWidth = true;
                vGroup.childControlHeight = true;

                ContentSizeFitter fitter = content.GetComponent<ContentSizeFitter>();
                fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

                scrollView.GetComponent<ScrollRect>().content = contentRect;

                try
                {
                    Logging.Warn("Obtaining online languages from UltrakULL repo...");
                    string responseJsonRaw = await Client.GetStringAsync(masterLanguageUrl);
                    MasterLanguages responseJson = JsonConvert.DeserializeObject<MasterLanguages>(responseJsonRaw);

                    foreach (LanguageInfo langInfo in responseJson.availableLanguages)
                    {
                        GameObject langButtonObj = GameObject.Instantiate(referenceButton.gameObject, content.transform);
                        langButtonObj.name = langInfo.languageTag + " " + langInfo.languageFullName;
                        langButtonObj.transform.SetParent(content.transform, false);

                        Button langButton = langButtonObj.GetComponent<Button>();
                        langButton.onClick = new Button.ButtonClickedEvent();
                        langButton.onClick.AddListener(() => downloadLanguageFile(langInfo.languageTag, langInfo.languageFullName));

                        // Setting the RectTransform of the button
                        RectTransform buttonRect = langButtonObj.GetComponent<RectTransform>();
                        buttonRect.sizeDelta = new Vector2(250f, 60f);

                        // Customising the text of the button
                        TextMeshProUGUI textComponent = langButtonObj.GetComponentInChildren<TextMeshProUGUI>();
                        textComponent.text = langInfo.languageFullName;
                        textComponent.alignment = TextAlignmentOptions.Center;
                        textComponent.enableAutoSizing = true;
                        textComponent.fontSizeMin = 10f;
                        textComponent.fontSizeMax = 36f;
                    }
                }
                catch (Exception e)
                {
                    Logging.Error("Error loading languages: " + e);
                }

                // The "Return" button
                GameObject backButtonObj = GameObject.Instantiate(referenceButton.gameObject, content.transform);
                backButtonObj.name = "Return from LanguageBrowserPage";
                backButtonObj.transform.SetParent(content.transform, false);
                backButtonObj.GetComponent<Image>().color = Color.red;

                Button backButton = backButtonObj.GetComponent<Button>();
                backButton.onClick.AddListener(() =>
                {
                    foreach (Transform page in pagesParent)
                    {
                        page.gameObject.SetActive(false);
                    }
                    langBrowserPage.SetActive(false);
                    languagePage.SetActive(true);
                });

                // Setting the RectTransform of the "Return" button
                RectTransform backButtonRect = backButtonObj.GetComponent<RectTransform>();
                backButtonRect.sizeDelta = new Vector2(250f, 60f);

                // Customising the text of the "Return" button
                TextMeshProUGUI backButtonTextComponent = backButtonObj.GetComponentInChildren<TextMeshProUGUI>();
                backButtonTextComponent.text = "Return";
                backButtonTextComponent.alignment = TextAlignmentOptions.Center;
                backButtonTextComponent.enableAutoSizing = true;
                backButtonTextComponent.fontSizeMin = 10f;
                backButtonTextComponent.fontSizeMax = 36f;


                Logging.Message("Setting up navigation buttons to hide language browser page...");
                foreach (Transform child in navigationRail)
                {
                    if (child.name != "Saves")
                    {
                        Button navButton = child.GetComponent<Button>();
                        if (navButton != null)
                        {
                            navButton.onClick.AddListener(() =>
                            {
                                if (langBrowserPage.activeSelf)
                                {
                                    Logging.Message("Hiding Language Browser Page as another button was clicked: " + child.name);
                                    langBrowserPage.SetActive(false);
                                }
                            });
                        }
                    }
                }
            }
        }






        public static void downloadLanguageFile(string languageTag, string languageName)
        {
            MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=orange>DOWNLOADING...</color>");
            
            string fileName = languageTag + ".json";

            string languageFileUrl = "https://clearwateruk.github.io/mods/ultrakULL/" + fileName;
            
            string localLanguageFolder = Path.Combine(BepInEx.Paths.ConfigPath, "ultrakull//");
            
            string fullPath = localLanguageFolder + fileName;
            
            Logging.Warn("Downloading to: " + fullPath);
            
            Client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            Client.Timeout = TimeSpan.FromSeconds(5);
            
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string messageNotif;
                    bool newLangDownloaded = false;
              
                    //If the file was simply updated, it can be used straightaway.
                    //If a new lang file was downloaded, display a notif to the user to enter a level or reload the menu.
                    if(langFileLocallyExists(languageTag))
                    {
                        messageNotif = "Language file \"" + languageName + "\" has been updated.";
                    }
                    else
                    {
                        messageNotif = "A new language file \"" + languageName + "\" has been downloaded.";
                        newLangDownloaded = true;
                    }

                    webClient.DownloadFile(languageFileUrl, fullPath);
                    string jsonFile = File.ReadAllText(fullPath);
                    JsonFormat file = JsonConvert.DeserializeObject<JsonFormat>(jsonFile);
                    
                    Logging.Info("Lang file saved.");
                       
                    
                    MonoSingleton<HudMessageReceiver>.Instance.ClearMessage();
                    MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=green>" + messageNotif + "</color>");

                    if(newLangDownloaded)
                    {

                        LanguageManager.allLanguages.Add(languageTag, file);
                        
                        
                        Transform optionsParent = GetGameObjectChild(GetInactiveRootObject("Canvas"),"OptionsMenu").transform;
                        GameObject languageButtonPrefab = optionsParent.Find("Save Slots").Find("Grid").Find("Slot Row").gameObject;
                        addLocalLanguageToLocalList(ref languageButtonPrefab, file.metadata.langName,true);
                    }
                }
            }
            catch(Exception e)
            {
                MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=red>A download error occured, file has not been saved.</color>");
                Logging.Error("Attempted to download from: " + languageFileUrl);
                Logging.Error(e.ToString());
            }

        }
        
        public static void addLocalLanguageToLocalList(ref GameObject languageButtonPrefab, string language, bool newlyAdded=false)
        {
            Transform contentParent = langLocalPage.transform.Find("Scroll Rect (1)").Find("Contents");

            GameObject languageButtonInstance = GameObject.Instantiate(languageButtonPrefab,contentParent);
            languageButtonInstance.name = language;
            
            languageButtonInstance.GetComponent<RectTransform>().localScale = new Vector3(0.2188f, 1.1236f, 0.5089f);
            languageButtonInstance.transform.Find("Select Wrapper").gameObject.SetActive(false);
            languageButtonInstance.transform.Find("Delete Wrapper").gameObject.SetActive(false);
            languageButtonInstance.transform.Find("State Text").gameObject.SetActive(false);
            if(newlyAdded)
            {
                languageButtonInstance.transform.SetSiblingIndex(2);
            }
            GameObject.Destroy(languageButtonInstance.GetComponent<SlotRowPanel>());

            Transform slotTextTf = languageButtonInstance.transform.Find("Slot Text");
            slotTextTf.localScale = new Vector3(4.983107f, 0.970607f, 2.1431f);
            slotTextTf.localPosition = new Vector3(0f, 0f, 0f);
            TextMeshProUGUI slotText = slotTextTf.GetComponent<TextMeshProUGUI>();
            slotText.text = LanguageManager.allLanguages[language].metadata.langDisplayName;
            if(LanguageManager.CurrentLanguage.metadata.langName == language) {slotText.text += "\n(<color=green>Selected</color>)";}
            slotText.alignment = TextAlignmentOptions.Midline;
            slotText.fontSize = 16;
            
            Button langButton = languageButtonInstance.AddComponent<Button>();
            langButton.transition = Selectable.Transition.ColorTint;
            langButton.colors = new ColorBlock()
            {
                normalColor = new Color32(255, 255, 255, 255),
                highlightedColor = new Color32(255, 0, 0, 255),
                pressedColor = new Color32(255, 255, 0, 255),
                disabledColor = new Color32(255, 255, 0, 255),
                colorMultiplier = 1f,
                fadeDuration = 0.1f
            };
            langButton.targetGraphic = languageButtonInstance.transform.Find("Panel").GetComponent<Graphic>();
            
            langButton.onClick.AddListener(delegate
            {
                GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(contentParent.gameObject,LanguageManager.CurrentLanguage.metadata.langName),"Slot Text")).text = LanguageManager.CurrentLanguage.metadata.langDisplayName;

                GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(contentParent.gameObject,language),"Slot Text")).text += "\n(<color=green>Selected</color>)";

                LanguageManager.SetCurrentLanguage(language);
            });

            languageButtonInstance.SetActive(true);
        }

        public static bool Prefix(OptionsMenuToManager __instance)
        {
            
            hasAlreadyFetchedLanguages = false;
            languageButtons.Clear();

            if (GetCurrentSceneName() == "Main Menu")
            {
                Logging.Message("In main menu");
            }

            Logging.Message("Adding language option to options menu...");

            Transform optionsParent = __instance.optionsMenu.transform;
            Transform navigationRail = optionsParent.Find("Navigation Rail");
            Transform pagesParent = optionsParent.Find("Pages");
            Transform generalPage = pagesParent.Find("General");
            Transform generalScrollRect = generalPage.Find("Scroll Rect");
            Transform generalContents = generalScrollRect.Find("Contents");
            RectTransform generalScrollRectTransform = generalScrollRect.GetComponent<RectTransform>();
            RectTransform generalContentsTransform = generalContents.GetComponent<RectTransform>();


            Logging.Message("Creating language settings page...");
            GameObject languagePage = new GameObject("Language Page", typeof(RectTransform), typeof(CanvasRenderer));
            languagePage.transform.SetParent(pagesParent, false);
            languagePage.SetActive(false);
            RectTransform pageRect = languagePage.GetComponent<RectTransform>();
            pageRect.sizeDelta = new Vector2(600, 800);
            //languagePage.SetActive(false);


            // ScrollView
            GameObject scrollView = new GameObject("Scroll Rect", typeof(RectTransform), typeof(ScrollRect), typeof(Image), typeof(Mask));
            scrollView.transform.SetParent(languagePage.transform, false);
            RectTransform scrollRect = scrollView.GetComponent<RectTransform>();
            scrollRect.anchorMin = generalScrollRectTransform.anchorMin;
            scrollRect.anchorMax = generalScrollRectTransform.anchorMax;
            scrollRect.pivot = generalScrollRectTransform.pivot;
            scrollRect.anchoredPosition = generalScrollRectTransform.anchoredPosition;
            scrollRect.sizeDelta = generalScrollRectTransform.sizeDelta;
            scrollView.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            scrollView.GetComponent<Mask>().showMaskGraphic = false;

            // ScrollRect settings to limit side-to-side scrolling
            ScrollRect scrollRectComponent = scrollView.GetComponent<ScrollRect>();
            scrollRectComponent.horizontal = false; // Отключаем горизонтальную прокрутку
            scrollRectComponent.vertical = true; // Включаем вертикальную прокрутку
            scrollRectComponent.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;

            // Adding a scrollbar
            Transform referencePage = pagesParent.transform.Find("General");
            Scrollbar referenceScrollbar = referencePage.GetComponentsInChildren<Scrollbar>().FirstOrDefault();
            GameObject scrollbar = GameObject.Instantiate(referenceScrollbar.gameObject, languagePage.transform);
            scrollbar.transform.SetParent(languagePage.transform, false);
            RectTransform scrollbarRect = scrollbar.GetComponent<RectTransform>();

            Scrollbar scrollbarComponent = scrollbar.GetComponent<Scrollbar>();
            scrollbarComponent.direction = Scrollbar.Direction.BottomToTop;
            scrollRectComponent.verticalScrollbar = scrollbarComponent;

            // Content Container
            GameObject content = new GameObject("Contents", typeof(RectTransform), typeof(VerticalLayoutGroup), typeof(ContentSizeFitter));
            content.transform.SetParent(scrollView.transform, false);
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.anchorMin = generalContentsTransform.anchorMin;
            contentRect.anchorMax = generalContentsTransform.anchorMax;
            contentRect.pivot = generalContentsTransform.pivot;
            contentRect.anchoredPosition = generalContentsTransform.anchoredPosition;
            contentRect.sizeDelta = generalContentsTransform.sizeDelta;

            VerticalLayoutGroup vGroup = content.GetComponent<VerticalLayoutGroup>();
            vGroup.spacing = 10;
            vGroup.childAlignment = TextAnchor.UpperCenter;
            vGroup.childForceExpandWidth = true;
            vGroup.childForceExpandHeight = false;
            vGroup.childControlWidth = true;
            vGroup.childControlHeight = true;

            ContentSizeFitter fitter = content.GetComponent<ContentSizeFitter>();
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            scrollView.GetComponent<ScrollRect>().content = contentRect;

            GameObject titleObject = new GameObject("Title", typeof(TextMeshProUGUI));
            titleObject.transform.SetParent(content.transform, false);
            TextMeshProUGUI languagePageTitle = titleObject.GetComponent<TextMeshProUGUI>();
            languagePageTitle.text = "--" + LanguageManager.CurrentLanguage.options.language_languages + "--";
            languagePageTitle.alignment = TextAlignmentOptions.Center;
            languagePageTitle.fontSize = 24;
            languagePageTitle.font = Core.GlobalFontTMP;

            RectTransform titleRect = languagePageTitle.rectTransform;
            titleRect.anchorMin = new Vector2(0.5f, 1);
            titleRect.anchorMax = new Vector2(0.5f, 1);
            titleRect.pivot = new Vector2(0.5f, 1);
            titleRect.anchoredPosition = new Vector2(0, -50);
            titleRect.sizeDelta = new Vector2(400, 50);
            //VerticalLayoutGroup layoutGroup = languagePage.AddComponent<VerticalLayoutGroup>();
            //layoutGroup.spacing = 10f;
            //layoutGroup.childAlignment = TextAnchor.UpperCenter;

            //ContentSizeFitter fitter = languagePage.AddComponent<ContentSizeFitter>();
            //fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            //fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            //



            Logging.Message("Finding reference button for cloning...");
            Button referenceButton = navigationRail.GetComponentsInChildren<Button>().FirstOrDefault();
            if (referenceButton == null)
            {
                Logging.Warn("No reference button found in navigation rail! Aborting instantiation.");
                return true;
            }

            Logging.Message("Creating language menu button...");
            GameObject languageButton = GameObject.Instantiate(referenceButton.gameObject, navigationRail);
            languageButton.name = "Language";
            languageButton.transform.SetSiblingIndex(7);
            Button languageButtonComp = languageButton.GetComponent<Button>();
            languageButtonComp.onClick = new Button.ButtonClickedEvent();
            languageButtonComp.onClick.AddListener(() => ShowLanguagePage());
            languageButton.GetComponentInChildren<TextMeshProUGUI>().text = LanguageManager.CurrentLanguage.options.language_title;

            Logging.Message("Adding language selection buttons...");
            foreach (string language in LanguageManager.allLanguages.Keys)
            {
                GameObject langButton = GameObject.Instantiate(referenceButton.gameObject, content.transform);
                langButton.name = language;
                langButton.transform.SetParent(content.transform, false);
                Button langButtonComp = langButton.GetComponent<Button>();
                langButtonComp.onClick = new Button.ButtonClickedEvent();
                langButtonComp.onClick.AddListener(() => SelectLanguage(language));
                langButtonComp.colors = new ColorBlock()
                {
                    normalColor = new Color32(255, 255, 255, 255),
                    highlightedColor = new Color32(255, 0, 0, 255),
                    pressedColor = new Color32(255, 255, 0, 255),
                    disabledColor = new Color32(255, 255, 0, 255),
                    colorMultiplier = 1f,
                    fadeDuration = 0.1f
                };
                TextMeshProUGUI textComponent = langButton.GetComponentInChildren<TextMeshProUGUI>();
                
                textComponent.text = LanguageManager.allLanguages[language].metadata.langDisplayName;
                textComponent.alignment = TextAlignmentOptions.Center;
                textComponent.enableAutoSizing = true;
                textComponent.fontSizeMin = 10f;
                textComponent.fontSizeMax = 36f;

                RectTransform buttonRect = langButton.GetComponent<RectTransform>();
                buttonRect.sizeDelta = new Vector2(250f, 60f);
            }

            Logging.Message("Creating Open Language Folder button...");

            GameObject openLangFolder = GameObject.Instantiate(referenceButton.gameObject, content.transform);
            openLangFolder.name = "openLangFolder";
            openLangFolder.transform.SetParent(content.transform, false);
            Button openLangFolderComp = openLangFolder.GetComponent<Button>();
            openLangFolderComp.onClick = new Button.ButtonClickedEvent();
            openLangFolderComp.onClick.AddListener(() => Application.OpenURL(Path.Combine(BepInEx.Paths.ConfigPath, "ultrakull")));

            TextMeshProUGUI openLangFolderTextComponent = openLangFolder.GetComponentInChildren<TextMeshProUGUI>();

            openLangFolderTextComponent.text = "<color=#03fc07>" + LanguageManager.CurrentLanguage.options.language_openLanguageFolder + "</color>"; ;
            openLangFolderTextComponent.alignment = TextAlignmentOptions.Center;
            openLangFolderTextComponent.enableAutoSizing = true;
            openLangFolderTextComponent.fontSizeMin = 10f;
            openLangFolderTextComponent.fontSizeMax = 36f;

            RectTransform openLangFolderButtonRect = openLangFolder.GetComponent<RectTransform>();
            openLangFolderButtonRect.sizeDelta = new Vector2(250f, 60f);



            void ShowLanguagePage()
            {
                Logging.Message("Opening Language Settings Page...");
                foreach (Transform page in pagesParent)
                {
                    page.gameObject.SetActive(false);
                }
                languagePage.SetActive(true);
            }

            void SelectLanguage(string language)
            {
                Logging.Message("Selected language: " + language);
                LanguageManager.SetCurrentLanguage(language);
            }

            Logging.Message("Setting up navigation buttons to hide language page...");
            foreach (Transform child in navigationRail)
            {
                if (child.name != "Language" && child.name != "Saves")
                {
                    Button navButton = child.GetComponent<Button>();
                    if (navButton != null)
                    {
                        navButton.onClick.AddListener(() =>
                        {
                            if (languagePage.activeSelf)
                            {
                                Logging.Message("Hiding Language Page as another button was clicked: " + child.name);
                                languagePage.SetActive(false);
                            }
                        });
                    }
                }
            }

            Logging.Message("Creating language browser page...");
            langBrowserPage = new GameObject("LanguageBrowser", typeof(RectTransform));
            langBrowserPage.transform.SetParent(pagesParent, false);
            langBrowserPage.SetActive(false);

            VerticalLayoutGroup browserLayout = langBrowserPage.AddComponent<VerticalLayoutGroup>();
            browserLayout.spacing = 10f;
            browserLayout.childAlignment = TextAnchor.UpperCenter;

            Logging.Message("Creating Browse Online Languages button...");
            GameObject browseLangButtonObj = GameObject.Instantiate(referenceButton.gameObject, content.transform);
            browseLangButtonObj.name = "LangBrowser";
            browseLangButtonObj.transform.SetParent(content.transform, false);
            Button browseLangButton = browseLangButtonObj.GetComponent<Button>();
            browseLangButton.onClick = new Button.ButtonClickedEvent();
            browseLangButton.onClick.AddListener(() =>
            {
                languagePage.SetActive(false);
                langBrowserPage.SetActive(true);
                if (langBrowserPage.transform.Find("Title") == null) {
                    getOnlineLanguages(pagesParent, languagePage);
                }
            });

            TextMeshProUGUI browseLangButtonTextComponent = browseLangButtonObj.GetComponentInChildren<TextMeshProUGUI>();

            browseLangButtonTextComponent.text = "<color=#03fc07>→Browse langs online←</color>";
            browseLangButtonTextComponent.alignment = TextAlignmentOptions.Center;
            browseLangButtonTextComponent.enableAutoSizing = true;
            browseLangButtonTextComponent.fontSizeMin = 10f;
            browseLangButtonTextComponent.fontSizeMax = 36f;

            RectTransform browseLangButtonButtonRect = browseLangButtonObj.GetComponent<RectTransform>();
            browseLangButtonButtonRect.sizeDelta = new Vector2(250f, 60f);
            Logging.Info("Browse Language button added successfully.");
            return true;
        }

    }
}
