using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.Localization.Settings;

using System.Text.RegularExpressions;

// ScrollViewにめっちゃいいhttps://www.youtube.com/watch?v=UZxxzeRGJxg
public class Login : MonoBehaviour
{
    const string STATISTICS_NAME = "Mugen_ver2.8";
    // public string ranking;
    public Text text;
    public TMP_InputField name;
    public string id;
    public string masterId;
    public string currentName;
    public Text nameCheckText;
    public GameObject nameChangeCanvas;
    public GameObject homeCanvas;
    public bool nameCheckFlg;
    public bool nameRequestFlg;
    private static readonly string ID_CHARACTERS = "0123456789abcdefghijklmnopqrstuvwxyz";
    public Text rankingText;
    public GameObject rankingSV;
    public bool firstLoginFlg;
    public Text bandukeText;
    public bool ngWordFlg;
    public GameObject InfCanvas;
    public GameObject InfMain;
    public GameObject developper;
    public GameObject termOfUse;
    public GameObject privacyPolicy;
    public GameObject contact;
    public GameObject faCanvas;
    public bool faCheck;
    public Toggle faToggle;
    public Text top10;
    public bool top10Flg;
    public int bandsukeChangeNum;
    string[] ngWords = new string[] { "AV", "dick", "drug", "fuck", "FUCK", "Gスポット", "gスポット", "ちんこ", "ちんぽ", "ちんちん", "チンチン", "ペニス", "Chinko", "Tinko", "まんこ", "マンコ", "オナニー", "マスターベーション", "セックス", "SEX", "sex", "あなる", "アナル", "アナニー", "インポ", "オメコ", "フェラ", "ふぇら", "イマラチオ", "クリトリス", "くりとりす", "殺", "開発者", "作成者", "製作者", "スカトロ", "てまん", "手マン", "中出し", "パイパン", "おっぱい", "オッパイ", "パイオツ", "ヤクザ", "レイプ", "巨根", "巨乳" }; // NGワードリスト
    public MenuSystem menuSystem;
    public int loginTry;
    public Sprite loginErrorImage;
    public SnapbarManager snapbarManager;
    public NGWordFilter ngWordFilter;

    public TextMeshProUGUI nameChangeMessage;
    private string tableName = "TextTable"; // Localizationテーブル名を指定


