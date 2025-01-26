using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager Instance { get; private set; }

    [SerializeField] private string leaderboardName = "Ranking_2024";
    private const string SessionTicketKey = "PlayFabSessionTicket";

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

    public void CheckLoginStatusAndLogin(Action onSuccess, Action<PlayFabError> onFailure)
    {
        // PlayFabが既にログイン済みかどうかをチェック
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            Debug.Log("既にログイン済みです。");
            onSuccess?.Invoke(); // 既にログイン済みなら成功コールバックを実行
        }
        else
        {
            Debug.Log("ログインが必要です。ログインを開始します。");
            LoginWithDeviceId(onSuccess, onFailure);
        }
    }


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
            onSuccess?.Invoke(); // 成功時のコールバックを実行
        },
        error =>
        {
            Debug.LogError("PlayFabへのログインに失敗しました: " + error.GenerateErrorReport());
            onFailure?.Invoke(error);
        });
    }


    public void SetDisplayName(string playerName, Action onSuccess, Action<PlayFabError> onFailure)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playerName
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, result =>
        {
            Debug.Log("プレイヤー名の設定に成功しました: " + result.DisplayName);
            if (playerName.Length > 1 && playerName.Length < 11)
            {

                PlayerPrefs.SetString("Name", result.DisplayName);
                onSuccess?.Invoke();
            }
            else
            {
                Debug.Log("プレイヤー名は10文字以内にしてください");
            }
        },
        error =>
        {
            Debug.LogError("プレイヤー名の設定に失敗しました: " + error.GenerateErrorReport());
            onFailure?.Invoke(error);
        });
    }

    public void SendScore(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = leaderboardName,
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, result =>
        {
            Debug.Log("スコアの送信に成功しました。");
        },
        error =>
        {
            Debug.LogError("スコアの送信に失敗しました: " + error.GenerateErrorReport());
        });
    }

    public void GetLeaderboard(Action<List<PlayerLeaderboardEntry>> onSuccess, Action<string> onFailure)
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = leaderboardName,
            StartPosition = 0,
            MaxResultsCount = 100
        };

        PlayFabClientAPI.GetLeaderboard(request, result =>
        {
            Debug.Log("ランキングの取得に成功しました。");
            onSuccess?.Invoke(result.Leaderboard);
        },
        error =>
        {
            Debug.LogError("ランキングの取得に失敗しました: " + error.GenerateErrorReport());
            onFailure?.Invoke(error.GenerateErrorReport());
        });
    }
    public void SendPlayCount(int playCount)
    {
        // まず現在のプレイ回数を取得
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            // 新しいプレイ回数を更新
            var updateRequest = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                { "PlayCount", playCount.ToString() }
                }
            };
        },
        error =>
        {
            Debug.LogError("プレイ回数の取得に失敗しました: " + error.GenerateErrorReport());
        });
    }
    public void GetDisplayName(Action<string> onSuccess, Action<PlayFabError> onFailure)
    {
        var request = new GetAccountInfoRequest();

        PlayFabClientAPI.GetAccountInfo(request, result =>
        {
            string displayName = result.AccountInfo.TitleInfo.DisplayName;
            Debug.Log("プレイヤー名の取得に成功しました: " + displayName);
            onSuccess?.Invoke(displayName);
        },
        error =>
        {
            Debug.LogError("プレイヤー名の取得に失敗しました: " + error.GenerateErrorReport());
            onFailure?.Invoke(error);
        });
    }

    public void SendCount_WebSite(int count)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "WebSite",
                    Value = count
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, result =>
                {
                    Debug.Log("スコアの送信に成功しました。");
                },
                error =>
                {
                    Debug.LogError("スコアの送信に失敗しました: " + error.GenerateErrorReport());
                });
    }

}
