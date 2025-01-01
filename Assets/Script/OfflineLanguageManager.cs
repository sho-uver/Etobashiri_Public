using System.Collections.Generic;
using UnityEngine;

public class OfflineLanguageManager : MonoBehaviour
{
    private string currentLanguage = "ja"; // デフォルトの言語を設定
    private Dictionary<string, Localization> languageData;

    void Start()
    {
        Debug.Log("言語1");
        LoadLanguageData();
        ApplyLanguage();
        Debug.Log("言語2");
    }

    void LoadLanguageData()
    {
        // JSONファイルをResourcesから読み込み
        TextAsset jsonText = Resources.Load<TextAsset>("languages");
        if (jsonText != null)
        {
            // JSONを直接Dictionaryに変換
            var loadedData = JsonUtility.FromJson<LanguageDataWrapper>(jsonText.text);
            if (loadedData != null)
            {
                languageData = loadedData.languages;
                Debug.Log("言語3");
            }
            else
            {
                Debug.LogError("Failed to parse JSON data.");
            }
        }
        else
        {
            Debug.LogError("Language data not found!");
        }
    }

    void ApplyLanguage()
    {
        // 言語データを適用
        if (languageData == null)
        {
            Debug.LogError("Language data is null!");
            return;
        }

        if (!languageData.ContainsKey(currentLanguage))
        {
            Debug.LogError($"Language data does not contain key: {currentLanguage}");
            return;
        }

        var localizedText = languageData[currentLanguage];
        if (localizedText == null)
        {
            Debug.LogError("Localized text is null!");
            return;
        }

        Debug.Log($"Hello: {localizedText.HELLO}");
        Debug.Log($"Goodbye: {localizedText.GOODBYE}");
        Debug.Log("言語4");
    }
}

// JSONを読み込むためのクラス
[System.Serializable]
public class LanguageDataWrapper
{
    public Dictionary<string, Localization> languages;

    public static LanguageDataWrapper FromJson(string jsonData)
    {
        return JsonUtility.FromJson<LanguageDataWrapper>(jsonData);
    }
}

[System.Serializable]
public class Localization
{
    public string HELLO;
    public string GOODBYE;
}
