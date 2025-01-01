using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TMP_InputFieldを使用するために必要

public class Friend : MonoBehaviour
{
    [SerializeField] private TMP_InputField friendCode; // 友達のPlayFab ID入力用
    [SerializeField] private Button friendSearch;       // 検索を開始するボタン

    void Start()
    {
        // 最初に検索ボタンを無効にし、有効なIDが入力されるまで待つ
        friendSearch.interactable = false;
        friendCode.onValueChanged.AddListener(delegate {ChangeButtonEnabled();});
    }

    // 入力されたIDの長さに基づいて検索ボタンを有効または無効にする
    public void ChangeButtonEnabled()
    {
        bool isValidCode = friendCode.text.Length == 16;
        friendSearch.interactable = isValidCode;
    }

    // 検索ボタンが押されたときに呼ばれる
    public void Search()
    {
        SearchFriend(friendCode.text);
    }

    private void SearchFriend(string friendPlayFabId)
    {
        var request = new GetPlayerProfileRequest
        {
            PlayFabId = friendPlayFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true
            }
        };

        PlayFabClientAPI.GetPlayerProfile(request, result =>
        {
            Debug.Log("Player found: " + result.PlayerProfile.DisplayName);
        }, 
        error =>
        {
            Debug.LogError("Failed to find player: " + error.GenerateErrorReport());
        });
    }
}



/*using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class Friend : MonoBehaviour
{
    // 入力する友達の PlayFabId
[SerializeField] TMP_InputField friendCode;
// 検索ボタン
[SerializeField] Button friendSearch;

// 検索ボタンの入力可否
public void ChangeButtonEnabled()
{
    // PlayFabId は16桁固定
    bool isValidCode = friendCode.text.Length == 16;
    friendSearch.interactable = isValidCode;
}

// 検索ボタンが押されたとき
public void Search()
{
    SearchFriend(friendCode.text);
}
    
    public void SearchFriend(string friendPlayFabId)
{
    PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest
    {
        PlayFabId = friendPlayFabId,
        ProfileConstraints = new PlayerProfileViewConstraints
        {
            ShowDisplayName = true,
        }
    }, result =>
    {
        Debug.Log("プレイヤーが見つかりました。");
    }
    , error =>
    {
        if (error.Error == PlayFabErrorCode.PlayerNotInGame ||
            error.Error == PlayFabErrorCode.InvalidParams)
        {
            Debug.Log("プレイヤーが見つかりません。");
        }
    });
}
// フォロワーの一覧から追加する場合の引数
FunctionParameter = new
{
    FriendInfo = new PlayFab.ClientModels.FriendInfo
    {
        FriendPlayFabId = friendInfo.FriendPlayFabId,
        Tags = friendInfo.Tags
    }
}

// 相手からフォローされているかどうか（Followers は List<FriendInfo> の前提）
var friendFollowInfo = Followers.Find(x => x.FriendPlayFabId == PlayFab.PlayFabSettings.staticPlayer.PlayFabId);

// ID検索から追加する場合の引数
FunctionParameter = new
{
    FriendInfo = new PlayFab.ClientModels.FriendInfo
    {
        FriendPlayFabId = friendCode.text,
        Tags = friendFollowInfo?.Tags
    }
}

}
*/