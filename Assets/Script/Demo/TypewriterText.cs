using UnityEngine;
using UnityEngine.UI; // Imageコンポーネントのために必要
using TMPro;
using System.Collections;

public class TypewriterText : MonoBehaviour
{
    public static TypewriterText Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI textUI; // 表示するText UI
    [SerializeField] private float characterDelay; // 一文字表示する間隔（秒）
    [SerializeField] private RectTransform samuraiRectTransform; // サムライのUI画像
    [SerializeField] private Image samuraiImage; // サムライの顔画像
    [SerializeField] private Sprite normalFaceSprite; // 通常時の顔画像
    [SerializeField] private Sprite happyFaceSprite; // 笑顔の画像
    [SerializeField] private Sprite sadFaceSprite; // 悲しい顔の画像
    private Coroutine currentCoroutine;
    private bool isInterruptible = true; // 現在の処理が割り込み可能かどうか

    private void Awake()
    {
        // シングルトンの設定
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void DisplayInterruptibleText(string message)
    {
        StartNewCoroutine(() => TypeText(message));
    }

    public void DisplayNonInterruptibleText(string message)
    {
        isInterruptible = true;
        StartNewCoroutine(() => TypeText(message));
        isInterruptible = false;
    }

    public void DisplayInterruptibleListText(string[] messages, float seconds)
    {
        StartNewCoroutine(() => TypeListText(messages, seconds));
    }

    private void StartNewCoroutine(System.Func<IEnumerator> coroutineMethod)
    {
        if (currentCoroutine != null)
        {
            if (isInterruptible)
            {
                StopCoroutine(currentCoroutine);
            }
            else
            {
                Debug.LogWarning("現在のテキスト表示が割り込み不可のため、新しいテキストを表示できません。");
                return;
            }
        }
        currentCoroutine = StartCoroutine(coroutineMethod());
    }

    private IEnumerator TypeText(string message)
    {
        textUI.text = ""; // 表示をリセット
        foreach (char c in message)
        {
            textUI.text += c; // 一文字追加
            yield return new WaitForSeconds(characterDelay); // 一文字ごとに待機
        }

        currentCoroutine = null;
        isInterruptible = true;
    }

    private IEnumerator TypeListText(string[] messages, float seconds)
    {
        foreach (string message in messages)
        {
            textUI.text = "";
            foreach (char c in message)
            {
                textUI.text += c; // 一文字追加
                yield return new WaitForSeconds(characterDelay); // 一文字ごとに待機
            }
            yield return new WaitForSeconds(seconds);
        }

        currentCoroutine = null;
        isInterruptible = true;
    }

    /// <summary>
    /// サムライの顔を笑顔に変更
    /// </summary>
    public void ChangeFaceToHappy()
    {
        if (samuraiImage != null && happyFaceSprite != null)
        {
            samuraiImage.sprite = happyFaceSprite;
        }

        // 1秒後に通常顔に戻す
        Invoke("ChangeFaceToNormal", 1);
    }

    /// <summary>
    /// サムライの顔を悲しい顔に変更
    /// </summary>
    public void ChangeFaceToSad()
    {
        if (samuraiImage != null && sadFaceSprite != null)
        {
            samuraiImage.sprite = sadFaceSprite;
        }

        // 1秒後に通常顔に戻す
        Invoke("ChangeFaceToNormal", 1);
    }

    /// <summary>
    /// サムライの顔を通常顔に変更
    /// </summary>
    public void ChangeFaceToNormal()
    {
        if (samuraiImage != null && normalFaceSprite != null)
        {
            samuraiImage.sprite = normalFaceSprite;
        }
    }
}
