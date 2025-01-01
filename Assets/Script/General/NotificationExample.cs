/*
using UnityEngine;
using Unity.Notifications.iOS;

public class NotificationExample : MonoBehaviour
{
    void Start()
    {
        // 承認をリクエスト
        // iOSNotificationCenter.RequestAuthorization(AuthorizationOption.Alert | AuthorizationOption.Badge | AuthorizationOption.Sound, true);

        // 通知をスケジュール
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(0, 1, 0), // 1分
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            Title = "テストタイトル",
            Body = "テストボディ",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }

    void OnEnable()
    {
        iOSNotificationCenter.OnNotificationReceived += OnNotificationReceived;
    }

    void OnDisable()
    {
        iOSNotificationCenter.OnNotificationReceived -= OnNotificationReceived;
    }

    private void OnNotificationReceived(iOSNotification notification)
    {
        Debug.Log("受信した通知: " + notification.Identifier);
    }

}
*/
/*
// https://qiita.com/townsoft/items/dd5cbd8be7590e12f3cf

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
using System;
using UnityEngine;
using Unity.Notifications.iOS;

/// <summary>
/// ローカルプッシュ通知送信クラス
/// </summary>
public class NotificationExample : MonoBehaviour
{
    /// <summary>
    /// Androidで使用するプッシュ通知用のチャンネルを登録する。
    /// </summary>

    void start()
    {
        AllClear(); 
        AddSchedule("えとばしり！", "明けましておめでとうございます！", 1, 10, "channel");
    } 

    public static void RegisterChannel(string cannelId, string title, string description)
    {
#if UNITY_ANDROID
        // チャンネルの登録
        var c = new AndroidNotificationChannel()
        {
            Id = cannelId,
            Name = title,
            Importance = Importance.High,
            Description = description,
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
#endif
    }

    /// <summary>
    /// 通知をすべてクリアーします。
    /// </summary>
    public static void AllClear()
    {
#if UNITY_ANDROID
        // Androidの通知をすべて削除します。
        AndroidNotificationCenter.CancelAllScheduledNotifications();
        AndroidNotificationCenter.CancelAllNotifications();
#endif
#if UNITY_IOS
        // iOSの通知をすべて削除します。
        iOSNotificationCenter.RemoveAllScheduledNotifications();
        iOSNotificationCenter.RemoveAllDeliveredNotifications();
        // バッジを消します。
        iOSNotificationCenter.ApplicationBadge = 0;
#endif
    }

    /// <summary>
    /// プッシュ通知を登録します。
    /// </summary>
    /// <param name="title">通知のタイトル</param>
    /// <param name="message">通知メッセージ</param>
    /// <param name="badgeCount">表示するバッジ数</param>
    /// <param name="elapsedTime">何秒後に表示させるか？</param>
    /// <param name="cannelId">Androidで使用するチャンネル</param>
    public static void AddSchedule(string title, string message, int badgeCount, int elapsedTime, string cannelId)
    {
#if UNITY_ANDROID
        SetAndroidNotification(title, message, badgeCount, elapsedTime, cannelId);
#endif
#if UNITY_IOS
        SetIOSNotification(title, message, badgeCount, elapsedTime);
#endif
    }

#if UNITY_IOS
    /// <summary>
    /// 通知を登録します。(iOS)
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="badgeCount"></param>
    /// <param name="elapsedTime"></param>
    static private void SetIOSNotification(string title, string message, int badgeCount, int elapsedTime)
    {
        // 通知を作成します。
        iOSNotificationCenter.ScheduleNotification(new iOSNotification()
        {
            // ※プッシュ通知を個別に取り消しなどをする場合はこのIdentifierを使用します。
            Identifier = $"_notification_{badgeCount}",
            Title = title,
            Body = message,
            ShowInForeground = false,
            Badge = badgeCount,
            Trigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = new TimeSpan(0, 0, elapsedTime),
                Repeats = false
            }
        });
    }
#endif

#if UNITY_ANDROID
    /// <summary>
    /// 通知を登録する。(Android)
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="badgeCount"></param>
    /// <param name="elapsedTime"></param>
    /// <param name="cannelId"></param>
    static private void SetAndroidNotification(string title, string message, int badgeCount, int elapsedTime, string cannelId)
    {
        // 通知を作成します。
        var notification = new AndroidNotification
        {
            Title = title,
            Text = message,
            Number = badgeCount,
            // ※ここでAndroidのアイコンを設定します。
            SmallIcon = "icon_small",
            LargeIcon = "icon_large",
            FireTime = DateTime.Now.AddSeconds(elapsedTime)
        };

        // 通知を送信します。
        AndroidNotificationCenter.SendNotification(notification, cannelId);
        // ※以下のコードを使うことで個別にプッシュ通知の制御ができます。
        //var identifier = AndroidNotificationCenter.SendNotification(notification, cannelId);
        //UnityEngine.Debug.Log($"TownSoftPush: プッシュ通知の登録完了 -> {DateTime.Now.AddSeconds(elapsedTime)}");

        //if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
        //{
        //    // Replace the currently scheduled notification with a new notification.
        //    UnityEngine.Debug.Log("プッシュ通知はすでに登録済み");
        //}
        //else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Delivered)
        //{
        //    //Remove the notification from the status bar
        //    //AndroidNotificationCenter.CancelNotification(identifier);
        //    UnityEngine.Debug.Log("プッシュ通知はすでに通知済み");
        //}
        //else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Unknown)
        //{
        //    //AndroidNotificationCenter.SendNotification(newNotification, "channel_id");
        //    UnityEngine.Debug.Log("プッシュ通知は不明な状況");
        //}
    }
#endif
}
*/