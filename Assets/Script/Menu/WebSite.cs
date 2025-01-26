using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Linq;

public class WebSite : MonoBehaviour
{
    [System.Serializable]
    private class LocalizedUrl
    {
        public string localeCode;
        public string url;
    }

    [SerializeField]
    private LocalizedUrl[] localizedUrls = new LocalizedUrl[]
    {
        new LocalizedUrl { localeCode = "ja", url = "https://hisho-game.heavy.jp/2025/01/03/hisho_omoshiro_game/" },
        new LocalizedUrl { localeCode = "en", url = "https://hisho-game.heavy.jp/2025/01/25/lets-play-hisho-game/" }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoWebSite()
    {
        PlayerPrefs.SetInt("WebSite", PlayerPrefs.GetInt("WebSite", 0) + 1);
        PlayfabManager.Instance.SendCount_WebSite(PlayerPrefs.GetInt("WebSite", 0));
        OpenWebsite();
    }

    private void OpenWebsite()
    {
        string currentLocaleCode = LocalizationSettings.SelectedLocale.Identifier.Code;
        string url = localizedUrls.FirstOrDefault(x => x.localeCode == currentLocaleCode)?.url
            ?? localizedUrls.FirstOrDefault(x => x.localeCode == "en")?.url
            ?? localizedUrls[0].url;

        Application.OpenURL(url);
    }
}
