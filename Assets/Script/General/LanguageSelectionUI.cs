using UnityEngine;
using UnityEngine.UI; // UIコンポーネント用
using UnityEngine.Localization; // Localization用
using UnityEngine.Localization.Settings; // 言語切り替え用

public class LanguageSelectionUI : MonoBehaviour
{
    private Dropdown languageDropdown;

    void Start()
    {
        // ドロップダウンメニューの作成
        CreateLanguageDropdown();
        
        // 初期化時に現在の言語を設定
        InitializeLanguage();
    }

    void CreateLanguageDropdown()
    {
        // Canvasの設定
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // ドロップダウンメニューを作成
        GameObject dropdownGO = new GameObject("LanguageDropdown");
        dropdownGO.transform.SetParent(canvasGO.transform);
        
        RectTransform dropdownRect = dropdownGO.AddComponent<RectTransform>();
        dropdownRect.sizeDelta = new Vector2(200, 40);
        dropdownRect.localPosition = new Vector3(0, 0, 0);

        languageDropdown = dropdownGO.AddComponent<Dropdown>();

        // ドロップダウンの選択肢を設定
        var options = new Dropdown.OptionDataList();
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            options.options.Add(new Dropdown.OptionData(locale.Identifier.CultureInfo.DisplayName));
        }
        languageDropdown.options = options.options;

        // 言語を選択したときのコールバック
        languageDropdown.onValueChanged.AddListener(delegate {
            OnLanguageSelected(languageDropdown.value);
        });
    }

    void InitializeLanguage()
    {
        // 現在のロケールを取得してドロップダウンに反映
        Locale currentLocale = LocalizationSettings.SelectedLocale;
        int index = LocalizationSettings.AvailableLocales.Locales.IndexOf(currentLocale);
        languageDropdown.value = index;
    }

    // 言語選択時に呼ばれるメソッド
    void OnLanguageSelected(int index)
    {
        // 選択された言語に切り替え
        var selectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        LocalizationSettings.SelectedLocale = selectedLocale;
        Debug.Log("Language changed to: " + selectedLocale.Identifier.CultureInfo.DisplayName);
    }
}
