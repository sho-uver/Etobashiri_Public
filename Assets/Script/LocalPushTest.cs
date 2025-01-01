using UnityEngine;

public class LocalPushTest : MonoBehaviour
{   
    //Unityが用意した関数(名前は固定)
    //「アプリを開始した時」、「Homeボタンを押した時」、「Backボタンを押した時(ボタンはAndroidのみに存在)」、「OvewViewボタンを押した時(ボタンはAndroidのみに存在)」に実行
    private void OnApplicationFocus()
    {
        SettingPush();//プッシュ通知の設定
    }


    //プッシュ通知の設定
    private void SettingPush()
    {
        //　Androidチャンネルの登録
        //LocalPushNotification.RegisterChannel(引数1,引数２,引数３);
        //引数１ Androidで使用するチャンネルID なんでもいい LocalPushNotification.AddSchedule()で使用する
        //引数2　チャンネルの名前　なんでもいい　アプリ名でも入れておく
        //引数3　通知の説明 なんでもいい　自分がわかる用に書いておくもの　
        LocalPushNotification.RegisterChannel("channelId", "PushTest", "通知の説明");

        //通知のクリア
        LocalPushNotification.AllClear();

        // プッシュ通知の登録
        //LocalPushNotification.AddSchedule(引数１,引数2,引数3,引数4,引数5);
        //引数１ プッシュ通知のタイトル
        //引数2　通知メッセージ
        //引数3　表示するバッジの数(バッジ数はiOSのみ適用の様子 Androidで数値を入れても問題無い)
        //引数4　何秒後に表示させるか？
        //引数5　Androidで使用するチャンネルID　「Androidチャンネルの登録」で登録したチャンネルIDと合わせておく
        //注意　iOSは45秒経過後からしかプッシュ通知が表示されない        
        LocalPushNotification.AddSchedule("プッシュ通知一つ目", "45秒経過", 1, 45, "channelId");
        LocalPushNotification.AddSchedule("プッシュ通知二つ目", "60秒経過", 2, 60, "channelId");
        LocalPushNotification.AddSchedule("プッシュ通知三つ目", "75秒経過", 3, 75, "channelId");

    }

}