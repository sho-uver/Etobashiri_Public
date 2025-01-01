using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
using System;
//https://anogame.net/mobile-notifications-local-ios-android/

public class NotificationManager : MonoBehaviour
{
    private void Start()
    {
        #if UNITY_ANDROID
        NotificationAndroid();
        #endif
        #if UNITY_IOS
        NotificationiOS();
        #endif
    }

    #if UNITY_IOS
    public void NotificationiOS()
    {
        // iOSの通知をすべて削除します。
        iOSNotificationCenter.RemoveAllScheduledNotifications();
        iOSNotificationCenter.RemoveAllDeliveredNotifications();
        // バッジを消します。
        iOSNotificationCenter.ApplicationBadge = 0;
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(0, 1, 0, 0),
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            Identifier = "_notification_01",
            Title = "えとばしり！",
            Body = "今日のおみくじが引けるよ\nたくさん遊んでいってね！",
            // Subtitle = "サブタイトル",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };
        iOSNotificationCenter.ScheduleNotification(notification);
        
        var timeTrigger2 = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(0, 7, 0, 0),
            Repeats = false
        };

        var notification2 = new iOSNotification()
        {
            Identifier = "_notification_02",
            Title = "えとばしり！",
            Body = "たまにはパーっと遊ぼう！",
            // Subtitle = "サブタイトル",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger2,
        };
        iOSNotificationCenter.ScheduleNotification(notification2);

