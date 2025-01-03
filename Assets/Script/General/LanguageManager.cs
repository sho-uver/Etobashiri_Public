using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using System.Collections;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SetLanguage(string lang)
    {
        yield return LocalizationSettings.InitializationOperation; // 初期化を待つ
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(lang);
    }
    public void Ja()
    {
        StartCoroutine(SetLanguage("ja"));
    }

    public void En()
    {
        StartCoroutine(SetLanguage("en"));
    }
}