    void Start()
    {
        id = PlayerPrefs.GetString("ID", "No ID");
        currentName = PlayerPrefs.GetString("Name", "");
        // Debug.Log(id);
        // Debug.Log(currentName);
        // if(id == "No ID" || currentName == "")
        if (PlayerPrefs.GetInt("FirstLogin", 1) == 1)
        {
            FirstTimeLogin();
            OpenFirstAgreeCanvas();
            firstLoginFlg = true;
        }

        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = id, CreateAccount = true },
            result =>
            {
                Debug.Log("ログイン成功！");
                SubmitScore(PlayerPrefs.GetInt(STATISTICS_NAME, 0));
                masterId = result.PlayFabId;
                PlayerPrefs.SetString("MasterID", masterId);
                if (!firstLoginFlg)
                {
                    RequestLeaderBoardAroundPlayer();
                }
            },
            error =>
            {
                Debug.Log("ログイン失敗");
                StartCoroutine(LoginAgain(1));
            });

        if (!firstLoginFlg)
        {
            menuSystem.Login();
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // SubmitScore(400);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // RequestLeaderBoard();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            // SetPlayerDisplayName("ひまわり");
        }

        /* ここ削除
        if (nameCheckFlg && name.text != currentName)
        {
            currentName = name.text;
            NameCheck();
        }
        */
    }

    public void SubmitScore(int playerScore)
    {
        SetPlayerDisplayName(PlayerPrefs.GetString("Name", ""));
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = STATISTICS_NAME,

                        Value = playerScore
                    }
                }
            },
            result =>
            {
                Debug.Log("スコア送信");
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }

    public void CallSetPlayerDisplayName()
    {
        SetPlayerDisplayName(name.text);
    }

    public void SetPlayerDisplayName(string displayName)
    {

        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = displayName
            },
            result =>
            {
                Debug.Log("Set display name was succeeded.");
            },
            error =>
            {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }

    /*
    public void RequestLeaderBoard()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = STATISTICS_NAME,
                StartPosition = 0,
                MaxResultsCount = 10
            },
            result =>
            {
                /*
                result.Leaderboard.ForEach(
                    x => Debug.Log(string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue))
                    );
                */
    /*
    ranking = "";
    for (int i = 0; i < result.Leaderboard.Count; i++)
    {
        var x = result.Leaderboard[i];
        ranking += string.Format("{0}位:{1}:{2}点", x.Position + 1, x.DisplayName, x.StatValue) + "\n";
    };
    text.text = ranking;
},
error =>
{
    Debug.Log(error.GenerateErrorReport());
    RequestLeaderBoard();
}
);
}
*/
    public void BandsukeChange1()
    {
        RequestFriendLeaderBoard();

    }

    public void BandsukeChange2()
    {
        RequestLeaderBoardAroundPlayer();
    }

    public void RequestFriendLeaderBoard()
    {
        // yield return new WaitForSecondsRealtime(1);
        PlayFabClientAPI.GetFriendLeaderboardAroundPlayer(
            new GetFriendLeaderboardAroundPlayerRequest
            {
                StatisticName = STATISTICS_NAME,
                MaxResultsCount = 100
            },
            result =>
            {
                bandsukeChangeNum = 0;
                foreach (Transform child in rankingSV.transform)
                {
                    // Destroy children of rankingSV to clean up old leaderboard entries
                    Destroy(child.gameObject);
                }

                // Instantiate header text for the leaderboard
                Text header = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                header.text = "友達番付";
                header.transform.SetParent(rankingSV.transform, false);
                header.transform.localScale = new Vector3(1, 1, 1);

                // Loop through each leaderboard entry and instantiate UI elements to display them
                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                    var entry = result.Leaderboard[i];
                    string ranking = string.Format("{0}位 {1}点", entry.Position + 1, entry.StatValue);
                    // string rankingName = entry.DisplayName;
                    string rankingName = "";
                    ngWordFilter.CheckNGWord(entry.DisplayName, (isNG) =>
                    {
                        if (isNG)
                        {
                            Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                            rankingName = "クプアス";
                        }
                        else
                        {
                            Debug.Log("NGワードは含まれていません。");
                            if (entry.DisplayName != null)
                            {
                                rankingName = entry.DisplayName;
                            }
                            else
                            {
                                rankingName = "名無しのゴンベ";
                            }
                        }
                    });


                    // Instantiate and setup UI elements for rank and player name
                    Text rankText = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                    Text nameText = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);

                    rankText.text = ranking.ToUpper();
                    nameText.text = rankingName.ToUpper();

                    rankText.transform.SetParent(rankingSV.transform, false);
                    rankText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.transform.SetParent(rankingSV.transform, false);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                }
                ;
            },
            error =>
            {
                Debug.LogError(error.GenerateErrorReport());
                // Retry the leaderboard request in case of error
                RequestFriendLeaderBoard();
            }
        );
    }

    public void RequestLeaderBoardAroundPlayer()
    {
        PlayFabClientAPI.GetLeaderboardAroundPlayer(
            new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = STATISTICS_NAME,
                MaxResultsCount = 21
            },
            result =>
            {

                foreach (Transform child in rankingSV.transform)
                {
                    //自分の子供をDestroyする
                    Destroy(child.gameObject);
                }
                Text banduke = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                // banduke.text = "好敵手番付";
                banduke.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "RankingTitle");
                // banduke.transform.parent = rankingSV.transform;
                banduke.transform.SetParent(rankingSV.transform, false);
                banduke.transform.localScale = new Vector3(1, 1, 1);
                // Debug.Log(id);
                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                    if (result.Leaderboard[i].PlayFabId == masterId)
                    {
                        top10Flg = true;
                        break;
                    }
                }

                for (int i = 0; i < result.Leaderboard.Count; i++)
                {

                    string ranking = "";
                    string rankingName = "";
                    Text iremono;
                    Text iremonoName;
                    var x = result.Leaderboard[i];
                    ranking = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, "Ranking", arguments: new object[] { x.Position + 1, x.StatValue });
                    ranking.ToUpper();
                    // rankingName = string.Format("{0}", x.DisplayName);
                    ngWordFilter.CheckNGWord(x.DisplayName, (isNG) =>
                    {
                        if (isNG)
                        {
                            Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                            rankingName = "クプアス";
                        }
                        else
                        {
                            Debug.Log("NGワードは含まれていません。");
                            if (x.DisplayName != null)
                            {
                                rankingName = string.Format("{0}", x.DisplayName);
                            }
                            else
                            {
                                rankingName = "名無しのゴンベ";
                            }
                        }
                    });
                    rankingName.ToUpper();
                    iremono = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                    iremonoName = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                    iremono.text = ranking;
                    iremonoName.text = rankingName;
                    // iremono.transform.parent = rankingSV.transform;
                    iremono.transform.SetParent(rankingSV.transform, false);
                    iremono.transform.localScale = new Vector3(1, 1, 1);
                    iremonoName.transform.SetParent(rankingSV.transform, false);
                    iremonoName.transform.localScale = new Vector3(1, 1, 1);

                    if (result.Leaderboard[i].PlayFabId == masterId)
                    {
                        iremono.GetComponent<BandukeText>().SetRedFlg();
                        iremonoName.GetComponent<BandukeText>().SetRedFlg();
                    }

                }
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
                RequestLeaderBoardAroundPlayer_Top10();
            }
            );
    }

    public void RequestLeaderBoardAroundPlayer_Top10()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = STATISTICS_NAME,
                StartPosition = 0,
                MaxResultsCount = 100
            },
            result =>
            {

                foreach (Transform child in rankingSV.transform)
                {
                    //自分の子供をDestroyする
                    Destroy(child.gameObject);
                }
                Text banduke = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                // banduke.text = "好敵手番付";
                banduke.text = "番付";
                // banduke.transform.parent = rankingSV.transform;
                banduke.transform.SetParent(rankingSV.transform, false);
                banduke.transform.localScale = new Vector3(1, 1, 1);
                // Debug.Log(id);
                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                    // Debug.Log(result.Leaderboard[i].PlayFabId);
                    if (result.Leaderboard[i].PlayFabId == masterId)
                    {
                        top10Flg = true;

                        break;
                    }
                }
                if (top10Flg)
                {
                    for (int i = 0; i < result.Leaderboard.Count; i++)
                    {

                        string ranking = "";
                        string rankingName = "";
                        Text iremono;
                        Text iremonoName;
                        var x = result.Leaderboard[i];
                        ranking = string.Format("{0}位 {1}点", x.Position + 1, x.StatValue);
                        ranking.ToUpper();
                        // rankingName = string.Format("{0}", x.DisplayName);
                        ngWordFilter.CheckNGWord(x.DisplayName, (isNG) =>
                        {
                            if (isNG)
                            {
                                Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                                rankingName = "クプアス";
                            }
                            else
                            {
                                Debug.Log("NGワードは含まれていません。");
                                if (x.DisplayName != null)
                                {
                                    rankingName = string.Format("{0}", x.DisplayName);
                                }
                                else
                                {
                                    rankingName = "名無しのゴンベ";
                                }
                            }
                        });
                        rankingName.ToUpper();
                        iremono = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                        iremonoName = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                        iremono.text = ranking;
                        iremonoName.text = rankingName;
                        // iremono.transform.parent = rankingSV.transform;
                        iremono.transform.SetParent(rankingSV.transform, false);
                        iremono.transform.localScale = new Vector3(1, 1, 1);
                        iremonoName.transform.SetParent(rankingSV.transform, false);
                        iremonoName.transform.localScale = new Vector3(1, 1, 1);
                    }
                    ;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (result.Leaderboard.Count < 10 && i == 10)
                        {
                            break;
                        }
                        string ranking = "";
                        string rankingName = "";
                        Text iremono;
                        Text iremonoName;
                        var x = result.Leaderboard[i];
                        ranking = string.Format("{0}位 {1}点", x.Position + 1, x.StatValue);
                        ranking.ToUpper();
                        // rankingName = string.Format("{0}", x.DisplayName);
                        ngWordFilter.CheckNGWord(x.DisplayName, (isNG) =>
                        {
                            if (isNG)
                            {
                                Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                                rankingName = "クプアス";
                            }
                            else
                            {
                                Debug.Log("NGワードは含まれていません。");
                                if (x.DisplayName != null)
                                {
                                    rankingName = string.Format("{0}", x.DisplayName);
                                }
                                else
                                {
                                    rankingName = "名無しのゴンベ";
                                }
                            }
                        });
                        rankingName.ToUpper();
                        iremono = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                        iremonoName = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                        iremono.text = ranking;
                        iremonoName.text = rankingName;
                        // iremono.transform.parent = rankingSV.transform;
                        iremono.transform.SetParent(rankingSV.transform, false);
                        iremono.transform.localScale = new Vector3(1, 1, 1);
                        iremonoName.transform.SetParent(rankingSV.transform, false);
                        iremonoName.transform.localScale = new Vector3(1, 1, 1);
                    }
                    ;
                }

            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
                RequestLeaderBoardAroundPlayer_Top10();
            }
            );
    }

    public void Old_RequestLeaderBoardAroundPlayer()
    {
        RequestLeaderBoardAroundPlayer_Top10();

        // yield return new WaitForSecondsRealtime(1);
        PlayFabClientAPI.GetLeaderboardAroundPlayer(
            new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = STATISTICS_NAME,
                MaxResultsCount = 100, // Total results to fetch
                PlayFabId = null, // Null will automatically use the current player's ID
            },
            result =>
            {
                bandsukeChangeNum = 1;
                if (top10Flg)
                {
                    top10Flg = false;
                    // Debug.Log(top10Flg);
                    return;
                }
                /*
                foreach (Transform child in rankingSV.transform)
                {
                    
                    Destroy(child.gameObject);
                }
                */

                // Instantiate header text for the leaderboard
                Text header1 = Instantiate(top10, new Vector3(0, 0, 0), Quaternion.identity);
                header1.text = "　";
                // header.text = header.text.ToCenter();
                header1.transform.SetParent(rankingSV.transform, false);
                header1.transform.localScale = new Vector3(1, 1, 1);
                Text header2 = Instantiate(top10, new Vector3(0, 0, 0), Quaternion.identity);
                header2.text = "割愛・・・・・・";
                // header.text = header.text.ToCenter();
                header2.transform.SetParent(rankingSV.transform, false);
                header2.transform.localScale = new Vector3(1, 1, 1);
                Text header3 = Instantiate(top10, new Vector3(0, 0, 0), Quaternion.identity);
                header3.text = "　";
                // header.text = header.text.ToCenter();
                header3.transform.SetParent(rankingSV.transform, false);
                header3.transform.localScale = new Vector3(1, 1, 1);

                // Ensure the player appears at the 51st position by adjusting the starting index
                // int startIndex = Math.Max(0, result.Leaderboard.FindIndex(entry => entry.PlayFabId == PlayFabSettings.staticPlayer.PlayFabId) - 10);
                int startIndex = 10;

                // Loop through each leaderboard entry starting from the adjusted index and instantiate UI elements to display them
                // for (int i = startIndex; i < startIndex + 100 && i < result.Leaderboard.Count; i++)
                for (int i = startIndex; i < result.Leaderboard.Count; i++)
                {
                    var entry = result.Leaderboard[i];
                    string ranking = string.Format("{0}位 {1}点", entry.Position + 1, entry.StatValue);
                    string rankingName = "";
                    ngWordFilter.CheckNGWord(entry.DisplayName, (isNG) =>
                    {
                        if (isNG)
                        {
                            Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                            rankingName = "クプアス";
                        }
                        else
                        {
                            Debug.Log("NGワードは含まれていません。");
                            if (entry.DisplayName != null)
                            {
                                rankingName = entry.DisplayName;
                            }
                            else
                            {
                                rankingName = "名無しのゴンベ";
                            }
                        }
                    });

                    // Instantiate and setup UI elements for rank and player name
                    Text rankText = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                    Text nameText = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);

                    rankText.text = ranking.ToUpper();
                    nameText.text = rankingName.ToUpper();

                    rankText.transform.SetParent(rankingSV.transform, false);
                    rankText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.transform.SetParent(rankingSV.transform, false);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                }
                ;
            },
            error =>
            {
                Debug.LogError(error.GenerateErrorReport());
                // Retry the leaderboard request in case of error
                RequestLeaderBoardAroundPlayer();
            }
        );
    }



    public void RequestLeaderBoard()
    {
        // yield return new WaitForSecondsRealtime(1);
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = STATISTICS_NAME,
                StartPosition = 0,
                MaxResultsCount = 100
            },
            result =>
            {
                foreach (Transform child in rankingSV.transform)
                {
                    //自分の子供をDestroyする
                    Destroy(child.gameObject);
                }
                /*
                int highScore = PlayerPrefs.GetInt("Mugen",0);
                Text banduke2 = Instantiate(bandukeText,new Vector3(0,0,0), Quaternion.identity);
                string comment = "";
                if(highScore < 1000)
                {
                    comment = "亥";
                }
                else if(highScore >= 1000 && highScore < 2000)
                {
                    comment = "戌";
                }
                else if(highScore >= 2000 && highScore < 3000)
                {
                    comment = "酉";
                }
                else if(highScore >= 3000 && highScore < 4000)
                {
                    comment = "申";
                }
                else if(highScore >= 4000 && highScore < 5000)
                {
                    comment = "未";
                }
                else if(highScore >= 5000 && highScore < 6000)
                {
                    comment = "午";
                }
                else if(highScore >= 6000 && highScore < 7000)
                {
                    comment = "巳";
                }
                else if(highScore >= 7000 && highScore < 8000)
                {
                    comment = "辰";
                }
                else if(highScore >= 8000 && highScore < 9000)
                {
                    comment = "卯";
                }
                else if(highScore >= 9000 && highScore < 10000)
                {
                    comment = "寅";
                }
                else if(highScore >= 10000 && highScore < 11000)
                {
                    comment = "丑";
                }
                else if(highScore > 11000)
                {
                    comment = "子";
                }

                banduke2.text = "階級 "　+ comment;
                // banduke2.transform.parent = rankingSV.transform;
                banduke2.transform.SetParent(rankingSV.transform,false);
                banduke2.transform.localScale = new Vector3(1,1,1);
                Text banduke1 = Instantiate(bandukeText,new Vector3(0,0,0), Quaternion.identity);
                banduke1.text = "最高得点 " + highScore + "点";
                // banduke1.transform.parent = rankingSV.transform;
                banduke1.transform.SetParent(rankingSV.transform,false);
                banduke1.transform.localScale = new Vector3(1,1,1);
                
                Text banduke6 = Instantiate(rankingText,new Vector3(0,0,0), Quaternion.identity);
                banduke6.text = " ";
                
                // banduke6.transform.parent = rankingSV.transform;
                banduke6.transform.SetParent(rankingSV.transform,false);
                banduke6.transform.localScale = new Vector3(1,1,1);
                */
                Text banduke = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                banduke.text = "番付";
                // banduke.transform.parent = rankingSV.transform;
                banduke.transform.SetParent(rankingSV.transform, false);
                banduke.transform.localScale = new Vector3(1, 1, 1);
                for (int i = 0; i < result.Leaderboard.Count; i++)
                {

                    string ranking = "";
                    string rankingName = "";
                    Text iremono;
                    Text iremonoName;
                    var x = result.Leaderboard[i];
                    ranking = string.Format("{0}位 {1}点", x.Position + 1, x.StatValue);
                    ranking.ToUpper();
                    ngWordFilter.CheckNGWord(x.DisplayName, (isNG) =>
                    {
                        if (isNG)
                        {
                            Debug.Log("NGワードが含まれているため、名前を「クプアス」に変更します。");
                            rankingName = "クプアス";
                        }
                        else
                        {
                            Debug.Log("NGワードは含まれていません。");
                            if (x.DisplayName != null)
                            {
                                rankingName = string.Format("{0}", x.DisplayName);
                            }
                            else
                            {
                                rankingName = "名無しのゴンベ";
                            }
                        }
                    });
                    // rankingName = string.Format("{0}", x.DisplayName);
                    rankingName.ToUpper();
                    iremono = Instantiate(rankingText, new Vector3(0, 0, 0), Quaternion.identity);
                    iremonoName = Instantiate(bandukeText, new Vector3(0, 0, 0), Quaternion.identity);
                    iremono.text = ranking;
                    iremonoName.text = rankingName;
                    // iremono.transform.parent = rankingSV.transform;
                    iremono.transform.SetParent(rankingSV.transform, false);
                    iremono.transform.localScale = new Vector3(1, 1, 1);
                    iremonoName.transform.SetParent(rankingSV.transform, false);
                    iremonoName.transform.localScale = new Vector3(1, 1, 1);
                }
                ;
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
                RequestLeaderBoard();
            }
            );
    }

    /*
    // Trick1_1
    public void SubmitScore_Trick1_1(int playerScore)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "Trick1_1",

                        Value = playerScore
                    }
                }
            },
            result =>
            {
                Debug.Log("スコア送信");
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }

    public void RequestLeaderBoard_Trick1_1()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = "Trick1_1",
                StartPosition = 0,
                MaxResultsCount = 10
            },
            result =>
            {
                /*
                result.Leaderboard.ForEach(
                    x => Debug.Log(string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue))
                    );
                */
    /*
    ranking = "";
    for (int i = 0; i < result.Leaderboard.Count; i++)
    {
        var x = result.Leaderboard[i];
        ranking += string.Format("{0}位:{1}:{2}点", x.Position + 1, x.DisplayName, x.StatValue) + "\n";
    };
    text.text = ranking;
},
error =>
{
    Debug.Log(error.GenerateErrorReport());
}
);
}
*/



    private string GenerateCustomID()
    {
        int idLength = 32;//IDの長さ
        StringBuilder stringBuilder = new StringBuilder(idLength);
        var random = new System.Random();
        //ランダムにIDを生成
        for (int i = 0; i < idLength; i++)
        {
            stringBuilder.Append(ID_CHARACTERS[random.Next(ID_CHARACTERS.Length)]);
        }
        return stringBuilder.ToString();
    }

    IEnumerator LoginAgain(int cnt)
    {
        yield return new WaitForSeconds(0.1f);
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = id, CreateAccount = true },
            result =>
            {
                Debug.Log("ログイン成功！");
                SubmitScore(PlayerPrefs.GetInt(STATISTICS_NAME, 0));
            },
            error =>
            {
                Debug.Log("ログイン失敗");
                loginTry++;
                if (loginTry >= 5)
                {
                    snapbarManager.ShowSnapbar("ログインができません。\nネット環境が良い状態で\n再ログインしてください。", loginErrorImage, 10);
                }
                else
                {
                    StartCoroutine(LoginAgain(1));
                }
                // PlayerPrefs.SetString("ID",GenerateCustomID());
                // id = PlayerPrefs.GetString("ID","No ID");

            });
    }

    public void OpenNameChangeCanvas()
    {
        nameChangeCanvas.SetActive(true);
        homeCanvas.SetActive(false);
        name.text = currentName;
        nameCheckFlg = true;

    }

    public void CloseNameChangeCanvas()
    {
        if (ngWordFlg)
        {
            return;
        }
        PlayFabClientAPI.UpdateUserTitleDisplayName(
        new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name.text
        },
        result =>
        {
            Debug.Log("Set display name was succeeded.");
            currentName = name.text;
            PlayerPrefs.SetString("Name", currentName);
            nameCheckFlg = false;
            nameChangeCanvas.SetActive(false);
            homeCanvas.SetActive(true);
            // RequestLeaderBoard();
            RequestLeaderBoardAroundPlayer();
            if (firstLoginFlg)
            {
                menuSystem.Login();
                PlayerPrefs.SetInt("FirstLogin", 0);
                SceneManager.LoadScene("Demo");
            }
        },
        error =>
        {
            Debug.LogError(error.GenerateErrorReport());
            NameError();
        }
        );
    }

    public void NameCheckLogin()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
        new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = PlayerPrefs.GetString("Name", currentName)
        },
        result =>
        {
        },
        error =>
        {
            Debug.LogError(error.GenerateErrorReport());
            snapbarManager.ShowSnapbar("バグで名前が使えなくなってます。\n名前変更から\n新しい名前を登録してください。", loginErrorImage, 10);
        }
        );
    }
    public void NameSendBtn()
    {
        string inputText = name.text; // テキストを取得
        StartCoroutine(NameCheck(inputText));
    }

    private IEnumerator NameCheck(string inputText)
    {
        // 入力規則を満たす正規表現: 半角英数字、全角ひらがな、全角カタカナ
        string pattern = @"^[a-zA-Z0-9\u3040-\u309F\u30A0-\u30FF]+$";

        if (inputText.Length >= 3 && inputText.Length <= 10 && Regex.IsMatch(inputText, pattern))
        {
            nameCheckFlg = true;
        }
        else
        {
            nameCheckFlg = false;
        }

        yield return null; // 一応コルーチンで非同期処理に対応

        // 入力が正しい場合はサーバーへ送信
        if (nameCheckFlg)
        {
            PlayfabManager.Instance.SetDisplayName(inputText, OnNameSendSuccess, OnNameSendFailure);
        }
        else
        {
            NameCheckError();
        }
    }
    private void OnNameSendSuccess()
    {
        string localizationKey = "NameSuccess";
        nameChangeMessage.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, localizationKey);
        nameChangeMessage.color = Color.black;
        Debug.Log("Set display name was succeeded.");
        currentName = name.text;
        PlayerPrefs.SetString("Name", currentName);
        nameCheckFlg = false;
        nameChangeCanvas.SetActive(false);
        homeCanvas.SetActive(true);
        // RequestLeaderBoard();
        RequestLeaderBoardAroundPlayer();
        if (firstLoginFlg)
        {
            menuSystem.Login();
            PlayerPrefs.SetInt("FirstLogin", 0);
            SceneManager.LoadScene("Demo");
        }
    }

    private void OnNameSendFailure(PlayFabError error)
    {
        Debug.LogError("名前の送信に失敗しました: " + error.GenerateErrorReport());
        string localizationKey = "NameFailure";
        nameChangeMessage.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, localizationKey);
        nameChangeMessage.color = Color.red;
    }
    public void nameChangeMessageClear()
    {
        nameChangeMessage.text = "";
    }

    private void NameCheckError()
    {
        string localizationKey = "NameFailure";
        nameChangeMessage.text = LocalizationSettings.StringDatabase.GetLocalizedString(tableName, localizationKey);
        nameChangeMessage.color = Color.red;
    }

    public void NameError()
    {
        nameCheckText.text = "この名前は使えません。\n名前を変更してください。";
    }

    public void FirstTimeLogin()
    {
        // PlayerPrefs.SetString("ID",GenerateCustomID());
        PlayerPrefs.SetString("ID", SystemInfo.deviceUniqueIdentifier);
        id = PlayerPrefs.GetString("ID", "No ID");
        PlayerPrefs.SetString("Name", "");
        currentName = PlayerPrefs.GetString("Name", "");
        PlayerPrefs.SetInt("AdCounter", 24);
    }

    public void OpenInformation()
    {
        InfCanvas.SetActive(true);
    }

    public void CloseInformation()
    {
        InfCanvas.SetActive(false);
    }

    public void OpenDevelopper()
    {
        developper.SetActive(true);
        InfMain.SetActive(false);
    }

    public void CloseDevelopper()
    {
        developper.SetActive(false);
        InfMain.SetActive(true);
    }

    public void OpenTermOfUse()
    {
        termOfUse.SetActive(true);
        InfMain.SetActive(false);
    }

    public void CloseTermOfUse()
    {
        termOfUse.SetActive(false);
        InfMain.SetActive(true);
    }

    public void OpenPrivacyPolicy()
    {
        privacyPolicy.SetActive(true);
        InfMain.SetActive(false);
    }

    public void ClosePrivacyPolicy()
    {
        privacyPolicy.SetActive(false);
        InfMain.SetActive(true);
    }

    public void OpenContact()
    {
        contact.SetActive(true);
        InfMain.SetActive(false);
    }

    public void CloseContact()
    {
        contact.SetActive(false);
        InfMain.SetActive(true);
    }

    public void OpenFirstAgreeCanvas()
    {
        faCanvas.SetActive(true);
        // homeCanvas.SetActive(false);
    }

    public void CloseFirstAgreeCanvas()
    {
        faCanvas.SetActive(false);
        OpenNameChangeCanvas();

        /*
        if(faToggle.GetComponent<Toggle>().IsOn)
        {
            
        }
        else
        {
            
        }
        */

    }




}