        var timeTrigger3 = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(1, 0, 0, 0),
            Repeats = false
        };

        var notification3 = new iOSNotification()
        {
            Identifier = "_notification_03",
            Title = "えとばしり！",
            Body = "最後に遊んでから１ヶ月。\nおみくじだけでも...！",
            // Subtitle = "サブタイトル",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger3,
        };
        iOSNotificationCenter.ScheduleNotification(notification3);

        var timeTrigger4 = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(12, 0, 0, 0),
            Repeats = false
        };
        var notification4 = new iOSNotification()
        {
            Identifier = "_notification_04",
            Title = "えとばしり！",
            Body = "最後の走りから1年...。\nえと達が遊んで欲しそうにしているよ！",
            // Subtitle = "サブタイトル",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger4,
        };
        iOSNotificationCenter.ScheduleNotification(notification4);

        DateTimeOffset notifyTime5 = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var notification5 = new iOSNotification()
        {
            Identifier = "_notification_05", // 一意の識別子
            Title = "えとばしり！",
            Body = "あけましておめでとう！\n今年もたくさん遊んでね！",
            ShowInForeground = true, // フォアグラウンドでも通知を表示
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound | PresentationOption.Badge),
        };

        // トリガーを設定（特定の日付と時間）
        var trigger5 = new iOSNotificationCalendarTrigger()
        {
            // Year = notifyTime5.Year,
            Month = notifyTime5.Month,
            Day = notifyTime5.Day,
            Hour = notifyTime5.Hour,
            Minute = notifyTime5.Minute,
            Second = 0,
            Repeats = true // 通知を繰り返さない
        };
        notification5.Trigger = trigger5;

        // 通知をスケジュール
        iOSNotificationCenter.ScheduleNotification(notification5);

        DateTimeOffset notifyTime6 = new DateTimeOffset(2025, 1, 2, 12, 0, 0, TimeSpan.Zero);
        var notification6 = new iOSNotification()
        {
            Identifier = "_notification_06", // 一意の識別子
            Title = "えとばしり！",
            Body = "初夢はどうだったかな？\nえと達は走る夢を見たらしい！",
            ShowInForeground = true, // フォアグラウンドでも通知を表示
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound | PresentationOption.Badge),
        };

        // トリガーを設定（特定の日付と時間）
        var trigger6 = new iOSNotificationCalendarTrigger()
        {
            // Year = notifyTime6.Year,
            Month = notifyTime6.Month,
            Day = notifyTime6.Day,
            Hour = notifyTime6.Hour,
            Minute = notifyTime6.Minute,
            Second = 0,
            Repeats = true // 通知を繰り返さない
        };

        notification6.Trigger = trigger6;

        // 通知をスケジュール
        iOSNotificationCenter.ScheduleNotification(notification6);

        DateTimeOffset notifyTime7 = new DateTimeOffset(2025, 1, 3, 12, 0, 0, TimeSpan.Zero);
        var notification7 = new iOSNotification()
        {
            Identifier = "_notification_07", // 一意の識別子
            Title = "えとばしり！",
            Body = "正月はまだまだおわらない\n全力で遊ぼう！",
            ShowInForeground = true, // フォアグラウンドでも通知を表示
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound | PresentationOption.Badge),
        };

        // トリガーを設定（特定の日付と時間）
        var trigger7 = new iOSNotificationCalendarTrigger()
        {
            // Year = notifyTime7.Year,
            Month = notifyTime7.Month,
            Day = notifyTime7.Day,
            Hour = notifyTime7.Hour,
            Minute = notifyTime7.Minute,
            Second = 0,
            Repeats = true // 通知を繰り返さない
        };
        notification7.Trigger = trigger7;
        // 通知をスケジュール
        iOSNotificationCenter.ScheduleNotification(notification7);
    
    }
    #endif

    #if UNITY_ANDROID
    public void NotificationAndroid()
    {
        // 通知チャンネルを作成

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notification Channel",
            Importance = Importance.Default,
            Description = "General Notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        int year;
        year = DateTime.Now.Year + 1;
        if(DateTime.Now.Month == 1 && DateTime.Now.Day == 1)
        {
            year = DateTime.Now.Year;
        }
        if(DateTime.Now.Month == 1 && DateTime.Now.Day == 2)
        {
            year = DateTime.Now.Year;
        }
        if(DateTime.Now.Month == 1 && DateTime.Now.Day == 3)
        {
            year = DateTime.Now.Year;
        }
        // 複数の通知を設定
        SendAndroidNotification("えとばしり！", "今日のおみくじが引けるよ\nたくさん遊んでいってね！", 15, "_notification_01");
        SendAndroidNotification("えとばしり！", "たまにはパーっと遊ぼう！", 30, "_notification_02");
        SendAndroidNotification("えとばしり！", "最後に遊んでから１ヶ月。\nおみくじだけでも...！", 45, "_notification_03");
        SendAndroidNotification("えとばしり！", "最後の走りから1年...。\nえと達が遊んで欲しそうにしているよ！", 60, "_notification_04");
        SendAndroidNotificationOnDate("えとばしり！", "あけましておめでとう！\n今年もたくさん遊んでね！", new DateTime(year, 1, 1, 12, 0, 0), "_notification_05");
        SendAndroidNotificationOnDate("えとばしり！", "初夢はどうだったかな？\nえと達は走る夢を見たらしい！", new DateTime(year, 1, 2, 12, 0, 0), "_notification_06");
        SendAndroidNotificationOnDate("えとばしり！", "正月はまだまだおわらない\n全力で遊ぼう！", new DateTime(year, 1, 3, 12, 0, 0), "_notification_07");
        /*
        SendAndroidNotificationOnDate("えとばしり！", "あけましておめでとう！\n今年もたくさん遊んでね！", new DateTime(year, 2, 12, 0, 36, 0), "_notification_08");
        SendAndroidNotificationOnDate("えとばしり！", "初夢はどうだったかな？\nえと達は走る夢を見たらしい！", new DateTime(year, 2, 12, 0, 36, 10), "_notification_09");
        SendAndroidNotificationOnDate("えとばしり！", "正月はまだまだおわらない\n全力で遊ぼう！", new DateTime(year, 2, 12, 0, 36, 20), "_notification_10");
        */
    }

    private void SendAndroidNotification(string title, string text, int seconds, string identifier)
    {
        var notification = new AndroidNotification()
        {
            Title = title,
            Text = text,
            SmallIcon = "icon_0", // アイコンの設定が必要です
            LargeIcon = "icon_1", // アイコンの設定が必要です
            FireTime = DateTime.Now.AddSeconds(seconds),
        };

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    private void SendAndroidNotificationOnDate(string title, string text, DateTime dateTime, string identifier)
    {
        var notification = new AndroidNotification()
        {
            Title = title,
            Text = text,
            SmallIcon = "icon_0", // アイコンの設定が必要です
            LargeIcon = "icon_1", // アイコンの設定が必要です
            FireTime = dateTime,
        };

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
    #endif
}