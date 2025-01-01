using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayFabLogin : MonoBehaviour
{
    // セッションチケットの保存キー
    private const string SessionTicketKey = "PlayFabSessionTicket";
    private const string PlayFabIdKey = "PlayFabId";

    // ログインが必要かどうかをチェックするメソッド
    public void CheckLoginStatusAndLogin(Action onSuccess, Action<PlayFabError> onFailure)
    {
        // PlayFabが既にログイン済みかどうかをチェック
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            Debug.Log("既にログイン済みです。");
            onSuccess?.Invoke();  // ログイン済みなら、すぐに成功コールバックを呼び出す
        }
        else
        {
            Debug.Log("ログインが必要です。ログインを開始します。");
            LoginWithDeviceId(onSuccess, onFailure);
        }
    }

    // PlayFabにログインする処理
    public void LoginWithDeviceId(Action onSuccess, Action<PlayFabError> onFailure)
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, result =>
        {
            Debug.Log("PlayFabへのログインに成功しました！");
            Debug.Log("Session Ticket: " + result.SessionTicket);

            // セッションチケットを保存
            PlayerPrefs.SetString(SessionTicketKey, result.SessionTicket);
            // PlayerPrefs.SetString(PlayFabIdKey, result.PlayFabId);
            onSuccess?.Invoke();
        },
        error =>
        {
            Debug.LogError("PlayFabへのログインに失敗しました: " + error.GenerateErrorReport());
            onFailure?.Invoke(error);
        });
    }
}
