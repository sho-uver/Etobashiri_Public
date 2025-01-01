using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class NGWordFilter : MonoBehaviour
{
    public List<string> ngWords = new List<string>();
    private bool isTitleDataLoaded = false;

    void Start()
    {
        // Title DataからNGワードリストを取得
        GetTitleData();
    }

    // DisplayNameにNGワードが含まれるかをチェックし、コールバックで結果を返す
    public void CheckNGWord(string displayName, System.Action<bool> callback)
    {
        if (!isTitleDataLoaded)
        {
            Debug.LogWarning("NG words list has not been loaded yet.");
            callback(false);
            Debug.Log(ngWords);
            return;
        }
        Debug.Log(ngWords);
        bool isNGWord = ContainsNGWord(displayName);
        callback(isNGWord);
    }

    // Title DataからNGワードリストを取得するメソッド
    void GetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataSuccess, OnTitleDataError);
    }

    void OnTitleDataSuccess(GetTitleDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("NGWords"))
        {
            // JSON形式のNGワードリストをパース
            var ngWordsJson = result.Data["NGWords"];
            var ngWordsData = JsonUtility.FromJson<NGWordsList>(ngWordsJson);
            ngWords = new List<string>(ngWordsData.words);
        }

        // Title Data取得完了を通知
        isTitleDataLoaded = true;
    }

    void OnTitleDataError(PlayFabError error)
    {
        Debug.LogError("Failed to get Title Data: " + error.GenerateErrorReport());
    }

    // DisplayNameにNGワードが含まれるか確認するメソッド
    bool ContainsNGWord(string displayName)
    {
        foreach (var word in ngWords)
        {
            if (displayName != null && displayName.Contains(word))
            {
                return true;
            }
        }
        return false;
    }
}

// Title Data用のNGワードリストクラス
[System.Serializable]
public class NGWordsList
{
    public string[] words;
}
