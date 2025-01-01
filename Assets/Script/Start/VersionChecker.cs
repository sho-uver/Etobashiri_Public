using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VersionChecker : MonoBehaviour
{
    public PlayFabLogin playFabLogin;  // PlayFabLoginのインスタンスを設定
    public GameObject updateBtn;
    public GameObject continueBtn;
    public Text message;
    private string latestVersionKey = "latestVersion";  // PlayFabのTitleDataに格納したキー
    public SceneChanger sceneChanger;
    public bool verCheckFlg;

    void Start()
    {
        // まずはPlayFabにログインしてからバージョンチェックを行う
        playFabLogin.CheckLoginStatusAndLogin(OnLoginSuccess, OnLoginFailure);
        StartCoroutine(ProceedToNextScreenAfterDelay());
    }

    private void OnLoginSuccess()
    {
        Debug.Log("ログインが成功しました。バージョンチェックを開始します。");
        verCheckFlg = true;
        CheckForUpdates();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("ログインに失敗しました。バージョンチェックをスキップします。");
        
        
    }

    void CheckForUpdates()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataReceived, OnError);
    }

    private void OnTitleDataReceived(GetTitleDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey(latestVersionKey))
        {
            string latestVersion = result.Data[latestVersionKey];
            string currentVersion = Application.version;  // アプリバージョンの直接取得

            Debug.Log($"最新バージョン: {latestVersion}, 現在のバージョン: {currentVersion}");

            if (IsUpdateRequired(currentVersion, latestVersion))
            {
                PromptUpdate();
            }
            else
            {
                sceneChanger.ChangeMenu();
            }
        }
    }

    private bool IsUpdateRequired(string currentVersion, string latestVersion)
    {
        // バージョン番号を比較 (例: 1.0.0形式)
        return string.Compare(currentVersion, latestVersion) < 0;
    }

    private void PromptUpdate()
    {
        // アップデートを促す処理
        message.text = "アップデートがあります。";
        updateBtn.SetActive(true);
        continueBtn.SetActive(true);
    }

    public void GoToStore()
    {
        // ここで、App StoreやGoogle Playのアップデートページへのリンクを表示したりします。
        #if UNITY_IOS
            Application.OpenURL("https://apps.apple.com/jp/app/えとばしり/id6470151998");
        #elif UNITY_ANDROID
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.HishoCompany.Chototsumoshin&pcampaignid=web_share");
        #endif
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError("PlayFabからTitleDataを取得中にエラーが発生しました: " + error.GenerateErrorReport());
    }

    private IEnumerator ProceedToNextScreenAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        if(!verCheckFlg){
            message.text = "通信できません。\nこのままあそぶと\n不具合が出る可能性があります。";
            continueBtn.SetActive(true);
        }
    }
}

