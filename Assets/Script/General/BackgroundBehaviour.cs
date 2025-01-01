using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    // アプリがバックグラウンドに移行するか、フォアグラウンドに戻るときに呼び出されます
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // アプリがバックグラウンドに移行した時の処理
            // Debug.Log("アプリがバックグラウンドに移行しました。");
            // ここにバックグラウンドに移行した際の処理を追加します
            GameSystemTrick.instance.Login();
            if(GameSystemTrick.instance.GetSCFlg())
            {
                return;
            }
            GameSystemTrick.instance.StopGame();
        }
        else
        {
            // アプリがフォアグラウンドに戻った時の処理
            // Debug.Log("アプリがフォアグラウンドに戻りました。");
            // ここにフォアグラウンドに戻った際の処理を追加します
            // GameSystemTrick.instance.StopGame();
            GameSystemTrick.instance.Login();
        }
    }
}
